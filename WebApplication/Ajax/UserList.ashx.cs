using BLL;
using Model;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Ajax
{
    /// <summary>
    /// Summary description for UserList
    /// </summary>
    public class UserList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageIndex;
            if (!int.TryParse(context.Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }
            UserInfoBLL bll = new UserInfoBLL();
            int pageSize = 3;
            int pageCount = bll.GetPageNum(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<UserInfo> list = bll.GetPageList(pageIndex,pageSize);
            //List<UserInfo> list= bll.GetAllUsers();
            string strPageBar = PageBar.GetPageBar(pageIndex,pageCount);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            //context.Response.Write(js.Serialize(list));
            context.Response.Write(js.Serialize(new { myList = list, myPageBar = strPageBar }));
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