
namespace VisitorTrackSystem.src.Common
{
    public  class ErrorMessageConst
    {
         /*
         * ログイン画面
         */
        public const string ADMIN_USER_ID_REQUIRED = "管理者のユーザIDは必須です。";
        public const string ADMIN_USER_PASSWORD_REQUIRED = "管理者のパスワードは必須です。";
        public const string ADMIN_USER_LOGIN_FAILED = "ログインに失敗しました。連続で５回失敗するとアカウントロックがかかります。";
        public const string ADMIN_USER_ACCOUNT_LOCK = "アカウントロックがかかりました。\nパスワードを忘れた方はこちらからパスワードをリセットしてください。";

        /*
         * 認証コード送信画面
        */
        public const string AUTHCODE_USERID_REQUIRED = "ユーザーIDは必須です";
        public const string AUTHCODE_EMAIL_REQUIRED = "メールアドレスを指定してください";
        public const string AUTHCODE_SEND_ERROR = "送信できませんでした。";
        /*
         * 認証コード送信画面
        */
        public const string AOUTH_CODE_UNMUCH = "認証コードが一致しません。";

        /*
        * 管理者新規登録、詳細画面
        */
        //　NULL、空白
        public const string INPUT_USER_ID_REQUIRED = "ユーザーIDを設定してください。";
        public const string INPUT_USER_EMAIL_REQUIRED = "メールアドレスを設定してください。";
        public const string INPUT_USER_PASSWORD_REQUIRED = "パスワードを設定してください。";
        public const string INPUT_USER_CONFIRM_PASSWORD_REQUIRED = "確認パスワードを入力してください。";
        //　規約違反
        public const string INPUT_USERID_RULE = "ユーザーIDは半角英数字で４文字～16文字以上で設定してください";
        public const string INPUT_EMAIL_RULE = "入力形式がメールアドレスではありません。";
        public const string INPUT_PASSWORD_RULE = "パスワードは半角英数字大文字小文字混在で8文字～32文字以上で設定してください";
        //　パスワード不一致
        public const string INPUT_PASSWORD_UNMATCH = "確認用パスワードと入力したパスワードが一致しません。再度お確かめください。";
        //　既に登録があるユーザID
        public const string EXISTING_ADMINUSER = "既に登録があるユーザーIDです。別のユーザーIDを設定してください。";
        //　リスト未選択
        public const string SELECTED_ADMIN_USER = "変更するユーザーを選択してください。";
        // 更新がない場合
        public const string ADMIN_UPDATE_NONE = "更新がありません。";

        /*
        * 参拝客登録（個人）
        */
        public const string LASTNAME_IS_NULL = "姓は必須です。";
        public const string FIRSTNAME_IS_NULL = "名前は必須です。";
        public const string LASTNAMEKANA_IS_NULL = "姓（カナ）は必須です。";
        public const string FIRSTNAMEKANA_IS_NULL = "名前（カナ）は必須です。";
        public const string BIRH_IS_NULL = "生年月日は必須です。";
        public const string BIRH_IS_FORMAT_ERROR = "生年月日が日付の形式ではありません。";
        public const string PHONE_IS_NONE = "電話番号は必須です";
        public const string PHONE_IS_FORMAT_ERROR = "電話番号の形式が不正です";
        public const string POSTALCODE_IS_NONE = "郵便番号は必須です";
        public const string POSTALCODE_IS_FORMAT_ERROR = "郵便番号の形式が不正です";
        public const string ADDRESS_IS_NULL = "住所は必須です。";
        public const string PRAYER_IS_NULL = "祈願名は必須です。";
        public const string FFF_IS_NULL = "初穂料は必須です。";
        public const string FFF_IS_FORMAT_ERROR= "初穂料が不正です。正しい金額を入力してください。";
        public const string FAMIRY_DATA_IS_NULL = "ご家族が有の場合はご家族の情報入力へ進んでください。";
    }
}
