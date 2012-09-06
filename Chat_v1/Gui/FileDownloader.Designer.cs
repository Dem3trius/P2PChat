namespace Chat_v1.Gui
{
    partial class FileDownloader
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
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbDownloadStatus = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отримані файли";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.file});
            this.listView1.Location = new System.Drawing.Point(12, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(445, 187);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Назва";
            this.name.Width = 159;
            // 
            // file
            // 
            this.file.Text = "Файл";
            this.file.Width = 212;
            // 
            // pbDownloadStatus
            // 
            this.pbDownloadStatus.Location = new System.Drawing.Point(12, 34);
            this.pbDownloadStatus.Name = "pbDownloadStatus";
            this.pbDownloadStatus.Size = new System.Drawing.Size(445, 23);
            this.pbDownloadStatus.TabIndex = 2;
            // 
            // FileDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 262);
            this.Controls.Add(this.pbDownloadStatus);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Name = "FileDownloader";
            this.Text = "Завантажені файли";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ProgressBar pbDownloadStatus;
    }
}