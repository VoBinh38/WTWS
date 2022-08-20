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
    public partial class Form1EF7_Tab1 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1EF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1EF7_Tab1_Load(object sender, EventArgs e)
        {
            Load1();
        }

        public void Load1()
        {
            string s1 = Form1E_F7.DLT.t1t1;
            string s2 = Form1E_F7.DLT.t2t1;
            string s3 = Form1E_F7.DLT.t3t1;
            string s4 = Form1E_F7.DLT.t4t1;
            string s5 = Form1E_F7.DLT.t5t1;
            string s6 = Form1E_F7.DLT.t6t1;
            string s7 = Form1E_F7.DLT.t7t1;
            string s8 = Form1E_F7.DLT.t8t1;

            cr_Form1EF7_Tab1 rpt = new cr_Form1EF7_Tab1();
            string st = "";

            if((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
            st = "Select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";

            if ((s1.ToString() != "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
                st = "Select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";

            if ((s1.ToString() == "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
                st = "Select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";

            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
                st = "Select C_NO from PSHQTYP";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() != "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP Where P_NO between '"+s3.ToString()+"' and '"+s4.ToString()+"'";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP Where P_NO between '"+s3.ToString()+"' and(select top(1) P_NO from PSHQTYP order by P_NO Desc)";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() != "") && (s5.ToString() == "") && (s6.ToString() == "") && (s7.ToString() == "") && (s8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP Where P_NO between (select top(1) P_NO from PSHQTYP order by P_NO Asc) and '"+s4.ToString()+"'";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") || (s5.ToString() != "") || (s6.ToString() != "") || (s7.ToString() != "") || (s8.ToString() != ""))
                st = "Select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";

            st = st + " ORDER BY SH_NO1,P_NO,SH_NO";
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
