using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Common.Message;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VisitorTrackSystem.src.Views.Login
{
    public partial class AuthCodeView : Form
    {
        private readonly string  authCode; // authCode を格納するフィールド
        private readonly string userId; //　userId を格納するフィールド
        public AuthCodeView(string userId, string authCode)
        {
            InitializeComponent();
            this.authCode = authCode; // コンストラクタで authCode を設定
            this.userId = userId; // コンストラクタで email を設定
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            //入力値を取得
            string authCodeVal = TxtAuthCode.Text;

            if (!authCode.Equals(authCodeVal))
            {
                //一致してない
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = ErrorMessageConst.AOUTH_CODE_UNMUCH;
                return;
            } else
            {
                LblErrorMessage.Visible = false;
                LblErrorMessage.Text = string.Empty;
                PasswordUpdateView passwordUpdateView = new PasswordUpdateView(userId);
                passwordUpdateView.Show();
                this.Close();
            }
        }
    }
}
