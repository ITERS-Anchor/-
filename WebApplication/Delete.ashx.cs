using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    /// <summary>
    /// Summary description for Delete
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                UserInfoBLL bll = new UserInfoBLL();
                if (bll.DeleteUser(id))
                {
                    context.Response.Redirect("UserInfoList.ashx");
                }
                else
                {
                    context.Response.Write("error");
                }

            }
            else
            {
                context.Response.Write("Parameters error");
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