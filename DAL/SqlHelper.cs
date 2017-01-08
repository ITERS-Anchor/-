using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["dbtest"].ConnectionString;
        //执行查询，返回多行多列
        public static DataTable ExecuteTable(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                //用于进行select操作，可以通过SelectCommand属性获取此操作的SqlCommand对象
                adapter.SelectCommand.Parameters.AddRange(ps);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        //执行查询，返回一行一列
        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
        //执行 增，删，改，返回受影响行数
        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }


    }
}
