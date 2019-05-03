using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Yibi.Consul.Models;

namespace Yibi.Consul
{
    public class ConsulDiscoveryService : IDiscoveryService
    {
        private readonly ConsulRestfulClient _client;
        private string _instanceId;
        private HashSet<ServiceRegistry> registries = new HashSet<ServiceRegistry>();
        private object sync = new object();
        private System.Timers.Timer timer;

        public ConsulDiscoveryService()
        {
            var consulServerEntryPoint = "http://localhost:8500";
            _client = new ConsulRestfulClient(new Uri(consulServerEntryPoint));

            timer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            timer.Elapsed += OnHeartBeat;
            timer.AutoReset = true;
        }

        public async Task<Uri[]> GetEntryPoints(string serviceName)
        {
            return await _client.GetDiscoveries(serviceName);
        }

        public async Task RegisterService(string serviceName, Uri entryPoint, Func<bool> healthCheck)
        {
            var registry = new ServiceRegistry(_instanceId, serviceName, entryPoint, healthCheck);
            await RegisterService(registry);
        }

        private async Task RegisterService(ServiceRegistry registry)
        {
            if (registries.Contains(registry))
                throw new InvalidOperationException($"Service \"{registry.ServiceName}\" is already registred.");

            await RegisterServiceCore(registry);
        }

        private async Task RegisterServiceCore(ServiceRegistry registry)
        {
            lock (sync)
            {
                var serviceId = string.IsNullOrEmpty(_instanceId) ? registry.ServiceName : _instanceId;

                Dictionary<string, string> meta = new Dictionary<string, string>
                {
                    { "EntryPoint", registry.EntryPoint.AbsoluteUri }
                };

                var checkInfo = new ServiceCheckInfo
                {
                    ID = serviceId,
                    Name = registry.ServiceName,
                    TTL = "30s"
                };

                var serviceInfo = new ServiceInfo
                {
                    ID = serviceId,
                    Name = registry.ServiceName,
                    Address = registry.EntryPoint.Host,
                    Port = registry.EntryPoint.Port,
                    Meta = meta,
                    Check = checkInfo
                };

                _client.Register(serviceInfo).Wait();

                registries.Add(registry);
            }
        }

        private async void OnHeartBeat(Object source, ElapsedEventArgs e)
        {
            var cancellationSource = new CancellationTokenSource(30000);  //一个请求发起至接收响应30秒左右正常

            var tasks = registries.Select(item => TrySendHeartBeat(item, cancellationSource.Token));

            await Task.WhenAll(tasks);

        }

        private async Task<bool> TrySendHeartBeat(ServiceRegistry registry, CancellationToken cancellationToken)
        {
            var health = false;
            try
            {
                health = await Task.Run(registry.HealthCheck, cancellationToken);
            }
            catch
            {
                health = false;
            }

            await _client.SendHeartBeat(registry.ServiceName, _instanceId, health);

            return health;
        }

        private sealed class ServiceRegistry
        {
            public ServiceRegistry(string instanceId, string serviceName, Uri entryPoint, Func<bool> healthCheck)
            {
                ServiceName = serviceName ?? throw new ArgumentNullException(nameof(serviceName));
                EntryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
                HealthCheck = healthCheck ?? throw new ArgumentNullException(nameof(healthCheck));

                if (EntryPoint.IsAbsoluteUri == false)
                    throw new ArgumentException("entry point must be an absoluate url", nameof(entryPoint));

                InstanceId = string.IsNullOrEmpty(instanceId) ? serviceName : instanceId;
            }

            public string InstanceId { get; }
            public string ServiceName { get; }
            public Uri EntryPoint { get; }
            public Func<bool> HealthCheck { get; }

            private StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            public override int GetHashCode()
            {
                return stringComparer.GetHashCode(ServiceName);
            }

            public override bool Equals(object obj)
            {
                if (obj is ServiceRegistry registry)
                    return stringComparer.Equals(registry.ServiceName, ServiceName);

                else
                    return false;
            }

            public override string ToString()
            {
                return $"[{ServiceName} on {EntryPoint.AbsoluteUri}]";
            }
        }
    }
}
