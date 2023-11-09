namespace VisitorTrackSystem.src.Views.AdminUsers
{
    partial class AdminUserListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUserListView));
            this.BtnAddAdminUserView = new System.Windows.Forms.Button();
            this.ListViewAdminUsers = new System.Windows.Forms.ListView();
            this.BtnUpdateAdminUserView = new System.Windows.Forms.Button();
            this.LblErrorMessage = new System.Windows.Forms.Label();
            this.BtnMenuView = new System.Windows.Forms.Button();
            this.LinkLogout = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // BtnAddAdminUserView
            // 
            this.BtnAddAdminUserView.Location = new System.Drawing.Point(650, 84);
            this.BtnAddAdminUserView.Name = "BtnAddAdminUserView";
            this.BtnAddAdminUserView.Size = new System.Drawing.Size(146, 51);
            this.BtnAddAdminUserView.TabIndex = 0;
            this.BtnAddAdminUserView.Text = "新規登録";
            this.BtnAddAdminUserView.UseVisualStyleBackColor = true;
            this.BtnAddAdminUserView.Click += new System.EventHandler(this.BtnAddAdminUserView_Click);
            // 
            // ListViewAdminUsers
            // 
            this.ListViewAdminUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewAdminUsers.CheckBoxes = true;
            this.ListViewAdminUsers.GridLines = true;
            this.ListViewAdminUsers.HideSelection = false;
            this.ListViewAdminUsers.HotTracking = true;
            this.ListViewAdminUsers.HoverSelection = true;
            this.ListViewAdminUsers.Location = new System.Drawing.Point(83, 84);
            this.ListViewAdminUsers.Name = "ListViewAdminUsers";
            this.ListViewAdminUsers.OwnerDraw = true;
            this.ListViewAdminUsers.Size = new System.Drawing.Size(470, 589);
            this.ListViewAdminUsers.TabIndex = 1;
            this.ListViewAdminUsers.UseCompatibleStateImageBehavior = false;
            // 
            // BtnUpdateAdminUserView
            // 
            this.BtnUpdateAdminUserView.Location = new System.Drawing.Point(650, 199);
            this.BtnUpdateAdminUserView.Name = "BtnUpdateAdminUserView";
            this.BtnUpdateAdminUserView.Size = new System.Drawing.Size(146, 51);
            this.BtnUpdateAdminUserView.TabIndex = 2;
            this.BtnUpdateAdminUserView.Text = "変更";
            this.BtnUpdateAdminUserView.UseVisualStyleBackColor = true;
            this.BtnUpdateAdminUserView.Click += new System.EventHandler(this.BtnUpdateAdminUserView_Click);
            // 
            // LblErrorMessage
            // 
            this.LblErrorMessage.AutoSize = true;
            this.LblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.LblErrorMessage.Location = new System.Drawing.Point(80, 24);
            this.LblErrorMessage.Name = "LblErrorMessage";
            this.LblErrorMessage.Size = new System.Drawing.Size(104, 18);
            this.LblErrorMessage.TabIndex = 3;
            this.LblErrorMessage.Text = "ERROEMESSAGE";
            this.LblErrorMessage.Visible = false;
            // 
            // BtnMenuView
            // 
            this.BtnMenuView.Location = new System.Drawing.Point(650, 310);
            this.BtnMenuView.Name = "BtnMenuView";
            this.BtnMenuView.Size = new System.Drawing.Size(146, 51);
            this.BtnMenuView.TabIndex = 4;
            this.BtnMenuView.Text = "メニューへ戻る";
            this.BtnMenuView.UseVisualStyleBackColor = true;
            this.BtnMenuView.Click += new System.EventHandler(this.BtnMenuView_Click);
            // 
            // LinkLogout
            // 
            this.LinkLogout.AutoSize = true;
            this.LinkLogout.Location = new System.Drawing.Point(824, 24);
            this.LinkLogout.Name = "LinkLogout";
            this.LinkLogout.Size = new System.Drawing.Size(68, 18);
            this.LinkLogout.TabIndex = 14;
            this.LinkLogout.TabStop = true;
            this.LinkLogout.Text = "ログアウト";
            this.LinkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLogout_LinkClicked);
            // 
            // AdminUserListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 736);
            this.Controls.Add(this.LinkLogout);
            this.Controls.Add(this.BtnMenuView);
            this.Controls.Add(this.LblErrorMessage);
            this.Controls.Add(this.BtnUpdateAdminUserView);
            this.Controls.Add(this.ListViewAdminUsers);
            this.Controls.Add(this.BtnAddAdminUserView);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminUserListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理者一覧";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAddAdminUserView;
        private System.Windows.Forms.ListView ListViewAdminUsers;
        private System.Windows.Forms.Button BtnUpdateAdminUserView;
        private System.Windows.Forms.Label LblErrorMessage;
        private System.Windows.Forms.Button BtnMenuView;
        private System.Windows.Forms.LinkLabel LinkLogout;
    }
}