using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.aspx
{
    public partial class EditUser : System.Web.UI.Page
    {
        public UserInfo EdUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoBLL bll = new UserInfoBLL();
            if (!IsPostBack)
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {                   
                    EdUser = bll.GetUserById(id);
                }
                else
                {
                    Response.Write("paras Error");
                }
            }
            else
            {
                UserInfo user = new UserInfo();
                user.UserId =Convert.ToInt32( Request.Form["id"]);
                user.UserName = Request.Form["name"];
                user.UserPwd = Encryption.MD5encryption(Request.Form["pwd"]);

                if (bll.EditUser(user) > 0)
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