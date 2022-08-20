using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PURCHASE.Form1S;

namespace PURCHASE
{
    public partial class Form1SF5 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable dataTable = new DataTable();
        BindingSource bing = new BindingSource();
        public Form1SF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox1, tb2,sender,e);
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb2, textBox1, sender, e);
        }
        private void Form1SF5_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dataTable = Data1S.Datashare;
            bing.DataSource = dataTable;
            dataGridView1.DataSource = bing;
            conn.DGV(dataGridView1);
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShareData1SF5.table = dataTable;
            ShareData1SF5.index = bing.Position;
            this.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Search();
            }    
        }
        private void tb2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb2.Text) && tb2.MaskFull == true)
            {
                Search();
            }
        }
        private void Search()
        {
            string sql = "select * from STOH WHERE 1=1";
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                sql = sql + " AND WS_NO = '" + textBox1.Text + "'";
            }
            if (!string.IsNullOrEmpty(tb2.Text) && tb2.MaskFull == true)
            {
                sql = sql + " AND WS_DATE = '" + conn.formatstr2(tb2.Text) + "'";
            }
            dataTable = conn.readdata(sql);
            bing.DataSource = dataTable;
            dataGridView1.DataSource = bing;
        }
        public class ShareData1SF5
        {
            public static DataTable table;
            public static int index;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShareData1SF5.table = dataTable;
            ShareData1SF5.index = bing.Position;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShareData1SF5.table = dataTable;
            this.Close();
        }
    }
}
