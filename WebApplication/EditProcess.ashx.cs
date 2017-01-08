using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;

namespace WebApplication
{
    /// <summary>
    /// Summary description for EditProcess
    /// </summary>
    public class EditProcess : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            UserInfoBLL bll = new UserInfoBLL();
         
            int id = Convert.ToInt32(context.Request.Form["id"]);
            UserInfo user = bll.GetUserById(id);
            if (user!=null)
            {
                user.UserId = id;
                user.UserName = context.Request.Form["name"];
                user.UserPwd = context.Request.Form["pwd"];
                //bll.EditUser(user);
                if (bll.EditUser(user) > 0)
                {
                    context.Response.Redirect("UserInfoList.ashx");
                }
                else
                {
                    context.Response.Write("Edit Faild");
                }
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