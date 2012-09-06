using System;
using System.Net;
using System.Windows.Forms;

namespace Chat_v1.Gui
{
    public partial class LogTable : Form
    {
        public LogTable()
        {
            InitializeComponent();
            LoggedMessage.NewMessage += new Action<LoggedMessage>(LoggedMessage_NewMessage);
        }

        void LoggedMessage_NewMessage(LoggedMessage obj)
        {
            if (this.dgvLogTable.InvokeRequired)
            {
                this.dgvLogTable.Invoke(new Action<LoggedMessage>(LoggedMessage_NewMessage), obj);
            }
            else
            {
                if (this.dgvLogTable.Rows.Count > 0)
                {
                    this.dgvLogTable.Rows.Add(obj.GetValues());
                }
            }
        }

        public void LoadHistory()
        {
            foreach (LoggedMessage msg in LoggedMessage.History)
            {
                this.dgvLogTable.Rows.Add(msg.GetValues());
            }
        }
    }
}
