using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.Eureka.Test
{
    public class EurekaRestfulTest
    {
        private readonly IEurekaService _eurekaService;

        public EurekaRestfulTest(IEurekaService eurekaService)
        {
            _eurekaService = eurekaService;
        }

        public async Task RegisterService()
        {
            await _eurekaService.RegisterService("myServiceName", new Uri("http://127.0.0.1:8081/Eureka"), HealthCheck);
        }

        private static bool HealthCheck()
        {
            return true;
        }
    }
}
