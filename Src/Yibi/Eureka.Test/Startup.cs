using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEurekaService(null);
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
