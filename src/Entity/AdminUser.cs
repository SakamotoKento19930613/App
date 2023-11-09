using System;
using LiteDB;


namespace VisitorTrackSystem.src.Entity
{
    public class AdminUser //　管理ユーザ
    {
        [BsonId]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool LoginFlag { get; set; } // 0 = 未ログイン　1 = ログイン状態
        public DateTime CreateDate { get; set; }
        public bool AccountLock { get; set; }  // 0 = ロック中　1 = 未ロック
        public int FailedLoginCount { get; set; } // ログイン失敗回数
    }

    public class UserSession //セッション管理
    {
        public int Id { get; set; }
        public int AdminId { get; set; } //管理者Id（ユーザIDではない）
        public string Session { get; set; }
        public DateTime SessionTime { get; set; }　//セッション開始時間
    }
}
