using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Chat_v1.Gui
{
    public partial class LocalInterfaceInput : Form
    {
        private string _selectedIP = null;

        public LocalInterfaceInput()
        {
            InitializeComponent();
            InitHelper();

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection ips = properties.UnicastAddresses;

                foreach (UnicastIPAddressInformation ip in ips)
                {
                    if ((ip.Address.AddressFamily == AddressFamily.InterNetwork) &&
                        (ip.Address.GetAddressBytes()[0] != 127))
                        lbInterfaces.Items.Add(ip.Address.ToString());
                }
                if (lbInterfaces.Items.Count > 0)
                {
                    lbInterfaces.SetSelected(0, true);
                }
                else
                {
                    MessageBox.Show("Не знайдено будь-яких засобів підключення.",
                                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void InitHelper()
        {
            string info;
            info = ("Зазвичай, адреси у локальній мережі починається числами \n" +
                    "192, 172, 10.\n" +
                    "Можливі проблеми якщо ви підключені через роутер :\n" +
                    "1. Адреса може не відображатися у списку;\n" +
                    "2. Згодом можливі проблеми при підключенні.\n");

            helper.SetShowHelp(this.lbInterfaces, true);
            helper.SetHelpString(this.lbInterfaces, info);
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            if (lbInterfaces.SelectedItems.Count > 0)
            {
                _selectedIP = lbInterfaces.SelectedItem.ToString();
            }
            else
            {
                _selectedIP = lbInterfaces.Items[0].ToString();
            }
        }

        public IPAddress GetSelectedIP()
        {
            try
            {
                IPAddress address = IPAddress.Parse(_selectedIP);
                return address;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
