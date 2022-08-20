using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryCalender;

namespace PURCHASE.MAINCODE.Search
{
    public partial class SearchPAYV : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        string wheres = "";
        int count = 0;
        int pageIndex = 1;
        int PageSize = 50;
        public SearchPAYV()
        {
            InitializeComponent();
            con.CheckLanguage(this);
            this.DGV1.MouseWheel += new MouseEventHandler(mousewheel);
        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            con.Mousewheelscroll(DGV1, e);
        }
        private void SearchPAYV_Load(object sender, EventArgs e)
        {
            wheres = Form4E.Getitem.Wheres;
            LoadData();
        }

        private void LoadData()
        {
            string sqlcount = "SELECT COUNT(CUTON) FROM dbo.PAYV";
            count = int.Parse(con.readdata(sqlcount).Rows[0][0].ToString());

            string sql = "SELECT TOP 50 CUTON,CUTOFF,C_ANAME as C_ANAME_1,C_NO,CTOTAL,TAX as TAX_1,DISCOUNT as DISCOUNT_1,CASH,CURRMON FROM PAYV WHERE 2 > 1 ";
            if (txtCUTON.MaskFull)
            {
                wheres = wheres + " AND CUTON LIKE '%" + txtCUTON.Text.Replace("/", "") + "%' ";
            }

            if (txtCUTOFF.MaskFull)
            {
                wheres = wheres + " AND CUTOFF LIKE '%" + txtCUTOFF.Text.Replace("/", "") + "%'";
            }
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                wheres = wheres + " AND C_NO LIKE '%" + txtC_NO.Text + "%'";
            }
            sql = sql + wheres + " ORDER BY CUTON DESC, C_NO";
            dt = new DataTable();
            dt = con.readdata(sql);

            if(dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    item["CUTON"] = con.formatstr2(item["CUTON"].ToString());
                    item["CUTOFF"] = con.formatstr2(item["CUTOFF"].ToString());
                }
            }
            DGV1.DataSource = dt;
            DGV1.CurrentCell = DGV1[2, GetItem.index];
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetItem.CUTON = DGV1.Rows[DGV1.CurrentRow.Index].Cells["CUTON"].Value.ToString();
            GetItem.CUTOFF = DGV1.Rows[DGV1.CurrentRow.Index].Cells["CUTOFF"].Value.ToString();
            GetItem.C_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            GetItem.C_ANAME = DGV1.Rows[DGV1.CurrentRow.Index].Cells["C_ANAME_1"].Value.ToString();
            GetItem.index = DGV1.CurrentRow.Index;
            Form4E.Getitem.Wheres = wheres;
            this.Close();
        }

        public class GetItem
        {
            public static string CUTON { get; set; }
            public static string CUTOFF { get; set; }
            public static string C_NO { get; set; }
            public static string C_ANAME { get; set; }
            public static int index { get; set; }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            GetItem.CUTON = DGV1.Rows[DGV1.CurrentRow.Index].Cells["CUTON"].Value.ToString();
            GetItem.CUTOFF = DGV1.Rows[DGV1.CurrentRow.Index].Cells["CUTOFF"].Value.ToString();
            GetItem.C_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            GetItem.C_ANAME = DGV1.Rows[DGV1.CurrentRow.Index].Cells["C_ANAME_1"].Value.ToString();
            GetItem.index = DGV1.CurrentRow.Index;
            Form4E.Getitem.Wheres = wheres;
            this.Close();
        }
        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtCUTON_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtCUTOFF_TextChanged(object sender, EventArgs e)
        {
            wheres = "";
            LoadData();
        }

        private void txtCUTON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                wheres = "";
                LoadData();
            }
        }

        private void txtCUTOFF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                wheres = "";
                LoadData();
            }
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                wheres = "";
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                                         "SELECT ROW_NUMBER() OVER(ORDER BY CUTON DESC,C_NO) AS ROWID,CUTON,CUTOFF,C_ANAME as C_ANAME_1,C_NO,CTOTAL,TAX as TAX_1,DISCOUNT as DISCOUNT_1,CASH,CURRMON FROM PAYV" +
                                         ") a where 1=1 " + (!string.IsNullOrEmpty(wheres) ? wheres : "") + " AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);

                            DataTable ds = new DataTable();
                            ds = con.readdata(str);
                            foreach (DataRow item in dt.Rows)
                            {
                                item["CUTON"] = con.formatstr2(item["CUTON"].ToString());
                                item["CUTOFF"] = con.formatstr2(item["CUTOFF"].ToString());
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

        private void txtCUTON_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtCUTON.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtCUTOFF_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtCUTOFF.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
