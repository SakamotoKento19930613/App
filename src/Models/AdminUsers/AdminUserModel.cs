using System;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Deployment.Application;

namespace VisitorTrackSystem.src.Models.AdminUsers
{
    public class AdminUserModel
    {
        //INSERT
        public void InsertAdminUser(string userId, string email, string password)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");

                AdminUser adminUser = new AdminUser
                {
                    UserId = userId,
                    Email = email,
                    Password = password,
                    CreateDate = DateTime.Now,
                    LoginFlag = true,
                    AccountLock = false,
                    FailedLoginCount = 0,
                };
                adminUsers.Insert(adminUser);
            }
        }

        //SELECT * FROM AdminUsers
        public List<AdminUser> SelectAllAdminUsers()
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsersCollection = db.GetCollection<AdminUser>("AdminUsers");
                List<AdminUser> adminUserList = adminUsersCollection.FindAll().ToList();
                return adminUserList;
            }
        }

        //SELECT * FROM AdminUsers WHERE Id = *;
        public AdminUser GetAdminUserGetById(int id)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUser = db.GetCollection<AdminUser>("AdminUsers");
                return adminUser.FindById(id);
            }
        }

        // UPDATE 
        public void UpdateAdminUser(string userId, string email, string password)
        {
            using (DbHelper dbHelper = new DbHelper()) {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");

                // 既存のユーザーを取得
                AdminUser existingUser = adminUsers.FindOne(x => x.UserId == userId);

                if (existingUser != null)
                {
                    //　更新がない場合は処理を行わない
                    if (email == existingUser.Email && password == existingUser.Password)
                    {
                        
                    } else
                    {
                        // Emailが異なる場合のみ更新
                        if (email != existingUser.Email)
                        {
                            existingUser.Email = email;
                        }
                        // パスワードが異なる場合のみ更新
                        if (password != existingUser.Password)
                        {
                            existingUser.Password = password;
                        }
                        adminUsers.Update(existingUser);
                    }
                }
            }
        }
        //DELETE
        public void DeleteAdminUserById(int Id)
        {
            using (DbHelper dbHelper = new DbHelper())
            {
                var db = dbHelper.db;
                var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                var record = adminUsers.FindOne(x => x.Id == Id);

                adminUsers.Delete(Id);
            }
         }
    }
}
