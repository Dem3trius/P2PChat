using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Chat_v1
{
    static class Program
    {
        public static mainForm main;
        public static User localUser { get; set; }
        public static ServerPool serverPool { get; set; }
        public static bool errorHandling = false;
        public static bool firstExec = false;
        public static bool saveSettings = true;
        private static FileInfo settFile;

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            main = new mainForm();
            serverPool = new ServerPool();
            settFile = new FileInfo("settings.xml");

            if (LoadSettings() == false)
            {
                firstExec = true;
                IPAddress local = LocalIPInput();
                string username = LocalUsernameInput();
                localUser = new User(local, username);
            }

            serverPool.Start();
            serverPool.LogIn();

            if (Program.firstExec)
            {
                main.FirstLogin();
            }

            Application.Run(main);

            CleanUp();
        }
        static void SaveSettings()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            XmlElement root = doc.CreateElement("Settings");
            doc.AppendChild(root);
            doc.InsertBefore(declaration, root);
            XmlElement local_user = doc.CreateElement("Localuser");
            XmlElement local_user_name = doc.CreateElement("Name");
            XmlElement local_user_ip = doc.CreateElement("IP");
            local_user_name.InnerText = localUser.Nickname;
            local_user_ip.InnerText = localUser.UserIP.ToString();
            local_user.AppendChild(local_user_name);
            local_user.AppendChild(local_user_ip);
            root.AppendChild(local_user);

            XmlElement contacts = doc.CreateElement("Contacts");
            root.AppendChild(contacts);

            foreach (User user in main.GetContactsList())
            {
                XmlElement friend = doc.CreateElement("User");
                XmlElement friend_name = doc.CreateElement("Name");
                XmlElement friend_ip = doc.CreateElement("IP");
                friend.AppendChild(friend_name);
                friend.AppendChild(friend_ip);
                friend_name.InnerText = user.Nickname;
                friend_ip.InnerText = user.UserIP.ToString();
                contacts.AppendChild(friend);
            }
            doc.Save(settFile.FullName);
        }
        static bool LoadSettings()
        {
            if (settFile.Exists)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(settFile.FullName);

                XmlElement root = doc.DocumentElement;
                XmlElement local_user = (XmlElement)root.ChildNodes[0];
                string nickname = ((XmlElement)local_user.ChildNodes[0]).InnerText;
                string ip = ((XmlElement)local_user.ChildNodes[1]).InnerText;
                localUser = new User(System.Net.IPAddress.Parse(ip), nickname);

                List<User> temp = new List<User>();
                foreach (XmlElement node in ((XmlElement)root.ChildNodes[1]).ChildNodes)
                {
                    nickname = ((XmlElement)node.ChildNodes[0]).InnerText;
                    ip = ((XmlElement)node.ChildNodes[1]).InnerText;
                    temp.Add(new User(IPAddress.Parse(ip), nickname));
                }

                main.LoadContactList(temp);
                return true;
            }
            return false;
        }
        
        static IPAddress LocalIPInput()
        {
            IPAddress ip = null;
            Gui.LocalInterfaceInput input = new Gui.LocalInterfaceInput();

            if (input.ShowDialog() == DialogResult.OK)
            {
                ip = input.GetSelectedIP();
            }
            input.Dispose();
            return ip;
        }
        static string LocalUsernameInput()
        {
            Gui.LocalNicknameInput input = new Gui.LocalNicknameInput();

            string nick = "???";
            if (input.ShowDialog() == DialogResult.OK)
            {
                nick = input.GetChoosenNickname();
            }
            else
            {
                Environment.Exit(0);
            }

            input.Dispose();
            return nick;
        }
        static void CleanUp()
        {
            serverPool.LogOut();

            if (saveSettings)
            {
                SaveSettings();
            }
        }

        public static void DeleteSettings()
        {
            FileInfo temp = new FileInfo("settings.xml");
            if (temp.Exists)
            {
                temp.Delete();
            }
        }
        public static void ReportServerError(ServerException e)
        {
            if (Program.errorHandling)
            {
                return;
            }
            else
            {
                errorHandling = true;

                switch (e.errCode)
                {
                    case ErrorCode.BadIP:
                    {
                        DialogResult result = MessageBox.Show("Ця IP адреса не підтримується. Виберіть іншу");
                        localUser.UserIP = LocalIPInput();
                        serverPool.Start();
                        break;
                    }
                    case ErrorCode.CannotConnect:
                    {
                        DialogResult result = MessageBox.Show("Неможу з'єднатися з користувачем");
                        break;
                    }
                }
                errorHandling = false;
            }
        }
        public static string GetProperName(long size)
        {
            string value = "Байт";
            if (size > 1048576)
            {
                size = size / 1048576;
                value = "МБайт";
            }
            else if (size > 1024)
            {
                size = size / 1024;
                value = "Кбайт";
            }
            return (size.ToString() + " " + value);
        }
    }
}
