using System;
using System.Windows.Forms;

namespace Chat_v1.Gui
{
    public partial class LocalNicknameInput : Form
    {
        public LocalNicknameInput()
        {
            InitializeComponent();

            tbNickname.Text = Environment.UserName;
            tbNickname.Focus();
            tbNickname.SelectAll();
        }

        public string GetChoosenNickname()
        {
            string temp = tbNickname.Text;

            if (tbNickname.Text.Length > 15)
                temp = tbNickname.Text.Remove(15);

            if (temp == "")
            {
                return "Nickname";
            }
            else
            {
                return temp;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
