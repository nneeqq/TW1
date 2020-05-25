using eProject.Web.Extensions;
using eProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject.Web.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user == null)
            {
                return View();
            }

            var cities = new List<City>();
            cities.Add(new City() { Title = "Chisinau", Lat = 47.003670, Lng = 28.907089 });

            UserData u = new UserData
            {
                Username = user.Username,
            };

            return View(cities);
        }

        [HttpPost]
		public JsonResult GetAnswer(string question)
        {
            int index = _rnd.Next(_db.Count);
            var answer = _db[index];
            return Json(answer);
        }

        private static Random _rnd = new Random();

        private static List<string> _db = new List<string> { "Yes", "No", "Definitely, yes", "I don't know", "Looks like, yes" };
    }
}
