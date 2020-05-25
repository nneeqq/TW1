using AutoMapper;
using eProject.BusinessLogic.Interfaces;
using eProject.Domain.Entities.Product;
using eProject.Domain.Entities.User;
using eProject.Web.App_Start;
using eProject.Web.Extensions;
using eProject.Web.Models;
using System.Web.Mvc;

namespace eProject.Web.Controllers
{
    public class AdminController : BaseController
    {
        [AdminMode]
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