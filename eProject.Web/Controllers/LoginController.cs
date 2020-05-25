using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using eProject.BusinessLogic.Interfaces;
using eProject.Domain.Entities.User;
using eProject.Web.Models;

namespace eProject.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLoginData login)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserLoginData, ULoginData>());
                var mapper = new Mapper(config);
                var data = mapper.Map<ULoginData>(login);

                data.LoginDateTime  = DateTime.Now;
                data.LoginIp = Request.UserHostAddress;

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", userLogin.StatusMsg);
                return View();
            }
            return View(login);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
            {
                var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}