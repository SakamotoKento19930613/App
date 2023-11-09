using System;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common.Message;
using VisitorTrackSystem.src.Service.Auth;

namespace VisitorTrackSystem.src.Views.Login
{
    public partial class PasswordUpdateView : Form
    {
        private readonly string userId; //　userId を格納するフィールド
        public PasswordUpdateView(string userId)
        {
            InitializeComponent();
            this.userId = userId; // コンストラクタで userId を設定
        }

        //更新ボタン
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //入力値取得
            string newPassword = TxtNewPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;

            AuthService authService = new AuthService();
            Boolean errorResult = authService.ChangedPasswordCheck(newPassword, confirmPassword, out string errorMessage);

            if (!errorResult)
            {
                //規約違反あり
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;

            } else
            {
                //規約違反なし
                //パスワード変更
                Boolean updateResult = authService.UpdatePasswordFunction(userId, newPassword, out errorMessage);
                if (!updateResult)
                {
                    //変更失敗
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                }
                //変更成功
                LblErrorMessage.Visible = false;
                LblErrorMessage.Text = string.Empty;
                // パスワード変更後の処理を実行
                MessageBox.Show(MessageConst.PASSWORD_RESET_DONE_MESSAGE,
                    MessageConst.PASSWORD_RESET_DONE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginView loginView = new LoginView();
                loginView.Show();
                this.Close();
            }
        }
    }
}
