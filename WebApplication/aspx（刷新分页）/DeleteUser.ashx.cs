using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.aspx
{
    /// <summary>
    /// Summary description for DeleteUser
    /// </summary>
    public class DeleteUser : IHttpHandler
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
                    context.Response.Redirect("Index.aspx");
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