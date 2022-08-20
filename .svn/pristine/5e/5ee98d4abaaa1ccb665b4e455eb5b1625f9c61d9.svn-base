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
    public partial class Form1EF7_Tab2 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1EF7_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        private void Form1EF7_Tab2_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string s1 = Form1E_F7.DLT.t1t2;
            string s2 = Form1E_F7.DLT.t2t2;
            string s3 = Form1E_F7.DLT.t3t2;
            string s4 = Form1E_F7.DLT.t4t2;
         
           cr_Form1EF7_Tab2 rpt = new cr_Form1EF7_Tab2();
            string st = "";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "Select P_NO, P_NAME, UNIT from PROD";

            if ((s1.ToString() != "") || (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "Select P_NO, P_NAME, UNIT from PROD";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() == ""))
                st = "Select P_NO, P_NAME, UNIT from PROD where P_NO between '" + s3.ToString() + "' and (select top(1) P_NO from PROD order by P_NO Desc)";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() != ""))
                st = "Select P_NO, P_NAME, UNIT from PROD where P_NO between (select top(1) P_NO from PROD order by P_NO Asc) and '"+s4.ToString()+"'";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() != ""))
                st = "Select P_NO, P_NAME, UNIT from PROD where P_NO between '"+s3.ToString()+"' and '" + s4.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

    }
}
