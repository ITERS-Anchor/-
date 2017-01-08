using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.WebDemos
{
    public partial class NewsList : System.Web.UI.Page
    {
        public List<UserInfo> UserList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = 10;
            int pageIndex;
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }            
            UserInfoBLL bll = new UserInfoBLL();
            int pageCount = bll.GetPageNum(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            UserList=bll.GetPageList(pageIndex,pageSize);
        }
    }
}