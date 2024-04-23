﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal_System.Models
{
    public class AppraisalBases
    {
        public int Id { get; set; }
        public string BaseType { get; set; }
        public int AppraisalBase { get; set; }
        public bool IsDel { get; set; }

        public static List<AppraisalBases> ListAll()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            DataTable dt = SqlHelper.ExacuteTable("SELECT * FROM AppraisalBases");
            foreach (DataRow dr in dt.Rows)
            {
                appraisalBases.Add(ToModel(dr));
            }
            return appraisalBases;
        }

        public static AppraisalBases ToModel(DataRow dr)
        {
            AppraisalBases appraisalBase = new AppraisalBases();
            appraisalBase.Id = (int)dr["Id"];
            appraisalBase.BaseType = dr["BaseType"].ToString();
            appraisalBase.AppraisalBase = (int)dr["AppraisalBase"];
            appraisalBase.IsDel = (bool)dr["IsDel"];
            return appraisalBase;
        }
    }
}
