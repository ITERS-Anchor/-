using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserInfoDAL
    {
        public int AddUser(UserInfo user)
        {
            string sql = "insert into UserInfo (UserName,UserPwd) values(@UserName,@UserPwd)";
            SqlParameter[] ps = { new SqlParameter("@UserName", user.UserName), new SqlParameter("@UserPwd", user.UserPwd) };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        
        public int DeleteUser(int id)
        {
            string sql = "delete from UserInfo where UserId=@UserId";
            SqlParameter[] ps = { new SqlParameter("@UserId", id) };
            return SqlHelper.ExecuteNonQuery(sql,ps);
        }
        public int EditUser(UserInfo user)
        {
            string sql = "update UserInfo set UserName=@UserName,UserPwd=@UserPwd where UserId="+ user.UserId;
            SqlParameter[] ps = { new SqlParameter("@UserName", user.UserName), new SqlParameter("@UserPwd", user.UserPwd)};
            return SqlHelper.ExecuteNonQuery(sql,ps);
        }
        public int GetRecordNum()
        {
            string sql ="select count(*) from UserInfo";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
        }
        public  UserInfo GetUserByName(string name)
        {
            string sql = "select * from UserInfo where UserName=@UserName";
            SqlParameter[] ps = { new SqlParameter("@UserName", name) };
            DataTable dt = SqlHelper.ExecuteTable(sql, ps);
            UserInfo user = null;
            if (dt.Rows.Count > 0)
            {
                user = new UserInfo();
                user.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                user.UserName = dt.Rows[0]["UserName"].ToString();
                user.UserPwd = dt.Rows[0]["UserPwd"].ToString();
            }
            return user;
        }
        public List<UserInfo> GetPageList(int start,int end)
        {
            string sql = "select * from(select *,ROW_NUMBER() over(order by UserId) as rowIndex from UserInfo) as t1 where rowindex between @start and @end";
            SqlParameter[] ps = { new SqlParameter("@start", start), new SqlParameter("@end", end) };
            DataTable dt = SqlHelper.ExecuteTable(sql,ps);
            List<UserInfo> userList = null;
            if (dt.Rows.Count > 0)
            {
                userList = new List<UserInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    userList.Add(RowToUserInfo(dt.Rows[i]));
                }
            }
            return userList;
        }
        public UserInfo GetUserById(int id)
        {          
            string sql = "select * from UserInfo where UserId=@UserId";
            SqlParameter[] ps = { new SqlParameter("@UserId", id) };
            DataTable dt = SqlHelper.ExecuteTable(sql, ps);
            UserInfo user = null;
            if (dt.Rows.Count > 0)
            {
                user = new UserInfo();
                user.UserId =Convert.ToInt32(dt.Rows[0]["UserId"]);
                user.UserName = dt.Rows[0]["UserName"].ToString();
                user.UserPwd = dt.Rows[0]["UserPwd"].ToString();
            }
            return user;
        }
        public List<UserInfo> GetAllUsers()
        {
            string sql = "select * from UserInfo";
            DataTable dt = SqlHelper.ExecuteTable(sql);
            List<UserInfo> userList = null;
            if (dt.Rows.Count>0)
            {
                userList = new List<UserInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {                   
                    userList.Add(RowToUserInfo(dt.Rows[i]));
                }               
            }
            return userList;
        }
        public UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.UserId =Convert.ToInt32(dr["UserId"]);

            user.UserName = dr["UserName"]==DBNull.Value? string.Empty : dr["UserName"].ToString();//In case it's empty

            //user.UserName = dr["UserName"].ToString();
            user.UserPwd= dr["UserPwd"].ToString();
            return user;
        }
    }
}
