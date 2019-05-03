using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Yibi.Consul.Models;
using Yibi.Consul.Enums;

namespace Yibi.Consul
{
    public class ConsulRestfulClient
    {
        private readonly HttpClient _httpClient;

        public ConsulRestfulClient(Uri entrypoint)
        {
            if (entrypoint == null)
                throw new ArgumentNullException();

            if (entrypoint.IsAbsoluteUri == false)
                throw new ArgumentException("entry point must be an absoluate url.", nameof(entrypoint));

            _httpClient = new HttpClient() { BaseAddress = entrypoint };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Uri[]> GetDiscoveries(string serviceName)
        {
            var datas = new List<Uri>();

            var healths = await GetServiceHealths(serviceName);
            if (healths != null)
            {
                foreach (var item in healths)
                {
                    var uri = ToUri(item);
                    if (uri != null) datas.Add(uri);
                }
            }

            return datas.ToArray();
        }

        public async Task Register(ServiceInfo serviceInfo)
        {
            var jsonData = JsonConvert.SerializeObject(serviceInfo);

            var httpContent = new StringContent(jsonData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var response = await _httpClient.PutAsync("/v1/agent/service/register", httpContent))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task SendHeartBeat(string appid, string instanceId, bool isOK)
        {
            var checkEndPoint = isOK ? $"/v1/agent/check/pass/service:{instanceId}" : $"/v1/agent/check/fail/service:{instanceId}";
            using (var response = await _httpClient.PutAsync(checkEndPoint, null))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        private Uri ToUri(ServiceHealthInfo itemInfo)
        {
            if (itemInfo.AggregatedStatus == StatusOptions.Critical) return null;

            var meta = itemInfo.Service?.Meta;
            if (meta == null || !meta.Any()) return null;

            return new Uri(meta.First().Value);
        }

        private async Task<IEnumerable<ServiceHealthInfo>> GetServiceHealths(string serviceName)
        {
            using (var response = await _httpClient.GetAsync($"/v1/agent/health/service/name/{serviceName}"))
            {
                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(content)) return null;

                return JsonConvert.DeserializeObject<IEnumerable<ServiceHealthInfo>>(content);
            }
        }

        //private JsonSerializerSettings settings;
        //internal JsonSerializerSettings SerializerSettings
        //{
        //    get
        //    {
        //        if (settings != null) return settings;

        //        settings = new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };

        //        return settings;
        //    }
        //}
    }
}
