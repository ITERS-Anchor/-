using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication
{
    /// <summary>
    /// Summary description for Edit
    /// </summary>
    public class Edit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"],out id))
            {
                UserInfoBLL bll = new UserInfoBLL();
                UserInfo user= bll.GetUserById(id);
                string file = context.Request.MapPath("Edit.html");
                string content = File.ReadAllText(file);
                content = content.Replace("$UserId", user.UserId.ToString()).Replace("$UserName",user.UserName.ToString()).Replace("$UserPwd", user.UserPwd.ToString());
                context.Response.Write(content);
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