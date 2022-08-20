using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Search
{
    public partial class SearchPSHQTY : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        public SearchPSHQTY()
        {
            InitializeComponent();
        }

        private void SearchPSHQTY_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public class Item {
            public static string SH_NO;
        }

        private void LoadData()
        {
            string sql = "SELECT SH_NO,WS_RECNO,QTY FROM PSHQTY  where P_NO = N'" + Item.SH_NO + "'";
            dt = new DataTable();
            dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Item.SH_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["SH_NO"].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
