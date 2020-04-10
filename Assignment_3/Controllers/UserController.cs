using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPrac.Security;

namespace Assignment_3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ValidateUser(String login, String password)
        {

            Object data = null;

            try
            {
                var url = "";
                var flag = false;

                var obj = BAL.UserBO.ValidateUser(login, password);
                if (obj != null)
                {
                    flag = true;
                    SessionManager.User = obj;
                    url = Url.Content("~/User/Home");
                }

                data = new
                {
                    valid = flag,
                    urlToRedirect = url
                };
            }
            catch (Exception)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""
                };
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult save(String Name, String Login, String Password)
        {
            Object data = null;
            //var obj = BAL.UserBO.ValidateUser(Login, Password);

            //if(obj==null)
            //{
            //    var dto = new UserDTO();
            //    dto.Login = Login;
            //    dto.Password = Password;
            //    dto.Name = Name;
            //    var save = BAL.UserBO.Save(dto);
            //    SessionManager.User = obj;
            //    url = Url.Content("~/User/Home");
            //    data = new
            //    {
            //        valid = true,
            //        urlToRedirect = ""
            //    };
            //}
            try
            {
                var url = "";
                var flag = false;

                var obj = BAL.UserBO.ValidateUser(Login, Password);
                if (obj == null)
                {
                    var dto = new UserDTO();
                    dto.Login = Login;
                    dto.Password = Password;
                    dto.Name = Name;
                    var save = BAL.UserBO.Save(dto);
                    flag = true;
                    SessionManager.User = obj;
                    url = Url.Content("~/User/Home");
                }

                data = new
                {
                    valid = flag,
                    urlToRedirect = url
                };
            }
            catch (Exception)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}