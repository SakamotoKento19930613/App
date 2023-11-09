
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common.Message;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Service.AdminUsers;
using VisitorTrackSystem.src.Service.Auth;

namespace VisitorTrackSystem.src.Views.AdminUsers
{
    public partial class AdminUserDetailView : Form
    {
        public AdminUserDetailView(int id)
        {
            InitializeComponent();
            /**
             * 初期設定
             * コントロールボックスの［閉じる］ボタンの無効化
             * InactivityDetected イベントをハンドル
             * フォームの初期表示
             **/
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
            AppUserActivityDetector.UserActivityDetector.InactivityDetected += OnInactivityDetected;
            InitialAdminUser(id);
        }

        //更新ボタン押下
        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            //入力値の取得
            string userId = TxtUserId.Text;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;
            AdminUserService adminUserService = new AdminUserService();
            Boolean errorResult = adminUserService.IsUpdateErrorCheck(userId, email, password, confirmPassword, out string errorMessage);

            if (!errorResult)
            {
                // 規約違反あり
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
            } else
            {
                // 規約違反なし
                LblErrorMessage.Visible = false;
                LblErrorMessage.Text = string.Empty;
                // 更新処理
                Boolean upDateResult = adminUserService.UpdateFunction(userId, email, password, out errorMessage);
                if (!upDateResult)
                {
                    //更新失敗
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                }
                else
                {
                    //更新完了
                    //確認ダイアログを表示して一覧に戻るか、詳細画面のままか
                    DialogResult result = MessageBox.Show(MessageConst.UPDATE_DONE_MESSAGE,
                                       MessageConst.UPDATE_DONE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        AdminUserListView adminUserListView = new AdminUserListView();
                        adminUserListView.Show();
                        this.Close();
                    } else if (result == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        //キャンセルボタン押下
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //確認ダイアログを表示
            DialogResult result = MessageBox.Show(MessageConst.UPDATE_CANCEL_MESSAGE,
                MessageConst.UPDATE_CANCEL_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                AdminUserListView adminUserListView = new AdminUserListView();
                adminUserListView.Show();
                this.Close();
            }
            else
            {
                return;
            }
        }
        
        // 削除ボタン押下
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string userId = TxtUserId.Text;
            // 警告を表示する
            DialogResult result = MessageBox.Show(MessageConst.DELETE_CONFIM_MESSAGE,
                    MessageConst.DELETE_CONFIM_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // 削除処理
                AdminUserService adminUserService = new AdminUserService();
                Boolean deleteResult = (adminUserService.DeleteFunction(userId, out string errorMessage));
                 if (!deleteResult)
                {
                    // 削除失敗
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                }
                else
                {
                    //　削除成功
                    LblErrorMessage.Visible = false;
                    LblErrorMessage.Text = string.Empty;
                    MessageBox.Show(MessageConst.DELETE_DONE_MESSAGE,
                            MessageConst.DELETE_DONE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminUserListView adminUserListView = new AdminUserListView();
                    adminUserListView.Show();
                    this.Close();

                }
            }
            else if (result == System.Windows.Forms.DialogResult.No)
            {
                //何もしない
                return;
            }
        }

        //ログアウト
        private void LinkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthService authService = new AuthService();
            authService.Logout();
        }

        public void InitialAdminUser(int id)
        {
            AdminUserService adminUserService = new AdminUserService();
            AdminUser adminUser = adminUserService.GetAdminUser(id);
            //　ユーザ情報をセット
            string accountStatus;
            string loginStatus;
            if (adminUser.AccountLock)
            {
                accountStatus = MessageConst.ACCOUNT_LOCK_STATUS;
            }
            else
            {
                accountStatus = MessageConst.ACCOUNT_UNLOCK_STATUS;
            }
            if (adminUser.LoginFlag)
            {
                loginStatus = MessageConst.ACCOUNT_LOGIN_STATUS;
            }else
            {
                loginStatus = MessageConst.ACCOUNT_LOGOUT_STATUS;
            }

            TxtUserId.Text = adminUser.UserId;
            TxtEmail.Text = adminUser.Email;
            LblAccountStatusVal.Text = accountStatus;
            LblLoginStatusVal.Text = loginStatus;
            LblCreatedDateVal.Text = adminUser.CreateDate.ToString();
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
