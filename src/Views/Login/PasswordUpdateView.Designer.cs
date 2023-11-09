namespace VisitorTrackSystem.src.Views.Login
{
    partial class PasswordUpdateView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordUpdateView));
            this.LblErrorMessage = new System.Windows.Forms.Label();
            this.LblConfirmPassword = new System.Windows.Forms.Label();
            this.LblNewPassword = new System.Windows.Forms.Label();
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.TxtNewPassword = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblErrorMessage
            // 
            this.LblErrorMessage.AutoSize = true;
            this.LblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.LblErrorMessage.Location = new System.Drawing.Point(81, 45);
            this.LblErrorMessage.Name = "LblErrorMessage";
            this.LblErrorMessage.Size = new System.Drawing.Size(105, 18);
            this.LblErrorMessage.TabIndex = 6;
            this.LblErrorMessage.Text = "ERRORMESSAGE";
            this.LblErrorMessage.Visible = false;
            // 
            // LblConfirmPassword
            // 
            this.LblConfirmPassword.AutoSize = true;
            this.LblConfirmPassword.Location = new System.Drawing.Point(93, 159);
            this.LblConfirmPassword.Name = "LblConfirmPassword";
            this.LblConfirmPassword.Size = new System.Drawing.Size(92, 18);
            this.LblConfirmPassword.TabIndex = 11;
            this.LblConfirmPassword.Text = "確認パスワード";
            // 
            // LblNewPassword
            // 
            this.LblNewPassword.AutoSize = true;
            this.LblNewPassword.Location = new System.Drawing.Point(81, 115);
            this.LblNewPassword.Name = "LblNewPassword";
            this.LblNewPassword.Size = new System.Drawing.Size(104, 18);
            this.LblNewPassword.TabIndex = 10;
            this.LblNewPassword.Text = "新しいパスワード";
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConfirmPassword.Location = new System.Drawing.Point(201, 157);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(171, 25);
            this.TxtConfirmPassword.TabIndex = 9;
            this.TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // TxtNewPassword
            // 
            this.TxtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNewPassword.Location = new System.Drawing.Point(201, 113);
            this.TxtNewPassword.Name = "TxtNewPassword";
            this.TxtNewPassword.Size = new System.Drawing.Size(171, 25);
            this.TxtNewPassword.TabIndex = 8;
            this.TxtNewPassword.UseSystemPasswordChar = true;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(228, 204);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(103, 43);
            this.BtnUpdate.TabIndex = 7;
            this.BtnUpdate.Text = "変更";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // PasswordUpdateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 318);
            this.Controls.Add(this.LblConfirmPassword);
            this.Controls.Add(this.LblNewPassword);
            this.Controls.Add(this.TxtConfirmPassword);
            this.Controls.Add(this.TxtNewPassword);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.LblErrorMessage);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PasswordUpdateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "パスワード変更";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblErrorMessage;
        private System.Windows.Forms.Label LblConfirmPassword;
        private System.Windows.Forms.Label LblNewPassword;
        private System.Windows.Forms.TextBox TxtConfirmPassword;
        private System.Windows.Forms.TextBox TxtNewPassword;
        private System.Windows.Forms.Button BtnUpdate;
    }
}