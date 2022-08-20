using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE.WSEXE
{
    public partial class Report : Form
    {
        public Report()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        public class ShareReport
        {
            public static ReportDocument repo;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            var report = ShareReport.repo;
            crystalReportViewer1.ReportSource = report;
        }
    }
}
