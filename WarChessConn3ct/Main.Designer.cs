
namespace WarChessConn3ct
{
    partial class Main
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
            this.listUser = new System.Windows.Forms.ListBox();
            this.pathGame = new System.Windows.Forms.TextBox();
            this.chatRtb = new System.Windows.Forms.RichTextBox();
            this.contentRtb = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bgrWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // listUser
            // 
            this.listUser.FormattingEnabled = true;
            this.listUser.Location = new System.Drawing.Point(429, 35);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(153, 238);
            this.listUser.TabIndex = 0;
            // 
            // pathGame
            // 
            this.pathGame.Enabled = false;
            this.pathGame.Location = new System.Drawing.Point(429, 279);
            this.pathGame.Name = "pathGame";
            this.pathGame.Size = new System.Drawing.Size(112, 20);
            this.pathGame.TabIndex = 1;
            // 
            // chatRtb
            // 
            this.chatRtb.Location = new System.Drawing.Point(11, 35);
            this.chatRtb.Name = "chatRtb";
            this.chatRtb.Size = new System.Drawing.Size(411, 264);
            this.chatRtb.TabIndex = 2;
            this.chatRtb.Text = "";
            // 
            // contentRtb
            // 
            this.contentRtb.Location = new System.Drawing.Point(69, 305);
            this.contentRtb.Multiline = false;
            this.contentRtb.Name = "contentRtb";
            this.contentRtb.Size = new System.Drawing.Size(353, 51);
            this.contentRtb.TabIndex = 3;
            this.contentRtb.Text = "";
            this.contentRtb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contentRtb_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(11, 305);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(52, 51);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(429, 303);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(153, 53);
            this.btnLaunch.TabIndex = 5;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(547, 279);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(35, 20);
            this.btnBrowser.TabIndex = 6;
            this.btnBrowser.Text = "...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Users:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.contentRtb);
            this.Controls.Add(this.chatRtb);
            this.Controls.Add(this.pathGame);
            this.Controls.Add(this.listUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "War Chess Conn3ct";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listUser;
        private System.Windows.Forms.TextBox pathGame;
        private System.Windows.Forms.RichTextBox chatRtb;
        private System.Windows.Forms.RichTextBox contentRtb;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgrWorker;
    }
}

