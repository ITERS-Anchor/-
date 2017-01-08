using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for AddUser
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo user = new UserInfo();
            user.UserName = context.Request["name"];
            user.UserPwd =Common.Encryption.MD5encryption(context.Request["pwd"]);
            
            UserInfoBLL bll = new UserInfoBLL();
            if (bll.AddUser(user)>0)
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