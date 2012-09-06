using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Chat_v1.Server_classes
{
    /// <summary>
    /// Клас, що реалізує встановлення підключення, реєстрацію користувачів та ін.
    /// </summary>
    public class ServiceServer : BaseServer
    {
        public event ReceivedMessageHandler AskedConnection;
        public event ReceivedMessageHandler NewUserAdded;
        public event ReceivedMessageHandler AcceptedConnection;
        public event ReceivedMessageHandler CanceledConnection;
        public event ReceivedMessageHandler ClosedConnection;
        public event ReceivedMessageHandler UserLoggedOut;
        public event ReceivedMessageHandler UserLoggedIn;
        public event ReceivedMessageHandler AliveUser;

        public ServiceServer()
            : base()
        {
            this.def_list_port = Default.def_service_list_port;
        }

        public override void Send(MessageType msgType, NetworkStream stream, object options)
        {
            BinaryWriter writer = new BinaryWriter(stream);
            
            switch (msgType)
            {
                case MessageType.ConnectionAsk:
                    {
                        byte[] userTable = SimpleFormatters.ObjectToBytes(options);
                        int len = userTable.Length;
                        writer.Write(len);
                        writer.Write(userTable);
                        break;
                    }
                case MessageType.ConnectionUserAdded:
                    {
                        byte[] userBytes = SimpleFormatters.ObjectToBytes(options);
                        int len = userBytes.Length;
                        writer.Write(len);
                        writer.Write(userBytes);
                        break;
                    }
                case MessageType.ConnectionAccepted:
                case MessageType.LoggedIn:
                case MessageType.LoggedOut:
                case MessageType.IsAlive:
                    {
                        StreamWriter nickWriter = new StreamWriter(stream);
                        nickWriter.WriteLine((string)options);
                        nickWriter.Close();
                        break;
                    }
                default:
                    writer.Close();
                    break;
            }
        }

        public override void Receive(MessageType msgType, NetworkStream stream, IPAddress owner)
        {
            BinaryReader reader = new BinaryReader(stream);
            StreamReader nickReader = new StreamReader(stream);

            switch (msgType)
            {
                case MessageType.ConnectionAsk:
                    {
                        int len = reader.ReadInt32();
                        byte[] userTable = reader.ReadBytes(len);
                        User[] table = (User[])SimpleFormatters.BytesToObject(userTable);
                        AskedConnection(this, new ReceivedMessageEventArgs(msgType, table, owner));
                        break;
                    }
                case MessageType.ConnectionUserAdded:
                    {
                        int len = reader.ReadInt32();
                        byte[] userBytes = reader.ReadBytes(len);
                        User newUser = (User)SimpleFormatters.BytesToObject(userBytes);
                        NewUserAdded(this, new ReceivedMessageEventArgs(msgType, newUser, owner));
                        break;
                    }
                case MessageType.ConnectionAccepted:
                    {
                        string nickname = nickReader.ReadLine();
                        AcceptedConnection(this, new ReceivedMessageEventArgs(msgType, nickname, owner));
                        break;
                    }
                case MessageType.ConnectionCanceled:
                    {
                        string nickname = nickReader.ReadLine();
                        CanceledConnection(this, new ReceivedMessageEventArgs(msgType, nickname, owner));
                        break;
                    }
                case MessageType.ConnectionClosed:
                    {
                        ClosedConnection(this, new ReceivedMessageEventArgs(msgType, owner));
                        break;
                    }
                case MessageType.LoggedIn:
                    {
                        string nickname = nickReader.ReadLine();
                        UserLoggedIn(this, new ReceivedMessageEventArgs(msgType, nickname, owner));
                        break;
                    }
                case MessageType.LoggedOut:
                    {
                        string nickname = nickReader.ReadLine();
                        UserLoggedOut(this, new ReceivedMessageEventArgs(msgType, nickname, owner));
                        break;
                    }
                case MessageType.IsAlive:
                    {
                        string nickname = nickReader.ReadLine();
                        AliveUser(this, new ReceivedMessageEventArgs(msgType, nickname, owner));
                        break;
                    }
                case MessageType.Echo:
                    {
                        Send(MessageType.IsAlive, stream, Program.localUser.Nickname);
                        break;
                    }
                default:
                    break;
            }

            reader.Close();
            nickReader.Close();
        }
    }
}
