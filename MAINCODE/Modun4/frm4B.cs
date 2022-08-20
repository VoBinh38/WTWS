﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using LibraryCalender;
using PURCHASE.MAINCODE.Modun4.Search;
using PURCHASE.MAINCODE.Search;
using PURCHASE.DataCenter;
using CrystalDecisions.CrystalReports.Engine;
using PURCHASE.MAINCODE.Modun4.Report;
using static PURCHASE.DataCenter.Report1;
using PURCHASE.MAINCODE;

namespace PURCHASE
{
    public partial class Form4B : Form
    {
        DataProvider conn = new DataProvider();
        DataTable dt = new DataTable();
        BindingSource bindingSource = new BindingSource();
        string C_ANAME, ADR1,DEFA_MONEY;
        public Form4B()
        {
            InitializeComponent();
            conn.CheckLanguage(this);
            conn.CheckLoad(menuStrip1);
            this.ShowInTaskbar = false;
        }
        private void ShowTextBox()
        {
            this.txtWS_DATE.Text = currentRow["WS_DATE"].ToString();
            this.txtM_KIND.Text = currentRow["M_KIND"].ToString();
            this.txtWS_NO.Text = currentRow["WS_NO"].ToString();
            this.txtC_NO.Text = currentRow["C_NO"].ToString();
            this.txtC_NAME.Text = currentRow["C_NAME"].ToString();
            this.txtINV_NO.Text = currentRow["INV_NO"].ToString();
            this.txtFOB_DATE.Text = currentRow["FOB_DATE"].ToString();

            this.txtCAL_YM.Text = currentRow["CAL_YM"].ToString();
            this.txtTOTAL.Text = conn.ConvertNumber(currentRow["TOTAL"].ToString());
            
            this.txtM_TRAN_R.Text = currentRow["M_TRAN_R"].ToString();

            this.txtMEMO1.Text = currentRow["MEMO1"].ToString();
            this.txtTOT.Text = conn.ConvertNumber(currentRow["TOT"].ToString());
            this.txtTAX.Text = currentRow["TAX"].ToString();
            this.txtDISCOUNT.Text = conn.ConvertNumber(currentRow["DISCOUNT"].ToString());
            this.txtGWEGT.Text = currentRow["GWEGT"].ToString();
            this.txtNWEGT.Text = currentRow["NWEGT"].ToString();
            this.txtRCV_MON.Text = currentRow["RCV_MON"].ToString();
            this.txtNRCV_MON.Text = conn.ConvertNumber(currentRow["NRCV_MON"].ToString());

            C_ANAME = currentRow["C_ANAME"].ToString();
            ADR1 = currentRow["ADDR"].ToString();
            DEFA_MONEY = currentRow["M_TRAN"].ToString();
        }

