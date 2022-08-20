﻿using PURCHASE.MAINCODE;
using PURCHASE.MAINCODE.Modun4;
using PURCHASE.MAINCODE.Modun4.Search;
using PURCHASE.MAINCODE.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using LibraryCalender;
namespace PURCHASE
{
    public partial class Form4C : Form
    {
        DataProvider conn = new DataProvider();
        DataTable dt = new DataTable();
        BindingSource bindingSource = new BindingSource();
        string C_ANAME, ADR1, PAY_CON, DEFA_MONEY, RCV_DATE;
        int pageIndex = 1;
        int PageSize = 50;
        int count = 0;
        public Form4C()
        {
            InitializeComponent(); 
            this.ShowInTaskbar = false;
            conn.CheckLanguage(this);
            ReName();
        }
        private void ReName()
        {
            if (frmLogin.ValueLanguage == "1")
            {
                f6ToolStripMenuItem.Text = "F6. Mua Hàng";
            }
            else if (frmLogin.ValueLanguage == "2")
            {
                f6ToolStripMenuItem.Text = "F6. Purchase";
            }else
            {
                f6ToolStripMenuItem.Text = "F6. 採購";
            }
        }
        private void Form4C_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
            Loaddata();
            LoadTextBox();

            btnOK.Hide();
            btnClose.Hide();
            bt.Text = "NÚT DUYỆT";

            f10ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;

            conn.DGV(DGV1);
        }

