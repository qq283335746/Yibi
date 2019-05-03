using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.Consul
{
    public interface IDiscoveryService
    {
        Task<Uri[]> GetEntryPoints(string serviceName);

        Task RegisterService(string serviceName, Uri entryPoint, Func<bool> healthCheck);
    }
}
