　using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Common.Message;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;
using VisitorTrackSystem.src.Models.AdminUsers;
using VisitorTrackSystem.src.Models.Auth;

namespace VisitorTrackSystem.src.Service.AdminUsers
{
    internal class AdminUserService
    {
        /*
       * 管理者新規登録時の入力値の確認
       * @ param1 userId
       * @ param2 email
       * @ param3 password
       * @ param4 confirmPassword
       * @ param5 errorMessage
       * return true : 違反なし false : 違反あり
       */
        public Boolean IsErrorCheck(string userId, string email, string password, string confirmPassword, out string errorMessage)
        {
            errorMessage = string.Empty;//初期化
            StringHelper stringHelper = new StringHelper();

            // NULL判定
            if (stringHelper.IsValueNull(userId))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_ID_REQUIRED;
                return false;
            }
            if (stringHelper.IsValueNull(email))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_EMAIL_REQUIRED;
                return false;
            }
            if (stringHelper.IsValueNull(password))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_PASSWORD_REQUIRED;
                return false;
            }
            if (stringHelper.IsValueNull(confirmPassword))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_CONFIRM_PASSWORD_REQUIRED;
                return false;
            }

            //　規約違反判定
            if (stringHelper.ValidateUserId(userId))
            {
                errorMessage = ErrorMessageConst.INPUT_USERID_RULE;
                return false;
            }
            if (stringHelper.ValidateEmail(email))
            {
                errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                return false;
            }
            if (stringHelper.ValidatePassword(password))
            {
                errorMessage = ErrorMessageConst.INPUT_PASSWORD_RULE;
                return false;
            }

            //　確認用パスワードとパスワードが不一致
            if (!password.Equals(confirmPassword))
            {
                errorMessage = ErrorMessageConst.INPUT_PASSWORD_UNMATCH;
                return false;
            }

            //全てのチェックを抜けたらエラーなし
            return true;
        }

        /*
       * 管理者新規登録処理
       * @ param1 userId
       * @ param2 email
       * @ param3 Password
       * @ param3 errorMessage
       * return true : 登録成功 false : 登録失敗
       */
        public Boolean InsertFunction(string userId, string email, string password, out string errorMessage)
        {
            errorMessage = string.Empty;
            WoshipModel authModel = new WoshipModel();   //認証モデルのインスタンスを作成
            AdminUserModel adminUserModel = new AdminUserModel(); //管理者Modelのインスタンス作成
            PasswordHelper passwordHelper = new PasswordHelper(); //Helperのインスタンス作成

            try
            {
                // ユーザーIDからユーザを検索
                AdminUser adminUser = authModel.GetAdminUserGetByUserId(userId);

                if (adminUser  != null)
                {
                    // 既にユーザーIDが登録されている場合
                    errorMessage = ErrorMessageConst.EXISTING_ADMINUSER;
                    return false;
                }
                // 提供されたパスワードをハッシュ化
                string hashedPassword = passwordHelper.HashPassword(password);

                // 新規登録
                adminUserModel.InsertAdminUser(userId, email, hashedPassword);
                return true;
            } catch (Exception ex)
            {
                //　例外
                errorMessage = "エラーが発生しました: " + ex.Message;
                return false;
            }
        }

         /*
        * 管理者の一覧を取得
        * return 管理者一覧
        */
        public List<AdminUser> GetAllAdminUsers()
        {
            AdminUserModel adminUserModel = new AdminUserModel(); // AdminUserModel のインスタンスを作成
            List<AdminUser> adminUsers = adminUserModel.SelectAllAdminUsers(); // インスタンスを使用してメソッドを呼び出す
            return adminUsers;
        }

        /*
        * 一意の管理者情報を取得
        * return 管理者
        */
        public AdminUser GetAdminUser(int id)
        {
            AdminUserModel adminUserModel = new AdminUserModel(); // AdminUserModel のインスタンスを作成
            AdminUser adminUser = adminUserModel.GetAdminUserGetById(id);
            return adminUser;
        }

         /*
        * 管理者更新時の入力値の確認
        * @ param1 userId
        * @ param2 email
        * @ param3 password
        * @ param4 confirmPassword
        * @ param5 errorMessage
        * return true : 違反なし false : 違反あり
        */
        public Boolean IsUpdateErrorCheck(string userId, string email, string password, string confirmPassword, out string errorMessage)
        {

            StringHelper stringHelper = new StringHelper();

            // NULL判定
            if (stringHelper.IsValueNull(userId))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_ID_REQUIRED;
                return false;
            }
            if (stringHelper.IsValueNull(email))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_EMAIL_REQUIRED;
                return false;
            }
            //　パスワードと確認用パスワードに入力がない場合はスルーする
            if (!stringHelper.IsValueUpdatePasswordNull(password, confirmPassword, out errorMessage))
            {
                errorMessage += errorMessage;
                return false;
            }

            //　規約違反判定
            if (stringHelper.ValidateUserId(userId))
            {
                errorMessage = ErrorMessageConst.INPUT_USERID_RULE;
                return false;
            }
            if (stringHelper.ValidateEmail(email))
            {
                errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                return false;
            }
            //　パスワードと確認用パスワードに入力がない場合はスルーする
            if (!stringHelper.IsValidateUpdatePassword(password, confirmPassword, out errorMessage))
            {
                errorMessage += errorMessage;
                return false;
            }

            //全てのチェックを抜けたらエラーなし
            return true;
        }

        /*
       * 管理者更新処理
       * @ param1 userId
       * @ param2 email
       * @ param3 Password
       * @ param3 errorMessage
       * return true : 更新成功 false : 更新失敗
       */
        public Boolean UpdateFunction(string userId, string email, string password, out string errorMessage)
        {
            errorMessage = string.Empty;
            WoshipModel authModel = new WoshipModel();   //認証モデルのインスタンスを作成
            AdminUserModel adminUserModel = new AdminUserModel(); //管理者Modelのインスタンス作成
            PasswordHelper passwordHelper = new PasswordHelper(); //Helperのインスタンス作成

            try
            {
                // ユーザーIDからユーザを検索
                AdminUser adminUser = authModel.GetAdminUserGetByUserId(userId);
                // 提供されたパスワードをハッシュ化
                string hashedPassword = null;
                if (!string.IsNullOrEmpty(password))
                {
                    hashedPassword = passwordHelper.HashPassword(password);
                }

                // 更新がない場合
                if (email == adminUser.Email && string.IsNullOrEmpty(password))
                {
                    //更新がない
                    errorMessage = ErrorMessageConst.ADMIN_UPDATE_NONE;
                    return false;
                }
                else
                {
                    //  更新
                    adminUserModel.UpdateAdminUser(userId, email, hashedPassword);
            }
                return true;
            }
            catch (Exception ex)
            {
                // 例外
                errorMessage = "エラーが発生しました: " + ex.Message;
                return false;
            }
        }

        /*
       * 管理者削除処理
       * @ param1 userId
       * @ param2 errorMessage
       * return true : 削除成功 false : 削除失敗
       */
        public Boolean DeleteFunction(string userId, out string errorMessage)
        {
            errorMessage = string.Empty;
            WoshipModel authModel = new WoshipModel();   //認証モデルのインスタンスを作成
            AdminUserModel adminUserModel = new AdminUserModel(); //管理者Modelのインスタンス作成
            // ユーザーIDからユーザを検索
            try
            {
                AdminUser adminUser = authModel.GetAdminUserGetByUserId(userId);
                DialogResult result = MessageBox.Show(MessageConst.DELETE_CONFIM_MESSAGE_2,
                        MessageConst.DELETE_CONFIM_TITLE_2, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //  削除(ユーザIDではなくIDで該当レコードを削除)
                    adminUserModel.DeleteAdminUserById(adminUser.Id);
                    return true;
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("削除を中断しました",
                       "通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return false;
            } catch (Exception ex)
            {
                // 例外
                errorMessage = "エラーが発生しました: " + ex.Message;
                return false;
            }
        }
    }
}
