using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Chat_v1
{
    [Serializable]
    public sealed partial class User : IComparable, ISerializable
    {
        public IPAddress UserIP { get; set; }
        public string Nickname { get; set; }

        public User(IPAddress userIP, string nickname)
        {
            this.UserIP = userIP;
            this.Nickname = nickname;
        }

        #region IComparable realisation

        public int CompareTo(object obj)
        {
            return Comparer<IPAddress>.Default.Compare(this.UserIP, ((User)obj).UserIP);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if ((object)this == null || obj == null)
            {
                return false;
            }

            User u = obj as User;

            if (u.Nickname.Equals(Nickname) &&
                u.UserIP.ToString().Equals(UserIP.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region ISerializable realisation

        private User(SerializationInfo si, StreamingContext ctx)
        {
            UserIP = IPAddress.Parse(si.GetString("ipString"));
            Nickname = si.GetString("nickString");
        }

        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext ctx)
        {
            si.AddValue("ipString", UserIP.ToString());
            si.AddValue("nickString", Nickname);
        }

        private User() { }

        #endregion
    }
}
