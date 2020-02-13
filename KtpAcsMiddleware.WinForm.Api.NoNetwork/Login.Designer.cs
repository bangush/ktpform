namespace KtpAcsMiddleware.WinForm.Api
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menu_application = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_application_IsManualAddInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_application_journal = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_application_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.pic_ts = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pl_ts = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.menu_application.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ts)).BeginInit();
            this.pl_ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(187, 145);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 36);
            this.ExitButton.TabIndex = 20;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(268, 145);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 36);
            this.LoginBtn.TabIndex = 17;
            this.LoginBtn.Text = "登录";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "密码";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(162, 103);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(254, 21);
            this.PasswordTxt.TabIndex = 16;
            this.PasswordTxt.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "用户名";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(162, 65);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(254, 21);
            this.UserNameTxt.TabIndex = 15;
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // menu_application
            // 
            this.menu_application.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_application_IsManualAddInfo,
            this.menu_application_journal,
            this.menu_application_Exit});
            this.menu_application.Name = "menu_application";
            this.menu_application.Size = new System.Drawing.Size(149, 70);
            // 
            // menu_application_IsManualAddInfo
            // 
            this.menu_application_IsManualAddInfo.CheckOnClick = true;
            this.menu_application_IsManualAddInfo.Name = "menu_application_IsManualAddInfo";
            this.menu_application_IsManualAddInfo.Size = new System.Drawing.Size(148, 22);
            this.menu_application_IsManualAddInfo.Text = "是否手动编辑";
            this.menu_application_IsManualAddInfo.CheckStateChanged += new System.EventHandler(this.menu_application_IsManualAddInfo_CheckStateChanged);
            // 
            // menu_application_journal
            // 
            this.menu_application_journal.Name = "menu_application_journal";
            this.menu_application_journal.Size = new System.Drawing.Size(148, 22);
            this.menu_application_journal.Text = "日志";
            this.menu_application_journal.Click += new System.EventHandler(this.menu_application_journal_Click);
            // 
            // menu_application_Exit
            // 
            this.menu_application_Exit.Name = "menu_application_Exit";
            this.menu_application_Exit.Size = new System.Drawing.Size(148, 22);
            this.menu_application_Exit.Text = "退出";
            this.menu_application_Exit.Click += new System.EventHandler(this.menu_application_Exit_Click);
            // 
            // pic_ts
            // 
            this.pic_ts.Image = global::KtpAcsMiddleware.WinForm.Api.NoNetwork.Properties.Resources.wl;
            this.pic_ts.Location = new System.Drawing.Point(12, 7);
            this.pic_ts.Name = "pic_ts";
            this.pic_ts.Size = new System.Drawing.Size(15, 15);
            this.pic_ts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ts.TabIndex = 21;
            this.pic_ts.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(33, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "无网络状态";
            // 
            // pl_ts
            // 
            this.pl_ts.Controls.Add(this.label3);
            this.pl_ts.Controls.Add(this.pic_ts);
            this.pl_ts.Location = new System.Drawing.Point(436, 162);
            this.pl_ts.Name = "pl_ts";
            this.pl_ts.Size = new System.Drawing.Size(105, 28);
            this.pl_ts.TabIndex = 23;
            this.pl_ts.Visible = false;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 192);
            this.Controls.Add(this.pl_ts);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "用户登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.menu_application.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ts)).EndInit();
            this.pl_ts.ResumeLayout(false);
            this.pl_ts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserNameTxt;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private System.Windows.Forms.ContextMenuStrip menu_application;
        private System.Windows.Forms.ToolStripMenuItem menu_application_IsManualAddInfo;
        private System.Windows.Forms.ToolStripMenuItem menu_application_journal;
        private System.Windows.Forms.ToolStripMenuItem menu_application_Exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic_ts;
        private System.Windows.Forms.Panel pl_ts;
    }
}