using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisitorTrackSystem.src.Service.Auth;
using VisitorTrackSystem.src.Views.Login;
using VisitorTrackSystem.src.Views.Menu;

namespace VisitorTrackSystem
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            lblErrorMessage.Visible = false;
        }

        //　ログインボタン押下時のイベント
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // 入力値を取得
            string userId = txtAdminUserId.Text;
            string password = txtAdminUserPassword.Text;

            AuthService authService = new AuthService();

            //  return true : 規則違反あり  false : 規則違反なし
            Boolean errorResult =  authService.IsErrorCheck(userId, password, out  string errorMessage);
            if (!errorResult)
            {
                //　規約違反あり
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = errorMessage;
            } 
            else
            {
                //　規約違反なし
                lblErrorMessage.Visible = false;

                //  return true : ログイン成功  false : ログイン失敗
                Boolean loginResult = authService.Login(userId, password, out errorMessage);
                if (loginResult)
                {
                    //　ログイン成功
                    MenuView menuView = new MenuView();
                    menuView.Show();
                    BtnLogin.Enabled = false;
                }
                else
                {
                    //　ログイン失敗
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = errorMessage;
                }
            }
        }
        //パスワードを忘れたはこちら
        private void LinkPasswordReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EmailSendView emailSendView = new EmailSendView();
            emailSendView.Show();
        }
    }
}
