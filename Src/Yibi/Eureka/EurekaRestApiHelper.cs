using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using Yibi.Eureka.EurekaModels;
using Newtonsoft.Json;

namespace Yibi.Eureka
{
    public class EurekaRestApiHelper
    {
        private readonly HttpClient _httpClient;

        private EurekaRestApiHelper()
        {
            _httpClient = new HttpClient();
            MediaTypeWithQualityHeaderValue.TryParse("application/json", out var ajson);
            _httpClient.DefaultRequestHeaders.Accept.Add(ajson);
            _httpClient.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("gzip,deflate");
        }

        public static EurekaRestApiHelper Instance => new EurekaRestApiHelper();

        internal async Task<QueryAppInstancesResultInfo> QueryAppInstances(string appid)
        {
            using (var response = await _httpClient.GetAsync(string.Format(Urls._eurekaQueryInstancesByAppIdUrl, appid)))
            {
                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(content)) return null;

                return JsonConvert.DeserializeObject<QueryAppInstancesResultInfo>(content);
            }
        }

        internal async Task<bool> Register(string appid, RegisterAppInstanceRequestInfo requestInfo)
        {
            //var xmlBody = CreateXmlInstance(instanceInfo).ToString();
            var xmlBody = JsonConvert.SerializeObject(requestInfo, serializerSettings);

            var httpContent = new StringContent(xmlBody);
            MediaTypeHeaderValue.TryParse("application/json", out var ajson);
            httpContent.Headers.ContentType = ajson;
            //httpContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Xml);

            using (var response = await _httpClient.PostAsync(string.Format(Urls._eurekaRegisterInstanceUrl, appid), httpContent))
            {
                return response.IsSuccessStatusCode;
            }
        }

        internal async Task<bool> SendHeartBeat(string appid, string instanceId)
        {
            using (var response = await _httpClient.PutAsync(string.Format(Urls._eurekaSendHeartBeatUrl, appid, instanceId), null))
            {
                return response.IsSuccessStatusCode;
            }
        }

        private JsonSerializerSettings settings;
        internal JsonSerializerSettings serializerSettings
        {
            get
            {
                if (settings != null) return settings;

                settings = new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };

                return settings;
            }
        }

        #region 使用xml代码时请使用

        //private static ApplicationInstanceInfo ParseToApplicationInstanceInfo(string xmlApplicationSource)
        //{
        //    var applicationInstanceInfo = new ApplicationInstanceInfo();

        //    const string rootName = "application";
        //    XElement root;
        //    try
        //    {
        //        root = XElement.Parse(xmlApplicationSource);
        //        if (root.Name != rootName) return applicationInstanceInfo;
        //    }
        //    catch
        //    {
        //        return applicationInstanceInfo;
        //    }

        //    var json = JObject.Parse(JsonConvert.SerializeXNode(root));
        //    applicationInstanceInfo.Name = (string)json[rootName]["name"];

        //    var instanceNode = json[rootName]["instance"];

        //    if (instanceNode.Type == JTokenType.Array)
        //    {
        //        applicationInstanceInfo.Instance = instanceNode.ToObject<IEnumerable<InstanceInfo>>();
        //    }
        //    else
        //    {
        //        var instances = new List<InstanceInfo>()
        //        {
        //            instanceNode.ToObject<InstanceInfo>()
        //        };
        //        applicationInstanceInfo.Instance = instances;
        //    }

        //    return applicationInstanceInfo;
        //}

        //private static XElement CreateXmlInstance(InstanceInfo instanceInfo)
        //{
        //    var root = new XElement("instance",
        //       new XElement("instanceId", instanceInfo.InstanceId),
        //       new XElement("hostName", instanceInfo.HostName),
        //       new XElement("app", instanceInfo.App),
        //       new XElement("ipAddr", instanceInfo.IpAddr),
        //       new XElement("homePageUrl", instanceInfo.HomePageUrl));

        //    var dataCenterInfo = new XElement("dataCenterInfo",
        //        new XAttribute("class", "com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo"),
        //        new XElement("name", "MyOwn"));

        //    root.Add(dataCenterInfo);

        //    return root;
        //}

        #endregion
    }
}
