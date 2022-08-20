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
    public partial class Form1DF7_Tab2 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab2_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string t1 = Form1DF7.DLT.t1t2;
            string t2 = Form1DF7.DLT.t2t2;
            string t3 = Form1DF7.DLT.t3t2;
            string t4 = Form1DF7.DLT.t4t2;
            string t5 = Form1DF7.DLT.t5t2;
            string t6 = Form1DF7.DLT.t6t2;

            string st = "SELECT P_NO,ISNULL(P_NAME,'')+ISNULL(P_NAME1,'') AS P_NAME,P_NAME3,VENDC.C_ANAME,K_NAME,BUNIT FROM dbo.PROD1C " +
                "INNER JOIN VENDC ON VENDC.C_NO = PROD1C.C_NO INNER JOIN KIND1C ON KIND1C.K_NO = PROD1C.K_NO WHERE 1=1";
            if (!string.IsNullOrEmpty(t1) || !string.IsNullOrEmpty(t2))
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
                    st = st + " AND VENDC.C_NO between '" + t3 + "' and (SELECT TOP 1 C_NO FROM VENDC ORDER BY C_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t3) && !string.IsNullOrEmpty(t4))
                {
                    st = st + " AND VENDC.C_NO between (SELECT TOP 1 C_NO FROM VENDC ORDER BY C_NO ASC) and  '" + t4 + "'";
                }
                else
                {
                    st = st + " AND VENDC.C_NO between '" + t3 + "' and  '" + t4 + "'";
                }
            }
            if (!string.IsNullOrEmpty(t5) || !string.IsNullOrEmpty(t6))
            {
                if (!string.IsNullOrEmpty(t5) && string.IsNullOrEmpty(t6))
                {
                    st = st + " AND PROD1C.P_NO between '" + t5 + "' and (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t5) && !string.IsNullOrEmpty(t6))
                {
                    st = st + " AND PROD1C.P_NO between (SELECT TOP 1 P_NO FROM dbo.PROD1C ORDER BY P_NO ASC) and  '" + t6 + "'";
                }
                else
                {
                    st = st + " AND PROD1C.P_NO between '" + t5 + "' and  '" + t6 + "'";
                }
            }
            st = st + " ORDER BY PROD1C.P_NO";
            cr_Form1DF7_Tab2 rpt = new cr_Form1DF7_Tab2();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }

        private void crystalReportViewer1_ViewZoom(object source, CrystalDecisions.Windows.Forms.ZoomEventArgs e)
        {
            
        }
    }
}