        private void LoadData()
        {
            string counts = "SELECT COUNT(WS_NO) AS counts FROM COMHC where 1=1 " + frmSearchCOMHC.where;
            count = int.Parse(conn.readdata(counts).Rows[0][0].ToString());

            string sql = "SELECT top 10 WS_DATE,M_KIND,WS_NO,C_NO,C_NAME,INV_NO,FOB_DATE,CAL_YM" +
                ", TOTAL, M_TRAN_R, MEMO1, TOT, TAX, DISCOUNT, GWEGT" +
                ", NWEGT, RCV_MON, NRCV_MON, C_ANAME, ADDR, M_TRAN FROM COMHC where 1=1 "+ frmSearchCOMHC.where + " ORDER BY WS_DATE DESC,WS_NO DESC";
            dt = conn.readdata(sql);
            bindingSource.DataSource = dt;
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT NR,C_NO,P_NO,P_NAME,P_NAME1,P_NAME3,BQTY,BUNIT,PRICE,AMOUNT,DEPT_NAME,MEMO,OUTBQTY,OVER0,CUNIT,TRANS,K_NO,DEPT_NO,UNIT" +
                " FROM COMBC WHERE WS_NO = '" + txtWS_NO.Text + "'";
            DataTable data = conn.readdata(sql);
            DGV1.DataSource = data;

            if(DGV1.Rows.Count > 0)
            {
                if(f2ToolStripMenuItem.Checked == false || f4ToolStripMenuItem.Checked == false)
                {
                    DGV1.CurrentCell = DGV1[0, 0];
                    LoadDataGrid(DGV1.CurrentRow.Index);
                }
            }
            else
            {
                LoadDataGrid(0);
            }
            Loadcb(currentRow["M_TRAN"].ToString());
        }
        public DataRow currentRow
        {
            get
            {
                int position = this.BindingContext[bindingSource].Position;
                if (position > -1)
                {
                    return ((DataRowView)bindingSource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        private void Form4B_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            //f7ToolStripMenuItem.Enabled = false;
            LoadData();
            ShowTextBox(); 
            getInfo();
        }
        public void Loadcb(string M_NO)
        {
            string wheres = "";
            if (f2ToolStripMenuItem.Checked == false)
            {
                wheres = " AND M_NO = '" + M_NO + "'";
            }
            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1 " + wheres + "";
            DataTable data = conn.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";
        }
        int pageIndex = 1;
        int PageSize = 10;
        private void btsau_Click(object sender, EventArgs e)
        {
            int position = bindingSource.Position;
            if (bindingSource.Count < count)
            {
                if(position == (pageIndex * PageSize) - 1)
                {
                    string sql1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC, WS_NO DESC) AS ROWID, WS_DATE, M_KIND, WS_NO, C_NO, C_NAME, INV_NO, FOB_DATE," +
                                    " CAL_YM,TOTAL, M_TRAN_R, MEMO1, TOT, TAX, DISCOUNT, GWEGT, NWEGT, RCV_MON, NRCV_MON, C_ANAME, ADDR, M_TRAN FROM COMHC) a " +
                                    " where 1=1 " + frmSearchCOMHC.where + " AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize) + "";
                    DataTable ds = new DataTable();
                    ds = conn.readdata(sql1);
                    dt.Merge(ds);
                    bindingSource.DataSource = dt;
                    bindingSource.Position = position;
                    pageIndex++;
                }
            }
            bindingSource.MoveNext();
            ShowTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            if(position +1 == count -1)
            {
                btsau.Enabled = false;
                btketthuc.Enabled = false;
            }
        }
        int count = 0;
        private void btketthuc_Click(object sender, EventArgs e)
        {
            if(bindingSource.Count < count)
            {
                string sql1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC, WS_NO DESC) AS ROWID, WS_DATE, M_KIND, WS_NO, C_NO, C_NAME, INV_NO, FOB_DATE," +
                       " CAL_YM,TOTAL, M_TRAN_R, MEMO1, TOT, TAX, DISCOUNT, GWEGT, NWEGT, RCV_MON, NRCV_MON, C_ANAME, ADDR, M_TRAN FROM COMHC) a " +
                       " where 1=1 " + frmSearchCOMHC.where + "";
                DataTable ds = new DataTable();
                ds = conn.readdata(sql1);
                bindingSource  = new BindingSource();
                bindingSource.DataSource = ds;
            }
            
            bindingSource.MoveLast();
            ShowTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            ShowTextBox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
            ShowTextBox();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void txtM_KIND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                if (txtM_KIND.Text == "8")
                {
                    txtM_KIND.Text = "1";
                }
                else
                {
                    txtM_KIND.Text = (int.Parse(txtM_KIND.Text) + 1).ToString();
                }
            }
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F2Menu_Click();
        }

