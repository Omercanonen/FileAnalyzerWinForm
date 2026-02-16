namespace FileAnalyzerWinForm.View
{
    partial class MainForm
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
            this.panelNavbar = new System.Windows.Forms.Panel();
            this.labelLogOut = new System.Windows.Forms.Label();
            this.buttonAddAccount = new System.Windows.Forms.Button();
            this.buttonHomePage = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelNavbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavbar
            // 
            this.panelNavbar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelNavbar.Controls.Add(this.labelLogOut);
            this.panelNavbar.Controls.Add(this.buttonAddAccount);
            this.panelNavbar.Controls.Add(this.buttonHomePage);
            this.panelNavbar.Controls.Add(this.labelUser);
            this.panelNavbar.Location = new System.Drawing.Point(12, 12);
            this.panelNavbar.Name = "panelNavbar";
            this.panelNavbar.Size = new System.Drawing.Size(200, 426);
            this.panelNavbar.TabIndex = 0;
            // 
            // labelLogOut
            // 
            this.labelLogOut.AutoSize = true;
            this.labelLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelLogOut.Location = new System.Drawing.Point(3, 402);
            this.labelLogOut.Name = "labelLogOut";
            this.labelLogOut.Size = new System.Drawing.Size(60, 20);
            this.labelLogOut.TabIndex = 3;
            this.labelLogOut.Text = "Logout";
            this.labelLogOut.Click += new System.EventHandler(this.labelLogOut_Click);
            // 
            // buttonAddAccount
            // 
            this.buttonAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonAddAccount.Location = new System.Drawing.Point(19, 136);
            this.buttonAddAccount.Name = "buttonAddAccount";
            this.buttonAddAccount.Size = new System.Drawing.Size(168, 51);
            this.buttonAddAccount.TabIndex = 2;
            this.buttonAddAccount.Text = "Add Account";
            this.buttonAddAccount.UseVisualStyleBackColor = true;
            this.buttonAddAccount.Click += new System.EventHandler(this.buttonAddAccount_Click);
            // 
            // buttonHomePage
            // 
            this.buttonHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.buttonHomePage.Location = new System.Drawing.Point(19, 79);
            this.buttonHomePage.Name = "buttonHomePage";
            this.buttonHomePage.Size = new System.Drawing.Size(168, 51);
            this.buttonHomePage.TabIndex = 1;
            this.buttonHomePage.Text = "Homepage";
            this.buttonHomePage.UseVisualStyleBackColor = true;
            this.buttonHomePage.Click += new System.EventHandler(this.buttonHomePage_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelUser.Location = new System.Drawing.Point(15, 12);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(60, 24);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "label1";
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(235, 12);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(553, 426);
            this.panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelNavbar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelNavbar.ResumeLayout(false);
            this.panelNavbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavbar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonHomePage;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonAddAccount;
        private System.Windows.Forms.Label labelLogOut;
    }
}