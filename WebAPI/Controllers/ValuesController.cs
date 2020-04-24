using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "https://localhost:44397", headers: "*", methods: "*")]


    public class ValuesController : ApiController
    {
        ////[HttpGet]
        ////public Object GetToken()
        ////{
        ////    string key = "my_secret_key_12345";
        ////    var issuer = "http://mysite.com";
        ////    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        ////    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        ////    var permClaims = new List<Claim>();
        ////    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        ////    permClaims.Add(new Claim("valid", "1"));
        ////    permClaims.Add(new Claim("userid", "1"));
        ////    permClaims.Add(new Claim("name", "bilal"));

        ////    var token = new JwtSecurityToken(issuer,
        ////                    issuer,
        ////                    permClaims,
        ////                    expires: DateTime.Now.AddDays(1),
        ////                    signingCredentials: credentials);
        ////    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
        ////    return new { data = jwt_token };


        ////}
        //[HttpGet]
        //public Object ValidateUser(String login, String password)
        //{
        //    Object data = null;
        //    string key = "my_secret_key_12345";
        //    var issuer = "http://mysite.com";
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var permClaims = new List<Claim>();
        //    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //    if (login == "" || password == "")
        //    {
        //        //data = new
        //        //{
        //        //    empty = true,
        //        //    valid = false,
        //        //    urlToRedirect = "",
        //        //    userID = 0,
        //        //    token=""
        //        //};
        //        permClaims.Add(new Claim("empty", "true"));
        //        permClaims.Add(new Claim("userID", "0"));
        //        permClaims.Add(new Claim("valid", "false"));
        //        permClaims.Add(new Claim("urlToRedirect", ""));
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var url = "";
        //            var flag = false;

        //            var obj = BAL.UserBO.ValidateUser(login, password);
        //            if (obj != null)
        //            {
        //                flag = true;
        //                //SessionManager.User = obj;
        //                url = Url.Content("~/User/Home");
        //            }

        //            permClaims.Add(new Claim("empty", "false"));
        //            permClaims.Add(new Claim("userID", obj.UserID.ToString()));
        //            permClaims.Add(new Claim("valid", flag.ToString()));
        //            permClaims.Add(new Claim("urlToRedirect", url));

        //        }
        //        catch (Exception)
        //        {

        //            permClaims.Add(new Claim("empty", "false"));
        //            permClaims.Add(new Claim("userID", "0"));
        //            permClaims.Add(new Claim("valid", "false"));
        //            permClaims.Add(new Claim("urlToRedirect", ""));
        //        }
        //    }


        //    var token = new JwtSecurityToken(issuer,
        //                    issuer,
        //                    permClaims,
        //                    expires: DateTime.Now.AddDays(1),
        //                    signingCredentials: credentials);
        //    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

        //    return new { data = jwt_token };


        //}
        [HttpGet]
        public Object GetChildFolders(String pfid)
        {
            Object data = null;

            List<FolderDTO> list = new List<FolderDTO>();
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {

                    IEnumerable<Claim> claims = identity.Claims;
                    //var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                    //return new
                    //{
                    //    data = name
                    //};
                    try
                    {

                        var id = Convert.ToInt32(claims.Where(p => p.Type == "userid").FirstOrDefault()?.Value);
                        var obj = BAL.FolderBO.GetChildFolders(Convert.ToInt32(pfid), id);
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

                }
            }
            else
            {
                data = new
                {
                    response = "",
                };
            }
            return data;
        }
        //public JsonResult GetChildFolders(String pfid)
        //{

        //    Object data = null;

        //    List<FolderDTO> list = new List<FolderDTO>();
        //    try
        //    {


        //        var obj = BAL.FolderBO.GetChildFolders(Convert.ToInt32(pfid), SessionManager.User.UserID); ;
        //        if (obj != null)
        //        {
        //            list = obj;
        //        }

        //        data = new
        //        {
        //            response = list,
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        data = new
        //        {
        //            response = "",
        //        };
        //    }

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //// var d={"newFolderName":n,"pfid":i};
        ////public JsonResult Create(String newFolderName, String pfid)
        ////{

        ////    Object data = null;
        ////    if (newFolderName == "")
        ////    {
        ////        data = new
        ////        {
        ////            empty = true,
        ////            valid = false,
        ////        };
        ////    }
        ////    else
        ////    {
        ////        try
        ////        {

        ////            var dto = new FolderDTO();
        ////            dto.FolderName = newFolderName;
        ////            dto.ParentFolderID = Convert.ToInt32(pfid);
        ////            dto.UserID = SessionManager.User.UserID;
        ////            var save = BAL.FolderBO.Save(dto);

        ////            data = new
        ////            {
        ////                empty = false,
        ////                valid = true,
        ////            };
        ////        }
        ////        catch (Exception)
        ////        {
        ////            data = new
        ////            {
        ////                empty = false,
        ////                valid = false,
        ////            };
        ////        }
        ////    }
        ////    return Json(data, JsonRequestBehavior.AllowGet);
        ////}
        ////[HttpPost]
        ////public JsonResult save(String Name, String Login, String Password)
        ////{
        ////    Object data = null;
        ////    if (Name == "" || Login == "" || Password == "")
        ////    {
        ////        data = new
        ////        {
        ////            empty = true,
        ////            valid = false,
        ////            urlToRedirect = ""
        ////        };
        ////    }
        ////    else
        ////    {
        ////        try
        ////        {
        ////            var url = "";
        ////            var flag = false;

        ////            var obj = BAL.UserBO.ValidateUser(Login, Password);
        ////            if (obj == null)
        ////            {
        ////                var dto = new UserDTO();
        ////                dto.Login = Login;
        ////                dto.Password = Password;
        ////                dto.Name = Name;
        ////                var save = BAL.UserBO.Save(dto);
        ////                flag = true;
        ////                obj = BAL.UserBO.ValidateUser(Login, Password);
        ////                SessionManager.User = obj;
        ////                url = Url.Content("~/User/Home");
        ////            }

        ////            data = new
        ////            {
        ////                empty = false,
        ////                valid = flag,
        ////                urlToRedirect = url
        ////            };
        ////        }
        ////        catch (Exception)
        ////        {
        ////            data = new
        ////            {
        ////                empty = false,
        ////                valid = false,
        ////                urlToRedirect = ""
        ////            };
        ////        }
        ////    }
        ////    return Json(data, JsonRequestBehavior.AllowGet);
        ////}
        [HttpGet]
        public int GetData1()
        {
            return 10;
        }

        [HttpGet]
        public int GetData2(int a, int b) //Get data from query string
        {
            return a + b;
        }

        [HttpPost]
        public object Save(UserDTO dto) //Get data from body
        {
            object data = null;
            UserDTO dto2 = null;
            if (dto.Login=="" || dto.Password=="")
            {
                data = new
                {
                    token = "",
                    User=dto2,

                };
            }
            else
            {
                var obj = BAL.UserBO.ValidateUser(dto.Login, dto.Password);
                if(obj==null)
                {
                    data = new
                    {
                        token = "",
                        User = dto2,

                    };
                }
                else
                {
                    string key = "my_secret_key_12345";
                    var issuer = "http://mysite.com";
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var permClaims = new List<Claim>();
                    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    //permClaims.Add(new Claim("valid", "1"));
                    permClaims.Add(new Claim("userid", obj.UserID.ToString()));
                    //permClaims.Add(new Claim("name", "bilal"));

                    var token = new JwtSecurityToken(issuer,
                                    issuer,
                                   permClaims,
                                    expires: DateTime.Now.AddDays(1),
                                    signingCredentials: credentials);
                    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                    data = new
                    {
                        token = jwt_token,
                        User = obj,
                    };
                }
            }
            
            return data;
        }
    }
 public class StudentDTO
    {
        public int id { get; set; }
        public String name { get; set; }
    }

    
}
