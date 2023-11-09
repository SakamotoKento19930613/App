using System;
using System.Windows.Forms;
using VisitorTrackSystem.src.Service.AdminUsers;
using VisitorTrackSystem.src.Service.Auth;

namespace VisitorTrackSystem.src.Views.Login
{
    public partial class EmailSendView : Form
    {
        public EmailSendView()
        {
            InitializeComponent();
        }

        //送信ボタン
        private void BtnAuthCode_Click(object sender, EventArgs e)
        {
            string userId = TxtUserId.Text;
            string email = TxtEmail.Text;

            //入力値チェック
            AuthService authService = new AuthService();
            Boolean errorResult = authService.IsAuthCodeSendCheck(userId, email, out string errorMessage);
            if (!errorResult)
            {
                //違反あり
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
            }
            else
            {
                //違反なし
                string authCode = AuthService.GenerateAuthCode(); // 認証コードを生成
                // メール送信
                Boolean sendResult = authService.SendAuthCode(userId, email, authCode, out errorMessage);
                if (!sendResult)
                {
                    //送信失敗
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                }
                else
                {
                    //送信成功
                    AuthCodeView authCodeView = new AuthCodeView(userId, authCode); //認証コード入力画面表示
                    authCodeView.Show();
                    this.Close();
                }
            }
        }
    }
}
