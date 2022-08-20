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
    public partial class SearchCGBHC : Form
    {
        public static string Wheres;
        public static string OrderBy;
        DataProvider con = new DataProvider();
        DataTable dt;
        public class Getitem
        {
            public static string WS_NO;
            public static int index;
        }
        public SearchCGBHC()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchCGBHC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT WS_NO,WS_DATE,C_NAME,TOTAL,TAX,TOT,DISCOUNT,OR_NO FROM dbo.CGBHC where 1=1" + Wheres;
            if(!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                Wheres = Wheres + " AND WS_NO LIKE N'"+txtWS_NO.Text+"%'";
            }
            if(txtWS_DATE.MaskFull)
            {
                Wheres = Wheres + " AND WS_DATE LIKE N'"+txtWS_DATE.Text.Replace("/","")+"%'";
            }
            if(!string.IsNullOrEmpty(txtC_NO.Text))
            {
                Wheres = Wheres + " AND C_NO LIKE N'"+txtC_NO.Text+"%'";
            }
            if (!string.IsNullOrEmpty(txtC_NAME.Text))
            {
                Wheres = Wheres + " AND C_NAME LIKE N'%"+txtC_NAME.Text+"%'";
            }
            sql = sql + Wheres + OrderBy;
            dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            Wheres = "";
            LoadData();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            Wheres = "";
            LoadData();
        }

        private void txtC_NAME_TextChanged(object sender, EventArgs e)
        {
            Wheres = "";
            LoadData();
        }

        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
            Wheres = "";
            LoadData();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Getitem.WS_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            Getitem.index = DGV1.CurrentRow.Index;
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Getitem.WS_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            Getitem.index = DGV1.CurrentRow.Index;
            this.Close();
        }
    }
}
