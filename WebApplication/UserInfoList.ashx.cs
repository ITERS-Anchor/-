using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;
using System.IO;
using System.Text;

namespace WebApplication
{
    /// <summary>
    /// Summary description for UserInfoList
    /// </summary>
    public class UserInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            UserInfoBLL bll = new UserInfoBLL();
            List<UserInfo> list= bll.GetAllUsers();
            StringBuilder sb = new StringBuilder();
            foreach (UserInfo user in list)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td><a href='Edit.ashx?id={0}'>Edit</a></td><td><a class='delete' href='Delete.ashx?id={0}'>Delete</a></td></tr>", user.UserId, user.UserName, user.UserPwd);
            }
            
            string file = context.Request.MapPath("UserInfoList.html");
            string content = File.ReadAllText(file);
            content = content.Replace("$tbody", sb.ToString());
            context.Response.Write(content);
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