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
    public partial class Form1CF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1CF5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();

        private void Form1CF5timkiemdulieusanpham_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        public void LoadData()
        {

            datatable = Form1C.getDataTable1C.data;
            bindingsource.DataSource = datatable;
            Data1CF5.DataSource = bindingsource;
            conn.DGV1(Data1CF5);
        }
        public class ID
        {
            public static int index;
            public static DataTable datatable1CF5;

        }
        public class DL
        {
            public static string T1;
        }
        public class GUI_FORM1E
        {
            public static string t1;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            //table
            ID.datatable1CF5 = datatable;
            this.Close();
        }
        private void bttk_Click(object sender, EventArgs e)
        {
            Search();
        }

        public class GUI_FORM2D
        {
            public static string T2;
        }
        private void btok_Click(object sender, EventArgs e)
        {
                //table
                ID.datatable1CF5 = datatable;
                ID.index = bindingsource.Position;
                DL.T1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();

                GUI_FORM1E.t1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
                GUI_FORM2D.T2 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
                this.Hide();
                this.Close();
        }

        private void Data1CF5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //table
            ID.datatable1CF5 = datatable;
            ID.index = bindingsource.Position;

            DL.T1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
            GUI_FORM1E.t1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
            GUI_FORM2D.T2 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
           
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
        public void Search()
        {
           
            string sql;
            sql = "Select PROD.K_NO, KIND.K_NAME, P_NO, P_NAME, P_NAME1, P_NAME3, P_NAME2, UNIT, TRANS, BUNIT, CUNIT, PRICE, P_WEG, QTYKG, QTYSTORE, QTYPIC, BASEDATE, QTYFT, INDATE, QTYORD, OUTDATE, QTYBAT, QTYPROD, MEMO1, MEMO2, MEMO3, MEMO4, COST, COST_NEW, COST_AVG, PM_DATE, TN_DATE, DY_DATE, GD_DATE, TN_DATE1, DY_DATE1, GD_DATE1, PT_DATE, PT_FT, PK_DATE from PROD full outer join KIND on PROD.K_NO = KIND.K_NO WHERE 1=1";

            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND P_NO LIKE N'" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND P_NAME3 LIKE N'" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND P_NAME LIKE N'" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND P_NAME1  LIKE N'" + tb4.Text + "%'";
            datatable = conn.readdata(sql);
            bindingsource.DataSource = datatable;
            Data1CF5.DataSource = bindingsource;
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
