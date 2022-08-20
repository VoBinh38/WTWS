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
    public partial class Form1DF7_Tab5 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        bool rd1 = Form1DF7.RD.r1t5;
        bool rd2 = Form1DF7.RD.r2t5;
        private void Form1DF7_Tab5_Load(object sender, EventArgs e)
        {
            if (rd1 == true)
            {
                string st = "Select * from PROD1C WHERE 1=1";
                getWhere(st);
                getData(st);
            }
            if (rd2 == true)
            {
                string st = "Select * from PROD1C WHERE 1=1";
                getWhere(st);
                getData(st);
            }    
            
        }
        private void getWhere(string st)
        {
            string t1 = Form1DF7.DLT.t1t5;
            string t2 = Form1DF7.DLT.t2t5;
            string t3 = Form1DF7.DLT.t3t5;
            string t4 = Form1DF7.DLT.t4t5;
            string t8 = Form1DF7.DLT.t8t5;
            string t9 = Form1DF7.DLT.t9t5;
            //chưa sd đến
            string t5 = Form1DF7.DLT.t5t5;
            string t6 = Form1DF7.DLT.t6t5;
            string t7 = Form1DF7.DLT.t7t5;
            if (!string.IsNullOrEmpty(t1) || !string.IsNullOrEmpty(t1))
            {
                if (!string.IsNullOrEmpty(t1) && string.IsNullOrEmpty(t2))
                {
                    st = st + " AND PROD1C.K_NO between '" + t1 + "' and (SELECT TOP 1 K_NO FROM dbo.PROD1C ORDER BY K_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t1) && !string.IsNullOrEmpty(t2))
                {
                    st = st + " AND PROD1C.K_NO between (SELECT TOP 1 K_NO FROM dbo.PROD1C ORDER BY K_NO ASC) and  '" + t2 + "'";
                }
                else
                {
                    st = st + " AND PROD1C.K_NO between '" + t1 + "' and  '" + t2 + "'";
                }
            }
            if (!string.IsNullOrEmpty(t3) || !string.IsNullOrEmpty(t4))
            {
                if (!string.IsNullOrEmpty(t3) && string.IsNullOrEmpty(t4))
                {
                    st = st + " AND PROD1C.P_NO between '" + t3 + "' and (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t3) && !string.IsNullOrEmpty(t4))
                {
                    st = st + " AND PROD1C.P_NO between (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO ASC) and  '" + t4 + "'";
                }
                else
                {
                    st = st + " AND PROD1C.P_NO between '" + t3 + "' and  '" + t4 + "'";
                }
            }
            if (!string.IsNullOrEmpty(t8) || !string.IsNullOrEmpty(t9))
            {
                if (!string.IsNullOrEmpty(t8) && string.IsNullOrEmpty(t9))
                {
                    st = st + " AND VENDC.C_NO between '" + t8 + "' and (SELECT TOP 1 C_NO FROM VENDC ORDER BY C_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t8) && !string.IsNullOrEmpty(t9))
                {
                    st = st + " AND VENDC.C_NO between (SELECT TOP 1 C_NO FROM VENDC ORDER BY C_NO ASC) and  '" + t9 + "'";
                }
                else
                {
                    st = st + " AND VENDC.C_NO between '" + t8 + "' and  '" + t9 + "'";
                }
            }
        }
        private void getData(string sql)
        {
            cr_Form1DF7_Tab5 rpt = new cr_Form1DF7_Tab5();
            DataTable dt = connect.readdata(sql);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
