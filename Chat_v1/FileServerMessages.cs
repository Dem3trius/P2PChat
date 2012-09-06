using System.Net;

namespace Chat_v1
{
    /// <summary>
    /// Клас містить інформацію про файл, який необхідно завантажити
    /// </summary>
    public class FileServerDLMessage
    {
        public string TargetFile { get; set; }
        public string SaveDir { get; set; }
        public IPAddress Owner { get; set; }
        public long Size { get; set; }

        public FileServerDLMessage(string targetFile, string saveDir, IPAddress owner, long size)
        {
            this.TargetFile = targetFile;
            this.SaveDir = saveDir;
            this.Owner = owner;
            this.Size = size;
        }
    }

    /// <summary>
    /// Клас містить інформацію про файл, який необхідно відіслати
    /// </summary>
    public class FileServerULMessage
    {
        public string TargetFile { get; set; }
        public IPAddress target { get; set; }

        public FileServerULMessage(string targetFile, IPAddress target)
        {
            this.TargetFile = targetFile;
            this.target = target;
        }
    }
}
