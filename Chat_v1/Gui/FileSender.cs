using System.Windows.Forms;

namespace Chat_v1.Gui
{
    public partial class FileSender : Form
    {
        public FileSender()
        {
            InitializeComponent();
        }

        public void UpdateStatus(double value, string filename, string target)
        {
            this.progressBar1.Value = (int)(value * 100);
            this.lblTarget.Text = target;

            if (value == 1)
            {
                ListViewItem item = new ListViewItem(filename);
                item.SubItems.Add(target);
                this.listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
