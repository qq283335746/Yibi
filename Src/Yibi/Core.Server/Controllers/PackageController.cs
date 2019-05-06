using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Server.Controllers
{
    public class PackageController: Controller
    {
        [HttpGet]
        public string Get()
        {
            return "this is Package Controller!";
        }
    }
}
