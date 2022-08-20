using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PURCHASE.MAINCODE.Modun6.Search
{
    public partial class Form6AF5 : Form
    {
        DataTable datatable = new DataTable();
        DataProvider conn = new DataProvider();
        public Form6AF5()
        {
            InitializeComponent();
        }

        private void Form6AF5_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string SQL = "select WSNO, WSDATE, USER_ID, NAME from USRH";

            datatable = new DataTable();
            datatable = conn.readdata(SQL);
            foreach (DataRow dr in datatable.Rows)
            {
                dr["WSDATE"] = conn.formatstr2(dr["WSDATE"].ToString());
            }
            dataF6F5.DataSource = datatable;
            conn.DGV(dataF6F5);

        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql = "select WSNO, WSDATE, USER_ID, NAME from USRH WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND WSNO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND WSDATE LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND USER_ID LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND NAME LIKE N'%" + tb4.Text + "%'";

            dt = new DataTable();
            dt = conn.readdata(sql);
            dataF6F5.DataSource = dt;
            foreach (DataRow dr in datatable.Rows)
            {
                dr["WSDATE"] = conn.formatstr2(dr["WSDATE"].ToString());
            }
            conn.DGV(dataF6F5);
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb2.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb3.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb4.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb1.Focus();
            }
        }
        public class Get_data
        {
            public static string t1;
            public static string t2;
            public static string t3;
            public static string t4;
        }

        private void dataF6F5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Get_data.t1 = dataF6F5.Rows[dataF6F5.CurrentRow.Index].Cells["WSNO"].Value.ToString();
            Get_data.t2 = conn.formatstr2(dataF6F5.Rows[dataF6F5.CurrentRow.Index].Cells["WSDATE"].Value.ToString());
            Get_data.t3 = dataF6F5.Rows[dataF6F5.CurrentRow.Index].Cells["USER_ID"].Value.ToString();
            Get_data.t4 = dataF6F5.Rows[dataF6F5.CurrentRow.Index].Cells["NAME"].Value.ToString();
            this.Hide();
            this.Close();
        }
    }
}