        private void LoadTextBox()
        {
            this.txtWS_DATE.Text = currentRow["WS_DATE"].ToString();
            this.txtM_KIND.Text = currentRow["M_KIND"].ToString();
            this.txtWS_NO.Text = currentRow["WS_NO"].ToString();
            this.txtC_NO.Text = currentRow["C_NO"].ToString();
            this.txtC_NAME.Text = currentRow["C_NAME"].ToString();
            this.txtCAL_YM.Text = currentRow["CAL_YM"].ToString();
            this.txtTOTAL.Text = conn.ConvertNumber(currentRow["TOTAL"].ToString());
            this.txtM_TRAN_R.Text = currentRow["M_TRAN_R"].ToString();
            this.txtMEMO1.Text = currentRow["MEMO1"].ToString();
            this.txtTOT.Text = conn.ConvertNumber(currentRow["TOT"].ToString());
            this.txtTAX.Text = currentRow["TAX"].ToString();
            this.txtDISCOUNT.Text = conn.ConvertNumber(currentRow["DISCOUNT"].ToString());
            this.txtRCV_MON.Text = currentRow["RCV_MON"].ToString();
            this.txtNRCV_MON.Text = conn.ConvertNumber(currentRow["NRCV_MON"].ToString());
            this.txtOR_NO.Text = currentRow["OR_NO"].ToString();

            C_ANAME = currentRow["C_ANAME"].ToString();
            ADR1 = currentRow["ADDR"].ToString();

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
        public void Loaddata()
        {
            string counts = "SELECT COUNT(WS_NO) AS counts FROM COMHC1 where 1=1 " + Form4CF5.where;
            count = int.Parse(conn.readdata(counts).Rows[0][0].ToString());

            string sql = "select top 50 WS_DATE,M_KIND,WS_NO,C_NO,C_NAME,CAL_YM,TOTAL,M_TRAN_R, " +
                " TOT, TAX, DISCOUNT, RCV_MON, NRCV_MON, OR_NO, C_ANAME, ADDR,M_TRAN,MEMO1 FROM COMHC1 where 1=1 "+ Form4CF5.where+ " ORDER BY WS_DATE DESC,WS_NO DESC";
            dt = conn.readdata(sql);
            bindingSource.DataSource = dt;
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4CF5 frm = new Form4CF5();
            frm.ShowDialog();
            Loaddata();
            bindingSource.Position = Form4CF5.item.index;
            LoadTextBox();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = true;
            DateTime d1 = DateTime.Now;
            txtWS_DATE.Text = d1.ToString("yyyy/MM/dd");
            txtM_KIND.Text = "1";
            txtWS_NO.Text = "";
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtOR_NO.Text = "";
            txtCAL_YM.Text = "";
            txtMEMO1.Text = "";
            txtTOT.Text = "0.00";
            txtTOTAL.Text = "0.00";
            txtNRCV_MON.Text = "0.00";
            txtDISCOUNT.Text = "0.00";
            txtRCV_MON.Text = "0";
            txtTAX.Text = "0";

            bt.Text = "Thêm";
            btnOK.Show();
            btnClose.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            cbM_TRAN.Enabled = true;
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Loaddata();
            f10ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btnOK.Hide();
            btnClose.Hide();
            bt.Text = "NÚT DUYỆT";

            f10ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            Loaddata();
            LoadTextBox();
            conn.DGV(DGV1);
            cbM_TRAN.Enabled = false;
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT NR,P_NO,P_NAME,P_NAME1,P_NAME3,BQTY,PRICE,AMOUNT,OR_NO,SH_NAME,MEMO,OR_NR,PK_NO,COMBC1.SH_NO,BQTY as MAXBQTY" +
                        " FROM COMBC1 JOIN SHOUSE ON SHOUSE.SH_NO = COMBC1.SH_NO WHERE WS_NO = '" + txtWS_NO.Text + "'";
            DataTable data = conn.readdata(sql);
            DGV1.DataSource = data;
            Loadcb(currentRow["M_TRAN"].ToString());
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

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
            LoadTextBox();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            LoadTextBox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            int position = bindingSource.Position;
            if (bindingSource.Count > count)
            {
                if ((position + 1)== (pageIndex * PageSize))
                {
                    string sql1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC, WS_NO DESC) AS ROWID," +
                        " WS_DATE,M_KIND,WS_NO,C_NO,C_NAME,CAL_YM,TOTAL,M_TRAN_R, " +
                        " TOT, TAX, DISCOUNT, RCV_MON, NRCV_MON, OR_NO, C_ANAME, ADDR,M_TRAN,MEMO1 FROM COMHC1) a " +
                        " where 1=1 " + Form4CF5.where + " AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize) + "";
                    DataTable ds = new DataTable();
                    ds = conn.readdata(sql1);
                    dt.Merge(ds);
                    bindingSource.DataSource = dt;
                    bindingSource.Position = position;
                    pageIndex++;
                }
            }

            bindingSource.MoveNext();
            LoadTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            if (position + 1 == count - 1)
            {
                btsau.Enabled = false;
                btketthuc.Enabled = false;
            }
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            if (bindingSource.Count < count)
            {
                string sql1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC, WS_NO DESC) AS ROWID," +
                       " WS_DATE,M_KIND,WS_NO,C_NO,C_NAME,CAL_YM,TOTAL,M_TRAN_R, " +
                       " TOT, TAX, DISCOUNT, RCV_MON, NRCV_MON, OR_NO, C_ANAME, ADDR,M_TRAN,MEMO1 FROM COMHC1) a " +
                       " where 1=1 " + Form4CF5.where + "";
                DataTable ds = new DataTable();
                ds = conn.readdata(sql1);
                bindingSource = new BindingSource();
                bindingSource.DataSource = ds;
            }

