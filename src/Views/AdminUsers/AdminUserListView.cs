using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Common.Message;
using VisitorTrackSystem.src.Service.AdminUsers;
using VisitorTrackSystem.src.Service.Auth;
using VisitorTrackSystem.src.Views.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VisitorTrackSystem.src.Views.AdminUsers
{
    public partial class AdminUserListView : Form
    {
        public AdminUserListView()
        {
            InitializeComponent();
            /**
             * 初期設定
             * コントロールボックスの［閉じる］ボタンの無効化
             * InactivityDetected イベントをハンドル
             * リストの初期設定
             **/
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
            AppUserActivityDetector.UserActivityDetector.InactivityDetected += OnInactivityDetected;
            InitializeListView();
            ListViewAdminUsers.OwnerDraw = true;
            ListViewAdminUsers.DrawColumnHeader += ListViewAdminUsers_DrawColumnHeader;
            ListViewAdminUsers.DrawSubItem += ListViewAdminUsers_DrawSubItem;
        }

        //　新規登録ボタン
        private void BtnAddAdminUserView_Click(object sender, EventArgs e)
        {
            AddAdminUserView addAdminUserView = new AddAdminUserView();
            addAdminUserView.Show();
            this.Close();
        }

        //　変更ボタン
        private void BtnUpdateAdminUserView_Click(object sender, EventArgs e)
        {
            if (ListViewAdminUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = ListViewAdminUsers.SelectedItems[0];
                if (selectedItem != null)
                {
                    // ユーザーIDを取得
                    if (int.TryParse(selectedItem.SubItems[3].Text, out int itemIndexId))
                    {
                        LblErrorMessage.Visible = false;
                        LblErrorMessage.Text = string.Empty;
                        
                        AdminUserDetailView adminUserDetailView = new AdminUserDetailView(itemIndexId);
                        adminUserDetailView.Show();
                        this.Close();
                    }
                    else
                    {
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = ErrorMessageConst.SELECTED_ADMIN_USER;
                    }
                }
            } else
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = ErrorMessageConst.SELECTED_ADMIN_USER;
            }
        }

        //　戻るボタン
        private void BtnMenuView_Click(object sender, EventArgs e)
        {
            MenuView menuView = new MenuView();
            menuView.Show();
            this.Close();
        }
        // ログアウト
        private void LinkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void OnInactivityDetected(object sender, EventArgs e)
        {
            // 無操作の検出時に実行する処理をここに記述
            MessageBox.Show("一定時間無操作が続いたのでログアウトします。");
            AuthService authService = new AuthService();
            authService.Logout();
        }

        public void InitializeListView()
        {
            //初期化
            ListViewAdminUsers.Clear();
            //リストの詳細表示
            ListViewAdminUsers.View = View.Details;
            //カラムの背景色を変更するために OwnerDraw プロパティを true 
            ListViewAdminUsers.OwnerDraw = true;
            //カラムの設定
            ListViewAdminUsers.Columns.Add("ユーザーID", 110);
            ListViewAdminUsers.Columns.Add("メールアドレス", 200);
            ListViewAdminUsers.Columns.Add("ステータス", 170);
            //リストにデータの追加
            var adminUserService = new AdminUserService();
            var adminUsersList = adminUserService.GetAllAdminUsers();

            foreach (var adminUser in adminUsersList)
            {
                string accountStatus;
                //アカウントロックのステータスによって表示するメッセージを変更
                if (!adminUser.AccountLock)
                {
                    accountStatus = MessageConst.ACCOUNT_UNLOCK_STATUS;
                }
                else
                {
                    accountStatus = MessageConst.ACCOUNT_LOCK_STATUS;
                }

                var item = new ListViewItem
                {
                    Text = adminUser.UserId.ToString()
                };
                item.SubItems.Add(adminUser.Email);
                item.SubItems.Add(accountStatus);
                item.SubItems.Add(adminUser.Id.ToString());
                ListViewAdminUsers.Items.Add(item);
            }
        }

        private void ListViewAdminUsers_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightSkyBlue, e.Bounds); // カラムヘッダの背景色を指定
            e.DrawText(); // テキストを描画
        }
        private void ListViewAdminUsers_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true; // デフォルトの描画を行わせる
           // カラムごとに異なるスタイルを適用する場合、条件に合わせて背景色やテキスト色を変更することができます。
            if (e.ColumnIndex == 2) // 例: ステータス列
            {
                if (e.SubItem.Text == "アカウントロック中")  // アカウントロックの場合
                {
                    e.SubItem.ForeColor = Color.Red; // テキストの色を変更
                    e.SubItem.BackColor = Color.Yellow; // セルの背景色を変更
                }
            }
       }
    }
}
