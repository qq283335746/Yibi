using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Server.Controllers
{
    public class IndexController: Controller
    {
        [HttpGet]
        public string Get()
        {
            return "this is Index Controller!";
        }
    }
}
