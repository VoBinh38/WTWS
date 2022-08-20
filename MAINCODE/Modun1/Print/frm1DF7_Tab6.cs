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
using PURCHASE.DataCenter;
using CrystalDecisions.CrystalReports.Engine;
using static PURCHASE.DataCenter.Report1;

namespace PURCHASE
{
    public partial class Form1DF7_Tab6 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab6()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string st = "";
        bool r1 = Form1DF7.RD.r1t6;
        bool r2 = Form1DF7.RD.r2t6;
        bool r3 = Form1DF7.RD.r3t6;
        private void Form1DF7_Tab6_Load(object sender, EventArgs e)
        {
            if (r1 == true)
            {
                Load1();
            }
            else if (r2 == true)
            {
                getData();
            }
            if (r3 == true)
            {

            }    
        }

        public void Load1()
        {
            string sql = "SELECT H.P_NO,H.QTYSTORE,B.QTYSTORE_BB FROM PROD1C H,(SELECT SUM(QTY) AS QTYSTORE_BB,P_NO FROM PSHQTY GROUP BY P_NO) B WHERE H.P_NO = B.P_NO AND (B.QTYSTORE_BB > H.QTYSTORE OR B.QTYSTORE_BB < QTYSTORE) AND 1=1";
            DataTable dataTable = new DataTable();
            dataTable = connect.readdata(sql);
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Form1DF7_Tab6_t1();
            cryRpt.SetDataSource(dataTable);
            ShareReport.repo = cryRpt;
            crystalReportViewer1.ReportSource = cryRpt;
        }

        public void Load2_3(string sql)
        {
            DataTable dataTable = new DataTable();
            dataTable = connect.readdata(sql);
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Form1DF7_Tab6_t23();
            cryRpt.SetDataSource(dataTable);
            ShareReport.repo = cryRpt;
            crystalReportViewer1.ReportSource = cryRpt;
        }
       private void getData()
        {
            string t1 = Form1DF7.DLT.t1t6;
            string t2 = Form1DF7.DLT.t2t6;
            string t3 = Form1DF7.DLT.t3t6;
            string t4 = Form1DF7.DLT.t4t6;
            string t5 = Form1DF7.DLT.t5t6;
            string t6 = Form1DF7.DLT.t6t6;
            st = "SELECT * FROM PROD1C WHERE 1=1";
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
                    st = st + " AND K_NO between '" + t1 + "' and  '" + t2 + "'";
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
                    st = st + " AND C_NO between '" + t5 + "' and (SELECT TOP 1 C_NO FROM dbo.PROD1C ORDER BY C_NO DESC)";
                }
                else if (string.IsNullOrEmpty(t5) && !string.IsNullOrEmpty(t6))
                {
                    st = st + " AND C_NO between (SELECT TOP 1 C_NO FROM dbo.PROD1C ORDER BY C_NO ASC) and  '" + t6 + "'";
                }
                else
                {
                    st = st + " AND C_NO between '" + t5 + "' and  '" + t6 + "'";
                }
            }
            st = st + " ORDER BY P_NO";
            Load2_3(st);
        }
    }
}
