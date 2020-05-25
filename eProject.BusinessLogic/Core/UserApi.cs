using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using eProject.BusinessLogic.DBModel;
using eProject.BusinessLogic.DBModel.Seed;
using eProject.Domain.Entities.Product;
using eProject.Domain.Entities.User;
using eProject.Domain.Enums;
using eProject.Helpers;

namespace eProject.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UserDatas result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp {Status = false, StatusMsg = "The Email or Password is Incorrect"};
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp {Status = true, StatusMsg = "Registration Successfull! " +
                                                                  "Redirectind to login page in 5 seconds."
                };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp {Status = false, StatusMsg = "The Username or Password is Incorrect"};
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp {Status = true, StatusMsg = "Registration Successful! " +
                                                                  "Redirecting to login page in 5 seconds."};
            }
        }

        internal HttpCookie Cookie(string loginCredenntial)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredenntial)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredenntial))
                    curent = (from e in db.Sessions where e.Username == loginCredenntial select e).FirstOrDefault();
                else
                    curent = (from e in db.Sessions where e.Username == loginCredenntial select e).FirstOrDefault();

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredenntial,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal URegisterResp RegisterState(UserDatas user)
        {
            using (var db = new UserContext())
            {
                var pass = LoginHelper.HashGen(user.Password);
                var passrepeat = LoginHelper.HashGen(user.RepeatPassword);
                user.Password = pass;
                user.RepeatPassword = passrepeat;
                user.Level = URole.User;

                if (db.Users.Any(x => x.Username == user.Username))
                {
                    return new URegisterResp() {Status = false, StatusMsg = "The Username already exist! Please try again."};
                }

                if (db.Users.Any(x => x.Email == user.Email))
                {
                    return new URegisterResp() { Status = false, StatusMsg = "The Email already exist! Please try again." };
                }

                db.Users.Add(user);
                db.SaveChanges();
                return new URegisterResp() { Status = true, StatusMsg = "" };
            }
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UserDatas curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDatas, UserMinimal>());
            var mapper = new Mapper(config);
            var userminimal = mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }

        internal List<decimal> ProductListLogic1()
        {
            List<ProductsDatas> products;
            List<decimal> local = new List<decimal>();
            using(var db = new ProductsContext())
            {
                products = db.Products.ToList();
            }

            foreach (var p in products)
            {
                local.Add(p.Price);
            }
            return local;
        }

        internal List<string> ProductListLogic()
        {
            List<ProductsDatas> products;
            List<string> local = new List<string>();
            using (var db = new ProductsContext())
            {
                products = db.Products.ToList();
            }

            foreach (var p in products)
            {
                local.Add(p.Name);
            }
            return local;
        }

        internal List<string> ProductListLogic2()
        {
            List<ProductsDatas> products;
            List<string> local = new List<string>();
            using (var db = new ProductsContext())
            {
                products = db.Products.ToList();
            }

            foreach (var p in products)
            {
                local.Add(p.Description);
            }
            return local;
        }

        internal List<string> ImageListLogicURL()
        {
            List<ProductsDatas> products;
            List<string> local = new List<string>();
            using (var db = new ProductsContext())
            {
                products = db.Products.ToList();
            }

            foreach (var p in products)
            {
                local.Add(p.imageUrl);
            }
            return local;
        }

        internal ProductsResp AddProducts(ProductsDatas products)
        {
            using (var db = new ProductsContext())
            {
                db.Products.Add(products);
                db.SaveChanges();
                return new ProductsResp() { Status = true, StatusMsg = "" };
            }
        }
    }
}