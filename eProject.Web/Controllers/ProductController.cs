using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using eProject.BusinessLogic.Interfaces;
using eProject.Domain.Entities.Product;
using eProject.Web.App_Start;
using eProject.Web.Extensions;
using eProject.Web.Models;

namespace eProject.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProduct _product;
        public ProductController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductsBL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user == null)
            {
                return View();
            }

            List<string> ProductList = _product.GetProductsList();
            List<decimal> ProductPriceList = _product.GetProductsList1();
            List<string> ProductDescription = _product.GetProductsList2();
            List<string> ImageListURL = _product.GetImageList();

            var product = new UserData
            {
                Username = user.Username,
                NameList = ProductList,
                DescriptionList = ProductDescription,
                PriceList = ProductPriceList,
                imageList = ImageListURL
                
            };

            return View(product);
        }
        
        //public ActionResult Product()
        //{
        //    var user = System.Web.HttpContext.Current.GetMySessionObject();
        //    if (user == null)
        //    {
        //        return View();
        //    }

        //    List<decimal> ProductPriceList = _product.GetProductsList1();
        //    List<string> ProductDescription = _product.GetProductsList2();

        //    var u = new UserData
        //    {
        //        Username = user.Username,
        //        Level = user.Level,
        //        DescriptionList = ProductDescription,
        //        PriceList = ProductPriceList
        //    };

        //    return View(u);
        //}

        [HttpPost]
        public ActionResult Index(string btn)
        {
            return RedirectToAction("Product", "Product", new { product = btn });
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        [AdminMode]
        public ActionResult NewProduct(UserData products)
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

            if (ModelState.IsValid)
            {
                ProductsDatas data = new ProductsDatas
                {
                    Name = products.Name,
                    Description = products.Description,
                    Price = products.Price,
                    imageUrl = products.imageURL
                };

                var productResp = _product.SetProductsList(data);
                if (productResp.Status)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", productResp.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}