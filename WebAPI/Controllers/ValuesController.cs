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
        [HttpGet]
        public Object Create([FromUri]CreateFolderDTO dto1)
        {

            Object data = null;
            if (dto1.NewFolderName == null)
            {
                data = new
                {
                    empty = true,
                    valid = false,
                };
            }
            else
            {
                if (User.Identity.IsAuthenticated)
                {
                    var identity = User.Identity as ClaimsIdentity;
                    if (identity != null)
                    {

                        IEnumerable<Claim> claims = identity.Claims;
                        try
                        {

                            var dto = new FolderDTO();
                            dto.FolderName = dto1.NewFolderName;
                            dto.ParentFolderID = Convert.ToInt32(dto1.pfID);
                            dto.UserID = Convert.ToInt32(claims.Where(p => p.Type == "userid").FirstOrDefault()?.Value);
                            var save = BAL.FolderBO.Save(dto);

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
                                valid = false,
                            };
                        }
                    }
                }
            }
            return data;
        }


        [HttpPost]
        public object Save(UserDTO dto)
        {
            object data = null;
            UserDTO dto2 = null;
            if (dto.Login == "" || dto.Password == "")
            {
                data = new
                {
                    token = "",
                    User = dto2,

                };
            }
            else
            {
                var obj = BAL.UserBO.ValidateUser(dto.Login, dto.Password);
                if (obj == null)
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

                    permClaims.Add(new Claim("userid", obj.UserID.ToString()));


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

        [HttpPost]
        public Object Save2(UserDTO dto1)
        {
            Object data = null;
            if (dto1.Name == null || dto1.Login == null || dto1.Password == null)
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

                    var obj = BAL.UserBO.ValidateUser(dto1.Login, dto1.Password);
                    if (obj == null)
                    {
                        var dto = new UserDTO();
                        dto.Login = dto1.Login;
                        dto.Password = dto1.Password;
                        dto.Name = dto1.Name;
                        var save = BAL.UserBO.Save(dto);
                        flag = true;
                        obj = BAL.UserBO.ValidateUser(dto1.Login, dto1.Password);

                    }

                    data = new
                    {
                        empty = false,
                        valid = flag,

                    };
                }
                catch (Exception)
                {
                    data = new
                    {
                        empty = false,
                        valid = false,

                    };
                }
            }
            return data;
        }
    }
}
