namespace Chat_v1
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.друзіToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.вийтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.надіслатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиЛогПовідомленьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиУсіхПідключенихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скинутиНалаштуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateNewChat = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToChat = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFromListBox = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btSendText = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbChat = new System.Windows.Forms.RichTextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbInchat = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbContacts = new Chat_v1.UserListBox();
            this.mainMenu.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.друзіToolStripMenuItem,
            this.файлиToolStripMenuItem,
            this.логToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(575, 24);
            this.mainMenu.TabIndex = 11;
            this.mainMenu.Text = "menuStrip1";
            // 
            // друзіToolStripMenuItem
            // 
            this.друзіToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиToolStripMenuItem,
            this.toolStripSeparator1,
            this.вийтиToolStripMenuItem});
            this.друзіToolStripMenuItem.Name = "друзіToolStripMenuItem";
            this.друзіToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.друзіToolStripMenuItem.Text = "Контакти";
            // 
            // додатиToolStripMenuItem
            // 
            this.додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            this.додатиToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.додатиToolStripMenuItem.Text = "Додати...";
            this.додатиToolStripMenuItem.Click += new System.EventHandler(this.AddContact);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // вийтиToolStripMenuItem
            // 
            this.вийтиToolStripMenuItem.Name = "вийтиToolStripMenuItem";
            this.вийтиToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.вийтиToolStripMenuItem.Text = "Вийти...";
            this.вийтиToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItem);
            // 
            // файлиToolStripMenuItem
            // 
            this.файлиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.надіслатиToolStripMenuItem});
            this.файлиToolStripMenuItem.Name = "файлиToolStripMenuItem";
            this.файлиToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.файлиToolStripMenuItem.Text = "Файли";
            // 
            // надіслатиToolStripMenuItem
            // 
            this.надіслатиToolStripMenuItem.Name = "надіслатиToolStripMenuItem";
            this.надіслатиToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.надіслатиToolStripMenuItem.Text = "Надіслати..";
            this.надіслатиToolStripMenuItem.Click += new System.EventHandler(this.SendFile);
            // 
            // логToolStripMenuItem
            // 
            this.логToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатиЛогПовідомленьToolStripMenuItem,
            this.показатиУсіхПідключенихToolStripMenuItem,
            this.скинутиНалаштуванняToolStripMenuItem});
            this.логToolStripMenuItem.Name = "логToolStripMenuItem";
            this.логToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.логToolStripMenuItem.Text = "Налаштування";
            // 
            // показатиЛогПовідомленьToolStripMenuItem
            // 
            this.показатиЛогПовідомленьToolStripMenuItem.Name = "показатиЛогПовідомленьToolStripMenuItem";
            this.показатиЛогПовідомленьToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.показатиЛогПовідомленьToolStripMenuItem.Text = "Показати лог повідомлень...";
            this.показатиЛогПовідомленьToolStripMenuItem.Click += new System.EventHandler(this.ShowLogTable);
            // 
            // показатиУсіхПідключенихToolStripMenuItem
            // 
            this.показатиУсіхПідключенихToolStripMenuItem.Name = "показатиУсіхПідключенихToolStripMenuItem";
            this.показатиУсіхПідключенихToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.показатиУсіхПідключенихToolStripMenuItem.Text = "Показати усіх підключених ...";
            this.показатиУсіхПідключенихToolStripMenuItem.Click += new System.EventHandler(this.ShowConnectedUsers);
            // 
            // скинутиНалаштуванняToolStripMenuItem
            // 
            this.скинутиНалаштуванняToolStripMenuItem.Name = "скинутиНалаштуванняToolStripMenuItem";
            this.скинутиНалаштуванняToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.скинутиНалаштуванняToolStripMenuItem.Text = "Скинути налаштування";
            this.скинутиНалаштуванняToolStripMenuItem.Click += new System.EventHandler(this.DeleteSettings);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewChat,
            this.AddToChat,
            this.DeleteFromListBox});
            this.contextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenu.Name = "Test";
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(181, 70);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // CreateNewChat
            // 
            this.CreateNewChat.Name = "CreateNewChat";
            this.CreateNewChat.Size = new System.Drawing.Size(180, 22);
            this.CreateNewChat.Text = "Створити нову розмову";
            this.CreateNewChat.Click += new System.EventHandler(this.CreateNewChat_Click);
            // 
            // AddToChat
            // 
            this.AddToChat.Name = "AddToChat";
            this.AddToChat.Size = new System.Drawing.Size(180, 22);
            this.AddToChat.Text = "Додати до чату";
            this.AddToChat.Click += new System.EventHandler(this.AddSelected);
            // 
            // DeleteFromListBox
            // 
            this.DeleteFromListBox.Name = "DeleteFromListBox";
            this.DeleteFromListBox.Size = new System.Drawing.Size(180, 22);
            this.DeleteFromListBox.Text = "Видалити зі списку";
            this.DeleteFromListBox.Click += new System.EventHandler(this.DeleteFromList);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 29);
            this.textBox1.TabIndex = 13;
            // 
            // btSendText
            // 
            this.btSendText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btSendText.Location = new System.Drawing.Point(246, 3);
            this.btSendText.Name = "btSendText";
            this.btSendText.Size = new System.Drawing.Size(92, 29);
            this.btSendText.TabIndex = 14;
            this.btSendText.Text = "send";
            this.btSendText.UseVisualStyleBackColor = true;
            this.btSendText.Click += new System.EventHandler(this.SendTextMessage);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel3.Controls.Add(this.btSendText, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(341, 35);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // openDialog
            // 
            this.openDialog.FileName = "Виберіть файли для надсилання групі";
            this.openDialog.Multiselect = true;
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainContainer.Location = new System.Drawing.Point(12, 27);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.lbContacts);
            this.mainContainer.Panel1MinSize = 100;
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.splitContainer2);
            this.mainContainer.Size = new System.Drawing.Size(553, 362);
            this.mainContainer.SplitterDistance = 208;
            this.mainContainer.TabIndex = 20;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Panel2MinSize = 35;
            this.splitContainer2.Size = new System.Drawing.Size(341, 362);
            this.splitContainer2.SplitterDistance = 326;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbChat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 326);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbChat
            // 
            this.tbChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.tbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbChat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbChat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbChat.ForeColor = System.Drawing.SystemColors.Window;
            this.tbChat.Location = new System.Drawing.Point(3, 29);
            this.tbChat.Name = "tbChat";
            this.tbChat.ReadOnly = true;
            this.tbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbChat.Size = new System.Drawing.Size(335, 294);
            this.tbChat.TabIndex = 18;
            this.tbChat.Text = "";
            this.tbChat.TextChanged += new System.EventHandler(this.AutomaticScrolling);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbInchat);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button2);
            this.splitContainer3.Size = new System.Drawing.Size(335, 20);
            this.splitContainer3.SplitterDistance = 306;
            this.splitContainer3.TabIndex = 22;
            // 
            // lbInchat
            // 
            this.lbInchat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInchat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInchat.FormattingEnabled = true;
            this.lbInchat.ItemHeight = 15;
            this.lbInchat.Location = new System.Drawing.Point(0, 0);
            this.lbInchat.MultiColumn = true;
            this.lbInchat.Name = "lbInchat";
            this.lbInchat.Size = new System.Drawing.Size(306, 20);
            this.lbInchat.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Chat_v1.Properties.Resources.exit_button_mini;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CloseConnection);
            // 
            // lbContacts
            // 
            this.lbContacts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lbContacts.ContextMenuStrip = this.contextMenu;
            this.lbContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbContacts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbContacts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbContacts.FormattingEnabled = true;
            this.lbContacts.ItemHeight = 40;
            this.lbContacts.Location = new System.Drawing.Point(0, 0);
            this.lbContacts.Name = "lbContacts";
            this.lbContacts.Size = new System.Drawing.Size(208, 362);
            this.lbContacts.TabIndex = 14;
            // 
            // mainForm
            // 
            this.AcceptButton = this.btSendText;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 398);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.mainContainer);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "mainForm";
            this.Text = "Головне вікно";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem друзіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btSendText;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddToChat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem;
        private System.Windows.Forms.RichTextBox tbChat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private UserListBox lbContacts;
        private System.Windows.Forms.ListBox lbInchat;
        private System.Windows.Forms.ToolStripMenuItem файлиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem надіслатиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ToolStripMenuItem логToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиЛогПовідомленьToolStripMenuItem;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem показатиУсіхПідключенихToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem DeleteFromListBox;
        private System.Windows.Forms.ToolStripMenuItem CreateNewChat;
        private System.Windows.Forms.ToolStripMenuItem скинутиНалаштуванняToolStripMenuItem;
    }
}

