namespace Chat_v1.Forms
{
    partial class AddFriendByIP
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(5, 38);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(38, 20);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "0";
            this.tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb1.TextChanged += new System.EventHandler(this.tb1InputChecker);
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(49, 38);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(38, 20);
            this.tb2.TabIndex = 1;
            this.tb2.Text = "0";
            this.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb2.TextChanged += new System.EventHandler(this.tb2InputChecker);
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(93, 38);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(38, 20);
            this.tb3.TabIndex = 2;
            this.tb3.Text = "0";
            this.tb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb3.TextChanged += new System.EventHandler(this.tb3InputChecker);
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(137, 38);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(38, 20);
            this.tb4.TabIndex = 3;
            this.tb4.Text = "0";
            this.tb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb4.TextChanged += new System.EventHandler(this.tb4InputChecker);
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP адреса";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(12, 72);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 28);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "ОК";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(93, 72);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 28);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // AddFriendByIP
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(184, 107);
            this.ControlBox = false;
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(190, 135);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(190, 135);
            this.Name = "AddFriendByIP";
            this.Text = "Новий контакт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
    }
}