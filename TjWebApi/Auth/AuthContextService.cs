using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using ErpDb.Entitys;
using JWT;
using JWT.Serializers;
using Newtonsoft.Json;

namespace TjWebApi.Auth
{
    public static class AuthContextService
    {
        public static  void SetPrincipal(IPrincipal principal) {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null) {
                HttpContext.Current.User = principal;
            }
        }
        public static HttpContext Current => HttpContext.Current; 
//        public static AuthContextUser Currentuser
//        {
//            get
//            {
//
//                ClaimsIdentity identity = Current.User;
//
//                var user = new AuthContextUser
//                {
//                    LoginName = Current.User.FindFirstValue(ClaimTypes.NameIdentifier),
//                    DisplayName = Current.User.FindFirstValue("displayName"),
//                    EmailAddress = Current.User.FindFirstValue("emailAddress"),
//                    UserType = (UserType)Convert.ToInt32(Current.User.FindFirstValue("userType")),
//                    Avator = Current.User.FindFirstValue("avator"),
//                    Guid = new Guid(Current.User.FindFirstValue("guid"))
//                };
//                return user;
//            }
//        }

        public static User CurrentUser(this HttpActionContext actionContext,ErpDbContext dbContext)
        {  
         
           var json = actionContext.getToken();
           Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
           var userid = int.Parse(dic["UserId"].ToString());
          return  dbContext.Users.FirstOrDefault(x => x.UserId == userid);
        }
 
        public static string getToken(this HttpActionContext actionContext)
        {
          var par =  actionContext.Request.Headers.Authorization.Parameter;
        //  Where(x => x.Key == "Authorization").
            try {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(par, ConfigurationManager.AppSettings["SecureKey"], verify: true);
                return json;
            }
            catch (TokenExpiredException) {

                Console.WriteLine("Token has expired");
                return "Token has expired";
            }
            catch (SignatureVerificationException) {

                Console.WriteLine("Token has invalid signature");
                return "Token has invalid signature";
            }
        }
    }
}