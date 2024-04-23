using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public char Sex { get; set; }
        public int BaseTypeId { get; set; }
        public char IsDel { get; set; }
        public int AppraisalBase {  get; set; }
        public string BaseType { get; set; }

        public static List<Users> GetListJoinAppraisal()
        {
            List<Users> users = new List<Users>();
            DataTable dt = SqlHelper.ExacuteTable("SELECT u.Id, u.UserName, u.Sex, u.BaseTypeId, u.IsDel, a.AppraisalBase, a.BaseType FROM Users u LEFT JOIN AppraisalBases a ON u.BaseTypeId = a.Id");
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(ToModel(dr));
            }
            return users;
        }

        public static Users ToModel(DataRow dr)
        {
            Users user = new Users();
            user.Id = (int)dr["Id"];
            user.UserName = dr["UserName"].ToString();
            user.Sex = (int)dr["Sex"] == 1 ? '男' : '女';
            user.BaseTypeId = (int)dr["BaseTypeId"];
            user.IsDel = (bool)dr["IsDel"] == true ? '是' : '否';
            user.AppraisalBase = (int)dr["AppraisalBase"];
            user.BaseType = dr["BaseType"].ToString();
            return user;
        }
    }
}
