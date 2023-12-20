﻿using ECom.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECom.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userName)
        {
            string mail = $"Sayın {userName} Merhaba<br>" +
                $"{orderDate} tarihinde vermiş olduğunuz {orderCode} kodlu siparişiniz tamamlanmış ve kargo firmasına verilmiştir.<br>Hayrını görünüz efendim...";

            await SendMailAsync(to, $"{orderCode} Sipariş Numaralı Siparişiniz Tamamlandı", mail);

        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] {to}, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach ( var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "NG E-Ticaret", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["AngularClientUrl"]);
            mail.AppendLine("/update-password/");
            mail.AppendLine("userId");
            mail.AppendLine("/");
            mail.AppendLine("resetToken");
            mail.AppendLine("\">Yeni şifre talebi için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">Not: Eğer ki bu talep tarafınızca gerçekleştirişmemişse lütfen bu maili ciddiye almayınız.</span><br>Sagılarımızla...");
            await SendMailAsync(to, "Şifre yenileme talebi", mail.ToString());
        }
    }
}
