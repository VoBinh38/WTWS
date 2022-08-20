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
    public partial class FormSearchCOMHC1 : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt = new DataTable();
        public FormSearchCOMHC1()
        {
            InitializeComponent();
        }

        private void FormSearchCOMHC1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string sql = "SELECT C_NO,WS_DATE,'' AS a,TAX,WS_NO,TOTAL,C_NAME_O,TOT," +
                "LEFT(DATESE, 4) + '/' + SUBSTRING(DATESE, 5, 2) + '/' + SUBSTRING(DATESE, 7, 2) + '-' + '/' + SUBSTRING(DATESE, 9, 4) + '/' + SUBSTRING(DATESE, 13, 2) + '/' + SUBSTRING(DATESE, 15, 2) AS DATESE,DISCOUNT FROM COMHC1 WHERE 2>1 ";
            if (string.IsNullOrEmpty(txtWS_NO.Text))
            {
                sql = sql + " AND WS_NO LIKE '"+ txtWS_NO.Text +"%'";
            }
            if(string.IsNullOrEmpty(txtC_NO.Text))
            {
                sql = sql + " AND C_NO LIKE '"+ txtC_NO.Text +"%'";
            }
            if(txtWS_DATE.MaskFull)
            {
                sql = sql + " AND WS_DATE LIKE '" + txtWS_DATE.Text.Replace("/", "") + "%'";
            }
            sql = sql + " ORDER BY WS_DATE DESC,WS_NO DESC";
            dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtWS_DATE_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            LoadData();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetItem.WS_NO = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            GetItem.WS_NO = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }
        public class GetItem
        {
            public static string WS_NO { get; set; }
        }
    }
}
