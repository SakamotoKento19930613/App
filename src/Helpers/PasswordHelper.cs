using System.Security.Cryptography;
using System.Text;


namespace VisitorTrackSystem.src.Helpers
{
    internal class PasswordHelper
    {
        public string HashPassword(string passwordValue) 
        {
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    // パスワードをバイト配列にエンコード
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordValue);

                    // パスワードのハッシュを計算
                    byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                    // ハッシュを16進数文字列に変換
                    StringBuilder hashBuilder = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        hashBuilder.Append(b.ToString("x2"));
                    }
                    return hashBuilder.ToString();
                }
            }
        }
    }
}
