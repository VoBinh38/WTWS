using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Modun4.Search
{
    public partial class SearchDEPT : Form
    {
        DataProvider con = new DataProvider();
        public SearchDEPT()
        {
            InitializeComponent();
        }

        private void SearchDEPT_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string sql = "SELECT DEPT_NO,DEPT_NAME FROM DEPT";
            DataTable dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }
        public class GetData
        {
            public static string DEPT_NO;
            public static string DEPT_NAME;
        }

        public void Search()
        {
            string sql = "SELECT DEPT_NO,DEPT_NAME FROM DEPT Where 1=1";
            if(!string.IsNullOrEmpty(txtDEPT_NO.Text))
            {
                sql = sql + " AND DEPT_NO = '" + txtDEPT_NO.Text + "'";
            }
            if(string.IsNullOrEmpty(txtDEPT_NAME.Text))
            {
                sql = sql + " AND DEPT_NAME Like '%" + txtDEPT_NAME.Text + "%'";
            }
            DataTable dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }

        private void txtDEPT_NO_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtDEPT_NAME_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            GetData.DEPT_NO = DGV1.CurrentRow.Cells["DEPT_NO"].Value.ToString();
            GetData.DEPT_NAME = DGV1.CurrentRow.Cells["DEPT_NAME"].Value.ToString();
            this.Close();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetData.DEPT_NO = DGV1.CurrentRow.Cells["DEPT_NO"].Value.ToString();
            GetData.DEPT_NAME = DGV1.CurrentRow.Cells["DEPT_NAME"].Value.ToString();
            this.Close();
        }
    }
}
