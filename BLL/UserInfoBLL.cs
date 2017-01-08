using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal = new UserInfoDAL();
        public List<UserInfo> GetAllUsers()
        {
            return dal.GetAllUsers();
        }

        public int AddUser(UserInfo user)
        {
            return dal.AddUser(user);
        }
        public bool DeleteUser(int id)
        {
            return dal.DeleteUser(id)>0;
        }
        public UserInfo GetUserById(int id)
        {
            return dal.GetUserById(id);
        }
        public UserInfo GetUserByName(string name)
        {
            return dal.GetUserByName(name);
        }
        #region CheckLoginUser Method #1
        //public bool CheckLoginUser(string name,string pwd,out UserInfo user,out string msg)
        //{
        //    user = dal.GetUserByName(name);
        //    if (user!= null)
        //    {                
        //        if (user.UserPwd==pwd)
        //        {
        //            msg = "Login successful";
        //            return true;
        //        }
        //        else
        //        {
        //            //invalid pwd
        //            msg = "Invalid name or pswd";
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        //user not exist
        //        msg = "User not exist";
        //        return false;
        //    }
        //}

        #endregion


        #region CheckLoginUser Method #2
        public bool CheckLoginUser(string name, string pwd)
        {
            UserInfo user = dal.GetUserByName(name);
            if (user != null)
            {
                if (user.UserPwd == pwd)
                {
                    return true;
                }
                else
                {
                    //invalid pwd
                    return false;
                }
            }
            else
            {
                //user not exist
                return false;
            }
        }

        #endregion
        public int EditUser(UserInfo user)
        {
            return dal.EditUser(user);
        }
        public int GetPageNum(int pagesize)
        {
            int rcount = dal.GetRecordNum();
            int pcount = Convert.ToInt32(Math.Ceiling((double)rcount / pagesize));
            return pcount;
        }
        public List<UserInfo> GetPageList(int pageIndex, int pageSize)
        {
            int start =(pageIndex-1)*pageSize+1;
            int end = pageIndex*pageSize;
            return dal.GetPageList(start,end);
        }
    }
}
