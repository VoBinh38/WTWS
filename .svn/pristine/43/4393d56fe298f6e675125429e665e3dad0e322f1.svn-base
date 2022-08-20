using System;
using System.Data;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class FormSearchSHOUSE : Form
    {
        DataProvider conn = new DataProvider(); 
        public FormSearchSHOUSE()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable;

        private void FormSearchSHOUSE_Load(object sender, EventArgs e)
        {
            LoadData();
            conn.DGV(DataFormSHOUSE);
        }
        private void LoadData()
        {
           
            string sql = "select SH_NO, SH_NAME from SHOUSE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            DataFormSHOUSE.DataSource = bindingsource;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            this.Close();
        }
        public class DL
        {
            public static string t1;
        }

        private void DataFormSHOUSE_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DL.t1 = DataFormSHOUSE.CurrentRow.Cells["SH_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();


            string sql = "Select SH_NO, SH_NAME from SHOUSE WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND SH_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND SH_NAME LIKE N'%" + tb2.Text + "%'";

            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            DataFormSHOUSE.DataSource = bindingsource;
            conn.DGV(DataFormSHOUSE);
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
