namespace VisitorTrackSystem.src.Views.Menu
{
    partial class MenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.BtnAdminUserList = new System.Windows.Forms.Button();
            this.LinkLogout = new System.Windows.Forms.LinkLabel();
            this.BtnWorshipList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAdminUserList
            // 
            this.BtnAdminUserList.BackColor = System.Drawing.Color.Transparent;
            this.BtnAdminUserList.Location = new System.Drawing.Point(87, 147);
            this.BtnAdminUserList.Name = "BtnAdminUserList";
            this.BtnAdminUserList.Size = new System.Drawing.Size(225, 89);
            this.BtnAdminUserList.TabIndex = 0;
            this.BtnAdminUserList.Text = "管理者管理";
            this.BtnAdminUserList.UseVisualStyleBackColor = false;
            this.BtnAdminUserList.Click += new System.EventHandler(this.BtnAdminUserList_Click);
            // 
            // LinkLogout
            // 
            this.LinkLogout.AutoSize = true;
            this.LinkLogout.Location = new System.Drawing.Point(807, 26);
            this.LinkLogout.Name = "LinkLogout";
            this.LinkLogout.Size = new System.Drawing.Size(68, 18);
            this.LinkLogout.TabIndex = 1;
            this.LinkLogout.TabStop = true;
            this.LinkLogout.Text = "ログアウト";
            this.LinkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLogout_LinkClicked);
            // 
            // BtnWorshipList
            // 
            this.BtnWorshipList.BackColor = System.Drawing.Color.Transparent;
            this.BtnWorshipList.Location = new System.Drawing.Point(87, 302);
            this.BtnWorshipList.Name = "BtnWorshipList";
            this.BtnWorshipList.Size = new System.Drawing.Size(225, 89);
            this.BtnWorshipList.TabIndex = 2;
            this.BtnWorshipList.Text = "参拝客管理";
            this.BtnWorshipList.UseVisualStyleBackColor = false;
            this.BtnWorshipList.Click += new System.EventHandler(this.BtnWorshipList_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 675);
            this.Controls.Add(this.BtnWorshipList);
            this.Controls.Add(this.LinkLogout);
            this.Controls.Add(this.BtnAdminUserList);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "メニュー";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAdminUserList;
        private System.Windows.Forms.LinkLabel LinkLogout;
        private System.Windows.Forms.Button BtnWorshipList;
    }
}