using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Inventory_and_Asset_Management_2._0.Models
{
    public class MailAPI
    {
    public static string GmailUsername { get; set; }
    public static string GmailPassword { get; set; }
    public static string GmailHost { get; set; }
    public static int GmailPort { get; set; }
    public static bool GmailSSL { get; set; }

    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public MailAPI()
    {
        GmailHost = "smtp.mandrillapp.com";
        GmailPort = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
        GmailSSL = true;
        GmailUsername = "se542115021@vr.camt.info";
        GmailPassword = "yMWwR50KZJN6q6aLx8gBOA";

    }

    public bool Send(string toEmail, string subject, string body)
    {
        try
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, toEmail))
            {
                message.Subject = subject;
                message.Body = body;
                smtp.Send(message);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
    }
}