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
    public partial class frmSearchSale : Form
    {
        DataProvider con = new DataProvider();
        public frmSearchSale()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
           
        }
        public class getSale
        {
            public static string mabophan;
            public static string tenbophan;
        }
        private void loadDataGRV()
        {
            string str1 = "SELECT S_NO, S_NAME FROM SALE ";
            DataTable dt = con.readdata(str1);
            DGV2.DataSource = dt;
        }
        private void searching()
        {
            string sql = "SELECT S_NO, S_NAME FROM SALE WHERE 1=1";
            string mabophan = txtMaNV.Text;
            string tenbophan = txtTenNV.Text;
            if(mabophan == "" && tenbophan == "")
            {
                sql = sql + "";
            }
             if(mabophan != "")
            {
                sql = " AND S_NO LIKE '%"+ mabophan + "%'";
            }
             if (tenbophan != "")
            {
                sql = " AND S_NAME LIKE '%" + tenbophan + "%'";
            }
            DataTable dt = con.readdata(sql);
            DGV2.DataSource = dt;
            con.DGV(DGV2);
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            searching();
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            searching();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getSale.mabophan = DGV2.CurrentRow.Cells["S_NO"].Value.ToString();
            getSale.tenbophan = DGV2.CurrentRow.Cells["S_NAME"].Value.ToString();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            getSale.mabophan = DGV2.CurrentRow.Cells["S_NO"].Value.ToString();
            getSale.tenbophan = DGV2.CurrentRow.Cells["S_NAME"].Value.ToString();
            this.Close();
        }

        private void frm2LF7_Sale_Load(object sender, EventArgs e)
        {
            loadDataGRV();
            con.DGV(DGV2);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
