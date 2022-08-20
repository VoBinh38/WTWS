using CrystalDecisions.CrystalReports.Engine;
using PURCHASE.MAINCODE.Modun1.CrytalReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PURCHASE.DataCenter.Report1;

namespace PURCHASE.MAINCODE.Modun1.Print
{
    public partial class frm1BF7_tab1 : Form
    {
        public frm1BF7_tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        private void frm1BF7_tab1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = Form1BF7.getDataTable.table;
            ReportDocument cryRpt = new ReportDocument();
            if (Form1BF7.getDataTable.rdt1t1 == true)
            {
                cryRpt = new Cr_From1BF7_Tab1_1();
            }
            else
            {
                cryRpt = new Cr_From1BF7_Tab1_2();
            }
            cryRpt.SetDataSource(dataTable);
            ShareReport.repo = cryRpt;
            crystalReportViewer1.ReportSource = cryRpt;
        }
    }
}
