using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PURCHASE;

namespace PURCHASE
{
    public partial class SearchDept1A : Form
    {
        DataProvider conn = new DataProvider();
        public class DEPT
        {
            public static string S_NO;
            public static string S_NAME;
        }
        public SearchDept1A()
        {
            InitializeComponent();
        }
        DataTable table;
        BindingSource source;
        private void LoadData()
        {
            string sql = "SELECT S_NO,S_NAME FROM SALE";
            table = new DataTable();
            table = conn.readdata(sql);
            source = new BindingSource();
            source.DataSource = table;
            dgvDept.DataSource = source;
            conn.DGV(dgvDept);
        }

        private void SearchDept1A_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void seach()
        {
            string sql = "SELECT S_NO,S_NAME FROM SALE WHERE 1=1";
            if (txtMaBoPhan.Text != "")
            {
                sql = sql + " AND S_NO like '" + txtMaBoPhan.Text + "%'";
            }
            if (txtTenBoPhan.Text != "")
            {
                sql = sql + " AND S_NO like '" + txtTenBoPhan.Text + "%'";
            }
            table = new DataTable();
            table = conn.readdata(sql);
            source = new BindingSource();
            source.DataSource = table;
            dgvDept.DataSource = source;
            conn.DGV(dgvDept);
        }
        private void getData()
         {
             DEPT.S_NO = dgvDept.CurrentRow.Cells[0].Value.ToString();
             DEPT.S_NAME = dgvDept.CurrentRow.Cells[1].Value.ToString();
             this.Close();
         }
        private void txtMaBoPhan_TextChanged(object sender, EventArgs e)
        {
            seach();
        }

        private void txtTenBoPhan_TextChanged(object sender, EventArgs e)
        {
            seach();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvDept_KeyDown(object sender, KeyEventArgs e)
        {
         if (e.KeyCode == Keys.Enter)
            {
                getData();   
            }    
        }

        private void dgvDept_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            getData();
        }
    }
}
