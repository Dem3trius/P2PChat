namespace Chat_v1.Gui
{
    partial class LogTable
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
            this.dgvLogTable = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLogTable
            // 
            this.dgvLogTable.AllowUserToAddRows = false;
            this.dgvLogTable.AllowUserToDeleteRows = false;
            this.dgvLogTable.AllowUserToResizeRows = false;
            this.dgvLogTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.msgtype,
            this.from,
            this.to});
            this.dgvLogTable.Location = new System.Drawing.Point(12, 12);
            this.dgvLogTable.MultiSelect = false;
            this.dgvLogTable.Name = "dgvLogTable";
            this.dgvLogTable.RowHeadersVisible = false;
            this.dgvLogTable.Size = new System.Drawing.Size(622, 399);
            this.dgvLogTable.TabIndex = 0;
            // 
            // time
            // 
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            // 
            // msgtype
            // 
            this.msgtype.HeaderText = "MessageType";
            this.msgtype.Name = "msgtype";
            // 
            // from
            // 
            this.from.HeaderText = "From IP";
            this.from.Name = "from";
            // 
            // to
            // 
            this.to.HeaderText = "to IP";
            this.to.Name = "to";
            // 
            // LogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 423);
            this.Controls.Add(this.dgvLogTable);
            this.Name = "LogTable";
            this.Text = "Лог повідомлень";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn to;
    }
}