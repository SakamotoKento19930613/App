using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Common.Message;

public class EmailHelper
{
    public static Boolean SendEmail(string toAddress, string authCode)
    {

        // App.config から設定情報を読み取る
        string fromAddress = ConfigurationManager.AppSettings["SmtpFromAddress"];
        string password = ConfigurationManager.AppSettings["SmtpPassword"];
        string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

        // 送信元メールアドレス、宛先メールアドレス、タイトル、本文を設定
        MailMessage message = new MailMessage(fromAddress, toAddress)
        {
            Subject = EmailMessage.SEND_AUTHCODE_EMAIL_TITLE,
            Body = toAddress + EmailMessage.SEND_AUTHCODE_EMAIL_BODY_HEADER + EmailMessage.SEND_AUTHCODE_EMAIL_BODY_LINE + EmailMessage.SEND_AUTHCODE_EMAIL_BODY_CODE + authCode
             + EmailMessage.SEND_AUTHCODE_EMAIL_BODY_LINE + EmailMessage.SEND_AUTHCODE_EMAIL_BODY_FOOTER
        };

        // SMTP クライアントを設定
        SmtpClient client = new SmtpClient(smtpServer)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(fromAddress, password),
            EnableSsl = true // SSL を使用する場合は true に設定
        };

        try
        {
            // メールを送信
            client.Send(message);
            return true;
        }
        catch (Exception)
        {
            // エラーが発生した場合の処理
            return false;
        }
        finally
        {
            // メール関連のリソースを解放
            message.Dispose();
            client.Dispose();
        }
    }
}
