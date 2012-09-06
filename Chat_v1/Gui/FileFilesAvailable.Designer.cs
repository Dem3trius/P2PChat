namespace Chat_v1.Gui
{
    partial class FileFilesAvailable
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
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btLeft = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Доступні нові файли";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.SizeColumn});
            this.listView1.Location = new System.Drawing.Point(12, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(233, 156);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Ім\'я файлу";
            this.NameColumn.Width = 121;
            // 
            // SizeColumn
            // 
            this.SizeColumn.Text = "Розмір";
            this.SizeColumn.Width = 107;
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(29, 209);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(91, 29);
            this.btLeft.TabIndex = 3;
            this.btLeft.Text = "ОК";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Відміна";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FileFilesAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Name = "FileFilesAvailable";
            this.Text = "Завантаження файлів";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader SizeColumn;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}