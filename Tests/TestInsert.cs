using System;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;

namespace VisitorTrackSystem.Tests
{
    internal class TestInsert
    {
        public void TestInsertAdminUser()
        {
            PasswordHelper passwordHelper = new PasswordHelper();
            using (DbHelper dbHelper = new DbHelper())
            {
                {
                    AdminUser adminUser = new AdminUser()
                    {
                        UserId = "admin000",
                        Email = "b0001238@gmail.com",
                        Password = passwordHelper.HashPassword("B0001238xx5"),
                        AccountLock = false,
                        LoginFlag = true,
                        CreateDate = DateTime.Now,
                        FailedLoginCount = 0,
                    };
                    var db = dbHelper.db;
                    var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                    adminUsers.Insert(adminUser);
                }
            }
        }

        public void TestUpdateAdminUser()
        {
            PasswordHelper passwordHelper = new PasswordHelper();
            using (DbHelper dbHelper = new DbHelper())
            {
                {
                    AdminUser adminUser = new AdminUser()
                    {
                        UserId = "admin000",
                        Email = "b0001238@gmail.com",
                        Password = passwordHelper.HashPassword("B0001238xx5"),
                        AccountLock = false,
                        LoginFlag = true,
                        CreateDate = DateTime.Now,
                        FailedLoginCount = 0,
                    };
                    var db = dbHelper.db;
                    var adminUsers = db.GetCollection<AdminUser>("AdminUsers");
                    adminUsers.Insert(adminUser);
                }
            }
        }
    }
}