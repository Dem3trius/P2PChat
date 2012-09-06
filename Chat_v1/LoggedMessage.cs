using System;
using System.Collections.Generic;
using System.Net;

namespace Chat_v1
{
    /// <summary>
    /// Клас, що зберігає час, тип, адреси адресата та відправника повідомлення
    /// </summary>
    public class LoggedMessage
    {
        /// <summary>
        /// Містить усі відіслані або отримані повідомлення
        /// </summary>
        public static List<LoggedMessage> History = new List<LoggedMessage>();
        public static event Action<LoggedMessage> NewMessage;
        /// <summary>
        /// Час, у який було відправлено\отримано повідомлення
        /// </summary>
        public DateTime time { get; private set; }
        /// <summary>
        /// Тип повідомлення
        /// </summary>
        public MessageType msgType { get; private set; }
        /// <summary>
        /// Адреса того, хто відправив повідомлення
        /// </summary>
        public IPAddress sender { get; private set; }
        /// <summary>
        /// Адреса того, хто отримав повідомлення
        /// </summary>
        public IPAddress target { get; private set; }

        public LoggedMessage(DateTime time, MessageType msgType, IPAddress sender, IPAddress target)
        {
            this.time = time;
            this.msgType = msgType;
            this.sender = sender;
            this.target = target;

            History.Add(this);
            if (NewMessage != null)
            {
                NewMessage(this);
            }
        }

        public string[] GetValues()
        {
            string[] answer = new string[4];
            answer[0] = this.time.ToString("T");
            answer[1] = this.msgType.ToString();
            answer[2] = this.sender.ToString();
            answer[3] = this.target.ToString();
            return answer;
        }
    }
}
