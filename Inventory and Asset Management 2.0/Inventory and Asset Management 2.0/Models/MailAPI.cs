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
    public static string Username { get; set; }
    public static string Password { get; set; }
    public static string Host { get; set; }
    public static int Port { get; set; }
    public static bool SSL { get; set; }

    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public MailAPI()
    {
        Host = "smtp.mandrillapp.com";
        Port = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
        SSL = true;
        Username = "se542115021@vr.camt.info";
        Password = "yMWwR50KZJN6q6aLx8gBOA";

    }

    public bool Send(string toEmail, string subject, string body)
    {
        try
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Port;
            smtp.EnableSsl = SSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Username, Password);

            using (var message = new MailMessage(Username, toEmail))
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