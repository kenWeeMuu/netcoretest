using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using net_ef_training.Auth;

namespace net_ef_training.Controllers
{
    public class LoginController : ApiController
    {
        [Route("login")]
        [HttpGet]
        public LoginResult aaa(LoginRequest request) {
            LoginResult rs = new LoginResult();
            //假设用户名为"admin"，密码为"123"
            if (request.UserName == "admin" && request.Password == "123") {
                //如果用户登录成功，则可以得到该用户的身份数据。当然实际开发中，这里需要在数据库中获得该用户的角色及权限
                IDateTimeProvider provider = new UtcDateTimeProvider();
                var now = provider.GetNow();
                var unixEpoch = UnixEpoch.Value; // 1970-01-01 00:00:00 UTC
                var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);

                AuthInfo authInfo = new AuthInfo
                {
                    IsAdmin = true,
                    Roles = new List<string> {"admin", "owner"},
                    UserName = "admin"
                };

                    var payload = new Dictionary<string,object>
                    {
                        {"authInfo",authInfo },
                        {"exp", DateTimeOffset.UtcNow.AddSeconds(30).ToUnixTimeSeconds()}
                    };
                try {
                    //生成token,SecureKey是配置的web.config中，用于加密token的key，打死也不能告诉别人
                    byte[] key = Encoding.Default.GetBytes(ConfigurationManager.AppSettings["SecureKey"]);
                    //采用HS256加密算法
                    IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                    var token = encoder.Encode(payload, key);
                    rs.Token = token;
                    rs.Success = true;

                }
                catch {
                    rs.Success = false;
                    rs.Message = "登陆失败";
                }
            }
            else {
                rs.Success = false;
                rs.Message = "用户名或密码不正确";
            }
            return rs;
        }
    }
}
