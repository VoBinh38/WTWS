using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryCalender;

namespace PURCHASE.MAINCODE.Modun4.Search
{
    public partial class frmSearchCOMBC : Form
    {
        public static string C_NO;
        DataProvider con = new DataProvider();
        DataTable dt = new DataTable();
        public frmSearchCOMBC()
        {
            InitializeComponent();
            con.CheckLanguage(this);
        }

        private void frmSearchCOMBC_Load(object sender, EventArgs e)
        {
            txtC_NO.Text = C_NO;
            LoadData();
            items.Clear();
        }

        public class Items
        { 
            public string WS_NO { get; set; }
            public string NR { get; set; }
            public string WS_DATE { get; set; }
            public string C_NO { get; set; }
            public string P_NO { get; set; }
            public string P_NAME { get; set; }
            public string P_NAME1 { get; set; }
            public string P_NAME3 { get; set; }
            public string UNIT { get; set; }
            public float QTY { get; set; }
            public string BUNIT { get; set; }
            public float BQTY { get; set; }
            public float OUTBQTY { get; set; }
            public string CUNIT { get; set; }
            public string TRANS { get; set; }
            public float PRICE { get; set; }
            public int COST { get; set; }
            public float AMOUNT { get; set; }
            public string MEMO { get; set; }
            public string SH_NO { get; set; }
            public string DEPT_NO { get; set; }
            public string DEPT_NAME { get; set; }
            public string M_TRAN { get; set; }
            public string K_NO { get; set; }
            public string S_NO { get; set; }
        }
        public static List<Items> items = new List<Items>();

        private void LoadData()
        {
            string sql = "SELECT B.OVER0,NR,P_NO,P_NAME, P_NAME1,P_NAME3,BUNIT,BQTY,B.WS_NO,B.WS_DATE,DEPT_NAME,UNIT,QTY,B.CUNIT,TRANS,PRICE,COST,AMOUNT,MEMO,SH_NO,K_NO,DEPT_NO,M_TRAN,B.S_NO,B.C_NO,B.OUTBQTY" +
                " FROM COMBC B,COMHC H" +
                " WHERE B.WS_NO=H.WS_NO";
            if(rdbOpen.Checked == true)
            {
                sql = sql + " AND (B.OVER0<>'Y'AND B.HOVER<>'Y')";
            }
            else if(rdbClosed.Checked == true)
            {
                sql = sql + " AND (B.OVER0='Y'OR B.HOVER='Y')"; 
            }

            if(!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                sql = sql + " AND B.WS_NO LIKE '"+txtWS_NO.Text+"'";
            }
            if(txtWS_DATE.MaskFull)
            {
                sql = sql + " AND B.WS_DATE LIKE '"+ txtWS_DATE .Text.Replace("/","")+ "%'";
            }
            if (!string.IsNullOrEmpty(txtP_NAME1.Text))
            {
                sql = sql + " AND B.P_NAME1 LIKE '"+ txtP_NAME1.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                sql = sql + " AND B.C_NO LIKE '" + txtC_NO.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtP_NO.Text))
            {
                sql = sql + " AND B.P_NO LIKE '" + txtP_NO.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtP_NAME3.Text))
            {
                sql = sql + " AND B.P_NAME3 LIKE '" + txtP_NAME3.Text + "%'";
            }

            //sql = sql + " ORDER BY B.WS_DATE DESC,B.WS_NO DESC";
            dt = new DataTable();
            dt = con.readdata(sql);
            foreach(DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            if(dt.Rows.Count > 0)
            {
                DGV1.DataSource = dt.AsEnumerable().OrderByDescending(x => x.Field<string>("WS_DATE")).OrderByDescending(x => x.Field<string>("WS_NO")).CopyToDataTable();
            }
            else
            {
                DGV1.DataSource = dt;
            }
            
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtP_NAME1_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtP_NO_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtP_NAME3_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            var da = DGV1.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells[0].Value) == true).ToList();

            foreach (var item in da)
            {
                items.Add(new Items
                {
                    WS_NO = DGV1.Rows[item.Index].Cells["WS_NO"].Value.ToString(),
                    NR = DGV1.Rows[item.Index].Cells["NR"].Value.ToString(),
                    WS_DATE = DGV1.Rows[item.Index].Cells["WS_DATE"].Value.ToString(),
                    C_NO = DGV1.Rows[item.Index].Cells["C_NO"].Value.ToString(),
                    P_NO = DGV1.Rows[item.Index].Cells["P_NO"].Value.ToString(),
                    P_NAME = DGV1.Rows[item.Index].Cells["P_NAME"].Value.ToString(),
                    P_NAME1 = DGV1.Rows[item.Index].Cells["P_NAME1"].Value.ToString(),
                    P_NAME3 = DGV1.Rows[item.Index].Cells["P_NAME3"].Value.ToString(),
                    UNIT = DGV1.Rows[item.Index].Cells["UNIT"].Value.ToString(),
                    QTY = float.Parse(DGV1.Rows[item.Index].Cells["QTY"].Value.ToString()),
                    BUNIT = DGV1.Rows[item.Index].Cells["BUNIT"].Value.ToString(),
                    CUNIT = DGV1.Rows[item.Index].Cells["CUNIT"].Value.ToString(),
                    TRANS = DGV1.Rows[item.Index].Cells["TRANS"].Value.ToString(),
                    BQTY = float.Parse(DGV1.Rows[item.Index].Cells["BQTY"].Value.ToString()),
                    PRICE = float.Parse(DGV1.Rows[item.Index].Cells["PRICE"].Value.ToString()),
                    COST = int.Parse(DGV1.Rows[item.Index].Cells["COST"].Value.ToString()),
                    AMOUNT = float.Parse(DGV1.Rows[item.Index].Cells["AMOUNT"].Value.ToString()),
                    MEMO = DGV1.Rows[item.Index].Cells["MEMO"].Value.ToString(),
                    SH_NO = DGV1.Rows[item.Index].Cells["SH_NO"].Value.ToString(),
                    DEPT_NO = DGV1.Rows[item.Index].Cells["DEPT_NO"].Value.ToString(),
                    DEPT_NAME = DGV1.Rows[item.Index].Cells["DEPT_NAME"].Value.ToString(),
                    M_TRAN = DGV1.Rows[item.Index].Cells["M_TRAN"].Value.ToString(),
                    K_NO = DGV1.Rows[item.Index].Cells["K_NO"].Value.ToString(),
                    S_NO = DGV1.Rows[item.Index].Cells["S_NO"].Value.ToString(),
                    OUTBQTY = float.Parse(DGV1.Rows[item.Index].Cells["OUTBQTY"].Value.ToString())
                }); ;
            }
            this.Close();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cur = DGV1.CurrentRow.Index;
            if(Convert.ToBoolean(DGV1.Rows[cur].Cells[0].Value) == false)
            {
                DGV1.Rows[cur].SetValues(true);
            }
            else
            {
                DGV1.Rows[cur].SetValues(false);
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbAll.Checked == true)
            {
                LoadData();

            }
            
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbClosed.Checked == true)
            {
                LoadData();

            }
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOpen.Checked == true)
            {
                LoadData();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
