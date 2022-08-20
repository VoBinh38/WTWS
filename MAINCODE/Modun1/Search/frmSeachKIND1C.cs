using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PURCHASE
{
    public partial class FormSeachKIND1C : Form
    {
        DataProvider conn = new DataProvider();
        public FormSeachKIND1C()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable = new DataTable();

        private void FormSeachKIND1C_Load(object sender, EventArgs e)
        {
            Loaddata();
            conn.DGV(dataGridViewKIND1C);
        }

        public void Loaddata()
        {
            string sql = "select K_NO, K_NAME from dbo.KIND1C";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            dataGridViewKIND1C.DataSource = datatable;
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void bttk_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql;
            sql = "SELECT K_NO, K_NAME from dbo.KIND1C WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND K_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND K_NAME LIKE N'%" + tb2.Text + "%'";
            dt = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataGridViewKIND1C.DataSource = bindingsource;
            conn.DGV(dataGridViewKIND1C);
        }

        public class DL
        {
            public static string t1;
        }
        public class Form1D_GUI
        {
            public static string K1;
            public static string K2;
        }
        public class SEND_FORM6G
        {
            public static string s1;
        }
        private void btok_Click(object sender, EventArgs e)
        {
            DL.t1 = dataGridViewKIND1C.CurrentRow.Cells["K_NO"].Value.ToString();

            Form1D_GUI.K1 = dataGridViewKIND1C.CurrentRow.Cells["K_NO"].Value.ToString();
            Form1D_GUI.K2 = dataGridViewKIND1C.CurrentRow.Cells["K_NAME"].Value.ToString();
            SEND_FORM6G.s1 = dataGridViewKIND1C.CurrentRow.Cells["K_NO"].Value.ToString();

            this.Hide();
            this.Close();
        }

        private void dataGridViewKIND1C_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DL.t1 = dataGridViewKIND1C.CurrentRow.Cells["K_NO"].Value.ToString();

            Form1D_GUI.K1 = dataGridViewKIND1C.CurrentRow.Cells["K_NO"].Value.ToString();
            Form1D_GUI.K2 = dataGridViewKIND1C.CurrentRow.Cells["K_NAME"].Value.ToString();
            SEND_FORM6G.s1 = dataGridViewKIND1C.CurrentRow.Cells["K_NO"].Value.ToString();

            this.Hide();
            this.Close();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
            }
        }
    }
}
