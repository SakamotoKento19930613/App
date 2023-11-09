namespace VisitorTrackSystem.src.Views.Login
{
    partial class EmailSendView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailSendView));
            this.LblErrorMessage = new System.Windows.Forms.Label();
            this.LblUserId = new System.Windows.Forms.Label();
            this.TxtUserId = new System.Windows.Forms.TextBox();
            this.BtnAuthCode = new System.Windows.Forms.Button();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblErrorMessage
            // 
            this.LblErrorMessage.AutoSize = true;
            this.LblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.LblErrorMessage.Location = new System.Drawing.Point(63, 36);
            this.LblErrorMessage.Name = "LblErrorMessage";
            this.LblErrorMessage.Size = new System.Drawing.Size(105, 18);
            this.LblErrorMessage.TabIndex = 4;
            this.LblErrorMessage.Text = "ERRORMESSAGE";
            this.LblErrorMessage.Visible = false;
            // 
            // LblUserId
            // 
            this.LblUserId.AutoSize = true;
            this.LblUserId.Location = new System.Drawing.Point(117, 114);
            this.LblUserId.Name = "LblUserId";
            this.LblUserId.Size = new System.Drawing.Size(70, 18);
            this.LblUserId.TabIndex = 6;
            this.LblUserId.Text = "ユーザーID";
            // 
            // TxtUserId
            // 
            this.TxtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserId.Location = new System.Drawing.Point(215, 112);
            this.TxtUserId.Name = "TxtUserId";
            this.TxtUserId.Size = new System.Drawing.Size(236, 25);
            this.TxtUserId.TabIndex = 5;
            // 
            // BtnAuthCode
            // 
            this.BtnAuthCode.Location = new System.Drawing.Point(273, 230);
            this.BtnAuthCode.Name = "BtnAuthCode";
            this.BtnAuthCode.Size = new System.Drawing.Size(128, 34);
            this.BtnAuthCode.TabIndex = 7;
            this.BtnAuthCode.Text = "認証コード送信";
            this.BtnAuthCode.UseVisualStyleBackColor = true;
            this.BtnAuthCode.Click += new System.EventHandler(this.BtnAuthCode_Click);
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(117, 162);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(92, 18);
            this.LblEmail.TabIndex = 9;
            this.LblEmail.Text = "メールアドレス";
            // 
            // TxtEmail
            // 
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Location = new System.Drawing.Point(215, 160);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(236, 25);
            this.TxtEmail.TabIndex = 8;
            // 
            // EmailSendView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 376);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.BtnAuthCode);
            this.Controls.Add(this.LblUserId);
            this.Controls.Add(this.TxtUserId);
            this.Controls.Add(this.LblErrorMessage);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EmailSendView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "認証コード送信";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblErrorMessage;
        private System.Windows.Forms.Label LblUserId;
        private System.Windows.Forms.TextBox TxtUserId;
        private System.Windows.Forms.Button BtnAuthCode;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtEmail;
    }
}