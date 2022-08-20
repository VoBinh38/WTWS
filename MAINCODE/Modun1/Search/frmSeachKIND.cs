using System;
using System.Data;
using System.Windows.Forms;


namespace PURCHASE
{
    public partial class FormSeachKIND : Form
    {
        DataProvider conn = new DataProvider();
        public FormSeachKIND()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        private void FormSeachKIND_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select K_NO, K_NAME from dbo.KIND";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewKIND.DataSource = bindingsource;
            conn.DGV(dataGridViewKIND);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql;
            sql = "SELECT K_NO, K_NAME from dbo.KIND WHERE 1=1";
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
            dataGridViewKIND.DataSource = bindingsource;
            conn.DGV(dataGridViewKIND);
        }
        public class GUI_FORM1C 
        {
            public static string tx1;
            public static string tx2;
        }
        public class GUI_FORM1EF7
        {
            public static string tx1;
            public static string tx2;
        }
        private void dataGridViewKIND_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GUI_FORM1C.tx1 = dataGridViewKIND.CurrentRow.Cells["K_NO"].Value.ToString();
            GUI_FORM1C.tx2 = dataGridViewKIND.CurrentRow.Cells["K_NAME"].Value.ToString();

            GUI_FORM1EF7.tx1 = dataGridViewKIND.CurrentRow.Cells["K_NO"].Value.ToString();
            GUI_FORM1EF7.tx2 = dataGridViewKIND.CurrentRow.Cells["K_NAME"].Value.ToString();
           
            this.Hide();
            this.Close();
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
