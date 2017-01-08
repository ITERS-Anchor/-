using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for UserDetail
    /// </summary>
    public class UserDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id =Convert.ToInt32(context.Request["id"]);
            UserInfoBLL bll = new UserInfoBLL();
            UserInfo u= bll.GetUserById(id);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(u));
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