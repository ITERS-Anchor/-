using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace WebApplication.aspx
{
    /// <summary>
    /// Summary description for ValidateCode
    /// </summary> 
    public class ValidateCode : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {//                                  #### #一般处理程序中如果要用session，必须条件上边这个接口   
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Common.ValidateCode vc = new Common.ValidateCode();
            string code=vc.CreateValidateCode(4);
            context.Session["code"] = code;//#### #
            vc.CreateValidateGraphic(code,context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}