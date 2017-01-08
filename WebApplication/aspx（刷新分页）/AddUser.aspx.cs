using BLL;
using Model;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.aspx
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!string .IsNullOrEmpty(Request.Form["isPostBack"]))
            if(IsPostBack)
            {
                UserInfo user = new UserInfo();
                user.UserName = Request.Form["name"];
                user.UserPwd =Encryption.MD5encryption(Request.Form["pwd"]);
                UserInfoBLL bll = new UserInfoBLL();
                if (bll.AddUser(user) > 0)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Response.Write("Error");
                }

            }            
        }
    }
}