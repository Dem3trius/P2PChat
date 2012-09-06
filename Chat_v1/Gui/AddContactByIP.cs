using System;
using System.Windows.Forms;

namespace Chat_v1.Forms
{
    public partial class AddFriendByIP : Form
    {
        public AddFriendByIP()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public string GetAddress()
        {
            return (tb1.Text + "." + tb2.Text + "." + tb3.Text + "." + tb4.Text);
        }

        /*
            Наступні методи автоматично переводять курсор
            на наступне поле при вводі крапки або 4ого символу.
        */
        
        private void tb1InputChecker(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text[tb1.Text.Length - 1] == '.')
                {
                    tb1.Text = tb1.Text.TrimEnd('.');
                    tb2.Focus();
                }
                else if (tb1.Text.Length >= 3)
                {
                    tb2.Focus();
                }
            }
            catch { }
        }

        private void tb2InputChecker(object sender, EventArgs e)
        {
            try
            {
                if (tb2.Text[tb2.Text.Length - 1] == '.')
                {
                    tb2.Text = tb2.Text.TrimEnd('.');
                    tb3.Focus();
                }
                else if (tb2.Text.Length >= 3)
                {
                    tb3.Focus();
                }
            }
            catch { }
        }

        private void tb3InputChecker(object sender, EventArgs e)
        {
            try
            {
                if (tb3.Text[tb3.Text.Length - 1] == '.')
                {
                    tb3.Text = tb3.Text.TrimEnd('.');
                    tb4.Focus();
                }
                else if (tb3.Text.Length >= 3)
                {
                    tb4.Focus();
                }
            }
            catch { }
        }

        private void tb4InputChecker(object sender, EventArgs e)
        {
            try
            {
                if (tb4.Text[tb4.Text.Length - 1] == '.')
                {
                    tb4.Text = tb4.Text.TrimEnd('.');
                    btOK.Focus();
                }
                else if (tb4.Text.Length >= 3)
                {
                    btOK.Focus();
                }
            }
            catch { }
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                tb2.Focus();
                tb2.SelectAll();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                tb3.Focus();
                tb3.SelectAll();
            }
            else if (e.KeyCode == Keys.Left)
            {
                tb1.Focus();
                tb1.SelectAll();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                tb4.Focus();
                tb4.SelectAll();
            }
            else if (e.KeyCode == Keys.Left)
            {
                tb2.Focus();
                tb2.SelectAll();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                tb3.Focus();
                tb3.SelectAll();
            }
        }
    }
}
