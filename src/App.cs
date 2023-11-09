using System;
using System.Windows.Forms;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;

namespace VisitorTrackSystem
{
    internal static class App
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginView());
        }
    }
}
