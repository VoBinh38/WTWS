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
using PURCHASE.MAINCODE.Modun1.CrytalReport;

namespace PURCHASE
{
    public partial class Form1DF7_Tab3 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab3_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string s1 = Form1DF7.DLT.t1t3;
            string s2 = Form1DF7.DLT.t2t3;
            string st = "SELECT * FROM KIND1C WHERE 2>1";
           if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s1))
            {
                st = st + " AND K_NO BETWEEN '" + s1 + "' AND '" + s2 + "'";
            }   
           else if (!string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s1))
            {
                st = st + " AND K_NO BETWEEN '" + s1 + "' AND (SELECT TOP 1 K_NO FROM KIND1C ORDER BY K_NO DESC)";
            } 
           else if (string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s1))
            {
                st = st + " AND K_NO BETWEEN (SELECT TOP 1 K_NO FROM KIND1C ORDER BY K_NO ASC) AND '" + s2 + "'";
            }
            st = st + " ORDER BY K_NO";
            cr_Form1DF7_Tab3 rpt = new cr_Form1DF7_Tab3();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
