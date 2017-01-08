using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for ValidateLogin
    /// </summary>
    public class ValidateLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
            string password =Common.Encryption.MD5encryption(context.Request["pwd"]);
            UserInfoBLL bll = new UserInfoBLL();
            if (bll.CheckLoginUser(name, password))
            {
                context.Session["LoginName"] = name;
                context.Response.Write("yes");
            }
            else
            {
                context.Response.Write("no");
            }
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