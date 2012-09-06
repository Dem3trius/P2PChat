using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Chat_v1.Server_classes
{
    /// <summary>
    /// Реалізовує можливість передачі файлів у мережі
    /// </summary>
    class FileServer : BaseServer
    {
        /// <summary>
        /// Адреси файлів на диску, які користувачі можуть скачувати
        /// </summary>
        public List<string> AvailableFiles;
        /// <summary>
        /// Словник містить шлях до папки, в яку необіхдно скачати файл-ключ
        /// </summary>
        private Dictionary<string, string> SaveDirs;
        /// <summary>
        /// Черга на скачку файлів
        /// </summary>
        public Queue<FileServerDLMessage> DownloadQueue;
        /// <summary>
        /// Черга на відсилання файлів
        /// </summary>
        public Queue<FileServerULMessage> UploadQueue;

        private FileServerDLMessage CurrentMessage;
        private FileInfo CurrentFile;
        private bool Sending = false;
        private bool Writing = false;
        private int offset = 0;

        public event ReceivedMessageHandler RecievedFileTable;
        public event FileServerNotificationHandler SendedFile;
        public event FileServerSavedFileHandler SavedFile;

        public FileServer()
            : base()
        {
            this.def_list_port = Default.def_file_list_port;
            AvailableFiles = new List<string>();
            DownloadQueue = new Queue<FileServerDLMessage>();
            UploadQueue = new Queue<FileServerULMessage>();
            SaveDirs = new Dictionary<string, string>();
        }

        public override void Send(MessageType msgType, NetworkStream stream, object options)
        {
            BinaryWriter writer = new BinaryWriter(stream);
            switch (msgType)
            {
                case MessageType.FilesTableAvailable:
                    {
                        AvailableFiles.Clear();
                        AvailableFiles.AddRange((string[])options);

                        List<string> temp = new List<string>();
                        string[] files = (string[])options;
                        foreach (string file in files)
                        {
                            FileInfo f = new FileInfo(file);
                            long size = f.Length;
                            temp.Add(String.Concat(file, " ", size.ToString()));
                        }

                        byte[] buffer = SimpleFormatters.ObjectToBytes(temp);
                        byte[] count = BitConverter.GetBytes(buffer.Length);
                        writer.Write(count, 0, 4);
                        writer.Write(buffer, 0, buffer.Length);
                        break;
                    }
                case MessageType.FilesAsk:
                    {
                        byte[] buffer = SimpleFormatters.ObjectToBytes(options);
                        byte[] count = BitConverter.GetBytes(buffer.Length);
                        writer.Write(count, 0, 4);
                        writer.Write(buffer, 0, buffer.Length);
                        break;
                    }
                case MessageType.FileDataFirst:
                    {
                        char[] symbols = ((string)options).ToCharArray();
                        byte[] buffer = System.Text.Encoding.Unicode.GetBytes(symbols);
                        byte[] count = BitConverter.GetBytes(buffer.Length);
                        writer.Write(count, 0, 4);
                        writer.Write(buffer, 0, buffer.Length);
                        break;
                    }
                case MessageType.FileData:
                    {
                        byte[] buffer = (byte[])options;
                        byte[] count = BitConverter.GetBytes(buffer.Length);
                        writer.Write(count, 0, 4);
                        writer.Write(buffer, 0, buffer.Length);
                        
                        break;
                    }
                case MessageType.FileDataLast:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public override void Receive(MessageType msgType, NetworkStream stream, IPAddress owner)
        {
            switch (msgType)
            {
                case MessageType.FilesTableAvailable:
                    {
                        byte[] count = new byte[4];
                        stream.Read(count, 0, 4);
                        int size = BitConverter.ToInt32(count, 0);
                        byte[] buffer = new byte[size];
                        stream.Read(buffer, 0, size);

                        object filesData = SimpleFormatters.BytesToObject(buffer);
                        RecievedFileTable(this, new ReceivedMessageEventArgs(MessageType.FilesTableAvailable, filesData, owner));
                        break;
                    }
                case MessageType.FilesAsk:
                    {
                        byte[] count = new byte[4];
                        stream.Read(count, 0, 4);
                        int size = BitConverter.ToInt32(count, 0);
                        byte[] buffer = new byte[size];
                        stream.Read(buffer, 0, size);

                        string file = (string)SimpleFormatters.BytesToObject(buffer);
                        FileServerULMessage msg = new FileServerULMessage(file, owner);
                        UploadQueue.Enqueue(msg);

                        if (Sending == false)
                        {
                            this.AfterConnectionClosed += new Action(StartUploadFile);
                        }
                        
                        break;
                    }
                case MessageType.FileDataFirst:
                    {
                        byte[] count = new byte[4];
                        stream.Read(count, 0, 4);
                        int len = BitConverter.ToInt32(count, 0);
                        byte[] buffer = new byte[len];
                        stream.Read(buffer, 0, len);
                        char[] symbols = new char[len];
                        symbols = System.Text.Encoding.Unicode.GetChars(buffer);
                        string[] words = new string(symbols).Split();
                        string name = String.Join(" ", words, 0, words.Length - 1);
                        long lenght = Convert.ToInt64(words[words.Length - 1]);

                        FileServerDLMessage thisFIle = new FileServerDLMessage(name, SaveDirs[name], owner, lenght); 
                        if (Writing == true)
                        {
                            DownloadQueue.Enqueue(thisFIle);
                        }
                        else
                        {
                            StartWriteFile(thisFIle);
                        }
                        break;
                    }
                case MessageType.FileData:
                    {
                        byte[] count = new byte[4];
                        stream.Read(count, 0, 4);
                        int len = BitConverter.ToInt32(count, 0);
                        byte[] buffer = new byte[len];
                        int readed = 0, offset = 0, toRead = len;

                        while (true)
                        {
                            readed += stream.Read(buffer, offset, toRead);

                            if (readed < len)
                            {
                                offset = readed;
                                toRead = len - readed;
                            }
                            else
                            {
                                break;
                            }
                        }

                        AppendToFile(buffer);
                        break;
                    }
                case MessageType.FileDataLast:
                    {
                        CloseFile();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void GetFile(FileServerDLMessage msg)
        {
            if (Writing == true)
            {
                DownloadQueue.Enqueue(msg);
            }
            else
            {
                SendToOne(MessageType.FilesAsk, msg.TargetFile, msg.Owner);
                CurrentMessage = msg;
            }
            string[] items = msg.TargetFile.Split('\\');
            string name = items[items.Length - 1];

            if (SaveDirs.ContainsKey(name))
            {
                SaveDirs[name] = msg.SaveDir;
            }
            else
            {
                SaveDirs.Add(name, msg.SaveDir);
            }
        }
        private void StartUploadFile()
        {
            FileServerULMessage msg = UploadQueue.Dequeue();
            AfterConnectionClosed -= StartUploadFile;

            Sending = true;

            bool answer = false;
            foreach (string path in AvailableFiles)
            {
                if (path.EndsWith(msg.TargetFile))
                {
                    answer = true;
                    break;
                }
            }
            if (answer)
            {
                FileInfo info = new FileInfo(msg.TargetFile);
                SendToOne(MessageType.FileDataFirst, info.Name + " " + info.Length.ToString(), msg.target);

                long len = info.Length;
                FileStream reader = new FileStream(msg.TargetFile, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[Default.def_buffer_size];
                long writed = 0;
                double status = 0;
                
                while (len > Default.def_buffer_size)
                {
                    writed +=  reader.Read(buffer, 0, Default.def_buffer_size);
                    SendToOne(MessageType.FileData, buffer, msg.target);
                    len = len - Default.def_buffer_size;
                    status = writed / info.Length;
                    SendedFile(this, new FileServerNotificationEventArgs(status, info.Name, msg.target));
                }
                byte[] subBuffer = new byte[(Int32)len];
                reader.Read(subBuffer, 0, (Int32)len);
                SendToOne(MessageType.FileData, subBuffer, msg.target);
                SendToOne(MessageType.FileDataLast, null, msg.target);
                 
                status = 1;
                reader.Close();
                SendedFile(this, new FileServerNotificationEventArgs(status, info.Name, msg.target));
            }

            if (UploadQueue.Count > 0)
            {
                StartUploadFile();
            }
            else
            {
                Sending = false;
            }
        }
        private void StartWriteFile(FileServerDLMessage msg)
        {
            Writing = true;
            offset = 0;

            string[] words = msg.TargetFile.Split('\\');
            string name = words[words.Length - 1];
            CurrentFile = new FileInfo(msg.SaveDir + "\\" + name);
        }
        private void AppendToFile(byte[] buffer)
        {
            FileStream stream = CurrentFile.OpenWrite();
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(buffer, 0, buffer.Length);
            offset += buffer.Length; // +1 ??????
            stream.Close();
            double recieved = CurrentFile.Length/CurrentMessage.Size;
            SavedFile(this, new FileServerSavedFileEventArgs
                (CurrentFile.Name, CurrentFile.FullName, recieved));
        }
        private void CloseFile()
        {
            Writing = false;
            SavedFile(this, new FileServerSavedFileEventArgs(CurrentFile.Name, CurrentFile.FullName, 1));
            CurrentFile = null;
            if (DownloadQueue.Count > 0)
            {
                CurrentMessage = DownloadQueue.Dequeue();
                SendToOne(MessageType.FilesAsk, CurrentMessage.TargetFile, CurrentMessage.Owner);
            }
        }
    }
}
