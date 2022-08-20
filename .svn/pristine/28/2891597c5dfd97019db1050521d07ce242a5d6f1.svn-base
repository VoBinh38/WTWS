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
    public partial class Form4CF5 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable dt = new DataTable();
        int pageIndex = 1;
        int PageSize = 50;
        int count = 0;
        public Form4CF5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.CheckLanguage(this);
            this.DGV1.MouseWheel += new MouseEventHandler(mousewheel);
        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            conn.Mousewheelscroll(DGV1, e);
        }
        public class item
        {
            public static int index { get; set; }
            //public static DataTable dt { get; set; }
        }
        public static string where;
        private void Form4CF5_Load(object sender, EventArgs e)
        {
            LoadDate();
        }
        public void LoadDate()
        {
            string sqlcount = "SELECT COUNT(WS_NO) FROM dbo.COMHC1";
            count = int.Parse(conn.readdata(sqlcount).Rows[0][0].ToString());

            string sql = "select top 50 C_NO,WS_DATE,OR_NO,TAX,WS_NO,TOTAL,C_NAME,TOT,DATESE,DISCOUNT FROM COMHC1 WHERE 1=1";
            if (!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                where = where + " AND WS_NO LIKE '"+txtWS_NO.Text+"%'";
            }
            if(txtWS_DATE.MaskFull)
            {
                where = where + " AND WS_DATE = '" + txtWS_DATE.Text.Replace("/","")+"'";
            }if(!string.IsNullOrEmpty(txtC_NO.Text))
            {
                where = where + " AND C_NO LIKE '%"+txtC_NO.Text+"%'";
            }
            if(!string.IsNullOrEmpty(txtC_NAME.Text))
            {
                where = where + " AND C_NAME LIKE '%"+txtC_NAME.Text+"%'";
            }
            if(!string.IsNullOrEmpty(txtOR_NO.Text))
            {
                where = where + " AND OR_NO LIKE '%"+txtOR_NO.Text+"%'";
            }
            sql = sql + where + " ORDER BY WS_DATE DESC,WS_NO DESC";
            dt = new DataTable();
            dt = conn.readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString());
            }
            DGV1.DataSource = dt;
            conn.DGV(DGV1);
        }
        //public void SelectItemList()
        //{
        //    var da1 = item.dt.AsEnumerable().Select(x => new {
        //        C_NO = x.Field<string>("C_NO").ToString(),
        //        WS_DATE = x.Field<string>("WS_DATE").ToString(),
        //        OR_NO = x.Field<string>("OR_NO").ToString(),
        //        TAX = x.Field<double>("TAX"),
        //        WS_NO = x.Field<string>("WS_NO").ToString(),
        //        TOTAL = x.Field<double>("TOTAL"),
        //        C_NAME = x.Field<string>("C_NAME").ToString(),
        //        TOT = x.Field<double>("TOT"),
        //        DATESE = x.Field<string>("DATESE").ToString(),
        //        DISCOUNT = x.Field<double>("DISCOUNT")
        //    }).ToList();

        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadDate();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadDate();
        }

        private void txtOR_NO_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadDate();
        }

        private void txtC_NAME_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadDate();
        }

        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
            where = "";
            LoadDate();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            item.index = DGV1.CurrentRow.Index;
            this.Close();
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                where = "";
                LoadDate();
            }
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                where = "";
                LoadDate();
            }
        }

        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                where = "";
                LoadDate();
            }
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                where = "";
                LoadDate();
            }
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                where = "";
                LoadDate();
            }
        }

        private void DGV1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                int display = DGV1.Rows.Count - DGV1.DisplayedRowCount(false);
                if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
                {
                    if (e.NewValue >= DGV1.Rows.Count - GetDisplayedRowsCount())
                    {
                        if (count > DGV1.Rows.Count)
                        {
                            string str = "SELECT * FROM (" +
                                         "SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC, WS_NO DESC) AS ROWID, C_NO,WS_DATE,OR_NO,TAX,WS_NO,TOTAL,C_NAME,TOT,DATESE,DISCOUNT FROM COMHC1 " +
                                         ") a where 1=1 " + (!string.IsNullOrEmpty(where) ? where : "") + " AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);
                            DataTable ds = new DataTable();
                            ds = conn.readdata(str);
                            foreach (DataRow item in ds.Rows)
                            {
                                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString());
                            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            item.index = DGV1.CurrentRow.Index;
            this.Close();
        }
    }
}