            bindingSource.MoveLast();
            LoadTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void txtM_KIND_TextChanged(object sender, EventArgs e)
        {
            switch (txtM_KIND.Text)
            {
                case "1":
                    label1.Text = "化 料 - 台 灣";
                    break;
                case "2":
                    label1.Text = "化料-大陸";
                    break;
                case "3":
                    label1.Text = "開狀櫃化料-台灣";
                    break;
                case "4":
                    label1.Text = "總料-台灣";
                    break;
                case "5":
                    label1.Text = "總料-大陸";
                    break;
                case "6":
                    label1.Text = "化料-越南";
                    break;
                case "7":
                    label1.Text = "總料-越南";
                    break;
                case "8":
                    label1.Text = "化料-越南轉廠";
                    break;
            }
        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        conn.CreateMenuStrip(e, DGV1, Mouse_Click);
                    }
                    else
                    {
                        if (DGV1.Rows.Count > 0)
                        {
                            for (int i = 0; i < DGV1.RowCount; i++)
                            {
                                float qty = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                                float pri = float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString());
                                float sub = qty * pri;
                                DGV1.Rows[i].Cells["AMOUNT"].Value = sub.ToString();
                            }

                            float A = 0;
                            if (DGV1.Rows.Count >= 1)
                            {
                                for (int i = 0; i < DGV1.RowCount; i++)
                                {
                                    A = A + float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
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
        string STT = "";
        public void AddItemToDataDrid()
        {
            addDatatoDGV();
        }

        private void txtWS_NO_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                string WS_NO = "";
                string sql = "SELECT WS_NO FROM COMHC1 WHERE WS_NO LIKE '" + DateTime.Now.ToString("yyyyMMdd") + "%' ORDER BY WS_NO desc";
                DataTable table = conn.readdata(sql);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        WS_NO = DateTime.Now.ToString("yyyyMMdd") + (int.Parse(item[0].ToString().Substring(9, 3)) + 1);
                    }
                }
                else
                {
                    WS_NO = DateTime.Now.ToString("yyyyMMdd") + "001";
                }
                txtWS_NO.Text = WS_NO;
            }
        }

        private void txtM_KIND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
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

        private void txtCAL_YM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FromCalender frm = new FromCalender();
                frm.ShowDialog();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyy/MM");
            }
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4CF7 frm = new Form4CF7();
            frm.ShowDialog();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                if (f2ToolStripMenuItem.Checked == true)
                {
                    if(!string.IsNullOrEmpty(txtC_NO.Text))
                    {
                        string sql = "INSERT INTO COMHC1 (WS_NO,WS_DATE,FOB_DATE,C_NO,C_NAME,C_ANAME,ADDR,OR_NO," +
                                    "C_OR_NO,C_NO_O,C_NAME_O,C_ANAME_O,ADDR_O,TAX,DISCOUNT,RCV_MON,MEMO1,MEMO2," +
                                    "MEMO3,S_NO,S_NAME,TOT,TOTAL,NRCV_MON,T_METH,CAR_COMPANY,COSTTOT,PROFIT," +
                                    "PACK_NO,CAL_YM,M_TRAN,M_TRAN_R,USR_NAME,INV_NO,AC_WS_NO,DATESE,M_KIND,NWEGT,GWEGT,OVER0,HOVER) " +
                                    "VALUES(N'" + txtWS_NO.Text + "', N'" + txtWS_DATE.Text.Replace("/", "") + "', N'', N'" + txtC_NO.Text + "', N'" + txtC_NAME.Text + "', N'" + C_ANAME + "', N'" + ADR1 + "'," +
                                    "N'" + txtOR_NO.Text + "', N'', N'" + txtC_NO.Text + "', N'" + txtC_NAME.Text + "', N'" + C_ANAME + "', N'" + ADR1 + "', " + float.Parse(txtTAX.Text) + ", " + float.Parse(txtDISCOUNT.Text) + ", " + float.Parse(txtRCV_MON.Text) + ", N'" + txtMEMO1.Text + "', N''," +
                                    "N'', N'', N'', " + float.Parse(txtTOT.Text) + ", " + float.Parse(txtTOTAL.Text) + ", " + float.Parse(txtNRCV_MON.Text) + ", N'', N'', 0, " + float.Parse(txtTOT.Text) + ", 0, N'" + txtCAL_YM.Text.Replace("/", "") + "', N'" + cbM_TRAN.SelectedValue.ToString() + "', " + txtM_TRAN_R.Text + ", N'" + lbUserName.Text + "', N'', N'', N'', N'" + txtM_KIND.Text + "', 0, 0, N'', N'')";
                        if (conn.exedata(sql))
                        {
                            InsertUpDateDeleteDGV("INSERT");
                        }
                        btnClose.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Nhà cung cấp không được để trống");
                        txtC_NO.Focus();
                    }

                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    string sql = "DELETE COMHC1 WHERE WS_NO = N'" + txtWS_NO.Text + "'";
                    if (conn.exedata(sql))
                    {
                        InsertUpDateDeleteDGV("DELETE");
                    }
                    btnClose.PerformClick();
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    string sql = "UPDATE COMHC1 SET WS_NO=N'" + txtWS_NO.Text + "',WS_DATE=N'" + txtWS_DATE.Text.Replace("/", "") + "',FOB_DATE=N'',C_NO=N'" + txtC_NO.Text + "',C_NAME=N'" + txtC_NAME.Text + "',C_ANAME=N'" + C_ANAME + "'," +
                        " ADDR = N'" + ADR1 + "',OR_NO = N'" + txtOR_NO.Text + "',C_OR_NO = N'',C_NO_O = N'" + txtC_NO.Text + "',C_NAME_O = N'" + txtC_NAME.Text + "',C_ANAME_O = N'" + C_ANAME + "',ADDR_O = N'" + ADR1 + "'," +
                        " TAX = " + float.Parse(txtTAX.Text) + ",DISCOUNT = " + float.Parse(txtDISCOUNT.Text) + ",RCV_MON = " + float.Parse(txtRCV_MON.Text) + ",MEMO1 = N'" + txtMEMO1.Text + "',MEMO2 = N'',MEMO3 = N'',S_NO = N'',S_NAME = N''," +
                        " TOT = " + float.Parse(txtTOT.Text) + ",TOTAL = " + float.Parse(txtTOTAL.Text) + ",NRCV_MON = " + float.Parse(txtNRCV_MON.Text) + ",T_METH = N'',CAR_COMPANY = N'',COSTTOT = 0,PROFIT = " + float.Parse(txtTOT.Text) + "," +
                        " PACK_NO = 0,CAL_YM = N'" + txtCAL_YM.Text.Replace("/", "") + "',M_TRAN = N'" + cbM_TRAN.SelectedValue.ToString() + "',M_TRAN_R = " + txtM_TRAN_R.Text + ",USR_NAME = N'" + lbUserName.Text + "',INV_NO = N'',AC_WS_NO = N''," +
                        " DATESE = N'',M_KIND = N'" + txtM_KIND.Text + "',NWEGT = 0,GWEGT = 0,OVER0 = N'',HOVER = N''" +
                        " WHERE WS_NO = N'" + txtWS_NO.Text + "'";

                    if (conn.exedata(sql))
                    {
                        InsertUpDateDeleteDGV("UPDATE");
                        //string sql1 = "DELETE COMBC1 WHERE WS_NO=N'" + txtWS_NO.Text + "'";
                        //if (conn.exedata(sql1))
                        //{
                        //    InsertUpDateDeleteDGV("UPDATE");
                        //}
                    }
                    btnClose.PerformClick();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void InsertUpDateDeleteDGV(string type)
        {
            try
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    string sql = "dbo.InsertUpdataDele @WS_NO = N'"+txtWS_NO.Text+"',@NR = N'"+item.Cells["NR"].Value.ToString()+"',@WS_DATE = '"+txtWS_DATE.Text.Replace("/","").ToString()+"',@C_NO = N'"+txtC_NO.Text+"'," +
                        " @P_NO = N'"+item.Cells["P_NO"].Value.ToString()+ "',@P_NAME = N'" + item.Cells["P_NAME"].Value.ToString() + "',@P_NAME1 = N'" + item.Cells["P_NAME1"].Value.ToString() + "'," +
                        " @P_NAME3 = N'" + (item.Cells["P_NAME3"].Value.ToString().EndsWith("'") ? item.Cells["P_NAME3"].Value.ToString() + "'" : item.Cells["P_NAME3"].Value.ToString()) + "'," +
                        " @BQTY = " + double.Parse(item.Cells["BQTY"].Value.ToString()) + ",@PRICE = " + double.Parse(item.Cells["PRICE"].Value.ToString()) + "," +
                        " @AMOUNT = " + double.Parse(item.Cells["AMOUNT"].Value.ToString()) + ",  @MEMO = N'" + item.Cells["MEMO"].Value.ToString() + "', @SH_NO = N'" + item.Cells["SH_NO"].Value.ToString() + "'," +
                        " @OR_NO = N'" + item.Cells["OR_NO"].Value.ToString() + "',@OR_NR = N'" + item.Cells["OR_NR"].Value.ToString() + "',   @PK_NO = N'" + item.Cells["PK_NO"].Value.ToString() + "'," +
                        " @Type = N'"+ type + "'";
                    conn.exedata(sql);
                    //string sql1 = "INSERT INTO COMBC1(WS_NO, NR, WS_DATE, C_NO, P_NO, P_NAME, P_NAME1, P_NAME2, P_NAME3," +
                    //    "UNIT, QTY, BQTY, BUNIT, CUNIT, TRANS, PRICE, COST, AMOUNT, MEMO, SH_NO, S_NO, FOB_DATE," +
                    //    "C_OR_NO, OR_NO, OR_NR, NWEG, GWEG, NWEGT, GWEGT, K_NO, L_NO, OVER0, HOVER, OUTQTY," +
                    //    "OUTBQTY, PK_NO, DEPT_NO, DEPT_NAME)" +
                    //    "VALUES(N'" + txtWS_NO.Text + "', N'" + item["NR"].ToString() + "', N'" + txtWS_DATE.Text.Replace("/", "") + "', N'" + txtC_NO.Text + "', N'" + item["P_NO"].ToString() + "', N'" + item["P_NAME"].ToString() + "', N'" + item["P_NAME1"].ToString() + "', N'', N'" + item["P_NAME3"].ToString() + "'," +
                    //    "N'" + item["UNIT"].ToString() + "', 0, " + item["BQTY"].ToString() + ", N'" + item["BUNIT"].ToString() + "', N'" + item["CUNIT"].ToString() + "', " + item["TRANS"].ToString() + ", " + item["PRICE"].ToString() + ", " + item["COST1"].ToString() + ", " + item["AMOUNT"].ToString() + ", N'" + item["MEMO"].ToString() + "', " +
                    //    "N'" + item["SH_NO"].ToString() + "', " + item["S_NO"].ToString() + ", N'', N'', N'" + item["OR_NO"].ToString() + "'," +
                    //    "N'" + item["OR_NR"].ToString() + "', 0, 0, 0, 0, N'" + item["K_NO"].ToString() + "', N'', N'', N'', 0, 0, N'" + item["PK_NO"].ToString() + "', N'" + item["DEPT_NO"].ToString() + "', N'" + item["DEPT_NAME"].ToString() + "')";

                    //if(conn.exedata(sql1))
                    //{
                    //    string sql = "UPDATE COMHC SET OVER0=N'Y' WHERE WS_NO=N'" + item["OR_NO"].ToString() + "'";
                    //    string sqlCOMBC = "UPDATE COMBC SET OVER0=N'Y',OUTQTY=0,OUTBQTY=" + item["BQTY"].ToString() + " WHERE WS_NO=N'" + item["OR_NO"].ToString() + "' AND NR=N'" + item["OR_NR"].ToString() + "'";
                    //    string sqlPSHQTY = "UPDATE PSHQTY SET P_NO=N'" + item["P_NO"].ToString() + "',SH_NO=N'" + item["SH_NO"].ToString() + "',K_NO=N'" + item["K_NO"].ToString() + "',QTY=" + item["BQTY"].ToString() + ",QTYP=0 WHERE P_NO=N'" + item["P_NO"].ToString() + "' AND SH_NO=N'" + item["SH_NO"].ToString() + "'";
                    //    string sqlPROD1C = "UPDATE PROD1C SET INDATE=N'"+DateTime.Now.ToString("yyyyMMdd")+ "',QTYSTORE=QTYSTORE + " + item["BQTY"].ToString() + "" +
                    //        "WHERE QDATE = N'20150903' AND K_NO = N'CA' AND P_NO = N'CA0027-VT0044'";
                    //}
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                SearchVENDC1B frm = new SearchVENDC1B();
                frm.ShowDialog();
                txtC_NO.Text = SearchVENDC1B.getDataTable.C_NO;
                txtC_NAME.Text = SearchVENDC1B.getDataTable.C_NAME;
                C_ANAME = SearchVENDC1B.getDataTable.C_ANAME;
                ADR1 = SearchVENDC1B.getDataTable.ADR1;
            }
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 9)
                {
                    SearchPSHQTY frm = new SearchPSHQTY();
                    SearchPSHQTY.Item.SH_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["SH_NO"].Value.ToString();
                    frm.ShowDialog();
                    this.DGV1[9, DGV1.CurrentRow.Index].Value = "國內倉";
                    this.DGV1.Rows[DGV1.CurrentRow.Index].Cells["SH_NO"].Value = SearchPSHQTY.Item.SH_NO;
                }
                else if (Cur == 10)
                {
                    frmSearchMemo.getMeMo.M_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["SH_NO"].Value.ToString();
                    frmSearchMemo frm = new frmSearchMemo();
                    frm.ShowDialog();
                    this.DGV1[10, DGV1.CurrentRow.Index].Value = frmSearchMemo.getMeMo.M_NAME;
                }
            }
        }

        private void cbM_TRAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                string money = "SELECT M_TRAN FROM dbo.MONEYT WHERE M_NO = '" + cbM_TRAN.SelectedValue.ToString() + "'";
                DataTable dt = conn.readdata(money);
                txtM_TRAN_R.Text = dt.Rows[0]["M_TRAN"].ToString();
            }
        }

        private void txtMEMO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                frmSearchMemo frm = new frmSearchMemo();
                frm.ShowDialog();
                txtMEMO1.Text = frmSearchMemo.getMeMo.M_NAME;
            }
        }

        private void txtOR_NO_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtOR_NO.Text))
                {
                    string sql = "SELECT C.WS_NO,C.C_NO,V.C_NAME,V.C_ANAME,V.ADR1,V.S_NO,V.ADR2,V.ADR3,V.ADR4,V.PAY_CON,V.DEFA_MONEY,V.RCV_DATE" +
                    " FROM COMHC C JOIN VENDC V ON V.C_NO = C.C_NO" +
                    " WHERE WS_NO = '" + txtOR_NO.Text + "'";
                    DataTable dt = new DataTable();
                    dt = conn.readdata(sql);
                    txtC_NO.Text = dt.Rows[0]["C_NO"].ToString();
                    txtC_NAME.Text = dt.Rows[0]["C_NAME"].ToString();
                    C_ANAME = dt.Rows[0]["C_ANAME"].ToString();
                    ADR1 = dt.Rows[0]["ADR1"].ToString();
                    PAY_CON = dt.Rows[0]["PAY_CON"].ToString();
                    DEFA_MONEY = dt.Rows[0]["DEFA_MONEY"].ToString();
                    RCV_DATE = dt.Rows[0]["RCV_DATE"].ToString();

                    string sql1 = "SELECT B.P_NO,B.P_NAME,B.P_NAME1,B.P_NAME3,B.BQTY,B.PRICE,B.AMOUNT,B.WS_NO AS OR_NO,B.MEMO,'' AS SH_NAME, B.NR AS OR_NR," +
                        " '' AS PK_NO, B.SH_NO" +
                        " FROM COMHC H" +
                        " JOIN COMBC B ON B.WS_NO = H.WS_NO" +
                        " LEFT JOIN PROD1C P ON P.P_NO = B.P_NO" +
                        " WHERE H.WS_NO = '" + txtOR_NO.Text + "' AND (B.OVER0<>'Y'AND B.HOVER<>'Y')" +
                        " ORDER BY B.NR";
                    DataTable dt1 = new DataTable();
                    dt1 = conn.readdata(sql1);
                    if (dt1.Rows.Count > 0)
                    {
                        int NR1 = 1;
                        DataTable dataTable = (DataTable)DGV1.DataSource;
                        foreach (DataRow item in dt1.Rows)
                        {
                            STT = NR1.ToString("D" + 3);
                            DataRow drToAdd = dataTable.NewRow();
                            drToAdd["NR"] = STT;
                            drToAdd["P_NO"] = item["P_NO"].ToString();
                            drToAdd["P_NAME"] = item["P_NAME"].ToString();
                            drToAdd["P_NAME1"] = item["P_NAME1"].ToString();
                            drToAdd["P_NAME3"] = item["P_NAME3"].ToString();
                            drToAdd["BQTY"] = item["BQTY"].ToString();
                            drToAdd["PRICE"] = item["PRICE"].ToString();
                            drToAdd["AMOUNT"] = item["AMOUNT"].ToString();
                            drToAdd["OR_NO"] = item["OR_NO"].ToString();
                            drToAdd["MEMO"] = item["MEMO"].ToString();
                            drToAdd["SH_NAME"] = "國外倉";
                            drToAdd["OR_NR"] = item["OR_NR"].ToString();
                            drToAdd["PK_NO"] = item["PK_NO"].ToString();
                            drToAdd["SH_NO"] = "B";
                            drToAdd["MAXBQTY"] = item["BQTY"].ToString();

                            dataTable.Rows.Add(drToAdd);
                            NR1++;
                        }
                    }
                }
            }
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FromCalender frm = new FromCalender();
                frm.Show();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "Sửa";
            btnOK.Visible = true;
            btnClose.Visible = true;
            btdau.Enabled = false;
            btketthuc.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            cbM_TRAN.Enabled = true;

            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1";
            DataTable data = conn.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";

            cbM_TRAN.SelectedValue = currentRow["M_TRAN"].ToString();
        }

        public void addDatatoDGV()
        {
            int NR1 = 1;
            if (DGV1.RowCount > 0)
            {
                NR1 = DGV1.RowCount + 1;
            }

            frmSearchCOMBC frm = new frmSearchCOMBC();
            frmSearchCOMBC.C_NO = txtC_NO.Text;
            frm.ShowDialog();
            DataTable dataTable = (DataTable)DGV1.DataSource;
            foreach (var item in frmSearchCOMBC.items)
            {
                STT = NR1.ToString("D" + 3);
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["NR"] = STT;
                drToAdd["P_NO"] = item.P_NO;
                drToAdd["P_NAME"] = item.P_NAME;
                drToAdd["P_NAME1"] = item.P_NAME1;
                drToAdd["P_NAME3"] = item.P_NAME3;
                drToAdd["BQTY"] = item.BQTY - item.OUTBQTY;
                drToAdd["PRICE"] = item.PRICE;
                drToAdd["AMOUNT"] = item.AMOUNT;
                drToAdd["OR_NO"] = item.WS_NO;
                drToAdd["MEMO"] = "";
                drToAdd["SH_NAME"] = "國外倉";
                drToAdd["OR_NR"] = item.NR;
                drToAdd["PK_NO"] = "";
                drToAdd["SH_NO"] = "B";
                drToAdd["MAXBQTY"] = item.BQTY - item.OUTBQTY;
 
                dataTable.Rows.Add(drToAdd);
                NR1++;
            }
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDatatoDGV();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true;
            bt.Text = "Xoá";
            btnOK.Visible = true;
            btnClose.Visible = true;
            btdau.Enabled = false;
            btketthuc.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if(!string.IsNullOrEmpty(txtC_NO.Text))
                {
                    string sql = "SELECT C_NO,C_NAME,C_ANAME,ADR1 from dbo.VENDC WHERE 1 = 1 and C_NO LIKE N'" + txtC_NO.Text + "'";
                    DataTable dtnew = new DataTable();
                    dtnew = conn.readdata(sql);

                    if(dtnew.Rows.Count>0)
                    {
                        txtC_NO.Text = dtnew.Rows[0]["C_NO"].ToString();
                        txtC_NAME.Text = dtnew.Rows[0]["C_NAME"].ToString();
                        C_ANAME = dtnew.Rows[0]["C_ANAME"].ToString();
                        ADR1 = dtnew.Rows[0]["ADR1"].ToString();
                    }
                }
            }
        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                //int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (float.Parse(DGV1.Rows[DGV1.CurrentRow.Index].Cells["BQTY"].Value.ToString()) > float.Parse(DGV1.Rows[DGV1.CurrentRow.Index].Cells["MAXBQTY"].Value.ToString()))
                {
                    MessageBox.Show("Số lượng lớn nhập lớn hơn số lượng cho phép");
                    DGV1.Rows[DGV1.CurrentRow.Index].Cells["BQTY"].Value = 0.00;
                }
            }
        }

        private void txtRCV_MON_TextChanged(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                float A = 0;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    A = A + float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
            }
        }

        private void txtTAX_TextChanged(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                float A = 0;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    A = A + float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                txtTOTAL.Text = (A + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
                txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
            }
        }

        private void txtDISCOUNT_TextChanged(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                float A = 0;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    A = A + float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                txtTOTAL.Text = (A + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
                txtNRCV_MON.Text = (A - float.Parse(txtRCV_MON.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text)).ToString("0.00");
            }
        }
    }
}
