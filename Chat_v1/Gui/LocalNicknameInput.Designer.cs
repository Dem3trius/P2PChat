namespace Chat_v1.Gui
{
    partial class LocalNicknameInput
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
            this.btOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNickname = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(6, 62);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(60, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введіть ім\'я";
            // 
            // tbNickname
            // 
            this.tbNickname.Location = new System.Drawing.Point(6, 36);
            this.tbNickname.Name = "tbNickname";
            this.tbNickname.Size = new System.Drawing.Size(122, 20);
            this.tbNickname.TabIndex = 7;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btCancel.Location = new System.Drawing.Point(68, 62);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(60, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // LocalUsernameInput
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(134, 94);
            this.ControlBox = false;
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.tbNickname);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LocalUsernameInput";
            this.Text = "Ваші дані";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNickname;
        private System.Windows.Forms.Button btCancel;
    }
}