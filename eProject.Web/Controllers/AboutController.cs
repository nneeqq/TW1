using eProject.Web.Extensions;
using eProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject.Web.Controllers
{
    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult Index()
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user == null)
            {
                return View();
            }

            UserData u = new UserData
            {
                Username = user.Username,
                Level = user.Level
            };
            return View(u);
        }
    }
}