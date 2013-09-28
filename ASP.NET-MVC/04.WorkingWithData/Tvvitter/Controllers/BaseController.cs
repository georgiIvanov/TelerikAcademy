using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvvitter.Data;

namespace Tvvitter.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(ITvvitterData data)
        {
            this.Data = data;
        }

        public ITvvitterData Data { get; set; }
    }
}