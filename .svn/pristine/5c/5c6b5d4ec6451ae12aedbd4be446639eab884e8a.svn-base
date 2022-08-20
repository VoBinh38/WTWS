using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class Form8AF5 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable table = new DataTable();
        BindingSource source = new BindingSource();
        public Form8AF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public class shareData8AF5
        {
            public static BindingSource binding;
            public static int index;
            public static string WS_NO;
        }
        private void button5_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shareData8AF5.binding = source;
            shareData8AF5.index = source.Position;
            shareData8AF5.WS_NO = dataGridView2.CurrentRow.Cells["WS_NO"].ToString();
            this.Close();
            this.Hide();
        }

        private void Form8AF5_Load(object sender, EventArgs e)
        {
            table = Form8A.ShareData.datashare;
            foreach (DataRow row in table.Rows)
            {
                row["WS_DATE"] = conn.formatstr2(row["WS_DATE"].ToString());
            }
            source.DataSource = table;
            dataGridView2.DataSource = source;
            HideColumnDataGribView(dataGridView2,false);
            conn.DGV(dataGridView2);
           
        }
        private void HideColumnDataGribView(DataGridView dataGridView,bool check)
        {
          
            dataGridView.Columns["SH_NO"].Visible = check;
            dataGridView.Columns["SH_NAME"].Visible = check;
            dataGridView.Columns["S_NO"].Visible = check;
            dataGridView.Columns["S_NAME"].Visible = check;
            dataGridView.Columns["MEMO"].Visible = check;
            dataGridView.Columns["P_NO"].Visible = check;
            dataGridView.Columns["P_NAME"].Visible = check;
            dataGridView.Columns["P_NAME1"].Visible = check;
            dataGridView.Columns["P_NAME2"].Visible = check;
            dataGridView.Columns["P_NAME3"].Visible = check;
            dataGridView.Columns["QTY"].Visible = check;
            dataGridView.Columns["BQTY"].Visible = check;
            dataGridView.Columns["OUTQTY"].Visible = check;
            dataGridView.Columns["OUTBQTY"].Visible = check;
            dataGridView.Columns["OVER0"].Visible = check;
            dataGridView.Columns["USR_NAME"].Visible = check;
            dataGridView.Columns["SGN_NAME1"].Visible = check;
            dataGridView.Columns["SGN_NAME2"].Visible = check;
            dataGridView.Columns["SGN_NAME3"].Visible = check;
            dataGridView.Columns["SGN_NAME4"].Visible = check;
            dataGridView.Columns["K_NO"].Visible = check;
            dataGridView.Columns["UPDATEKIND"].Visible = check;
            dataGridView.Columns["WS_KIND"].Visible = check;
        }
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button6.PerformClick();
        }
        private void Search()
        {
            string sql = "SELECT WS_NO,WS_DATE,SH_NO,SH_NAME,S_NO,S_NAME,MEMO,OR_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,QTY,BQTY,OUTQTY,OUTBQTY," +
                "OVER0,USR_NAME,SGN_NAME1,SGN_NAME2,SGN_NAME3,SGN_NAME4,K_NO,UPDATEKIND,WS_KIND FROM COLH WHERE 1=1";
            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                sql = sql + " AND WS_NO LIKE '%" + textBox7.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                sql = sql + " AND P_NO LIKE '%" + textBox7.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                sql = sql + " AND P_NAME LIKE '%" + textBox7.Text + "%'";
            }
            if (!string.IsNullOrEmpty(maskedTextBox1.Text) && maskedTextBox1.MaskFull == true)
            {
                sql = sql + " AND WS_DATE LIKE '%" + conn.formatstr2(maskedTextBox1.Text) + "%'";
            }
            sql = sql + " ORDER BY WS_DATE,WS_NO DESC";
            table = conn.readdata(sql);
            foreach (DataRow row in table.Rows)
            {
                row["WS_DATE"] = conn.formatstr2(row["WS_DATE"].ToString());
            }
            source.DataSource = table;
            dataGridView2.DataSource = source;
            HideColumnDataGribView(dataGridView2, false);
            conn.DGV(dataGridView2);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
