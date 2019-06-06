﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using net_ef_training.Auth;
using net_ef_training.Extensions;
using net_ef_training.Models.Erp;

namespace net_ef_training.Controllers
{
 
    public class LoginController : ApiController
    {
        private readonly ErpDbContext _dbContext;

        public LoginController()
        {
            _dbContext = new ErpDbContext();
        }

        [Route("api/Oauth/Auth")]
        [HttpGet]
        public IHttpActionResult aaa(string username, string password)
        {
            var response = ResponseModelFactory.CreateInstance;
            DncUser user;
            using (_dbContext)
            {
                user = _dbContext.DncUser.FirstOrDefault(x => x.LoginName == username.Trim());
                if (user == null || user.IsDeleted == CommonEnum.IsDeleted.Yes)
                {
                    response.SetFailed("用户不存在");
                    return Ok(response);
                }

                if (user.Password != password.Trim())
                {
                    response.SetFailed("密码不正确");
                    return Ok(response);
                }

                if (user.IsLocked == CommonEnum.IsLocked.Locked)
                {
                    response.SetFailed("账号已被锁定");
                    return Ok(response);
                }

                if (user.Status == UserStatus.Forbidden)
                {
                    response.SetFailed("账号已被禁用");
                    return Ok(response);
                }



                var role = getRoles(user.Guid.ToString());
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtClaimTypes.Audience, "api"),
                    new Claim(JwtClaimTypes.Issuer, "http://localhost:54321"),
                    new Claim(JwtClaimTypes.Id, user.Guid.ToString()),
                    new Claim(JwtClaimTypes.Name, username),
                    new Claim("displayName", user.DisplayName),
                    new Claim("loginName", user.LoginName),
                    new Claim("avatar", ""),
                    new Claim(JwtClaimTypes.Email, ""),
                    new Claim("guid", user.Guid.ToString()),
                    new Claim("userType", ((int) user.UserType).ToString()),
                    new Claim("r", role),
                    //   new Claim(ClaimTypes.Role,role), 
                    new Claim(JwtClaimTypes.NotBefore,
                        new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString())

                    //new Claim(ClaimTypes.Name, username),
                    //new Claim("guid",user.Guid.ToString()),
                    //new Claim("avatar",""),
                    //new Claim("displayName",user.DisplayName),
                    //new Claim("loginName",user.LoginName),
                    //new Claim("emailAddress",""),
                    //new Claim("guid",user.Guid.ToString()),
                    //new Claim("userType",((int)user.UserType).ToString())
                });

                var payload = new Dictionary<string, object>
                {
                    {"Guid", user.Guid},
                    {"exp", DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds()}
                };
                
                    //生成token,SecureKey是配置的web.config中，用于加密token的key，打死也不能告诉别人
                    byte[] key = Encoding.Default.GetBytes(ConfigurationManager.AppSettings["SecureKey"]);
                    //采用HS256加密算法
                    IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                    var token = encoder.Encode(payload, key);
                    response.SetData(token);
                    return Ok(response);
            }
        }


        private string getRoles(string guid) {
            if (string.IsNullOrEmpty(guid)) return string.Empty;

            var sql = @"SELECT R.* FROM DncUserRoleMapping AS URM
INNER JOIN DncRole AS R ON R.Code=URM.RoleCode
WHERE URM.UserGuid=@p0";

            
            return _dbContext.DncRole.SqlQuery(sql, guid).Select(x => x.Name).FirstOrDefault();
            //  return query.Any(any => any.Name == "super_adminstrator");
        }
    }
}
