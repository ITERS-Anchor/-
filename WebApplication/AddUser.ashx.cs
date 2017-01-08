using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    /// <summary>
    /// Summary description for AddUser
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
            UserInfo user = new UserInfo();
            user.UserName=context.Request.Form["name"];
            user.UserPwd=context.Request.Form["pwd"];
            UserInfoBLL bll = new UserInfoBLL();
            if (bll.AddUser(user)>0)
            {
                context.Response.Redirect("UserInfoList.ashx");
            }
            else
            {
                context.Response.Write("Error");
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