using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using JWT;
using JWT.Serializers;

namespace net_ef_training.Auth
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader = from h in actionContext.Request.Headers
                where h.Key == "auth"
                select h.Value.FirstOrDefault();
            if (authHeader != null)
            {
                string token = authHeader.FirstOrDefault();
                if (string.IsNullOrEmpty(token)) return false;
                try
                {
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                    var json = decoder.Decode(token, ConfigurationManager.AppSettings["SecureKey"], verify: true);
                    return true;
                }
                catch (TokenExpiredException)
                {
                   
                    Console.WriteLine("Token has expired");
                    return false;
                }
                catch (SignatureVerificationException)
                {
              
                    Console.WriteLine("Token has invalid signature");
                    return false;
                }
            }
            else
            {
                return false;
            }


            //前端请求api时会将token存放在名为"auth"的请求头中
            //var authHeader = from h in actionContext.Request.Headers where h.Key == "auth" select h.Value.FirstOrDefault();
            //if (authHeader != null) {
            //    string token = authHeader.FirstOrDefault();
            //    if (!string.IsNullOrEmpty(token)) {
            //        try {
            //            //对token进行解密
            //            string secureKey = System.Configuration.ConfigurationManager.AppSettings["SecureKey"];
            //            AuthInfo authInfo = JWT.JsonWebToken.DecodeToObject<AuthInfo>(token, secureKey);
            //            if (authInfo != null) {
            //                //将用户信息存放起来，供后续调用
            //                actionContext.RequestContext.RouteData.Values.Add("auth", authInfo);
            //                return true;
            //            }
            //            else
            //                return false;
            //        }
            //        catch {
            //            return false;
            //        }
            //    }
            //    else
            //        return false;
            //}
            //else
            //    return false;
        }
    }
}