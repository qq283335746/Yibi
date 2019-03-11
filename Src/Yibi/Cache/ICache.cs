using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yibi.Cache
{
    public interface ICache
    {
        Task<byte[]> GetAsync(string key);

        Task SetAsync(string key, string value);
    }
}
