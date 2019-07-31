using System;
using System.Collections.Generic;
using System.Text;
using Yibi.Core.Server.Enums;

namespace Yibi.Core.Server
{
    public class ResponseResult<T>
    {
        public ResCodeOptions ResCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
