
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
    public partial class frmSearchCOMHC : Form
    {
        DataProvider conn = new DataProvider();
        DataTable dt;
        int count =0;

        public static string where;
        public frmSearchCOMHC()
        {
            InitializeComponent();
            conn.CheckLanguage(this);
            this.DGV1.MouseWheel += new MouseEventHandler(mousewheel);
        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            conn.Mousewheelscroll(DGV1, e);
        }
        private void frmSearchCOMHC_Load(object sender, EventArgs e)
        {
            txtWS_DATE.Text = Form4B.PassDataSearch.WS_DATE;
            txtC_NO.Text = Form4B.PassDataSearch.C_NO;
            txtWS_NO.Text = Form4B.PassDataSearch.WS_NO;
            LoadData();
        }

        public class GetDataLoad
        {
            public static DataTable GetData;
            public static int index;
        }
        public void LoadData()
        {
            string sqlcount = "SELECT COUNT(WS_NO) FROM dbo.COMHC";
            count = int.Parse(conn.readdata(sqlcount).Rows[0][0].ToString());

            string sql = "SELECT TOP 50 ROW_NUMBER() OVER (ORDER BY WS_DATE DESC,WS_NO DESC) AS ROWID, WS_NO,WS_DATE,C_NO,C_NAME,TOT,TAX,DISCOUNT,TOTAL,OR_NO,S_NO,INV_NO,DATESE FROM COMHC where 1 = 1 " + where;
            if (!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                where = where + " AND WS_NO = '" + txtWS_NO.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                where = where + " AND C_NO Like '%" + txtC_NO.Text + "%'";
            }
            if (txtWS_DATE.MaskFull)
            {
                where = where + " AND WS_DATE = '" + txtWS_DATE.Text.Replace("/","") + "'";
            }
            sql = sql + where + " ORDER BY WS_DATE DESC,WS_NO DESC";
            dt = conn.readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString()); 
            }
                DGV1.DataSource = dt;
        }
        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadData();
        }

        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadData();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadData();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            //GetDataLoad.GetData = dt;
            GetDataLoad.index = DGV1.CurrentRow.Index;
            Form4B.PassDataSearch.WS_DATE = txtWS_DATE.Text;
            Form4B.PassDataSearch.WS_NO = txtWS_NO.Text;
            Form4B.PassDataSearch.C_NO = txtC_NO.Text;
            this.Close();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //GetDataLoad.GetData = dt;
            GetDataLoad.index = DGV1.CurrentRow.Index;
            Form4B.PassDataSearch.WS_DATE = txtWS_DATE.Text;
            Form4B.PassDataSearch.WS_NO = txtWS_NO.Text;
            Form4B.PassDataSearch.C_NO = txtC_NO.Text;
            this.Close();
        }
        int pageIndex = 1;
        int PageSize = 50;
        private void DGV1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                int display = DGV1.Rows.Count - DGV1.DisplayedRowCount(false);
                if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
                {
                    if (e.NewValue >= DGV1.Rows.Count - GetDisplayedRowsCount())
                    {
                        if(count > DGV1.Rows.Count)
                        {
                            string str = "SELECT * FROM (" +
                                         "SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC, WS_NO DESC) AS ROWID, WS_NO,WS_DATE,C_NO,C_NAME,TOT,TAX,DISCOUNT,TOTAL,OR_NO,S_NO,INV_NO,DATESE FROM COMHC" +
                                         ") a where 1=1 " + (!string.IsNullOrEmpty(where) ? where : "") + " AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);

                            DataTable ds = new DataTable();
                            ds = conn.readdata(str);
                            dt.Merge(ds);
                            DGV1.DataSource = dt;
                            DGV1.ClearSelection();
                            DGV1.FirstDisplayedScrollingRowIndex = display;
                            pageIndex++;
                        }
                    }
                }
            }
        }
        private int GetDisplayedRowsCount()
        {
            int count = DGV1.Rows[DGV1.FirstDisplayedScrollingRowIndex].Height;
            count = DGV1.Height / count;
            return count;
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
