using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTrackSystem.src.Common.Message
{
    public class MessageConst
    {
        //　メニュー画面のメッセージ
        public const string LOGIN_ADMIN_USER = "ログイン中のユーザ：  ";
        //　管理者一覧画面のリスト内のアカウントロックのステータス
        public const string ACCOUNT_UNLOCK_STATUS = "アカウントロック未";
        public const string ACCOUNT_LOCK_STATUS = "アカウントロック中";
        //　管理者詳細画面のログインステータス
        public const string ACCOUNT_LOGIN_STATUS = "ログイン中";
        public const string ACCOUNT_LOGOUT_STATUS = "ログアウト済";
        //　パスワードリセット時のパスワード変更のメッセージ
        public const string PASSWORD_RESET_DONE_MESSAGE = "パスワードの変更が完了しました。ログイン画面からログインしてください。";
        public const string PASSWORD_RESET_DONE_TITLE = "完了";

        //　共通
        //　登録破棄のメッセージ
        public const string ADD_CANCEL_MESSAGE = "登録破棄しますか？\n編集中のデータは全て破棄されます。";
        public const string ADD_CANCEL_TITLE = "警告";
        //　更新破棄のメッセージ
        public const string UPDATE_CANCEL_MESSAGE = "更新破棄しますか？\n編集中のデータは全て破棄されます。";
        public const string UPDATE_CANCEL_TITLE = "警告";

        //　登録完了のメッセージ
        public const string ADD_DONE_MESSAGE = "登録が完了しました。管理者一覧画面へ戻ります。";
        public const string ADD_DONE_TITLE = "完了";
        //　更新完了のメッセージ
        public const string UPDATE_DONE_MESSAGE = "変更が完了しました。一覧画面へ戻りますか？";
        public const string UPDATE_DONE_TITLE = "完了";
        //　削除確認のメッセージ
        public const string DELETE_CONFIM_MESSAGE = "削除すると元に戻すことはできません。";
        public const string DELETE_CONFIM_TITLE = "警告";
        //  削除二重確認
        public const string DELETE_CONFIM_MESSAGE_2 = "本当に削除してもいいですか？";
        public const string DELETE_CONFIM_TITLE_2 = "警告";
        //　削除完了のメッセージ
        public const string DELETE_DONE_MESSAGE = "削除が完了しました。";
        public const string DELETE_DONE_TITLE = "完了";



    }
}
