using PURCHASE.MAINCODE.Modun1.CrytalReport;
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
    public partial class Form1DF7_Tab4 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab4()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab4_Load(object sender, EventArgs e)
        {
            bool r1 = Form1DF7.RD.r1t4;
            bool r2 = Form1DF7.RD.r2t4;
            
            if(r1 == true)
            {
                Load1();
            }
            else if (r2 == true)
            {
                Load2();
            }    
           
        }
        private void getData(string st)
        {
            string s1 = Form1DF7.DLT.t1t4;
            string s2 = Form1DF7.DLT.t2t4;
            string s3 = Form1DF7.DLT.t3t4;
            string s4 = Form1DF7.DLT.t4t4;
            if (!string.IsNullOrEmpty(s1) || !string.IsNullOrEmpty(s2))
            {
                if (!string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
                {
                    st = st + " AND P_NO BETWEEN '" + s1 + "' AND (SELECT TOP 1 P_NO from PROD1C ORDER BY P_NO DESC)";
                }
                else if (string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2))
                {
                    st = st + " AND P_NO BETWEEN (SELECT TOP 1 P_NO from PROD1C ORDER BY P_NO ASC) AND '" + s2 + "'";
                }
                else if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2))
                {
                    st = st + " AND P_NO BETWEEN '" + s1 + "' AND '" + s2 + "'";
                }
            }
            if (!string.IsNullOrEmpty(s3) || !string.IsNullOrEmpty(s4))
            {
                if (!string.IsNullOrEmpty(s3) && string.IsNullOrEmpty(s4))
                {
                    st = st + " AND K_NO BETWEEN '" + s3 + "' AND (SELECT TOP 1 K_NO from PROD1C ORDER BY K_NO DESC)";
                }
                else if (string.IsNullOrEmpty(s3) && !string.IsNullOrEmpty(s4))
                {
                    st = st + " AND K_NO BETWEEN (SELECT TOP 1 K_NO from PROD1C ORDER BY K_NO ASC) AND '" + s4 + "'";
                }
                else if (!string.IsNullOrEmpty(s3) && !string.IsNullOrEmpty(s4))
                {
                    st = st + " AND K_NO BETWEEN '" + s3 + "' AND '" + s4 + "'";
                }
            }
            st = st + " ORDER BY P_NO ASC";
            cr_Form1DF7_Tab4 rpt = new cr_Form1DF7_Tab4();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        public void Load1()
        {
            string sql = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE(QTYSAF - QTYSTORE) > 0 ";
            getData(sql);
        }

        public void Load2()
        {
            string st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C";
            getData(st);
        }
    }
}
