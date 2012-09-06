using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System;
using System.Collections.Generic;

namespace Chat_v1
{
    public partial class UserListBox : ListBox, IDisposable
    {
        private StringFormat _fmt;
        private Font _titleFont;
        private Font _detailsFont;

        public UserListBox()
        {
            InitializeComponent();
            _fmt = new StringFormat();
            _fmt.Alignment = StringAlignment.Near;
            _fmt.LineAlignment = StringAlignment.Near;
            _titleFont = new Font(this.Font, FontStyle.Bold);
            _detailsFont = new Font(this.Font, FontStyle.Regular);
        }

        public void SetState(IPAddress ip, OnlineState state)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                UserListBoxItem current = ((UserListBoxItem)this.Items[i]);

                if (current.User.UserIP.ToString() == ip.ToString())
                {
                    current.Online = state;
                    return;
                }
            }
        }
        public void SetNickname(IPAddress ip, string nickname)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                UserListBoxItem current = ((UserListBoxItem)this.Items[i]);

                if (current.User.UserIP.ToString() == ip.ToString())
                {
                    current.User.Nickname = nickname;
                    return;
                }
            }   
        }
        public UserListBoxItem GetItemByIP(IPAddress ip)
        {
            foreach (UserListBoxItem item in this.Items)
            {
                if (item.User.UserIP.ToString() == ip.ToString())
                {
                    return item;
                }
            }
            return null;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                UserListBoxItem item = (UserListBoxItem)this.Items[e.Index];
                item.drawItem(e, this.Margin, _titleFont, _detailsFont, _fmt);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }

    public class UserListBoxItem : IDisposable 
    {
        private User _user;
        private OnlineState _online;
        private Bitmap _onlineStatus;

        public string Title
        {
            get { return _user.Nickname; }
        }
        public string Details
        {
            get { return _user.UserIP.ToString(); }
        }
        public OnlineState Online
        {
            get { return _online; }
            set
            {
                _online = value;
                if (_onlineStatus != null)
                    _onlineStatus.Dispose();

                if (_online == OnlineState.Online)
                    _onlineStatus = new Bitmap(Properties.Resources.online);
                else
                    _onlineStatus = new Bitmap(Properties.Resources.offline);
            }
        }
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public UserListBoxItem(User user)
        {
            _user = user;
            _online = OnlineState.Unknown;
            _onlineStatus = new Bitmap(Properties.Resources.unknown);
        }

        public void drawItem(DrawItemEventArgs e, Padding margin,
                             Font titleFont, Font detailsFont, StringFormat aligment)
        {
            Brush titleBr, detailsBr, temp;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                temp = new SolidBrush(Color.FromArgb(50, 80, 85));
                titleBr = Brushes.White;
                detailsBr = Brushes.White;
                e.Graphics.FillRectangle(temp, e.Bounds);
            }
            else
            {
                temp = new SolidBrush(Color.FromArgb(25, 40, 45));
                e.Graphics.FillRectangle(temp, e.Bounds);
                titleBr = Brushes.DarkGray;
                detailsBr = Brushes.DarkGray;
            }

            e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);

            Rectangle titleBounds = new Rectangle(e.Bounds.X + margin.Horizontal + _onlineStatus.Width,
                                                  e.Bounds.Y + margin.Top,
                                                  e.Bounds.Width - margin.Right - margin.Horizontal - _onlineStatus.Width,
                                                  (int)titleFont.GetHeight() + 2);

            Rectangle detailBounds = new Rectangle(e.Bounds.X + margin.Horizontal + _onlineStatus.Width,
                                                   e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top,
                                                   e.Bounds.Width - margin.Right - margin.Horizontal - _onlineStatus.Width,
                                                   e.Bounds.Height - margin.Bottom - (int)titleFont.GetHeight() - 2 - margin.Vertical - margin.Top);

            e.Graphics.DrawImage(_onlineStatus, e.Bounds.X + 1,
                e.Bounds.Y + (detailBounds.Bottom - titleBounds.Top - _onlineStatus.Height) / 2);

            e.Graphics.DrawString(this.Title, titleFont, titleBr, titleBounds, aligment);
            e.Graphics.DrawString(this.Details, detailsFont, detailsBr, detailBounds, aligment);

            e.DrawFocusRectangle();
        }

        public void Dispose()
        {
            _onlineStatus.Dispose();
        }
    }
}