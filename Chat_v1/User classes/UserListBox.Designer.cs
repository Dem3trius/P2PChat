namespace Chat_v1
{
    partial class UserListBox
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
                _titleFont.Dispose();
                _detailsFont.Dispose();
                _fmt.Dispose();
            }
       
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserListBox
            // 
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.FormattingEnabled = true;
            this.ItemHeight = 40;
            this.ResumeLayout(false);

        }

        #endregion
    }
}
