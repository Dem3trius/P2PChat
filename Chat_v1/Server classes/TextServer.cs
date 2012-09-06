using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Chat_v1.Server_classes
{
    /// <summary>
    /// Клас, що реалізує отримання та відсилання простих текстових повідомлень
    /// </summary>
    public class TextServer : BaseServer
    {
        public event ReceivedMessageHandler TextRecieved;

        public TextServer() : base()
        {
            this.def_list_port = Default.def_text_list_port;
        }

        public override void Send(MessageType msgType, NetworkStream stream, object options)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine((string)options);
            writer.Close();
        }
        public override void Receive(MessageType msgType, NetworkStream stream, IPAddress owner)
        {
            StreamReader reader = new StreamReader(stream);
            string msg = reader.ReadLine();

            if (msg != "")
                TextRecieved(this, new ReceivedMessageEventArgs(msgType, msg, owner));

            reader.Close();
        }
    }
}
