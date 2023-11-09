namespace VisitorTrackSystem.src.Views.Login
{
    partial class AuthCodeView
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
            this.LblErrorMessage = new System.Windows.Forms.Label();
            this.TxtAuthCode = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblErrorMessage
            // 
            this.LblErrorMessage.AutoSize = true;
            this.LblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.LblErrorMessage.Location = new System.Drawing.Point(95, 33);
            this.LblErrorMessage.Name = "LblErrorMessage";
            this.LblErrorMessage.Size = new System.Drawing.Size(105, 18);
            this.LblErrorMessage.TabIndex = 5;
            this.LblErrorMessage.Text = "ERRORMESSAGE";
            this.LblErrorMessage.Visible = false;
            // 
            // TxtAuthCode
            // 
            this.TxtAuthCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAuthCode.Location = new System.Drawing.Point(98, 66);
            this.TxtAuthCode.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAuthCode.Name = "TxtAuthCode";
            this.TxtAuthCode.Size = new System.Drawing.Size(151, 25);
            this.TxtAuthCode.TabIndex = 3;
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(132, 115);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(87, 45);
            this.BtnSend.TabIndex = 6;
            this.BtnSend.Text = "送信";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // AuthCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(359, 193);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.LblErrorMessage);
            this.Controls.Add(this.TxtAuthCode);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AuthCodeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "認証コード入力";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtAuthCode;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Label LblErrorMessage;
    }
}