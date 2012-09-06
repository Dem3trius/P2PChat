using System;
using System.Collections.Generic;
using System.Net;
using Chat_v1.Server_classes;

namespace Chat_v1
{
    /// <summary>
    /// Клас, що реалізує підключення до інших користувачів, використовуючи класи "серверів"
    /// </summary>
    public class ServerPool : IDisposable
    {
        public List<User> connectedUsers { get; private set; }
        public User GetUserByIP(IPAddress ip)
        {
            int i = connectedUsers.FindIndex(a => a.UserIP.ToString() == ip.ToString());
            if (i == -1)
            {
                return null;
            }
            else
            {
                return connectedUsers[i];
            }
        }

        private ServiceServer serviceServer = new ServiceServer();
        private TextServer textServer = new TextServer();
        private FileServer fileServer = new FileServer();
        private Gui.FileSender sender;
        private Gui.FileDownloader downloader;

        public ServerPool()
        {
            connectedUsers = new List<User>();

            this.textServer.TextRecieved += new ReceivedMessageHandler(TextRecieved);
            this.serviceServer.AcceptedConnection += new ReceivedMessageHandler(AcceptedConnection);
            this.serviceServer.AskedConnection += new ReceivedMessageHandler(AskedConnection);
            this.serviceServer.CanceledConnection += new ReceivedMessageHandler(CanceledConnection);
            this.serviceServer.ClosedConnection += new ReceivedMessageHandler(ClosedConnection);
            this.serviceServer.NewUserAdded += new ReceivedMessageHandler(NewUserAdded);
            this.serviceServer.UserLoggedOut += new ReceivedMessageHandler(UserLoggedOut);
            this.serviceServer.UserLoggedIn += new ReceivedMessageHandler(UserLoggedIn);
            this.serviceServer.AliveUser += new ReceivedMessageHandler(AliveUser);

            this.fileServer.RecievedFileTable += new ReceivedMessageHandler(RecievedFileTable);
            this.fileServer.SendedFile += new FileServerNotificationHandler(SendedFile);
            this.fileServer.SavedFile += new FileServerSavedFileHandler(SavedFile);
        }

        // ------- Інтерфейс користувача --------

        public void TryConnectToUser(User user)
        {
            User[] temp = new User[connectedUsers.Count + 1];

            for (int i = 0; i < connectedUsers.Count; i++)
                temp[i] = connectedUsers[i];

            temp[connectedUsers.Count] = Program.localUser;

            serviceServer.SendToOne(MessageType.ConnectionAsk, temp, user.UserIP, true);
        }
        public void SendTextAll(string msg)
        {
            textServer.SendGroup(MessageType.TextData, msg, connectedUsers);
        }
        public void SendFileAll(ICollection<string> files)
        {
            fileServer.SendGroup(MessageType.FilesTableAvailable, files, connectedUsers);
            sender = new Gui.FileSender();
            sender.Show();
        }
        public void GetFiles(ICollection<FileServerDLMessage> msgs)
        {
            foreach (FileServerDLMessage msg in msgs)
            {
                fileServer.GetFile(msg);
            }
        }
        public void GetFile(FileServerDLMessage msg)
        {
            fileServer.GetFile(msg);
        }
        public bool IsConnected()
        {
            return (connectedUsers.Count > 0) ?
                    true :
                    false;
        }
        public void LogIn()
        {
            serviceServer.SendGroup(MessageType.LoggedIn, 
                                    Program.localUser.Nickname, 
                                    Program.main.GetContactsList());
        }
        public void LogOut()
        {
            serviceServer.SendGroup(MessageType.LoggedOut,
                                    Program.localUser.Nickname,
                                    Program.main.GetContactsList());
            connectedUsers.Clear();
        }
        public void CloseCurrentConnection()
        {
            serviceServer.SendGroup(MessageType.ConnectionClosed, null, connectedUsers);
            connectedUsers.Clear();
        }
        public void Start()
        {
            serviceServer.Start();
            textServer.Start();
            fileServer.Start();
        }
        public void Stop()
        {
            try
            {
                LogOut();
            }
            catch { }

            if (serviceServer != null)
            {
                serviceServer.Stop();
                serviceServer.Dispose();
                serviceServer = null;
            }

            if (textServer != null)
            {
                textServer.Stop();
                textServer.Dispose();
                textServer = null;
            }

            if (fileServer != null)
            {
                fileServer.Stop();
                fileServer.Dispose();
                fileServer = null;
            }
        }

        // ------- Обробка повідомлень серверів --------

