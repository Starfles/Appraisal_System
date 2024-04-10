using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System
{
    public class SqlHelper
    {
        // 连接字符串在App.config处配置
        public static string conStr {  get; set; }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="cmdTxt"></param>
        /// <returns></returns>
        public static DataTable ExacuteTable(string cmdTxt)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                // 管家,基于数据库连接保存命令
                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                // 推车
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                // 货车，后续将推车中东西装进货车
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //返回第一行
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 增删改数据
        /// </summary>
        /// <param name="cmdTxt"></param>
        /// <returns></returns>
        public static int ExacuteNonQuery(string cmdTxt)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0) 
                { 
                    throw new Exception("数据库操作失败！"); 
                }
                return rows;
            }
        }
    }
}
