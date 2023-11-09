using System;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;

namespace VisitorTrackSystem.src.Models.Auth
{
    public class WoshipModel
    {
        //　ログインIDが完全一致するレコードを検索
        public AdminUser GetAdminUserGetByUserId(string userId)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                return adminUsers.FindOne(a => a.UserId == userId);
            }
        }

        //  管理ユーザの更新
        public void UpdateAdminUser(AdminUser adminUser)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                adminUsers.Update(adminUser);
            }
        }
        //セッションスタート
        public void SessionStart(int id)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                SessionHelper sessionHelper = new SessionHelper();
                string sessionData = sessionHelper.GenerateRandomString();

                UserSession userSession = new UserSession
                {
                    AdminId = id,
                    Session = sessionData
                };
                var db = dbHelper.db;
                var session = db.GetCollection<UserSession>("UserSession");
                session.Insert(userSession);
            }
        }

        //　SELECT * FROM AdminUser WHERE LoginFlag = False
        public AdminUser GetAdminUserByLoginFlag()
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                return adminUsers.FindOne(a => a.LoginFlag == false);
            }
        }
        // DELETE
        public void DeleteUserSessionByAdminId(int adminId)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var userSession = db.GetCollection<UserSession>("UserSession");
                var record = userSession.FindOne(x => x.Id == adminId);
                userSession.DeleteAll();
            }
        }

        // UPDATE
        public void UpdateAdminUserLoginFlagById(int adminId)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                AdminUser adminUser = adminUsers.FindOne(x => x.Id == adminId);
                adminUser.LoginFlag = true;
                adminUsers.Update(adminUser);
            }
        }

        public void UpdateAdminUserPasswordById(int id, string password)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                AdminUser adminUser = adminUsers.FindOne(x => x.Id == id);
                adminUser.Password = password;
                adminUser.AccountLock = false;
                adminUser.FailedLoginCount = 0;
                adminUsers.Update(adminUser);
            }
        }

    }
}