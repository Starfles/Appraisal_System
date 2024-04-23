using Appraisal_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System
{
    public partial class FrmUserManager : Form
    {
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            BindCbx();
            dgvUserAppraisal.AutoGenerateColumns = false;
            List<Users> users = new List<Users>();
            users = Users.GetListJoinAppraisal();
            dgvUserAppraisal.DataSource = users;
        }

        private void BindCbx()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            //数据源绑定方法：展示查询名，但是以Id标识
            //第一种方法
            /*appraisalBases.Add(new AppraisalBases
            {
                Id = 0,
                BaseType = "-查询所有-",
                AppraisalBase = 0,
                IsDel = false
            });
            appraisalBases.AddRange(AppraisalBases.ListAll());*/
            //第二种方法
            appraisalBases = AppraisalBases.ListAll();
            appraisalBases.Insert(0, new AppraisalBases
            {
                Id = 0,
                BaseType = "-查询所有-",
                AppraisalBase = 0,
                IsDel = false
            });
            cbxBase.DataSource = appraisalBases;
            cbxBase.DisplayMember = "BaseType";
            cbxBase.ValueMember = "Id";

            //非数据源绑定方法（不推荐）
            /*cbxBase.Text = "查询所有";
            cbxBase.Items.Add("-查询所有-");
            foreach (var appraisalBae in appraisalBases)
            {
                cbxBase.Items.Add(appraisalBae.BaseType);
            }*/
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
