using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models.ViewModels;
using TestProject.Models;
using TestProject.Security;

namespace TestProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Verify(Autentication model) {
            if (!ModelState.IsValid) {
            }
            using (TestProjectEntities db = new TestProjectEntities()) {
                string pass = Encrypt.GetSHA256(model.pass);
                var list = (from d in db.User where d.email == model.email && d.pass == pass && d.idState == 1 select d);
                if (list.Count() > 0) {
                    User us = list.First();
                    Session["user"] = us;
                    return Content("1");
                }
                return Content("0");
            }
            
            
        }
        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model) {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (TestProjectEntities db = new TestProjectEntities())
            {
                User us = new User();
                us.idState = 1;
                us.email = model.email;
                us.edad = model.age;
                us.pass = Encrypt.GetSHA256(model.password);
                db.User.Add(us);
                db.SaveChanges();
                
            }
            return Redirect(Url.Content("~/Login/Login"));
        }
        
        public ActionResult Register()
        {
            
            return View();
            
        }
    }
}