        private void F2Menu_Click()
        {
            btnOK.Visible = true;
            btnClose.Visible = true;

            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtM_KIND.Text = "1";
            txtINV_NO.Text = "N";
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtWS_NO.Text = "";
            txtFOB_DATE.Text = "";
            txtCAL_YM.Text = "";
            txtMEMO1.Text = "";
            txtTOTAL.Text = "0.00";
            txtRCV_MON.Text = "0";
            txtNRCV_MON.Text = "0.00";
            txtNWEGT.Text = "0";
            txtTOT.Text = "0.00";
            txtTAX.Text = "0";
            txtDISCOUNT.Text = "0.00";
            txtGWEGT.Text = "0";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            cbM_TRAN.Enabled = true;
            label3.Text = "化 料 - 台 灣";

            bt.Text = "Thêm";
            DGV1.Refresh();
            DGV2.Refresh();
        }

        private void txtM_KIND_TextChanged(object sender, EventArgs e)
        {
                switch (txtM_KIND.Text)
                {
                    case "1":
                        label3.Text = "化 料 - 台 灣";
                        break;
                    case "2":
                        label3.Text = "化料-大陸";
                        break;
                    case "3":
                        label3.Text = "開狀櫃化料-台灣";
                        break;
                    case "4":
                        label3.Text = "總料-台灣";
                        break;
                    case "5":
                        label3.Text = "總料-大陸";
                        break;
                    case "6":
                        label3.Text = "化料-越南";
                        break;
                    case "7":
                        label3.Text = "總料-越南";
                        break;
                    case "8":
                        label3.Text = "化料-越南轉廠";
                        break;
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            LoadData();
            ShowTextBox();
            btnOK.Visible = false;
            btnClose.Visible = false;
            cbM_TRAN.Enabled = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            getInfo();
        }

        private void txtFOB_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender from = new LibraryCalender.FromCalender();
                from.ShowDialog();
                txtFOB_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender from = new LibraryCalender.FromCalender();
                from.ShowDialog();
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }

