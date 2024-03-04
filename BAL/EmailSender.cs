using System.Net.Mail;
using System.Net;

namespace CarChoice.BAL
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;


        public EmailSender(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
        }

        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var mail = "21010101075@darshan.ac.in";
        //    var pw = "KASUNDRA@1503";
        //    var client = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        Credentials = new NetworkCredential(mail, pw),
        //        EnableSsl = true
        //    };
        //    return client.SendMailAsync(
        //                       new MailMessage(
        //                           from: mail,
        //                           to: email,
        //                           subject,
        //                           message
        //                           ));
        //}


        public async Task SendEmailAsync(string Email, string subject, string message)
        {
            using (var smtpClient = new SmtpClient(_smtpServer))
            {
                smtpClient.Port = _smtpPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(Email);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }


}

