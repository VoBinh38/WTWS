using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Modun4.Search
{
    public partial class frmSearchSH_NUM : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt = new DataTable();
        public frmSearchSH_NUM()
        {
            InitializeComponent();
        }

        private void frmSearchSH_NUM_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string sql = "SELECT SH_NO,SH_NUM FROM SH_NUM";
            dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }
    }
}