        private void txtCAL_YM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender from = new LibraryCalender.FromCalender();
                from.ShowDialog();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyyMM");
            }
        }

        private void txtWS_NO_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                string Code_WS_NO = "";
                switch (txtM_KIND.Text)
                {
                    case "1":
                        Code_WS_NO = "台化 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "2":
                        Code_WS_NO = "大化 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "3":
                        Code_WS_NO = "台化 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "4":
                        Code_WS_NO = "台總 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "5":
                        Code_WS_NO = "越化 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "6":
                        Code_WS_NO = "台化 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "7":
                        Code_WS_NO = "越總 " + DateTime.Now.ToString("yy") + "-";
                        break;
                    case "8":
                        Code_WS_NO = "轉化 " + DateTime.Now.ToString("yy") + "-";
                        break;
                }
                string sql = "SELECT WS_NO FROM COMHC WHERE WS_NO LIKE '"+ Code_WS_NO + "%' ORDER BY WS_NO desc";
                DataTable data = conn.readdata(sql);
                if(data.Rows.Count > 0)
                {
                    string Code_WS_NO_NEW = data.Rows[0]["WS_NO"].ToString();
                    int number = int.Parse(Code_WS_NO_NEW.Substring(6,5)) + 1;

                    string da = ("00000").Substring(0, ("00000").Length - number.ToString().Length);
                    Code_WS_NO_NEW = da + number.ToString();

                    txtWS_NO.Text = Code_WS_NO + Code_WS_NO_NEW;
                }
                else
                {
                    txtWS_NO.Text = Code_WS_NO + "00001";
                }
            }
        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Cur = int.Parse(DGV1.CurrentRow.Index.ToString());
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    float qty = float.Parse(DGV1.Rows[i].Cells[6].Value.ToString());
                    float pri = float.Parse(DGV1.Rows[i].Cells[8].Value.ToString());
                    float sub = qty * pri;
                    DGV1.Rows[i].Cells[9].Value = sub.ToString();
                }

                float A = 0;
                if (DGV1.Rows.Count >= 1)
                {
                    for (int i = 0; i < DGV1.RowCount; i++)
                    {
                        A = A + float.Parse(DGV1.Rows[i].Cells[9].Value.ToString());
                    }
                    txtTOT.Text = A.ToString("0.00");
                    txtTOTAL.Text = (A + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
                    txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
                }
                else
                {
                    txtTOT.Text = "0.00";
                    txtTOTAL.Text = "0.00";
                    txtNRCV_MON.Text = "0.00";
                }
            }
            else
            {
                LoadDataGrid(Cur);
            }
        }

        public void LoadDataGrid(int Cur)
        {
            string or_no = "";
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                or_no = "";
            }
            else
            {
                or_no = DGV1.Rows[Cur].Cells["NR"].Value.ToString();
            }
            string sql = "SELECT WS_NO as WS_NO,NR as NR_1,P_NO as P_NO_1,P_NAME as P_NAME_1,BUNIT as BUNIT_1,BQTY as BQTY_1,PRICE as PRICE_1,AMOUNT as AMOUNT_1 " +
                        "FROM COMBC1 WHERE OR_NO = N'" + txtWS_NO.Text + "'AND OR_NR = N'" + or_no + "'";

            DataTable dtnew = new DataTable();
            dtnew = conn.readdata(sql);
            DGV2.DataSource = dtnew;
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                SearchVENDC1B frm = new SearchVENDC1B();
                frm.ShowDialog();

                txtC_NO.Text = SearchVENDC1B.getDataTable.C_NO;
                txtC_NAME.Text = SearchVENDC1B.getDataTable.C_NAME;
                C_ANAME = SearchVENDC1B.getDataTable.C_ANAME;
                ADR1 = SearchVENDC1B.getDataTable.ADR1;
                DEFA_MONEY = SearchVENDC1B.getDataTable.DEFA_MONEY;
            }
        }
        string STT = "";
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 1)
                {
                    SearchVENDC1B frm = new SearchVENDC1B();
                    frm.ShowDialog();
                    this.DGV1[1, DGV1.CurrentRow.Index].Value = SearchVENDC1B.getDataTable.C_NO;
                }
                else if (Cur == 2)
                {
                    AddItemToDataDrid();
                }
                else if (Cur == 10)
                {
                    SearchDEPT frm = new SearchDEPT();
                    frm.ShowDialog();
                    this.DGV1[10, DGV1.CurrentRow.Index].Value = SearchDEPT.GetData.DEPT_NAME;
                    this.DGV1.Rows[DGV1.CurrentRow.Index].Cells["DEPT_NO"].Value = SearchDEPT.GetData.DEPT_NO;
                }
                else if (Cur == 11)
                {
                    frmSearchMemo.getMeMo.M_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["DEPT_NO"].Value.ToString();
                    frmSearchMemo frm = new frmSearchMemo();
                    frm.ShowDialog();
                    this.DGV1[11, DGV1.CurrentRow.Index].Value = frmSearchMemo.getMeMo.M_NAME;
                }
            }
        }

        public void AddItemToDataDrid()
        {
            DataGridViewRow dr = new DataGridViewRow();
            int NR1 = 1;
            if (DGV1.RowCount > 0)
            {
                NR1 = DGV1.RowCount + 1;
            }

            SearchPROD1C frm = new SearchPROD1C();
            SearchPROD1C.SetC_NO.C_NO = txtC_NO.Text;
            frm.ShowDialog();
            DataTable dataTable = (DataTable)DGV1.DataSource;
            foreach (var item in SearchPROD1C.GetListData.lisdata)
            {
                STT = NR1.ToString("D" + 3);
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["NR"] = STT;
                drToAdd["C_NO"] = item.C_NO;
                drToAdd["P_NO"] = item.P_NO;
                drToAdd["P_NAME"] = item.P_NAME;
                drToAdd["P_NAME1"] = item.P_NAME1;
                drToAdd["P_NAME3"] = item.P_NAME3;
                drToAdd["BQTY"] = 0;
                drToAdd["BUNIT"] = item.BUNIT;
                drToAdd["PRICE"] = item.PRICE;
                drToAdd["AMOUNT"] = 0;
                drToAdd["MEMO"] = "";
                drToAdd["OUTBQTY"] = 0;
                drToAdd["OVER0"] = "N";
                drToAdd["CUNIT"] = item.CUNIT;
                drToAdd["TRANS"] = item.TRANS;
                drToAdd["K_NO"] = item.K_NO;
                drToAdd["DEPT_NO"] = "";
                drToAdd["DEPT_NAME"] = "";
                drToAdd["UNIT"] = item.UNIT;
                dataTable.Rows.Add(drToAdd);
                NR1++;
            }
        }
        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                if(!string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        conn.CreateMenuStrip(e, DGV1, Mouse_Click);
                    }
                }
                else
                {
                    MessageBox.Show("採購單號不正確,請重新輸入!");
                    txtM_KIND.Focus();
                }
            }
        }

        private void Mouse_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    AddItemToDataDrid();
                    break;
                case "Delele":
                    break;
            }
        }

        private void txtRCV_MON_TextChanged(object sender, EventArgs e)
        {
            if(f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                float A = 0;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    A = A + float.Parse(DGV1.Rows[i].Cells[9].Value.ToString());
                }
                txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
            }
        }

        private void txtCOSTTOT_TextChanged(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                float A = 0;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    A = A + float.Parse(DGV1.Rows[i].Cells[9].Value.ToString());
                }
                txtTOTAL.Text = (A + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
                txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
            }
        }

        private void txtDISCOUNT_TextChanged(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                float A = 0;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    A = A + float.Parse(DGV1.Rows[i].Cells[9].Value.ToString());
                }
                txtTOTAL.Text = (A + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
                txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
            }
        }

        private void txtMEMO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                frmSearchMemo frm = new frmSearchMemo();
                frm.ShowDialog();
                txtMEMO1.Text = frmSearchMemo.getMeMo.M_NAME;
            }
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true; 
            f2ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            bt.Text = "Xoá";
            btnOK.Visible = true;
            btnClose.Visible = true;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt.Text = "Sửa";
            btnOK.Visible = true;
            btnClose.Visible = true;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            cbM_TRAN.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1";
            DataTable data = conn.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";

            cbM_TRAN.SelectedValue = currentRow["M_TRAN"].ToString();
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchCOMHC frm = new frmSearchCOMHC();
            frm.ShowDialog();
            LoadData();
            bindingSource.Position = frmSearchCOMHC.GetDataLoad.index;
            //if(frmSearchCOMHC.GetDataLoad.GetData != null)
            //{
            //    bindingSource.DataSource = frmSearchCOMHC.GetDataLoad.GetData;
            //    bindingSource.Position = frmSearchCOMHC.GetDataLoad.index;
            //}

            ShowTextBox();
        }
        public class PassDataSearch
        {
            public static string WS_NO;
            public static string C_NO;
            public static string WS_DATE;
        }

        private void txtINV_NO_TextChanged(object sender, EventArgs e)
        {
            if (txtINV_NO.Text == "Y")
            {
                f4ToolStripMenuItem.Enabled = false;
                f10ToolStripMenuItem.Enabled = false;
                f1ToolStripMenuItem.Enabled = false;
            }
            else
            {
                f4ToolStripMenuItem.Enabled = true; 
                f10ToolStripMenuItem.Enabled = true;
                f1ToolStripMenuItem.Enabled = true;
            }

            //if (f2ToolStripMenuItem.Checked == true)
            //{
            //    f4ToolStripMenuItem.Enabled = false;
            //}
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtM_KIND.Text == "1" || txtM_KIND.Text == "6" || txtM_KIND.Text == "2" || txtM_KIND.Text == "3" || txtM_KIND.Text == "8")
            {
                sql = "SELECT* FROM(SELECT COMHC.WS_NO, COMHC.WS_DATE, COMHC.FOB_DATE, CAL_YM, NR, P_NAME, P_NAME1, BUNIT, BQTY, PRICE, COMBC.OVER0, AMOUNT, DEPT_NAME, P_NO, COMHC.USR_NAME,MEMO,VENDC.C_ANAME" +
                " FROM COMBC, COMHC,VENDC" +
                " WHERE COMBC.WS_NO= COMHC.WS_NO AND VENDC.C_NO = COMBC.C_NO AND COMHC.WS_NO= '" + txtWS_NO.Text + "')a" +
                " JOIN(" +
                " SELECT P_NO, K_NO_O, KIND1C.K_NO, K_NAME" +
                " FROM PROD1C" +
                " JOIN KIND1C ON KIND1C.K_NO = PROD1C.K_NO) b ON b.P_NO = a.P_NO" +
                " ORDER BY a.WS_NO,a.NR";

            }
            else if(txtM_KIND.Text == "5" || txtM_KIND.Text == "7")
            {
                sql = "SELECT * FROM COMBC, COMHC, VENDC" +
                    " WHERE COMBC.WS_NO = COMHC.WS_NO AND VENDC.C_NO = COMHC.C_NO AND COMBC.WS_NO = '"+txtWS_NO.Text+"'" +
                    " ORDER BY COMHC.WS_NO";
            }
            else if (txtM_KIND.Text == "4")
            {
                sql = "SELECT * FROM COMBC, COMHC, KIND1C" +
                    " WHERE COMBC.WS_NO = COMHC.WS_NO AND COMBC.K_NO = KIND1C.K_NO AND COMBC.WS_NO = '" + txtWS_NO.Text + "'" +
                    " ORDER BY COMHC.WS_NO";
            }


            DataTable data = new DataTable();
            data = conn.readdata(sql);
            foreach(DataRow item in data.Rows)
            {
                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString());
                item["FOB_DATE"] = conn.formatstr2(item["FOB_DATE"].ToString());
                item["CAL_YM"] = conn.formatstr2(item["CAL_YM"].ToString());
            }

            ReportDocument cryRpt = new ReportDocument();
            if (txtM_KIND.Text == "1" || txtM_KIND.Text == "8")
            {
                cryRpt = new cr_Frm4BF7_1();
            }
            else if (txtM_KIND.Text == "2" || txtM_KIND.Text == "3" || txtM_KIND.Text == "6")
            {
                cryRpt = new cr_Frm4BF7_2();
            }
            else if (txtM_KIND.Text == "4")
            {
                cryRpt = new cr_Frm4BF7_4();
            }
            else if(txtM_KIND.Text == "5")
            {
                cryRpt = new cr_Frm4BF7_5();
            }
            else if(txtM_KIND.Text == "7")
            {
                cryRpt = new cr_frm4BF7_7();
            }

            cryRpt.SetDataSource(data);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                try
                {
                    string sql1 = "INSERT INTO COMHC (WS_NO,WS_DATE,FOB_DATE,C_NO,C_NAME,C_ANAME,ADDR,OR_NO,C_OR_NO,C_NO_O,C_NAME_O,C_ANAME_O,ADDR_O,TAX,DISCOUNT," +
                    "RCV_MON,MEMO1,MEMO2,MEMO3,S_NO,S_NAME,TOT,TOTAL,NRCV_MON,T_METH,CAR_COMPANY,COSTTOT,PROFIT,PACK_NO,CAL_YM,M_TRAN,M_TRAN_R," +
                    "USR_NAME,INV_NO,AC_WS_NO,DATESE,M_KIND,NWEGT,GWEGT,OVER0,HOVER) " +
                    "VALUES(N'" + txtWS_NO.Text + "', N'" + txtWS_DATE.Text.Replace("/", "") + "', N'" + txtFOB_DATE.Text.Replace("/", "") + "', N'" + txtC_NO.Text + "', N'" + txtC_NAME.Text + "', N'" + C_ANAME + "', N'" + ADR1 + "', N''," +
                    "N'', N'" + txtC_NO.Text + "', N'" + txtC_NAME.Text + "', N'" + C_ANAME + "', N'" + ADR1 + "', " + float.Parse(txtTAX.Text) + ", " + float.Parse(txtDISCOUNT.Text) +", " + float.Parse(txtRCV_MON.Text) + ", N'" + txtMEMO1.Text + "', N'', N'', N'', N'', " + float.Parse(txtTOT.Text) + ", " + float.Parse(txtTOTAL.Text) + "," +
                    " " + float.Parse(txtNRCV_MON.Text) + ", N'', N'', 0, " + float.Parse(txtTOT.Text) + ", 0, N'" + txtCAL_YM.Text.Replace("/", "") + "'," +
                    "N'" + DEFA_MONEY + "', " + txtM_TRAN_R.Text + ", N'" + lbUserName.Text + "', N'" + txtINV_NO.Text + "', N'', N'', N'" + txtM_KIND.Text + "', " + txtNWEGT.Text + ", " + txtGWEGT.Text + ", N'N', N'N')";
                    bool chek = conn.exedata(sql1);
                    if (chek)
                    {
                        AddDataGridView();
                        F2Menu_Click();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong quá trình thực thi câu lệnh");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(f3ToolStripMenuItem.Checked == true)
            {
                try
                {
                    string sql1 = "DELETE COMHC WHERE WS_NO= N'" + txtWS_NO.Text + "'";
                    bool check = conn.exedata(sql1);
                    if(check == true)
                    {
                        string sql = "DELETE COMBC WHERE WS_NO=N'" + txtWS_NO.Text + "'";
                        conn.exedata(sql);
                        LoadData();
                        ShowTextBox();
                        f3ToolStripMenuItem.Checked = false;
                        btnOK.Visible = false;
                        btnClose.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong quá trình thực thi câu lệnh");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(f4ToolStripMenuItem.Checked == true)
            {
                try
                {
                    string sql = "UPDATE dbo.COMHC SET WS_NO=N'" + txtWS_NO.Text + "',WS_DATE=N'" + txtWS_DATE.Text.Replace("/", "") + "',FOB_DATE=N'" + txtFOB_DATE.Text.Replace("/", "") + "',C_NO=N'" + txtC_NO.Text + "',C_NAME=N'" + txtC_NAME.Text + "'," +
                    " C_ANAME = N'" + C_ANAME + "',ADDR = N'" + ADR1 + "',OR_NO = N'',C_OR_NO = N'',C_NO_O = N'" + txtC_NO.Text + "',C_NAME_O = N'" + txtC_NAME.Text + "'," +
                    " C_ANAME_O = N'" + C_ANAME + "',ADDR_O = N'" + ADR1 + "',TAX = " + float.Parse(txtTAX.Text) + ",DISCOUNT = " + float.Parse(txtDISCOUNT.Text) + ",RCV_MON = " + float.Parse(txtRCV_MON.Text) + ",MEMO1 = N'" + txtMEMO1.Text + "'," +
                    " MEMO2 = N'',MEMO3 = N'',S_NO = N'',S_NAME = N'',TOT = " + float.Parse(txtTOT.Text) + ",TOTAL = " + float.Parse(txtTOTAL.Text) + ",NRCV_MON = " + float.Parse(txtNRCV_MON.Text) + "," +
                    " T_METH = N'',CAR_COMPANY = N'',COSTTOT = 0,PROFIT = " + float.Parse(txtTOT.Text) + ",PACK_NO = 0,CAL_YM = N'" + txtCAL_YM.Text.Replace("/", "") + "'," +
                    " M_TRAN = N'" + cbM_TRAN.SelectedValue.ToString() + "',M_TRAN_R = " + txtM_TRAN_R.Text + ",USR_NAME = N'" + lbUserName.Text + "',INV_NO = N'" + txtINV_NO.Text + "',AC_WS_NO = N'',DATESE = N''," +
                    " M_KIND = N'" + txtM_KIND.Text + "',NWEGT = 0,GWEGT = 0,OVER0 = N'N',HOVER = N'N'" +
                    " WHERE WS_NO = N'" + txtWS_NO.Text + "'";
                    bool check = conn.exedata(sql);
                    if (check == true)
                    {
                        string sql1 = "DELETE COMBC WHERE WS_NO=N'" + txtWS_NO.Text + "'";
                        bool check1 = conn.exedata(sql1);
                        if (check1 == true)
                        {
                            AddDataGridView();
                            LoadData();
                            ShowTextBox();
                            f4ToolStripMenuItem.Checked = false; 
                            btnOK.Visible = false;
                            btnClose.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong quá trình thực thi câu lệnh");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            txtINV_NO.Text = "Y";
            bt.Text = "Sửa";

            btnOK.Visible = true;
            btnClose.Visible = true;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            cbM_TRAN.Enabled = true;

            f10ToolStripMenuItem.Enabled = true;
            f1ToolStripMenuItem.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1";
            DataTable data = conn.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";

            cbM_TRAN.SelectedValue = currentRow["M_TRAN"].ToString();
        }

        private void txtINV_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                frmSearchSH_NUM frm = new frmSearchSH_NUM();
                frm.ShowDialog();
            }
        }

        private void cbM_TRAN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f9ToolStripMenuItem.Checked == true)
            {
                string money = "SELECT M_TRAN FROM dbo.MONEYT WHERE M_NO = '" + cbM_TRAN.SelectedValue.ToString() + "'";
                DataTable dt = conn.readdata(money);
                txtM_TRAN_R.Text = dt.Rows[0]["M_TRAN"].ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        public void AddDataGridView()
        {
            try
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    string sql = "INSERT INTO COMBC (WS_NO,NR,WS_DATE,C_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,UNIT,QTY,BQTY,BUNIT,CUNIT,TRANS,PRICE,COST,AMOUNT," +
                                "MEMO,SH_NO,S_NO,FOB_DATE,C_OR_NO,OR_NO,OR_NR,NWEG,GWEG,NWEGT,GWEGT,K_NO,L_NO,OUTQTY,OUTBQTY,OVER0,HOVER,DEPT_NO,DEPT_NAME) " +
                                "VALUES(N'" + txtWS_NO.Text + "', N'" + item.Cells["NR"].Value.ToString() + "', N'" + txtWS_DATE.Text.Replace("/", "") + "', N'" + item.Cells["C_NO"].Value.ToString() + "', N'" + item.Cells["P_NO"].Value.ToString() + "', N'" + item.Cells["P_NAME"].Value.ToString() + "'," +
                                " N'" + item.Cells["P_NAME1"].Value.ToString() + "', N'', N'" + item.Cells["P_NAME3"].Value.ToString() + "', N'" + item.Cells["UNIT"].Value.ToString() + "', 0, " + item.Cells["BQTY"].Value.ToString() + "," +
                                " N'" + item.Cells["BUNIT"].Value.ToString() + "', N'" + item.Cells["CUNIT"].Value.ToString() + "', " + item.Cells["TRANS"].Value.ToString() + "," +
                                "" + item.Cells["PRICE"].Value + ", 0, " + item.Cells["AMOUNT"].Value + ", N'" + item.Cells["MEMO"].Value + "', N'', 0, N'', N'', N'', N'', " + item.Cells["TRANS"].Value.ToString() + "," +
                                " 0, 0, 0, N'" + item.Cells["K_NO"].Value + "', N'', 0, " + item.Cells["OUTBQTY"].Value + ", N'" + item.Cells["OVER0"].Value + "', N'N', N'" + item.Cells["DEPT_NO"].Value + "', N'" + item.Cells["DEPT_NAME"].Value + "')";
                    conn.exedata(sql);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)  // get IP Local  
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = conn.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
            btndateNow.Text = conn.getDateNow(); // get getDateNow
        }
    }
}
