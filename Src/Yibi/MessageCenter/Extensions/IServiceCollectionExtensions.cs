using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.MessageCenter.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddYibiMessageCenter(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettingInfo>(options => configuration.GetSection("EmailSettings"));

            services.AddSingleton<IEmailService, EmailService>();

            return services;
        }
    }
}
