using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CinicAutomation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("Check")]
        public String  Index()
        {
            return "Checking Attribute Routing";
        }
    }
}