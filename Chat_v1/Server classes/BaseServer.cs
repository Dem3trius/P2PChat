using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Chat_v1;
using System.Collections.Generic;

namespace Chat_v1.Server_classes
{
    /// <summary>
    /// Базовий клас для усіх "серверів".
    /// Віртуальні методи Send та Receive перевизначаються в наслідниках
    /// </summary>
    public abstract class BaseServer : IDisposable
    {
        private Socket serverSocket;
        private Thread serverThread;
        private TcpClient serverSender;

        protected event Action AfterConnectionClosed;

        protected int def_list_port = 0;

        /// <summary>
        /// Відправляє повідомлення на вказану IP адресу
        /// </summary>
        /// <param name="msgType">Код подвідомлення</param>
        /// <param name="options">Параметри повідомлення - додаткові дані для передачі</param>
        /// <param name="target">Адреса отримувача</param>
        /// <param name="errorReport">Чи необхідно викликати виняткову ситуацію при виникненні помилки</param>
        public void SendToOne(MessageType msgType, object options, IPAddress target, bool errorReport)
        {
            serverSender = new TcpClient();
            IAsyncResult result = serverSender.BeginConnect(target, def_list_port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(1000, true);

            if (serverSender.Connected)
            {
                NetworkStream netStream = serverSender.GetStream();
                byte[] buffer = BitConverter.GetBytes((int)msgType);
                netStream.Write(buffer, 0, 4);

                Send(msgType, netStream, options);

                new LoggedMessage(DateTime.Now, msgType, Program.localUser.UserIP, target);
             
                netStream.Close();
                serverSender.Close();

                if (AfterConnectionClosed != null)
                {
                    AfterConnectionClosed();
                }
            }
            else
            {
                serverSender.Close();
                if (errorReport)
                {
                    Program.ReportServerError(new ServerException(ErrorCode.CannotConnect, target));
                }
            }
        }
        public void SendToOne(MessageType msgType, object options, IPAddress target)
        {
            SendToOne(msgType, options, target, false);
        }
        public void SendGroup(MessageType msgType, object options, List<User> target, bool errorReport)
        {
            foreach (User user in target)
                SendToOne(msgType, options, user.UserIP, errorReport);
        }
        public void SendGroup(MessageType msgType, object options, List<User> target)
        {
            SendGroup(msgType, options, target, false);
        }

        /// <summary>
        /// Запускає процес для прослуховування вхідних повідомлень
        /// </summary>
        public void Start()
        {
            serverThread = new Thread(new ThreadStart(StartListen));
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        /// <summary>
        /// Зупиняє роботу сервера
        /// </summary>
        public void Stop()
        {
            serverThread.Abort();
            serverThread = null;
        }
        private void StartListen()
        {
            IPEndPoint hostEP = null;
            try
            {
                hostEP = new IPEndPoint(Program.localUser.UserIP, def_list_port);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(hostEP);
            }
            catch
            {
                Program.ReportServerError(new ServerException(ErrorCode.BadIP, hostEP.Address));
                return;
            }
            serverSocket.Listen(-1);

            while (true)
            {
                try
                {
                    Socket newSocket = serverSocket.Accept();
                    NetworkStream netStream = new NetworkStream(newSocket);
                    byte[] buffer = new byte[4];
                    netStream.Read(buffer, 0, 4);
                    MessageType msgType = (MessageType)BitConverter.ToInt32(buffer, 0);
                    IPEndPoint host = (IPEndPoint)newSocket.RemoteEndPoint;

                    Receive(msgType, netStream, host.Address);
                    new LoggedMessage(DateTime.Now, msgType, host.Address, Program.localUser.UserIP);

                    newSocket.Close();
                    netStream.Close();

                    if (AfterConnectionClosed != null)
                    {
                        AfterConnectionClosed();
                    }
                }
                catch (ServerException ex2)
                {
                    Program.ReportServerError(ex2);
                }
                catch (SocketException) { }
            }
        }

        public virtual void Send(MessageType msgType, NetworkStream stream, object options)
        {
            // Тут необхідно виконати запис у потік параметрів 'data' і 'options'
        }
        public virtual void Receive(MessageType msgType, NetworkStream stream, IPAddress owner)
        {
            // Тут необхідно виконати зчитування полів залежно від того,
            // як вони були записані у методі Send
        }

        #region IDisposable realisation
        private bool disposed = false;

        public void Dispose()
        {
            Stop();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (serverSocket != null)
                    {
                        serverSocket.Close();
                        serverSocket = null;
                    }

                    if (serverSender != null)
                    {
                        serverSender.Close();
                        serverSender = null;
                    }
                }

                disposed = true;
            }
        }
        #endregion
    }
}
