using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public string LoginCheck(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return "1";
            }
            return "0";
        }

    }
}
