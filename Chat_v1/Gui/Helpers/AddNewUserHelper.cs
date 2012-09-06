using System;
using System.Windows.Forms;

namespace Chat_v1.Gui.Helpers
{
    public partial class AddNewUserHelper : Form
    {
        public AddNewUserHelper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
