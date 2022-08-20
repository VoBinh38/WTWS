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
    public partial class Form1DF7_Tab1 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab1_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string t1 = Form1DF7.DLT.t1t1;
            string t2 = Form1DF7.DLT.t2t1;
            string t3 = Form1DF7.DLT.t3t1;
            string t4 = Form1DF7.DLT.t4t1;
            string t5 = Form1DF7.DLT.t5t1;
            string t6 = Form1DF7.DLT.t6t1;
            string t7 = Form1DF7.DLT.t7t1;
            string t8 = Form1DF7.DLT.t8t1;

            string st = "SELECT *,cast(ROUND((QTYSTORE*PRICE),0) as int) as TICH1, cast(ROUND((QTYSTORE*COST_NEW),0) as int) as TICH2 From PROD1C WHERE 1=1";
            if (!string.IsNullOrEmpty(t1) || !string.IsNullOrEmpty(t2))
            {
                if (!string.IsNullOrEmpty(t1) && string.IsNullOrEmpty(t2))
                {
                    st = st + " AND K_NO between '" + t1 + "' and (SELECT TOP 1 K_NO FROM dbo.PROD1C ORDER BY K_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t1) && !string.IsNullOrEmpty(t2))
                {
                    st = st + " AND K_NO between (SELECT TOP 1 K_NO FROM dbo.PROD1C ORDER BY K_NO ASC) and  '" + t2 + "'";
                }   
                else
                {
                    st = st + " AND K_NO between '"+t1+"' and  '"+ t2+ "'";
                }    
            }
            if (!string.IsNullOrEmpty(t3) || !string.IsNullOrEmpty(t4))
            {
                if (!string.IsNullOrEmpty(t3) && string.IsNullOrEmpty(t4))
                {
                    st = st + " AND P_NO between '" + t3 + "' and (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t3) && !string.IsNullOrEmpty(t4))
                {
                    st = st + " AND P_NO between (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO ASC) and  '" + t4 + "'";
                }
                else
                {
                    st = st + " AND P_NO between '" + t3 + "' and  '" + t4 + "'";
                }
            }
            if (!string.IsNullOrEmpty(t5) || !string.IsNullOrEmpty(t6))
            {
                if (!string.IsNullOrEmpty(t5) && string.IsNullOrEmpty(t6))
                {
                    st = st + " AND P_NAME between '" + t5 + "' and (SELECT TOP 1 P_NAME FROM dbo.PROD1C ORDER BY P_NAME DESC)";
                }
                else if (string.IsNullOrEmpty(t5) && !string.IsNullOrEmpty(t6))
                {
                    st = st + " AND P_NAME between (SELECT TOP 1 P_NAME FROM dbo.PROD1C ORDER BY P_NAME ASC) and  '" + t6 + "'";
                }
                else
                {
                    st = st + " AND P_NAME between '" + t5 + "' and  '" + t6 + "'";
                }
            }
            if (!string.IsNullOrEmpty(t7) || !string.IsNullOrEmpty(t8))
            {
                //if (!string.IsNullOrEmpty(t7) && string.IsNullOrEmpty(t8))
                //{
                //    st = st + " AND K_NO between '" + t5 + "' and (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO DESC)";
                //}
                //else if (string.IsNullOrEmpty(t7) && !string.IsNullOrEmpty(t8))
                //{
                //    st = st + " AND K_NO between (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO ASC) and  '" + t6 + "'";
                //}
                //else
                //{
                //    st = st + " AND K_NO between '" + t7 + "' and  '" + t8 + "'";
                //}
                st = st;
            }

            st = st + " ORDER BY P_NO";
            cr_Form1DF7_Tab1 rpt = new cr_Form1DF7_Tab1();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
