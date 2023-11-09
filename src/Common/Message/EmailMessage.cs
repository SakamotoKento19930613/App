
namespace VisitorTrackSystem.src.Common
{
    public  class EmailMessage
    {
        public const string SEND_AUTHCODE_EMAIL_TITLE = "【認証コード発行】Visitor Track System";
        public const string SEND_AUTHCODE_EMAIL_BODY_HEADER = "様\n\n認証コードを送信しました。\n画面上に表示される入力欄に以下の認証コードをご確認の上ご入力ください。";
        public const string SEND_AUTHCODE_EMAIL_BODY_LINE = "\n\n*--------------------------------*\n\n";
        public const string SEND_AUTHCODE_EMAIL_BODY_CODE = "認証コード : ";
        public const string SEND_AUTHCODE_EMAIL_BODY_FOOTER = "\n\n※有効期限は30分以内となります。\n恐れ入りますが、時間を超過した場合は再度認証コード発行からお手続きをお願いいたします。\n\nこのメールに試あたりがない方は無視してください。";
    }
}
