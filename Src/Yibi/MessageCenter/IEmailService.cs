using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.MessageCenter
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}
