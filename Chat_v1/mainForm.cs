using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Chat_v1.Forms;

namespace Chat_v1
{
    public partial class mainForm : Form
    {
        public List<User> GetContactsList()
        {
            List<User> temp = new List<User>();
            foreach (UserListBoxItem item in lbContacts.Items)
            {
                temp.Add(item.User);
            }
            return temp;
        }
        public void LoadContactList(List<User> userlist)
        {
            foreach (User user in userlist)
            {
                contacts_ItemAdd(user);
            }
        }
        private int _lastWidth = 0;

        // ------- Запуск та зупинка програми --------

        public mainForm()
        {
            InitializeComponent();
            CloseChatPanel();
        }
        public void FirstLogin()
        {
            Gui.Helpers.AddNewUserHelper helper1 = new Gui.Helpers.AddNewUserHelper();
            helper1.ShowDialog();
            helper1.Dispose();
        }
        public void HowToCreateChat()
        {
            Gui.Helpers.CreateChatHelper helper2 = new Gui.Helpers.CreateChatHelper();
            helper2.ShowDialog();
            helper2.Dispose();
        }
        public void HowToAddUsers()
        {
            Gui.Helpers.AddUsersToChat helper3 = new Gui.Helpers.AddUsersToChat();
            helper3.ShowDialog();
            helper3.Dispose();
        }
        public void HowToDisconnectFromChat()
        {
            Gui.Helpers.DisconnectFromChat helper4 = new Gui.Helpers.DisconnectFromChat();
            helper4.ShowDialog();
            helper4.Dispose();
        }

        // ------ Контрол, що оброблює список контактів --------

        private void contacts_ItemRemove(User user)
        {
            if (lbContacts.InvokeRequired)
            {
                lbContacts.Invoke(new Action<User>(contacts_ItemRemove), user);
            }
            else
            {
                UserListBoxItem item = lbContacts.GetItemByIP(user.UserIP);

                if (item != null)
                {
                    lbContacts.Items.Remove(item);
                }

                lbContacts.Refresh();
            }
        }
        private void contacts_ItemAdd(User user)
        {
            if (lbContacts.InvokeRequired)
            {
                lbContacts.Invoke(new Action<User>(contacts_ItemAdd), user);
            }
            else
            {
                UserListBoxItem item = lbContacts.GetItemByIP(user.UserIP);

                if (item == null)
                {
                    lbContacts.Items.Add(new UserListBoxItem(user));
                }
                else
                {
                    item.User.Nickname = user.Nickname;
                }
            
                lbContacts.Refresh();

                if (Program.firstExec)
                {
                    HowToCreateChat();
                }
            }
        }
        private void contacts_UserUpdateNickname(User user)
        {
            if (lbContacts.InvokeRequired)
            {
                lbContacts.Invoke(new Action<User>(contacts_UserUpdateNickname), user);
            }
            else
            {
                lbContacts.SetNickname(user.UserIP, user.Nickname);
                lbContacts.Refresh();
            }
            contacts_UserUpdateStatus(user.UserIP, OnlineState.Online);
        }
        private void contacts_UserUpdateStatus(IPAddress ip, OnlineState state)
        {
            if (lbContacts.InvokeRequired)
            {
                lbContacts.Invoke(new Action<IPAddress, OnlineState>(contacts_UserUpdateStatus), ip, state);
            }
            else
            {
                lbContacts.SetState(ip, state);
                lbContacts.Refresh();
            }
        }
        private void contacts_Disconnected(IPAddress ip, string nickname)
        {
            contacts_UserUpdateStatus(ip, OnlineState.Offline);
        }

        // ------ Контролюють панель повідомлеь у чаті

        private void OpenChatPanel()
        {
            if (mainContainer.Panel2Collapsed)
            {
                mainContainer.Panel2Collapsed = false;
                this.Width += _lastWidth;
            }
        }
        private void CloseChatPanel()
        {
            if (mainContainer.Panel2Collapsed == false)
            {
                _lastWidth = mainContainer.Panel2.Width;
                this.Width = mainContainer.Panel1.Width + 40;
                mainContainer.Panel2Collapsed = true;
            }
        }
        
