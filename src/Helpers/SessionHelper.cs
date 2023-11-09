using LiteDB;
using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;

namespace VisitorTrackSystem.src.Helpers
{
    public class SessionHelper
    {
        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public string GenerateRandomString() 
        {
            var sb = new StringBuilder(80);
            for (int i = 0; i < 80; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }
    }
}
