using CrystalDecisions.CrystalReports.Engine;
using PURCHASE.MAINCODE.Modun1.CrytalReport;
using PURCHASE.MAINCODE.Modun1.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PURCHASE.DataCenter.Report1;

namespace PURCHASE
{
    public partial class Form1BF7 : Form
    {
        DataProvider conn = new DataProvider();
        string sql = "";
        DataTable table = new DataTable();
        public Form1BF7()
        {
            //data.choose_languege();
            InitializeComponent();
        }
        private void Form1BF7_Load(object sender, EventArgs e)
        {
            
        }
        private void checkText()
        {
             sql = "SELECT * FROM VENDC WHERE 1=1";
            if (!string.IsNullOrEmpty(tb1t1.Text) || !string.IsNullOrEmpty(tb2t1.Text))
            {
                if (!string.IsNullOrEmpty(tb1t1.Text) && string.IsNullOrEmpty(tb2t1.Text))
                {
                    sql = sql + " AND C_NO BETWEEN '" + tb1t1.Text + "' AND (SELECT TOP 1 C_NO FROM dbo.VENDC ORDER BY C_NO DESC)";
                }
                else if (string.IsNullOrEmpty(tb1t1.Text) && !string.IsNullOrEmpty(tb2t1.Text))
                {
                    sql = sql + " AND C_NO BETWEEN (SELECT TOP 1 C_NO FROM dbo.VENDC ORDER BY C_NO ASC) AND '"+tb2t1.Text+"'";
                }
                else
                {
                    sql = sql + " AND C_NO BETWEEN '" + tb1t1.Text + "' AND '" + tb2t1.Text + "'";
                }
            }
        }
        private void checkText2()
        {
            sql = "SELECT * FROM VENDC WHERE 1=1";
            if (!string.IsNullOrEmpty(tb1t2.Text) || !string.IsNullOrEmpty(tb2t2.Text))
            {
                if (!string.IsNullOrEmpty(tb1t2.Text) && string.IsNullOrEmpty(tb2t2.Text))
                {
                    sql = sql + " AND C_NO BETWEEN '" + tb1t2.Text + "' AND (SELECT TOP 1 C_NO FROM dbo.VENDC ORDER BY C_NO DESC)";
                }
                else if (string.IsNullOrEmpty(tb1t2.Text) && !string.IsNullOrEmpty(tb2t2.Text))
                {
                    sql = sql + " AND C_NO BETWEEN (SELECT TOP 1 C_NO FROM dbo.VENDC ORDER BY C_NO ASC) AND '" + tb2t2.Text + "'";
                }
                else
                {
                    sql = sql + " AND C_NO BETWEEN '" + tb1t2.Text + "' AND '" + tb2t2.Text + "'";
                }
            }
        }
        public class getDataTable
        {
            public static DataTable table;
            public static bool rdt1t1;
            public static bool rdt2t1;

        }
        private void ReportControlTab1()
        {
            checkText();
            table = conn.readdata(sql);
            getDataTable.rdt1t1 = rd1t1.Checked;
            getDataTable.rdt2t1 = rd2t1.Checked;
            getDataTable.table = table;
            frm1BF7_tab1 frm1BF7_ = new frm1BF7_tab1();
            frm1BF7_.ShowDialog();
        }
        private void Print()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ReportControlTab1();
            }   
            if (tabControl1.SelectedIndex == 1)
            {
                ReportControlTab2();
            }    
           
        }
        private void ReportControlTab2()
        {
            checkText2();
            table = conn.readdata(sql);
            getDataTable.table = table;
            getDataTable.rdt1t1 = rd1t2.Checked;
            if (rd1t2.Checked == false)
            {
                getDataTable.rdt2t1 = rd2t1.Checked;
            }    
            frm1BF7_tab2 _Tab2 = new frm1BF7_tab2();
            _Tab2.ShowDialog();
        }

        private void tb1t1_DoubleClick(object sender, EventArgs e)
        {
            OpenSearch();
        }
        private void tb2t1_DoubleClick(object sender, EventArgs e)
        {
            OpenSearch2();
        }
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void tbxem_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// mở bảng tìm kiếm
            //if (tb1t1.Focus() == true)
            //{
            //    OpenSearch();
            //    tb1t1.Focus();
            //}// mở bảng tìm kiếm
            ////if (tb2t1.Focus() == true)
            ////{
            ////    OpenSearch2();
            ////    tb2t1.Focus();
            ////}
            
        }
        private void OpenSearch()
        {
            SearchVENDC1B searchVENDC1B = new SearchVENDC1B();
            searchVENDC1B.ShowDialog();
            tb1t1.Text = SearchVENDC1B.getDataTable.C_NO;
        }
        private void OpenSearch2()
        {
            SearchVENDC1B searchVENDC1B = new SearchVENDC1B();
            searchVENDC1B.ShowDialog();
            tb2t1.Text = SearchVENDC1B.getDataTable.C_NO;
        }
    }
}
