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
        
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.error = TempData["message"];
            return View();
        }
        [HttpPost]
        public JsonResult ValidateUser(String login, String password)
        {
            Object data = null;
            if (login == "" || password == "")
            {
                data = new
                {
                    empty = true,
                    valid = false,
                    urlToRedirect = ""
                };
            }
            else
            {
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
                        empty = false,
                        valid = flag,
                        urlToRedirect = url
                    };
                }
                catch (Exception)
                {
                    data = new
                    {
                        empty = false,
                        valid = false,
                        urlToRedirect = ""
                    };
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetChildFolders(String pfid)
        {

            Object data = null;

            List<FolderDTO> list = new List<FolderDTO>();
            try
            {
                var obj = BAL.FolderBO.GetChildFolders(Convert.ToInt32(pfid), SessionManager.User.UserID); ;
                if (obj != null)
                {
                    list = obj;
                }

                data = new
                {
                    response = list,
                };
            }
            catch (Exception)
            {
                data = new
                {
                    response = "",
                };
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Create(String newFolderName, String pfid)
        {

            Object data = null;
            if (newFolderName == "")
            {
                data = new
                {
                    empty = true,
                    valid = false,
                };
            }
            else
            {
                try
                {
                    var flag = false;
                    var dto = new FolderDTO();
                    dto.FolderName = newFolderName;
                    dto.ParentFolderID = Convert.ToInt32(pfid);
                    dto.UserID = SessionManager.User.UserID;
                    var save = BAL.FolderBO.Save(dto);
                    flag = true;
                    data = new
                    {
                        empty = false,
                        valid = true,
                    };
                }
                catch (Exception)
                {
                    data = new
                    {
                        empty = false,
                        valid = false
                    };
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Home()
        {

            if (SessionManager.IsValidUser)
            {
                return View();
            }
            else
            {
                TempData["message"] = "unauthorized access!";
                return Redirect("~/User/Login");
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            SessionManager.ClearSession();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult save(String Name, String Login, String Password)
        {
            Object data = null;
            if (Name == "" || Login == "" || Password == "")
            {
                data = new
                {
                    empty = true,
                    valid = false,
                    urlToRedirect = ""
                };
            }
            else
            {
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
                        obj = BAL.UserBO.ValidateUser(Login, Password);
                        SessionManager.User = obj;
                        url = Url.Content("~/User/Home");
                    }

                    data = new
                    {
                        empty = false,
                        valid = flag,
                        urlToRedirect = url
                    };
                }
                catch (Exception)
                {
                    data = new
                    {
                        empty = false,
                        valid = false,
                        urlToRedirect = ""
                    };
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}