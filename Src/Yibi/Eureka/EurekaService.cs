using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Yibi.Eureka.EurekaModels;

namespace Yibi.Eureka
{
    public class EurekaService : IEurekaService
    {
        System.Timers.Timer timer;

        private static List<(string name, Uri entrypoint, Func<bool> healthCheck)> checkers;

        public EurekaService()
        {
            timer = new System.Timers.Timer(3000);
            //timer.Elapsed += OnHeartBeat;
            timer.AutoReset = true;
            timer.Enabled = true;
            checkers = new List<(string, Uri, Func<bool>)>();
        }

        public static async void OnHeartBeat(Object source, ElapsedEventArgs e)
        {
            foreach (var (name, entrypoint, healthCheck) in checkers)
            {
                var cancelSource = new CancellationTokenSource(100);

                var task = Task.Run(() =>
                {
                    return healthCheck();
                }, cancelSource.Token);

                task.Wait();

                if (task.IsCompleted && task.Result)
                    await SendHeartBeat(name,entrypoint);
            }
        }

        public async Task<Uri[]> GetEntryPoints(string serviceName)
        {
            var appInstances = await EurekaRestApiHelper.Instance.QueryAppInstances(serviceName);

            return appInstances?.Application?.Instance?.Select(m => new Uri(m.HomePageUrl))?.ToArray();
        }

        public async Task RegisterService(string serviceName, Uri entryPoint, Func<bool> healthCheck)
        {
            var url = entryPoint.ToString();
            var ip = entryPoint.Host.LastIndexOf(":") > -1 ? entryPoint.Host.Substring(0, entryPoint.Host.LastIndexOf(":")) : entryPoint.Host;

            var instanceId = GetInstanceId(serviceName, entryPoint);

            var instanceInfo = new InstanceInfo
            {
                InstanceId = instanceId,
                HostName = entryPoint.Host,
                App = serviceName,
                IpAddr = ip,
                HomePageUrl = url,
                Status = "UP",
                DataCenterInfo = new DataCenterInfo { Name= "MyOwn",ClassRelation= "com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo" }
            };

            var requestInfo = new RegisterAppInstanceRequestInfo { Instance = instanceInfo };

            var isSuccess = await EurekaRestApiHelper.Instance.Register(serviceName, requestInfo);
            if (!isSuccess) return;

            checkers.Add((serviceName, entryPoint, healthCheck));
        }

        public static async Task<bool> SendHeartBeat(string serviceName, Uri entryPoint)
        {
            var instanceId = GetInstanceId(serviceName, entryPoint);
            return await EurekaRestApiHelper.Instance.SendHeartBeat(serviceName, instanceId);
        }

        private static string GetInstanceId(string serviceName,Uri entryPoint)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes($"{serviceName}|{entryPoint.ToString()}"));
        }
    }
}
