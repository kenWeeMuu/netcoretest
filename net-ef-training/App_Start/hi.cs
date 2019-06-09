using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace net_ef_training
{
    public class Cores : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionExecutedContext) 
        {
          
          
            base.OnActionExecuting(actionExecutedContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) {
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            base.OnActionExecuted(actionExecutedContext);
        }
         

//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            base.OnActionExecuting(actionContext);
//             
////            if (!actionContext.Request.Method.Method.ToLower().Equals("get") &&
////                !actionContext.Request.Method.Method.ToLower().Equals("post")) return;
////            else {
////               
////            }
//        }
    }
}
