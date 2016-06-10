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

        public ActionResult GetUserReadingNook()
        {
            var user_id = User.Identity.GetUserId();
            var nook_context = new BibliotopiaContext();
            var selected_nook = nook_context.ReadingNooks.FirstOrDefault(n => n.Owner.Id == user_id);
            if ((selected_nook != null))
            {
                return View(selected_nook);
            }
            return View()
        }
    }

}