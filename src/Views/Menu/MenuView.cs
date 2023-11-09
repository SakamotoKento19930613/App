using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisitorTrackSystem.src.Service.Auth;
using VisitorTrackSystem.src.Views.AdminUsers;
using VisitorTrackSystem.src.Views.Worshipers;



namespace VisitorTrackSystem.src.Views.Menu
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
            /**
             * 初期設定
             * コントロールボックスの［閉じる］ボタンの無効化
             * InactivityDetected イベントをハンドル
             **/
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
            AppUserActivityDetector.UserActivityDetector.InactivityDetected += OnInactivityDetected;
        }

        //管理者管理ボタン
        private void BtnAdminUserList_Click(object sender, EventArgs e)
        {
            AdminUserListView adminUserListView = new AdminUserListView();
            adminUserListView.Show();
            this.Close();
        }

        //参拝客管理ボタン
        private void BtnWorshipList_Click(object sender, EventArgs e)
        {
            WorshiperListView worshiperListView = new WorshiperListView();
            worshiperListView.Show();
            this.Close();
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
