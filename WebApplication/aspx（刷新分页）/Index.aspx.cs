using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.aspx
{
    public partial class Index : System.Web.UI.Page
    {
        public List<UserInfo> UserList { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public string LoginName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"] != null)
            {
                LoginName = Session["LoginName"].ToString();

                UserInfoBLL bll = new UserInfoBLL();
                int pageSize = 3;
                if (!IsPostBack)
                {
                    int pageIndex;
                    if (!int.TryParse(Request.QueryString["page"], out pageIndex))
                    {
                        pageIndex = 1;
                    }
                    PageCount = bll.GetPageNum(pageSize);
                    pageIndex = pageIndex < 1 ? 1 : pageIndex;
                    pageIndex = pageIndex > PageCount ? PageCount : pageIndex;
                    PageIndex = pageIndex;
                    UserList = bll.GetPageList(pageIndex, pageSize);

                }
                else
                {
                    int gopage;
                    if (!int.TryParse(Request.Form["goPage"], out gopage))
                    {
                        gopage = Convert.ToInt32(Request.Form["crtPage"]);
                    }
                    PageCount = bll.GetPageNum(pageSize);
                    gopage = gopage < 1 ? 1 : gopage;
                    gopage = gopage > PageCount ? PageCount : gopage;
                    PageIndex = gopage;
                    UserList = bll.GetPageList(gopage, pageSize);
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}