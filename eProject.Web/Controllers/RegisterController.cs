using System;
using System.Web.Mvc;
using AutoMapper;
using eProject.BusinessLogic.Interfaces;
using eProject.Domain.Entities.User;
using eProject.Web.Models;

namespace eProject.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegister _register;
        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _register = bl.GetRegisterBL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserRegisterData userModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegisterData, UserDatas>());
            var mapper = new Mapper(config);
            var user = mapper.Map<UserDatas>(userModel);

            user.LastLogin = DateTime.Now;
            user.LastIp = Request.UserHostAddress;

            URegisterResp userStatus = _register.UserRegisterAction(user);

            if (userStatus.Status)
            {
                ModelState.AddModelError("", userStatus.StatusMsg);
                return RedirectToAction("Index", "Login");
            }

            ModelState.AddModelError("", userStatus.StatusMsg);
            return View("Index");
        }
    }
}