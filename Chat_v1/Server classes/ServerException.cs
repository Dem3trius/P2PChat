using System;
using System.Net;

namespace Chat_v1
{
    /// <summary>
    /// Виняткова ситуація що виникає при невдалій спробі ініціалізувати сервер
    /// </summary>
    public class ServerException : Exception
    {
        public ErrorCode errCode { get; private set; }
        public IPAddress target { get; private set; }

        public ServerException(ErrorCode errCode, IPAddress target)
            : base()
        {
            this.errCode = errCode;
            this.target = target;
        }
    }
}
