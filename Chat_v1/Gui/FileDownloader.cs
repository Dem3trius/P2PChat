using System.Windows.Forms;

namespace Chat_v1.Gui
{
    public partial class FileDownloader : Form
    {
        public FileDownloader()
        {
            InitializeComponent();
        }

        public void UpdateFile(string name, string path, double recieved)
        {
            this.pbDownloadStatus.Value = (int)(recieved * 100);
         
            foreach (ListViewItem item in this.listView1.Items)
            {
                if (item.Text == name)
                {
                    return;
                }
            }

            ListViewItem currentItem = new ListViewItem(name);
            currentItem.SubItems.Add(path);
            this.listView1.Items.Add(currentItem);
        }
    }
}
