using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AH.Controllers
{
    public class PersonController : Controller
    {
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
    }
}