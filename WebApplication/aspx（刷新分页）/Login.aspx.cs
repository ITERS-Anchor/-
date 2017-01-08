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
    public partial class Login : System.Web.UI.Page
    {
        public string ErrorMsg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //先看验证码是否匹配
                if (CheckValidationCode())
                {
                    //判断用户名密码是否匹配
                    CheckUserNameAndPwd();                    
                }
                else
                {
                    ErrorMsg = "validateCode is incorrect";
                }               

            }
            else
            {//check cookie
                if (Request.Cookies["ckName"]!=null&&Request.Cookies["ckPwd"]!=null)
                {
                    string name = Request.Cookies["ckName"].Value;
                    string pwd= Request.Cookies["ckPwd"].Value;
                    UserInfoBLL bll = new UserInfoBLL();
                    UserInfo u= bll.GetUserByName(name);
                    if (u!=null)
                    {
                        //if (Encryption.MD5encryption(u.UserPwd)==pwd)
                        if(u.UserPwd==pwd)
                        {
                            Session["LoginName"] = name;
                            Response.Redirect("Index.aspx");
                        }
                    }
                    else
                    {
                        Response.Cookies["ckName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["ckPwd"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
               
            }          
        }
        //验证码校验
        private bool CheckValidationCode()
        {
            bool isSucess = false;
            //string code = Session["code"].ToString();

            if (Session["code"]!=null)
            {
                string txtCode = Request.Form["txtCode"];
                string sysCode = Session["code"].ToString ();
                if (txtCode.Equals(sysCode,StringComparison.InvariantCultureIgnoreCase))//ignore letter case
                {
                    Session["code"] = null;
                    isSucess = true;
                }
            }
            return isSucess;
        }

        //用户名密码校验
        private void CheckUserNameAndPwd()
        {
            string name = Request.Form["name"];
            string password = Encryption.MD5encryption(Request.Form["pwd"]);
            UserInfoBLL bll = new UserInfoBLL();
            #region Method #1
            //UserInfo user = null;
            //string msg = string.Empty;
            //if (bll.CheckLoginUser(name,password,out user,out msg))
            //{
            //    //Session["LoginUser"] = user;
            //    Session["LoginName"] = user.UserName;
            //    Response.Redirect("Index.aspx");
            //}
            //else
            //{
            //    ErrorMsg = msg;
            //}

            #endregion
            #region Method #2
            //判断用户名密码是否匹配
            if (bll.CheckLoginUser(name, password))
            {
                if (!string.IsNullOrEmpty(Request.Form["autoLogin"]))
                {
                    HttpCookie cookie1 = new HttpCookie("ckName", name);
                    cookie1.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie1);
                    HttpCookie cookie2 = new HttpCookie("ckPwd", password);
                    cookie2.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie2);
                }
                Session["LoginName"] = name;
                Response.Redirect("Index.aspx");
            }
            else
            {
                ErrorMsg = "Invalid user name or pswd";
            }

            #endregion
        }
    }
}