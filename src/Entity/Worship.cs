using System;
using LiteDB;


namespace VisitorTrackSystem.src.Entity
{
    public class Worship // 参拝客
    {
        [BsonId]
        public int Id { get; set; } // 参拝客ID
        public int PrayerId { get; set; } //祈願ID
        public int FamilyId { get; set; } //家族ID
        public string LastName { get; set; }　// 姓
        public string FirstName { get; set; }　// 名
        public string FullName { get; set; }　// 姓名
        public string LastNameKane { get; set; } // セイ
        public string FirstNameKane { get; set; } // ナマエ
        public string FullNameKana { get; set; } // フルネームカナ
        public DateTime BirthDate { get; set; } // 生年月日
        public string Email { get; set; } // メールアドレス
        public string Phone { get; set; } // 電話番号
        public string PostalCode { get; set; } // 郵便番号
        public string Pref { get; set; } //　都道府県
        public string City { get; set; } // 市区町村
        public string Street { get; set; }　// 番地
        public string Building { get; set; } // 建物名/部屋番号
        public string Address { get; set; } // 住所
        public int NotificationMethod { get; set; } // 通知方法 0 = ハガキ 1 = SMS 2 = 電子メール 3 = 通知しない
        public string Note { get; set; } // 備考
        public int AdminUserId { get; set; }  // 管理者ID
        public DateTime CreateDate { get; set; } // 登録日
    }

    public class CompanyWorship // 参拝客・団体
    {
        [BsonId]
        public int Id { get; set; } // 参拝客ID
        public int PrayerId { get; set; } //祈願ID
        public string CompanyName { get; set; }　// 姓
        public string CompanyNameKana { get; set; }　// 名
        public string PresLastName { get; set; }　// 代表者（姓）
        public string PresFirstName { get; set; } // 代表者（名前）
        public string PresLastNameKana { get; set; } // 姓カナ
        public string PresFirstNameKana { get; set; } // 名前カナ
        public string PresFullName { get; set; } // フルネーム
        public string PresFullNameKana { get; set; } // フルネームカナ
        public string Email { get; set; } // メールアドレス
        public string Phone { get; set; } // 電話番号
        public string PostalCode { get; set; } // 郵便番号
        public string Pref { get; set; } //　都道府県
        public string City { get; set; } // 市区町村
        public string Street { get; set; }　// 番地
        public string Building { get; set; } // 建物名/部屋番号
        public string Address { get; set; } // 住所
        public int NotificationMethod { get; set; } // 通知方法 0 = ハガキ 1 = SMS 2 = 電子メール 3 = 通知しない
        public string Note { get; set; } // 備考
        public int AdminUserId { get; set; }  // 管理者ID
        public DateTime CreateDate { get; set; } // 登録日
    }

    public class PrayerData // 祈願データ
    {
        [BsonId]
        public int Id { get; set; }
        public int WorshipId { get; set; } //参拝者ID
        public int FamilyId { get; set; } //家族ID
        public string PrayerType { get; set; } //祈願名
        public int FirstfruitsFee { get; set; } //初穂料                               
        public DateTime PrayerDate { get; set; } //祈願を受けた日
    }

    public class  Family // 家族
    {
        [BsonId]
        public int Id { get; set; }
        public int WorshipId { get; set; } //参拝者ID
        public int PrayerId { get; set; }　//祈願ID
        public string LastName { get; set; }　// 姓
        public string FirstName { get; set; }　// 名
        public string FullName { get; set; }　// 姓名
        public string LastNameKane { get; set; } // セイ
        public string FirstNameKane { get; set; } // ナマエ
        public string FullNameKana { get; set; }　// フルネームカナ
        public DateTime BirthDate { get; set; } // 生年月日
        public string Email { get; set; } // メールアドレス
        public string Phone { get; set; } // 電話番号
        public string PostalCode { get; set; } // 郵便番号
        public string Pref { get; set; } //　都道府県
        public string City { get; set; } // 市区町村
        public string Street { get; set; }　// 番地
        public string Building { get; set; } // 建物名/部屋番号
        public string Address { get; set; } // 住所
        public int NotificationMethod { get; set; } // 通知方法 0 = ハガキ 1 = SMS 2 = 電子メール 3 = 通知しない
        public string Note { get; set; } // 備考
        public int AdminUserId { get; set; }  // 管理者ID
        public DateTime CreateDate { get; set; } // 登録日
    }
}