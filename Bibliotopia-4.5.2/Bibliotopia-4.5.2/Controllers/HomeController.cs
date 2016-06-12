using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliotopia_4._5._2.DAL;
using System.Web.Mvc;

namespace Bibliotopia_4._5._2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }

}