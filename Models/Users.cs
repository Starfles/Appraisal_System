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
        int Id { get; set; }
        string UserName { get; set; }
        int Sex { get; set; }
        int BaseTypeId { get; set; }
        bool IsDel { get; set; }
        int AppraisalBase {  get; set; }
        string BaseType { get; set; }

        private static List<Users> GetListJoinAppraisal()
        {
            List<Users> users = new List<Users>();
            DataTable dt = SqlHelper.ExacuteTable("SELECT" +
                " u.Id, u.UserName, u.Sex, u.BaseTypeId, u.IsDel, a.AppraisalBase, a.BaseType" +
                " FROM Users u LEFT JOIN AppraisalBases a ON u.BaseTypeId = a.Id");
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(ToModel(dr));
            }
            return users;
        }

        private static Users ToModel(DataRow dr)
        {
            Users user = new Users();
            user.Id = (int)dr["Id"];
            user.UserName = dr["UserName"].ToString();
            user.Sex = (int)dr["Sex"];
            user.BaseTypeId = (int)dr["BaseTypeId"];
            user.IsDel = (bool)dr["IsDel"];
            user.AppraisalBase = (int)dr["AppraisalBase"];
            user.BaseType = dr["BaseType"].ToString();
            return user;
        }
    }
}
