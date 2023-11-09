namespace VisitorTrackSystem.src.Views.Worshipers
{
    partial class WorshiperListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorshiperListView));
            this.BtnAddWorshipView = new System.Windows.Forms.Button();
            this.BtnMenuView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAddWorshipView
            // 
            this.BtnAddWorshipView.Location = new System.Drawing.Point(600, 102);
            this.BtnAddWorshipView.Name = "BtnAddWorshipView";
            this.BtnAddWorshipView.Size = new System.Drawing.Size(146, 51);
            this.BtnAddWorshipView.TabIndex = 0;
            this.BtnAddWorshipView.Text = "参拝客登録";
            this.BtnAddWorshipView.UseVisualStyleBackColor = true;
            this.BtnAddWorshipView.Click += new System.EventHandler(this.BtnAddWorshipView_Click);
            // 
            // BtnMenuView
            // 
            this.BtnMenuView.Location = new System.Drawing.Point(600, 206);
            this.BtnMenuView.Name = "BtnMenuView";
            this.BtnMenuView.Size = new System.Drawing.Size(146, 51);
            this.BtnMenuView.TabIndex = 5;
            this.BtnMenuView.Text = "メニューへ戻る";
            this.BtnMenuView.UseVisualStyleBackColor = true;
            this.BtnMenuView.Click += new System.EventHandler(this.BtnMenuView_Click);
            // 
            // WorshiperListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 681);
            this.Controls.Add(this.BtnMenuView);
            this.Controls.Add(this.BtnAddWorshipView);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WorshiperListView";
            this.Text = "参拝客一覧";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAddWorshipView;
        private System.Windows.Forms.Button BtnMenuView;
    }
}