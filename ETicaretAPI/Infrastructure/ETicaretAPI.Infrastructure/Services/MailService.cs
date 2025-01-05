using ETicaretAPI.Application.Abstraction.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Body = body;
            mail.From = new(_configuration["Mail:UserName"], "NG E-Ticaret",System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);


        }

        public async Task SendPasswordResetMailAsync(string to,string userId,string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Merhaba<br>Eger yeni sifre talebinde bulunduysaniz asagidaki linkten sifrenizi yenileyebilirsiniz.<br><strong><a target =\"_blank\" href=\"");
            mail.AppendLine(_configuration["AngularClientUrl"]);
            mail.AppendLine("/update-password/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">Yeni sifre talebi icin tiklayiniz....</a></strong><br><br><span style = \"font-size:12px;\">NOT:Eger bu talep tarafinizca gerceklestirilmemisse ltfen bu maili ciddiye almayiniz.</span><br>Saygilarimizla...<br><br><br>NG - Mini|E-Ticaret");


            await SendMailAsync(to,"Sifre Yenileme talebi",mail.ToString());   
        }

        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userName)
        {
            string mail = $"Sayin{userName}  Merhaba<br>" + $"{orderDate} tarihinde vermis oldugunuz {orderCode} kodlu siparisiniz tamamlanmis ve kargo firmasina verilmisdir.Hayrli olsun efendim...";

            await SendMailAsync(to, $"{orderCode} Siparis Numarali Siparisiniz Tamamlandi",mail);
        }

       
    }
}
