namespace VisitorTrackSystem
{
    partial class LoginView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblAdminUserPassword = new System.Windows.Forms.Label();
            this.lblAdminUserId = new System.Windows.Forms.Label();
            this.LinkPasswordReset = new System.Windows.Forms.LinkLabel();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.txtAdminUserPassword = new System.Windows.Forms.TextBox();
            this.txtAdminUserId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(109, 40);
            this.lblErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(112, 18);
            this.lblErrorMessage.TabIndex = 13;
            this.lblErrorMessage.Text = "ERRORMESSEAGE";
            this.lblErrorMessage.Visible = false;
            // 
            // lblAdminUserPassword
            // 
            this.lblAdminUserPassword.AutoSize = true;
            this.lblAdminUserPassword.Location = new System.Drawing.Point(109, 168);
            this.lblAdminUserPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminUserPassword.Name = "lblAdminUserPassword";
            this.lblAdminUserPassword.Size = new System.Drawing.Size(68, 18);
            this.lblAdminUserPassword.TabIndex = 12;
            this.lblAdminUserPassword.Text = "パスワード";
            // 
            // lblAdminUserId
            // 
            this.lblAdminUserId.AutoSize = true;
            this.lblAdminUserId.Location = new System.Drawing.Point(109, 130);
            this.lblAdminUserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminUserId.Name = "lblAdminUserId";
            this.lblAdminUserId.Size = new System.Drawing.Size(70, 18);
            this.lblAdminUserId.TabIndex = 11;
            this.lblAdminUserId.Text = "ユーザーID";
            // 
            // LinkPasswordReset
            // 
            this.LinkPasswordReset.AutoSize = true;
            this.LinkPasswordReset.Location = new System.Drawing.Point(405, 330);
            this.LinkPasswordReset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkPasswordReset.Name = "LinkPasswordReset";
            this.LinkPasswordReset.Size = new System.Drawing.Size(176, 18);
            this.LinkPasswordReset.TabIndex = 10;
            this.LinkPasswordReset.TabStop = true;
            this.LinkPasswordReset.Text = "パスワードを忘れた方はこちら";
            this.LinkPasswordReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkPasswordReset_LinkClicked);
            // 
            // BtnLogin
            // 
            this.BtnLogin.AutoSize = true;
            this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogin.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnLogin.Location = new System.Drawing.Point(233, 211);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(150, 45);
            this.BtnLogin.TabIndex = 9;
            this.BtnLogin.Text = "LOGIN";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // txtAdminUserPassword
            // 
            this.txtAdminUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminUserPassword.Location = new System.Drawing.Point(197, 165);
            this.txtAdminUserPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdminUserPassword.Name = "txtAdminUserPassword";
            this.txtAdminUserPassword.Size = new System.Drawing.Size(208, 25);
            this.txtAdminUserPassword.TabIndex = 8;
            this.txtAdminUserPassword.UseSystemPasswordChar = true;
            // 
            // txtAdminUserId
            // 
            this.txtAdminUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminUserId.Location = new System.Drawing.Point(197, 120);
            this.txtAdminUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdminUserId.Name = "txtAdminUserId";
            this.txtAdminUserId.Size = new System.Drawing.Size(208, 25);
            this.txtAdminUserId.TabIndex = 7;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 371);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblAdminUserPassword);
            this.Controls.Add(this.lblAdminUserId);
            this.Controls.Add(this.LinkPasswordReset);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.txtAdminUserPassword);
            this.Controls.Add(this.txtAdminUserId);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblAdminUserPassword;
        private System.Windows.Forms.Label lblAdminUserId;
        private System.Windows.Forms.LinkLabel LinkPasswordReset;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.TextBox txtAdminUserPassword;
        private System.Windows.Forms.TextBox txtAdminUserId;
    }
}

