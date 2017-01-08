using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for ValidateUserName
    /// </summary>
    public class ValidateUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];
            UserInfoBLL bll = new UserInfoBLL();
            if (bll.GetUserByName(name)!=null)
            {
                context.Response.Write("User name already taken");
            }
            else
            {
                context.Response.Write("ok");
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