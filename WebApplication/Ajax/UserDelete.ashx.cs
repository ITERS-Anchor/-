using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for UserDelete
    /// </summary>
    public class UserDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);
            UserInfoBLL bll = new UserInfoBLL();
            if (bll.DeleteUser(id))
            {
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