using System;
using System.Net;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;
using VisitorTrackSystem.src.Views.Worshipers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VisitorTrackSystem.src.Models.Worship
{
    public class WorshipModel
    {
        //SELECT　ALL
        public int getLoginUserId()
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                UserSession user = new UserSession();
                var db = dbHelper.db;
                var loginUser = db.GetCollection<UserSession>("UserSession");
                user = loginUser.FindOne(a => a.Id == 1);
                int loginUserId = user.AdminId;
                return loginUserId;
            }
        }

        // INSERT(参拝客・個人)
        public void InsertWorship(int loginUserId, string lastName, string firstName, string fullName, string lastNameKana, string firstNameKana,
            DateTime birthData, string email, string phone,
                string postalCode, string pref, string city, string street, string building,
                string prayer, int firstfruitsFeeVal, int notiffcationMethod, string note)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var worshiper = db.GetCollection<Entity.Worship>("Worship");
                Entity.Worship worship = new Entity.Worship
                {
                    AdminUserId = loginUserId,
                    PrayerId = 0, //一旦ここでは0を設定
                    LastName = lastName,
                    FirstName = firstName,
                    FullName = fullName,
                    LastNameKane = lastNameKana,
                    FirstNameKane = firstNameKana,
                    FullNameKana = lastNameKana + firstNameKana,
                    BirthDate = birthData,
                    Email = email,
                    Phone = phone,
                    PostalCode = postalCode,
                    Pref = pref,
                    City = city,
                    Street = street,
                    Building = building,
                    Address = pref + city + street + building,
                    CreateDate = DateTime.Now,
                    NotificationMethod = notiffcationMethod,
                    Note = note
                };
                worshiper.Insert(worship);
                //　祈願情報の登録
                var prayers = db.GetCollection<Entity.PrayerData>("PrayerData");
                Entity.PrayerData prayerData = new PrayerData
                {
                    PrayerType = prayer,
                    FirstfruitsFee = firstfruitsFeeVal,
                    PrayerDate = DateTime.Now,
                    WorshipId = worship.Id,
                    FamilyId = 0,
                };
                prayers.Insert(prayerData);
                //参拝客テーブルに祈願情報のIDを付与する
                //更新対象の参拝客
                Entity.Worship UpdateWorship = worshiper.FindOne(x => x.Id == worship.Id);
                UpdateWorship.PrayerId = prayerData.Id;
                //更新
                worshiper.Update(UpdateWorship);
            }
        }
        public void InsertWorshipCompany(int loginUserId, string companyName, string companyNameKana, string presFirstName, string presLastName, string presLastNameKana, string presFirstNameKana, string email, string phone,
               string postalCode, string pref, string city, string street, string building, string prayer, int firstfruitsFeeVal, int notiffcationMethod, string note)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var worshipCompany = db.GetCollection<CompanyWorship>("CompanyWorship");
                CompanyWorship companyWorship = new CompanyWorship
                {
                    AdminUserId = loginUserId,
                    PrayerId = 0, //一旦ここでは0を設定
                    CompanyName = companyName,
                    CompanyNameKana= companyNameKana,
                    PresLastName = presLastName,
                    PresFirstName = presFirstName,
                    PresFullName = presLastName + " " + presFirstName,
                    PresLastNameKana= presLastNameKana,
                    PresFirstNameKana= presFirstNameKana,
                    PresFullNameKana = presLastNameKana + " " + presFirstNameKana,
                    Email = email,
                    Phone = phone,
                    PostalCode = postalCode,
                    Pref = pref,
                    City = city,
                    Street = street,
                    Building = building,
                    Address = pref + city + street + building,
                    CreateDate = DateTime.Now,
                    NotificationMethod = notiffcationMethod,
                    Note = note
                };

                worshipCompany.Insert(companyWorship);
                //　祈願情報の登録
                var prayers = db.GetCollection<Entity.PrayerData>("PrayerData");
                Entity.PrayerData prayerData = new PrayerData
                {
                    PrayerType = prayer,
                    FirstfruitsFee = firstfruitsFeeVal,
                    PrayerDate = DateTime.Now,
                    WorshipId = companyWorship.Id,
                    FamilyId = 0,
                };
                prayers.Insert(prayerData);
                //参拝客テーブルに祈願情報のIDを付与する
                //更新対象の参拝客
                Entity.CompanyWorship UpdateCompany = worshipCompany.FindOne(x => x.Id == companyWorship.Id);
                UpdateCompany.PrayerId = prayerData.Id;
                //更新
                worshipCompany.Update(UpdateCompany);
            }
        }
    }
}