        private void TextRecieved(object sender, ReceivedMessageEventArgs e)
        {
            User owner = GetUserByIP(e.ip);

            if (sender != null)
            {
                Program.main.ShowRecievedText(owner.Nickname, (string)e.options);
            }
            else
            {
                throw new Exception("Отримано повідомлення від стороннього користувача з адресою " +
                                    e.ip.ToString());
            }
        }
        private void AskedConnection(object sender, ReceivedMessageEventArgs e)
        {
            User[] userTable = (User[])e.options;
            bool answer = Program.main.AskUserForConnection(userTable, e.ip);

            if (answer)
            {
                CloseCurrentConnection();
                foreach (User user in userTable)
                {
                    connectedUsers.Add(user);
                }

                serviceServer.SendToOne(MessageType.ConnectionAccepted, Program.localUser.Nickname, e.ip);
                Program.main.ShowConnectionAccepted(Program.localUser.Nickname, e.ip);
            }
            else
            {
                serviceServer.SendToOne(MessageType.ConnectionCanceled, Program.localUser.Nickname, e.ip);
            }
        }
        private void AcceptedConnection(object sender, ReceivedMessageEventArgs e)
        {
            User newUser = new User(e.ip, (string)e.options);
            foreach (User user in connectedUsers)
            {
                serviceServer.SendToOne(MessageType.ConnectionUserAdded, newUser, user.UserIP);
            }

            connectedUsers.Add(newUser);
            Program.main.ShowConnectionAccepted((string)e.options, e.ip);
        }
        private void CanceledConnection(object sender, ReceivedMessageEventArgs e)
        {
            Program.main.ShowConnectionCanceled((string)e.options, e.ip);
        }
        private void NewUserAdded(object sender, ReceivedMessageEventArgs e)
        {
            User newUser = (User)e.options;
            connectedUsers.Add(newUser);
            Program.main.ShowConnectionAccepted(newUser.Nickname, newUser.UserIP);
            Program.main.UpdateNickname(newUser.Nickname, newUser.UserIP);
        }
        private void IsAlive(object sender, ReceivedMessageEventArgs e)
        {
            Program.main.UpdateNickname((string)e.options, e.ip);
        }
        private void ClosedConnection(object sender, ReceivedMessageEventArgs e)
        {
            int itsIndex = connectedUsers.FindIndex(u => u.UserIP.ToString() == e.ip.ToString());

            if (itsIndex > -1)
            {
                Program.main.ShowConnectionClosed(connectedUsers[itsIndex].Nickname, e.ip);
                connectedUsers.RemoveAt(itsIndex);
            }
        }
        private void UserLoggedOut(object sender, ReceivedMessageEventArgs e)
        {
            ClosedConnection(sender, e);
            Program.main.ShowConnectionLoggedOut((string)e.options, e.ip);
        }
        private void UserLoggedIn(object sender, ReceivedMessageEventArgs e)
        {
            Program.main.UpdateNickname((string)e.options, e.ip);
            serviceServer.SendToOne(MessageType.IsAlive, Program.localUser.Nickname, e.ip);
        }
        private void AliveUser(object sender, ReceivedMessageEventArgs e)
        {
            Program.main.UpdateNickname((string)e.options, e.ip);
        }

        private void RecievedFileTable(object sender, ReceivedMessageEventArgs e)
        {
            bool answer = Program.main.AskForAvailableFiles(GetUserByIP(e.ip).Nickname, e.ip);
            if (answer == true)
            {
                var fileTable = new Gui.FileFilesAvailable();
                fileTable.LoadFiles((List<string>)e.options, e.ip);
                fileTable.ShowDialog();
            }
        }
        private void SendedFile(object sender, FileServerNotificationEventArgs e)
        {
            if (this.sender != null)
            {
                if (this.sender.InvokeRequired)
                {
                    this.sender.Invoke(new Action<double, string, string>(this.sender.UpdateStatus),
                                       e.Value, e.Filename, e.Owner.ToString());
                }
                else
                {
                    this.sender.UpdateStatus(e.Value, e.Filename, e.Owner.ToString());
                }
            }
        }
        private void SavedFile(object sender, FileServerSavedFileEventArgs e)
        {
            if (downloader == null)
            {
                downloader = new Gui.FileDownloader();
                Program.main.Invoke(new Action(downloader.Show));
            }

            if (downloader.InvokeRequired)
            {
                Delegate temp = new Action<string, string, double>(downloader.UpdateFile);
                downloader.Invoke(temp, e.Filename, e.SavedPath, e.Recieved);
            }
            else
            {
                downloader.UpdateFile(e.Filename, e.SavedPath, e.Recieved);
            }
        }

        #region Dispose methods
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Stop();
                    sender.Dispose();
                    downloader.Dispose();
                }

                disposed = true;
            }
        }
        #endregion
    }
}
