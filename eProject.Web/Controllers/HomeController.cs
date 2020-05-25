using System.Web.Mvc;
using eProject.Web.Extensions;
using eProject.Web.Models;

namespace eProject.Web.Controllers
{
    public class HomeController : BaseController
    {
        [HandleError]
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