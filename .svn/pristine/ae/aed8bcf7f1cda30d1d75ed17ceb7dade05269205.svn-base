using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PURCHASE
{
    public partial class Form1DF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1DF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
      
        BindingSource bindingsource;
        DataTable datatable = new DataTable();

        private void Form1DF5_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select TOP 100 PROD1C.K_NO, KIND1C.K_NAME, C_NO, K_NO_O, DEPT, P_NO, P_NAME, P_NAME1, P_NAME2, P_NAME3, UNIT, TRANS, BUNIT, CUNIT, PRICE, QDATE, M_TRAN, W_CHECK, QTYSTORE, QTYSAF, P_WEG, QTYSTORE_B, QTYSTORE_BB, BASEDATE, INDATE, OUTDATE, PLACE, MEMO1, MEMO2, MEMO3, MEMO4, PRICE1, PRICE2, PRICE4, " +
                " QTY01, PRICE5, PRICE6, PRICE7, PRICE8, PRICE3, DKIND, QDATE1, QDATE2, QDATE4, QDATE5, QDATE6, QDATE7, QDATE8, QDATE3, COST, COST_AVG, COST_NEW from dbo.PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO Order by PROD1C.P_NO ASC";
    
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataForm1DF5.DataSource = bindingsource;
            conn.DGV(dataForm1DF5);
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1D fr = new Form1D();
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            search();
        }
        public class DL
        {
            public static string t1;
            public static string t2;
            public static string t3;
            public static string t4;
            public static string t5;

            public static string t6;
            public static string t7;
            public static string t8;
            public static string t9;
            public static string t10;

            public static string t11;
            public static string t12;
            public static string t13;
            public static string t14;
            public static string t15;

            public static string t16;
            public static string t17;
            public static string t18;
            public static string t19;
            public static string t20;

            public static string t21;
            public static string t22;
            public static string t23;
            public static string t24;
            public static string t25;

            public static string t26;
            public static string t27;
            public static string t28;
            public static string t29;
            public static string t30;

            public static string t31;
            public static string t32;
            public static string t33;
            public static string t34;
            public static string t35;

            public static string t36;
            public static string t37;
            public static string t38;
            public static string t39;
            public static string t40;

            public static string t41;
            public static string t42;
            public static string t43;
            public static string t44;
            public static string t45;

            public static string t46;
            public static string t47;
            public static string t48;
            public static string t49;
            public static string t50;

            public static string t51;
            public static string t52;
            public static string t53;
            public static string t54;
            public static string t55;

            public static string t56;
            public static string t57;
            public static string t58;
            public static string t59;
        
        }
        public class GUI
        {
            public static string t1;
        }

        private void dataForm1DF5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DL.t1 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            DL.t2 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["K_NAME"].Value.ToString();
            DL.t3 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DL.t4 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["K_NO_O"].Value.ToString();

            //tb5.Text = dataGridViewForm1D.Rows[dataGridViewForm1D.CurrentRow.Index].Cells[""].Value.ToString();

            DL.t6 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["DEPT"].Value.ToString();
            DL.t7 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NO"].Value.ToString();
            DL.t8 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME"].Value.ToString();
            DL.t9 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME1"].Value.ToString();
            DL.t10 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME2"].Value.ToString();

            DL.t11 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME3"].Value.ToString();
            DL.t12 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["UNIT"].Value.ToString();
            DL.t13 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["TRANS"].Value.ToString();
            DL.t14 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["BUNIT"].Value.ToString();
            DL.t15 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["CUNIT"].Value.ToString();

            //tb16.Text = dataGridViewForm1D.Rows[dataGridViewForm1D.CurrentRow.Index].Cells[""].Value.ToString();

            DL.t17 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE"].Value.ToString();
            DL.t18 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE"].Value.ToString();
            DL.t19 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["M_TRAN"].Value.ToString();
            DL.t20 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["W_CHECK"].Value.ToString();

            DL.t21 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString();
            DL.t22 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSAF"].Value.ToString();
            DL.t23 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_WEG"].Value.ToString();
            DL.t24 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE_B"].Value.ToString();

            //tb25.Text = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString() ;

            DL.t26 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE_BB"].Value.ToString();
            DL.t27 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString();
            DL.t28 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["BASEDATE"].Value.ToString();
            DL.t29 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["INDATE"].Value.ToString();
            DL.t30 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PLACE"].Value.ToString();

            DL.t31 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["OUTDATE"].Value.ToString();
            DL.t32 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO1"].Value.ToString();
            DL.t33 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO2"].Value.ToString();
            DL.t34 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO3"].Value.ToString();
            DL.t35 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO4"].Value.ToString();

            DL.t36 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE1"].Value.ToString();
            DL.t37 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE2"].Value.ToString();
            DL.t38 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE4"].Value.ToString();
            DL.t39 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTY01"].Value.ToString();
            DL.t40 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE5"].Value.ToString();

            DL.t41 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE6"].Value.ToString();
            DL.t42 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE7"].Value.ToString();
            DL.t43 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE8"].Value.ToString();
            DL.t44 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE3"].Value.ToString();
            DL.t45 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["DKIND"].Value.ToString();

            DL.t46 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE1"].Value.ToString();
            DL.t47 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE2"].Value.ToString();
            DL.t48 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE4"].Value.ToString();
            DL.t49 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE5"].Value.ToString();
            DL.t50 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE6"].Value.ToString();

            DL.t51 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE7"].Value.ToString();
            DL.t52 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE8"].Value.ToString();
            DL.t53 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE3"].Value.ToString();
            DL.t54 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST"].Value.ToString();
            DL.t55 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST_NEW"].Value.ToString();

            DL.t56 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST_AVG"].Value.ToString();

            //tb57.Text = (float.Parse(dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST_NEW"].Value.ToString();
           DL.t58 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTY01"].Value.ToString();
           DL.t59 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString();

            GUI.t1 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NO"].Value.ToString();

            this.Hide();
            this.Close();

        }

        private void btok_Click(object sender, EventArgs e)
        {
            DL.t1 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            DL.t2 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["K_NAME"].Value.ToString();
            DL.t3 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DL.t4 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["K_NO_O"].Value.ToString();

            //tb5.Text = dataGridViewForm1D.Rows[dataGridViewForm1D.CurrentRow.Index].Cells[""].Value.ToString();

            DL.t6 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["DEPT"].Value.ToString();
            DL.t7 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NO"].Value.ToString();
            DL.t8 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME"].Value.ToString();
            DL.t9 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME1"].Value.ToString();
            DL.t10 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME2"].Value.ToString();

            DL.t11 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NAME3"].Value.ToString();
            DL.t12 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["UNIT"].Value.ToString();
            DL.t13 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["TRANS"].Value.ToString();
            DL.t14 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["BUNIT"].Value.ToString();
            DL.t15 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["CUNIT"].Value.ToString();

            //tb16.Text = dataGridViewForm1D.Rows[dataGridViewForm1D.CurrentRow.Index].Cells[""].Value.ToString();

            DL.t17 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE"].Value.ToString();
            DL.t18 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE"].Value.ToString();
            DL.t19 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["M_TRAN"].Value.ToString();
            DL.t20 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["W_CHECK"].Value.ToString();

            DL.t21 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString();
            DL.t22 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSAF"].Value.ToString();
            DL.t23 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_WEG"].Value.ToString();
            DL.t24 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE_B"].Value.ToString();

            //tb25.Text = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString() ;

            DL.t26 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE_BB"].Value.ToString();
            DL.t27 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString();
            DL.t28 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["BASEDATE"].Value.ToString();
            DL.t29 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["INDATE"].Value.ToString();
            DL.t30 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PLACE"].Value.ToString();

            DL.t31 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["OUTDATE"].Value.ToString();
            DL.t32 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO1"].Value.ToString();
            DL.t33 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO2"].Value.ToString();
            DL.t34 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO3"].Value.ToString();
            DL.t35 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["MEMO4"].Value.ToString();

            DL.t36 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE1"].Value.ToString();
            DL.t37 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE2"].Value.ToString();
            DL.t38 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE4"].Value.ToString();
            DL.t39 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTY01"].Value.ToString();
            DL.t40 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE5"].Value.ToString();

            DL.t41 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE6"].Value.ToString();
            DL.t42 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE7"].Value.ToString();
            DL.t43 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE8"].Value.ToString();
            DL.t44 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["PRICE3"].Value.ToString();
            DL.t45 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["DKIND"].Value.ToString();

            DL.t46 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE1"].Value.ToString();
            DL.t47 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE2"].Value.ToString();
            DL.t48 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE4"].Value.ToString();
            DL.t49 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE5"].Value.ToString();
            DL.t50 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE6"].Value.ToString();

            DL.t51 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE7"].Value.ToString();
            DL.t52 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE8"].Value.ToString();
            DL.t53 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QDATE3"].Value.ToString();
            DL.t54 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST"].Value.ToString();
            DL.t55 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST_NEW"].Value.ToString();

            DL.t56 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST_AVG"].Value.ToString();

            //tb57.Text = (float.Parse(dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["COST_NEW"].Value.ToString();
            DL.t58 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTY01"].Value.ToString();
            DL.t59 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["QTYSTORE"].Value.ToString();

            GUI.t1 = dataForm1DF5.Rows[dataForm1DF5.CurrentRow.Index].Cells["P_NO"].Value.ToString();

            this.Hide();
            this.Close();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb2.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb5.Focus();
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

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb6.Focus();
            }
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb8.Focus();
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

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb7.Focus();
            }
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb1.Focus();
            }
        }
        public void search()
        {
            DataTable dt = new DataTable();

            string sql;
            sql = "select TOP 100 PROD1C.K_NO, KIND1C.K_NAME, C_NO, K_NO_O, DEPT, P_NO, P_NAME, P_NAME1, P_NAME2, P_NAME3, UNIT, TRANS, BUNIT, CUNIT, PRICE, QDATE, M_TRAN, W_CHECK, QTYSTORE, QTYSAF, P_WEG, QTYSTORE_B, QTYSTORE_BB, BASEDATE, INDATE, OUTDATE, PLACE, MEMO1, MEMO2, MEMO3, MEMO4, PRICE1, PRICE2, PRICE4, " +
                " QTY01, PRICE5, PRICE6, PRICE7, PRICE8, PRICE3, DKIND, QDATE1, QDATE2, QDATE4, QDATE5, QDATE6, QDATE7, QDATE8, QDATE3, COST, COST_AVG, COST_NEW from dbo.PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == "") && (tb5.Text == "") && (tb6.Text == "") && (tb7.Text == "") && (tb8.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND PROD1C.K_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND P_NO LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND P_NAME LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND P_NAME1 LIKE N'%" + tb4.Text + "%'";
            if (tb5.Text != "")
                sql = sql + " AND P_NAME2 LIKE N'%" + tb5.Text + "%'";
            if (tb6.Text != "")
                sql = sql + " AND P_NAME3 LIKE N'%" + tb6.Text + "%'";
            if (tb7.Text != "")
                sql = sql + " AND M_TRAN LIKE N'%" + tb7.Text + "%'";
            if (tb8.Text != "")
                sql = sql + " AND C_NO LIKE N'%" + tb8.Text + "%'";
             sql = sql + "AND PROD1C.P_NO is not null Order by PROD1C.P_NO Asc";

            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = sql;
            // co the su dung cm.ExecuteNonQuery();

            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataForm1DF5.DataSource = bindingsource;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb5_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb7_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb6_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void tb8_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
