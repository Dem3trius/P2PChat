using System;
using System.Net;

namespace Chat_v1
{
    public delegate void ReceivedMessageHandler(object sender, ReceivedMessageEventArgs e);
    public delegate void FileServerNotificationHandler(object sender, FileServerNotificationEventArgs e);
    public delegate void FileServerSavedFileHandler(object sender, FileServerSavedFileEventArgs e);

    public class ReceivedMessageEventArgs : EventArgs
    {
        public IPAddress ip { get; set; }
        public MessageType msgType { get; set; }
        public object options { get; set; }

        public ReceivedMessageEventArgs(MessageType msgType, object options, IPAddress ip)
        {
            this.msgType = msgType;
            this.options = options;
            this.ip = ip;
        }

        public ReceivedMessageEventArgs(MessageType msgType, IPAddress owner)
            : this(msgType, null, owner) { }

    }
    public class FileServerNotificationEventArgs : EventArgs
    {
        public double Value { get; set; }
        public string Filename { get; set; }
        public IPAddress Owner { get; set; }
        public FileServerNotificationEventArgs(double value, string filename, IPAddress owner)
        {
            this.Value = value;
            this.Filename = filename;
            this.Owner = owner;
        }
    }
    public class FileServerSavedFileEventArgs : EventArgs
    {
        public string Filename { get; set; }
        public string SavedPath { get; set; }
        public double Recieved { get; set; }

        public FileServerSavedFileEventArgs(string filename, string path, double recieved)
        {
            this.Filename = filename;
            this.SavedPath = path;
            this.Recieved = recieved;
        }
    }

}
