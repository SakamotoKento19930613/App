using System;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Helpers;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Models.Auth;
using System.Windows.Forms;

namespace VisitorTrackSystem.src.Service.Auth
{
    internal class AuthService
    {
         /*
         * ログイン時の入力値の確認
         * @ param1 userId
         * @ param2 password
         * @ param3 errorMessage
         * return true : 違反なし false : 違反あり
         */
        public Boolean IsErrorCheck(String userId, String password, out string errorMessage)
        {
            errorMessage = string.Empty;
            StringHelper stringHelper = new StringHelper();
            // Nullか空白を判定
            if (stringHelper.IsValueNull(userId))
            {
                errorMessage = ErrorMessageConst.ADMIN_USER_ID_REQUIRED;
                return false;
            }
            if (stringHelper.IsValueNull(password))
            {
                errorMessage = ErrorMessageConst.ADMIN_USER_PASSWORD_REQUIRED;
                return false;
            }
            return true;
        }

         /*
        * ログイン処理
        * @ param1 userId
        * @ param2 password
        * @ param3 errorMessage
        * return true : ログイン成功 false : ログイン失敗
        */
        public Boolean Login(String userId, String password, out string errorMessage)
        {
            errorMessage = string.Empty; //初期化
            WoshipModel authModel = new WoshipModel();   //Modelのインスタンスを作成
            PasswordHelper passwordHelper = new PasswordHelper(); //Helperのインスタンス作成

            // ユーザIDからユーザを検索
            AdminUser adminUser =  authModel.GetAdminUserGetByUserId(userId);
            // ユーザーに該当がない
            if (adminUser != null)
            {
                // アカウントロックがかかっている場合
                if (adminUser.AccountLock)
                {
                    errorMessage = ErrorMessageConst.ADMIN_USER_ACCOUNT_LOCK;
                    return false;
                }
                // ログイン試行回数が一定回数を超えた場合にアカウントをロック
                if (adminUser.FailedLoginCount >= 5)
                {
                    adminUser.AccountLock = true;
                    authModel.UpdateAdminUser(adminUser);
                    errorMessage = ErrorMessageConst.ADMIN_USER_ACCOUNT_LOCK;
                    return false;
                }
                else
                {
                    // 提供された平文のパスワードをハッシュ化
                    string hashedPassword = passwordHelper.HashPassword(password);

                    //　ハッシュ値の比較して認証
                    if (adminUser.Password == hashedPassword)
                    {
                        //一致したらログイン試行回数をリセットしてログインフラグをTrueに設定する
                        adminUser.FailedLoginCount = 0;
                        adminUser.LoginFlag = false;
                        authModel.UpdateAdminUser(adminUser);
                        //ログインユーザでのセッション開始 Pram1 = Id
                        authModel.SessionStart(adminUser.Id);
                    }
                    else
                    {
                        //不一致の場合、ログイン試行回数をログイン試行回数をカウントする
                        errorMessage = ErrorMessageConst.ADMIN_USER_LOGIN_FAILED;
                        adminUser.FailedLoginCount++;
                        authModel.UpdateAdminUser(adminUser);
                        return false;
                    }
                }
            }　else
            {
                errorMessage = ErrorMessageConst.ADMIN_USER_LOGIN_FAILED;
                return false;
            }
            return true;
        }

        /*
       * 認証コード送信時の規約違反確認
       * @ param1 userId
       * @ param2 email
       * @ param3 errorMessage
       * return true : 違反なし false : 違反あり
       */
        public Boolean IsAuthCodeSendCheck(string userId, string email, out string errorMessage)
        {
            errorMessage = string.Empty;

            StringHelper stringHelper = new StringHelper();
            if (stringHelper.IsValueNull(userId))
            {
                errorMessage = ErrorMessageConst.ADMIN_USER_ID_REQUIRED;
                return false;
            }
            if (stringHelper.IsValueNull(email))
            {
                errorMessage = ErrorMessageConst.AUTHCODE_EMAIL_REQUIRED;
                return false;
            }
            if (stringHelper.ValidateEmail(email))
            {
                errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                return false;
            }
            return true;
        }
        /*
       * 5桁のランダムな認証コードを発行
       * return認証コード
       */
        public static string GenerateAuthCode()
        {
            // ランダムなシードを使用して新しい Random インスタンスを作成
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            // 5桁の認証コードを生成
            int authCode = random.Next(10000, 99999);
            return authCode.ToString();
        }

        /*
       * メール送信
       * return true : 送信成功 false: 送信失敗
       */
        public  Boolean SendAuthCode(string userId, string toAddress, string authCode, out string errorMessage)
        {
            errorMessage = string.Empty;
            WoshipModel authModel = new WoshipModel();
            AdminUser adminUser = authModel.GetAdminUserGetByUserId(userId);
            //登録があるユーザIDか確認
            if(adminUser.UserId != userId)
            {
                //登録がない
                errorMessage = ErrorMessageConst.AUTHCODE_SEND_ERROR;
                return false;
            }
            //登録があるユーザID
            // メール送信
            Boolean sendEmail = EmailHelper.SendEmail(toAddress, authCode);
            if (!sendEmail)
            {
                errorMessage = ErrorMessageConst.AUTHCODE_SEND_ERROR;
                return false;
            }
            return true;
        }

        /*
       * パスワード変更画面でのパスワードの規約確認
       * @ param1 newPassword
       * @ param2 confirmPassword
       * @ param3 errorMessage
       * return true : 違反なし false : 違反あり
       */
        public Boolean ChangedPasswordCheck(string password, string confirmPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            StringHelper stringHelper = new StringHelper();

            // NULL判定
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

            // 規約判定
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
            return true;
        }

        /*
       * パスワード変更画面でのパスワード変更処理
       * @ param1 newPassword
       * @ param2 confirmPassword
       * @ param3 errorMessage
       * return true : 違反なし false : 違反あり
       */
        public Boolean UpdatePasswordFunction(string userId, string password, out string errorMessage)
        {
            //ユーザIDから変更対象のIDを取得
            WoshipModel authModel = new WoshipModel();
            AdminUser adminUser = authModel.GetAdminUserGetByUserId(userId);
            int id = adminUser.Id;
            //提供されたパスワードをハッシュ化
            PasswordHelper passwordHelper = new PasswordHelper();
            string hashPassword = passwordHelper.HashPassword(password);
            //変更
            authModel.UpdateAdminUserPasswordById(id, hashPassword);
            errorMessage = string.Empty;
            return true;
        }

        //ログアウト処理
        public void Logout()
        {
            //　ログイン中のユーザ情報を取得(ログインフラグがFalse = "ログイン中"のユーザー)
            WoshipModel authModel = new WoshipModel();
            AdminUser loginAdminUser = authModel.GetAdminUserByLoginFlag();
            //　管理ユーザーのログインフラグをTrueに設定
            authModel.UpdateAdminUserLoginFlagById(loginAdminUser.Id);
            //　セッションデータの削除
            authModel.DeleteUserSessionByAdminId(loginAdminUser.Id);
            Application.Exit();
        }
    }
}
