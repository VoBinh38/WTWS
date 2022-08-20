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
    public partial class SearchQUVHC : Form
    {
        public static string wheres ="";
        DataProvider con = new DataProvider();
        DataTable dt;

        public class GetItem
        {
            public static string QDATE;
            public static string K_NO;
            public static string P_NO;
            public static int index;
        }
        public SearchQUVHC()
        {
            InitializeComponent();
        }

        private void SearchQUVHC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT K_NO,C_NO,P_NO,QDATE,P_NAME,P_NAME3,PRICE,P_NAME1,PRICE5,PRICE3,PRICE9,PRICE6,PRICE7" +
                        " FROM QUVHC WHERE 2 > 1 ";
            if(!string.IsNullOrEmpty(txtP_NO.Text))
            {
                wheres = wheres + " AND P_NO LIKE N'"+txtP_NO.Text+"%'";
            }
            if (!string.IsNullOrEmpty(txtP_NAME.Text))
            {
                wheres = wheres + " AND P_NAME LIKE N'%" + txtP_NAME.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtP_NAME1.Text))
            {
                wheres = wheres + " AND P_NAME1 LIKE N'%" + txtP_NAME1.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtP_NAME3.Text))
            {
                wheres = wheres + " AND P_NAME3 LIKE N'%" + txtP_NAME3.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtK_NO.Text))
            {
                wheres = wheres + " AND K_NO LIKE N'"+txtK_NO.Text+"%'";
            }
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                wheres = wheres + " AND C_NO LIKE N'" + txtC_NO.Text + "%'";
            }

            if(rbW_CHECK1.Checked == true)
            {
                wheres = wheres + " AND W_CHECK= 'Y'";
            }else if(rbW_CHECK2.Checked == true)
            {
                wheres = wheres + " AND W_CHECK= 'N'";
            }else if(rbW_CHECK3.Checked == true)
            {
                wheres = wheres + " AND W_CHECK= '*'";
            }
            sql = sql + wheres + " order by P_NO,qdate DESC";
            dt = new DataTable();
            dt = con.readdata(sql);
            foreach(DataRow item in dt.Rows)
            {
                item["QDATE"] = con.formatstr2(item["QDATE"].ToString());
            }
            DGV1.DataSource = dt;
        }

        private void txtP_NO_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtP_NAME_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtP_NAME1_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtP_NAME3_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtK_NO_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void rbW_CHECK_CheckedChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void rbW_CHECK1_CheckedChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void rbW_CHECK2_CheckedChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void rbW_CHECK3_CheckedChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            wheres = "";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetItem.QDATE = DGV1.Rows[DGV1.CurrentRow.Index].Cells["QDATE"].Value.ToString();
            GetItem.K_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            GetItem.P_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NO"].Value.ToString();
            GetItem.index = DGV1.CurrentRow.Index;
            this.Close();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetItem.QDATE = DGV1.Rows[DGV1.CurrentRow.Index].Cells["QDATE"].Value.ToString();
            GetItem.K_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            GetItem.P_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NO"].Value.ToString();
            GetItem.index = DGV1.CurrentRow.Index;
            this.Close();
        }
    }
}
