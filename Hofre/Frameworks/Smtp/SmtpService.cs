using Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Smtp
{
    public class SmtpService : ISmtpService
    {
        public SmtpService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public async Task Send(EmailViewModel commend)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(Configuration.GetSection("Smtp")["Email"], Configuration.GetSection("Smtp")["password"]);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(Configuration.GetSection("Smtp")["Email"]);
            message.To.Add(commend.Emailreceiver);
            message.Subject = commend.Subject;
            message.IsBodyHtml = true;
            message.Body =  commend.Text;
            try
            {
                await smtpClient.SendMailAsync(message);

            }
            catch (Exception ex)
            {

                throw new SmtpErrorException(ex.Message);
            }
        }
    }
}
