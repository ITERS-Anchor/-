using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for EditUser
    /// </summary>
    public class EditUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo user = new UserInfo();
            user.UserId =Convert.ToInt32(context.Request["id"]);
            user.UserName = context.Request["name"];
            user.UserPwd = Common.Encryption.MD5encryption(context.Request["pwd"]);
            UserInfoBLL bll = new UserInfoBLL();
            if (bll.EditUser(user)>0)
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