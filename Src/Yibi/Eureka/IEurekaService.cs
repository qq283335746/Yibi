using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.Eureka
{
    public interface IEurekaService
    {
        /// <summary>
        /// 注册一个服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="entryPoint">服务接入点</param>
        /// <param name="healthCheck">健康检查方法</param>
        /// <returns>服务心跳信息凭据</returns>
        Task RegisterService(string serviceName, Uri entryPoint, Func<bool> healthCheck);

        /// <summary>
        /// 获取服务接入点
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns>服务接入点</returns>
        Task<Uri[]> GetEntryPoints(string serviceName);
    }
}
