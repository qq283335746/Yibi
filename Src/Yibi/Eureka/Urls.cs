using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Eureka
{
    public class Urls
    {
        internal const string _eurekaRootUrl = "http://10.168.95.76:8080";

        //Query for all instances, GET /eureka/v2/apps
        internal const string _eurekaQueryAllInstancesUrl = _eurekaRootUrl + "/eureka/apps";

        //Query for all appID instances, GET /eureka/v2/apps/appID
        internal const string _eurekaQueryInstancesByAppIdUrl = _eurekaRootUrl + "/eureka/apps/{0}";

        //Register new application instance, POST /eureka/v2/apps/appID
        internal const string _eurekaRegisterInstanceUrl = _eurekaRootUrl + "/eureka/apps/{0}";

        //Send application instance heartbeat, PUT /eureka/v2/apps/appID/instanceID
        internal const string _eurekaSendHeartBeatUrl = _eurekaRootUrl + "/eureka/apps/{0}/{1}";  
    }
}
