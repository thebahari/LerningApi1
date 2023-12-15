using System.Net.Mail;
using System.Net;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["MailServices:_mailTo"];
            _mailFrom = configuration["MailServices:_mailFrom" +
                "" +
                ""];
        }
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail  From {_mailFrom}  To {_mailTo}  , "
                + $"with {nameof(LocalMailService)}  ,  ");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message {message}");
            Email(subject, message, "bahare.zarei7616@gmail.com");
        }



        public static void Email(string subject, string htmlString
            , string to)
        {
            try
            {
                string _mailFrom = "bahare.zarei0140@gmail.com";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(_mailFrom);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 2525;
                smtp.Host = "smtp.elasticemail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("bahare.zarei0140@gmail.com", "B9288415194DF3437C0AF6A37561F9C76385");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
