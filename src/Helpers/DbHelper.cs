using LiteDB;
using System;
using System.Configuration;

namespace VisitorTrackSystem.src.Helpers
{
    public class DbHelper : IDisposable
    {
        public readonly LiteDatabase db;
        public  DbHelper()
        {
            //データベースの接続を確立
            db = new LiteDatabase(ConfigurationManager.AppSettings["DbFilePath"]);
        }

        public void Dispose()
        {
            // データベース接続をクローズ
            db.Dispose();
        }
    }
}
