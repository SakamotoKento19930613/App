namespace VisitorTrackSystem.src.Views.AdminUsers
{
    partial class AddAdminUserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAdminUserView));
            this.GroupAdminData = new System.Windows.Forms.GroupBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblConfirmPassword = new System.Windows.Forms.Label();
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblUserId = new System.Windows.Forms.Label();
            this.TxtUserID = new System.Windows.Forms.TextBox();
            this.LblErrorMessage = new System.Windows.Forms.Label();
            this.BtnAddAdminUser = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LinkLogout = new System.Windows.Forms.LinkLabel();
            this.GroupAdminData.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupAdminData
            // 
            this.GroupAdminData.Controls.Add(this.TxtEmail);
            this.GroupAdminData.Controls.Add(this.LblEmail);
            this.GroupAdminData.Controls.Add(this.LblConfirmPassword);
            this.GroupAdminData.Controls.Add(this.TxtConfirmPassword);
            this.GroupAdminData.Controls.Add(this.TxtPassword);
            this.GroupAdminData.Controls.Add(this.LblPassword);
            this.GroupAdminData.Controls.Add(this.LblUserId);
            this.GroupAdminData.Controls.Add(this.TxtUserID);
            this.GroupAdminData.Location = new System.Drawing.Point(39, 61);
            this.GroupAdminData.Name = "GroupAdminData";
            this.GroupAdminData.Size = new System.Drawing.Size(462, 388);
            this.GroupAdminData.TabIndex = 0;
            this.GroupAdminData.TabStop = false;
            this.GroupAdminData.Text = "管理者情報";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(28, 156);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(256, 25);
            this.TxtEmail.TabIndex = 1;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(25, 125);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(92, 18);
            this.LblEmail.TabIndex = 6;
            this.LblEmail.Text = "メールアドレス";
            // 
            // LblConfirmPassword
            // 
            this.LblConfirmPassword.AutoSize = true;
            this.LblConfirmPassword.Location = new System.Drawing.Point(25, 289);
            this.LblConfirmPassword.Name = "LblConfirmPassword";
            this.LblConfirmPassword.Size = new System.Drawing.Size(92, 18);
            this.LblConfirmPassword.TabIndex = 5;
            this.LblConfirmPassword.Text = "確認パスワード";
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.Location = new System.Drawing.Point(26, 320);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(262, 25);
            this.TxtConfirmPassword.TabIndex = 3;
            this.TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(26, 248);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(262, 25);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(25, 216);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(68, 18);
            this.LblPassword.TabIndex = 2;
            this.LblPassword.Text = "パスワード";
            // 
            // LblUserId
            // 
            this.LblUserId.AutoSize = true;
            this.LblUserId.Location = new System.Drawing.Point(25, 45);
            this.LblUserId.Name = "LblUserId";
            this.LblUserId.Size = new System.Drawing.Size(70, 18);
            this.LblUserId.TabIndex = 1;
            this.LblUserId.Text = "ユーザーID";
            // 
            // TxtUserID
            // 
            this.TxtUserID.Location = new System.Drawing.Point(28, 76);
            this.TxtUserID.Name = "TxtUserID";
            this.TxtUserID.Size = new System.Drawing.Size(150, 25);
            this.TxtUserID.TabIndex = 0;
            // 
            // LblErrorMessage
            // 
            this.LblErrorMessage.AutoSize = true;
            this.LblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.LblErrorMessage.Location = new System.Drawing.Point(52, 22);
            this.LblErrorMessage.Name = "LblErrorMessage";
            this.LblErrorMessage.Size = new System.Drawing.Size(104, 18);
            this.LblErrorMessage.TabIndex = 1;
            this.LblErrorMessage.Text = "ERROEMESSAGE";
            this.LblErrorMessage.Visible = false;
            // 
            // BtnAddAdminUser
            // 
            this.BtnAddAdminUser.Location = new System.Drawing.Point(562, 264);
            this.BtnAddAdminUser.Name = "BtnAddAdminUser";
            this.BtnAddAdminUser.Size = new System.Drawing.Size(164, 70);
            this.BtnAddAdminUser.TabIndex = 4;
            this.BtnAddAdminUser.Text = "登録";
            this.BtnAddAdminUser.UseVisualStyleBackColor = true;
            this.BtnAddAdminUser.Click += new System.EventHandler(this.BtnAddAdminUser_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(562, 379);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(164, 70);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LinkLogout
            // 
            this.LinkLogout.AutoSize = true;
            this.LinkLogout.Location = new System.Drawing.Point(731, 22);
            this.LinkLogout.Name = "LinkLogout";
            this.LinkLogout.Size = new System.Drawing.Size(68, 18);
            this.LinkLogout.TabIndex = 6;
            this.LinkLogout.TabStop = true;
            this.LinkLogout.Text = "ログアウト";
            this.LinkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLogout_LinkClicked);
            // 
            // AddAdminUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(832, 489);
            this.Controls.Add(this.LinkLogout);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAddAdminUser);
            this.Controls.Add(this.LblErrorMessage);
            this.Controls.Add(this.GroupAdminData);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddAdminUserView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理者新規登録";
            this.GroupAdminData.ResumeLayout(false);
            this.GroupAdminData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupAdminData;
        private System.Windows.Forms.TextBox TxtUserID;
        private System.Windows.Forms.Label LblUserId;
        private System.Windows.Forms.Label LblConfirmPassword;
        private System.Windows.Forms.TextBox TxtConfirmPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblErrorMessage;
        private System.Windows.Forms.Button BtnAddAdminUser;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.LinkLabel LinkLogout;
    }
}