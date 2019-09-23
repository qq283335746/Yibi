using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yibi.Web.Enums;

namespace Yibi.Web.Models
{
    public class ResponseResult
    {
        public ResCodeOptions ResCode { get; set; }

        public string Message { get; set; }
    }
}
