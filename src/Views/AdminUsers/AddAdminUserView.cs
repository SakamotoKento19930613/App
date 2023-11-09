using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common.Message;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Service.AdminUsers;
using VisitorTrackSystem.src.Service.Auth;

namespace VisitorTrackSystem.src.Views.AdminUsers
{
    public partial class AddAdminUserView : Form
    {
        public AddAdminUserView()
        {
            InitializeComponent();
            /**
             * 初期設定
             * コントロールボックスの［閉じる］ボタンの無効化
             * InactivityDetected イベントをハンドル
             **/
            AppUserActivityDetector.UserActivityDetector.InactivityDetected += OnInactivityDetected;
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
        }

        //登録ボタン
        private void BtnAddAdminUser_Click(object sender, EventArgs e)
        {
            //入力値を取得
            string userId = TxtUserID.Text;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;

            AdminUserService adminUserService = new AdminUserService();
            //  return true : 規則違反あり  false : 規則違反なし
            Boolean errorResult = adminUserService.IsErrorCheck(userId, email, password, confirmPassword, out string errorMessage);
            if (!errorResult)
            {
                // 規約違反あり
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
            }
            else
            {
                //規約違反なし
                LblErrorMessage.Visible = false;
                LblErrorMessage.Text = string.Empty;

                // 登録処理
                Boolean insertResult = adminUserService.InsertFunction(userId, email, password, out errorMessage);
                if (!insertResult)
                {
                    //登録失敗
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                } else
                {
                    //登録成功
                    LblErrorMessage.Visible = false;
                    LblErrorMessage.Text = string.Empty;

                    //完了のダイアログを表示して一覧画面を呼んで、登録画面を閉じる
                    MessageBox.Show(MessageConst.ADD_DONE_MESSAGE, 
                        MessageConst.ADD_DONE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminUserListView adminUserListView = new AdminUserListView();
                    adminUserListView.Show();
                    this.Close();
                }
            }
        }
        //キャンセルボタン
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //確認ダイアログを表示
            DialogResult result = MessageBox.Show(MessageConst.ADD_CANCEL_MESSAGE, 
                MessageConst.ADD_CANCEL_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                AdminUserListView adminUserListView = new AdminUserListView();
                adminUserListView.Show();
                this.Close();
            } else
            {
                return;
            }
        }

        //ログアウト
        private void LinkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthService authService = new AuthService();
            authService.Logout();
        }
        private void OnInactivityDetected(object sender, EventArgs e)
        {
            // 無操作の検出時に実行する処理をここに記述
            MessageBox.Show("一定時間無操作が続いたのでログアウトします。");
            AuthService authService = new AuthService();
            authService.Logout();
        }

        // Win32 APIのインポート
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);
        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        // ［閉じる］ボタンを無効化するための値
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;
    }
}
