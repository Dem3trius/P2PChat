using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Chat_v1.Gui
{
    public partial class FileFilesAvailable : Form
    {
        private List<string> fullNames;
        public string filesPath { get; set; }
        public IPAddress Sender { get; set; }

        public FileFilesAvailable()
        {
            InitializeComponent();
        }

        public void LoadFiles(List<string> files, IPAddress ip)
        {
            foreach (string file in files)
            {
                string[] temp = file.Split('\\');
                string nameAndLenght = temp[temp.Length - 1];
                string[] items = nameAndLenght.Split();
                string lenght = items[items.Length - 1];
                string name = String.Join(" ", items, 0, items.Length - 1);
                long size = Convert.ToInt64(lenght);

                ListViewItem item = new ListViewItem(name);
                item.SubItems.Add(Program.GetProperName(size));
                item.Checked = true;
                listView1.Items.Add(item);
            }
            filesPath = "Recieved files";
            fullNames = files;
            Sender = ip;
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = (DialogResult)(Program.main.Invoke(new Func<DialogResult>(folderDialog.ShowDialog)));

            if (result == DialogResult.OK)
            {
                string saveDir = folderDialog.SelectedPath;
                foreach (int i in this.listView1.CheckedIndices)
                {
                    string fullname = fullNames[i];
                    string[] items = fullname.Split();
                    string withoutLenght = String.Join(" ", items, 0, items.Length - 1);
                    long lenght = Convert.ToInt64(items[items.Length - 1]);

                    FileServerDLMessage msg = new FileServerDLMessage(withoutLenght, saveDir, Sender, lenght);
                    Program.serverPool.GetFile(msg);
                }
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