        // ------ Контрол, що оброблює список користувачів в конференції --------

        private void inchat_UpdateNames()
        {
            if (lbInchat.InvokeRequired)
            {
                lbInchat.Invoke(new MethodInvoker(inchat_UpdateNames));
            }
            else
            {
                lbInchat.Items.Clear();
                lbInchat.Items.Add(Program.localUser.Nickname);

                foreach (User user in Program.serverPool.connectedUsers)
                {
                    lbInchat.Items.Add(user.Nickname);
                }
            }
        }
        
        // ------ Обробка повідомлень сервера --------

        public bool AskUserForConnection(User[] userTable, IPAddress ip)
        {
            string temp = "???";
            foreach (User user in userTable)
                if (user.UserIP.Equals(ip))
                {
                    temp = user.Nickname;
                    break;
                }

            temp = ("Користувач '" + temp + "' з адресою <" + ip.ToString() + "> " +
                   "запрошує вас до конференції.\n\n");

            foreach (User user in userTable)
            {
                temp += "Нік : " + user.Nickname + " \n";
            }
            temp += "\nБажаєте приєднатись?";

            DialogResult result = MessageBox.Show(temp, "Запрошення до конференції", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                foreach (User user in userTable)
                {
                    contacts_ItemAdd(user);
                    contacts_UserUpdateStatus(user.UserIP, OnlineState.Online);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowConnectionAccepted(string nickname, IPAddress ip)
        {
            if (tbChat.InvokeRequired)
            {
                tbChat.Invoke(new Action<string, IPAddress>(ShowConnectionAccepted), nickname, ip);
            }
            else
            {
                OpenChatPanel();
                if (nickname == Program.localUser.Nickname)
                {
                    tbChat.AppendText("Ви підключились до конференції\n");

                    if (Program.firstExec)
                    {
                        HowToAddUsers();
                        HowToDisconnectFromChat();
                    }
                }
                else
                {
                    tbChat.AppendText("Користувач '" + nickname + "' приєднався до конференції\n");
                    contacts_ItemAdd(new User(ip, nickname));
                }
            }
            contacts_UserUpdateStatus(ip, OnlineState.Online);
            inchat_UpdateNames();
        }
        public void ShowConnectionCanceled(string nickname, IPAddress ip)
        {
            MessageBox.Show("Користувач '" + nickname + "' відхилив запрошення.",
                            "Запрошення відхилено",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }
        public void ShowConnectionClosed(string nickname, IPAddress ip)
        {
            if (tbChat.InvokeRequired)
            {
                tbChat.Invoke(new Action<string, IPAddress>(ShowConnectionClosed), nickname, ip);
            }
            else
            {
                tbChat.AppendText("Користувач '" + nickname + "' вийшов\n");
            }
            inchat_UpdateNames();
        }
        public void ShowConnectionLoggedOut(string nickname, IPAddress ip)
        {
            if (lbContacts.InvokeRequired)
            {
                lbContacts.Invoke(new Action<string, IPAddress>(ShowConnectionLoggedOut), nickname, ip);
            }
            else
            {
                lbContacts.SetState(ip, OnlineState.Offline);
                lbContacts.Refresh();
            }
            inchat_UpdateNames();
        }
        public void UpdateNickname(string nickname, IPAddress ip)
        {
            contacts_UserUpdateNickname(new User(ip, nickname));
            inchat_UpdateNames();
        }
        public void ShowRecievedText(string nickname, string data)
        {
            if (tbChat.InvokeRequired)
            {
                tbChat.Invoke(new Action<string, string>(ShowRecievedText), nickname, data);
            }
            else
            {
                tbChat.SelectionStart = tbChat.TextLength;
                tbChat.SelectionLength = 0;

                if (nickname == Program.localUser.Nickname)
                {
                    tbChat.SelectionColor = Color.Gray;
                }
                else
                {
                    tbChat.SelectionColor = Color.FromArgb(43, 149, 255);
                }

                tbChat.AppendText(nickname);
                tbChat.SelectionColor = Color.White;
                tbChat.AppendText(" : " + data + '\n');
            }
        }
        public bool AskForAvailableFiles(string ownerNickname, IPAddress owner)
        {
            DialogResult result = MessageBox.Show("Користувач " + ownerNickname + " передає файли.\n Отримати?",
                                                  "Передача файлів", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // ------- Взаємодія з користувачем --------

        private void AddContact(object sender, EventArgs e)
        {
            AddFriendByIP dialog = new AddFriendByIP();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IPAddress friend = IPAddress.Parse(dialog.GetAddress());
                if (friend.ToString() == Program.localUser.UserIP.ToString())
                {
                    MessageBox.Show("Неможна додавати самого себе");
                }
                else
                {
                    contacts_ItemAdd(new User(friend, "???"));
                }
            }
            dialog.Dispose();
        }
        private void CloseConnection(object sender, EventArgs e)
        {
            if (Program.serverPool.IsConnected())
            {
                Program.serverPool.CloseCurrentConnection();

                if (tbChat.InvokeRequired)
                {
                    tbChat.Invoke(new EventHandler(CloseConnection), sender, e);
                }
            }
            CloseChatPanel();
        }
        private void AddSelected(object sender, EventArgs e)
        {
            UserListBoxItem temp = null;
            if (lbContacts.SelectedIndices.Count != 0)
            {
                temp = (UserListBoxItem)lbContacts.Items[lbContacts.SelectedIndices[0]];
                if (Program.serverPool.connectedUsers.Contains(temp.User) 
                    || Program.localUser == temp.User)
                {
                    // Неможна додавати у чат тих, хто уже
                    // підключений.
                }
                else
                {
                    try
                    {
                        Program.serverPool.TryConnectToUser(temp.User);
                    }
                    catch (ServerException)
                    {
                        MessageBox.Show("Неможу зв'язатися");
                    }
                }
            }
        }
        private void SendTextMessage(object sender, EventArgs e)
        {
            if (Program.serverPool.IsConnected())
            {
                ShowRecievedText(Program.localUser.Nickname, textBox1.Text);
                Program.serverPool.SendTextAll(textBox1.Text);
                textBox1.Text = "";
            }
        }
        private void ExitMenuItem(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SendFile(object sender, EventArgs e)
        {
            if (Program.serverPool.IsConnected())
            {

                DialogResult result = openDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string[] files = openDialog.FileNames;
                    Program.serverPool.SendFileAll(files);
                }
            }
            else
            {
                MessageBox.Show("Для надсилання файлів необхідно бути у чаті з кимось");
            }
        }
        private void ShowLogTable(object sender, EventArgs e)
        {
            Gui.LogTable logger = new Gui.LogTable();
            logger.LoadHistory();
            logger.Show();
        }
        private void ShowConnectedUsers(object sender, EventArgs e)
        {
            string temp = "";
            foreach (User user in Program.serverPool.connectedUsers)
            {
                temp += "<" + user.UserIP.ToString() + ">:<" + user.Nickname + ">\n";
            }

            MessageBox.Show(temp);
        }
        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Program.serverPool.IsConnected())
            {
                AddToChat.Visible = true;
            }
            else
            {
                AddToChat.Visible = false;
            }
        }
        private void AutomaticScrolling(object sender, EventArgs e)
        {
            tbChat.SelectionStart = tbChat.Text.Length;
            tbChat.ScrollToCaret();
        }
        private void DeleteFromList(object sender, EventArgs e)
        {
            if (lbContacts.SelectedIndices.Count > 0)
            {
                var item = (UserListBoxItem)lbContacts.Items[lbContacts.SelectedIndices[0]];
                contacts_ItemRemove(item.User);
            }
        }
        private void CreateNewChat_Click(object sender, EventArgs e)
        {
            UserListBoxItem item = (UserListBoxItem)lbContacts.SelectedItem;
            Program.serverPool.TryConnectToUser(item.User);
        }
        private void DeleteSettings(object sender, EventArgs e)
        {
            Program.DeleteSettings();
            Program.saveSettings = false;
        }       
    }
}
