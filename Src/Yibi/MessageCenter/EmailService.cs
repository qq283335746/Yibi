using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Yibi.MessageCenter
{
    public class EmailService: IEmailService
    {
        private readonly EmailSettingInfo _emailSetting;
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(_emailSetting.SenderName, _emailSetting.SenderEmail));

                mimeMessage.To.Add(new MailboxAddress(email));

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_emailSetting.Server, _emailSetting.Port);

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(_emailSetting.SenderEmail, _emailSetting.Password);

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"MessageCenterService.SendEmailAsync,error:{ex.Message}");

                return false;
            }
        }
    }
}
