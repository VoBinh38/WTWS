﻿using PURCHASE.MAINCODE;
using PURCHASE.MAINCODE.Modun4;
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
    public partial class Form4E : Form
    {
        BindingSource bindingSource = new BindingSource();
        DataProvider con = new DataProvider();
        float PREMONEYS = 0;
        int count = 0;
        int pageIndex = 1;
        int PageSize = 50;
        DataTable dt;
        public class Getitem
        {
            public static string Wheres { get; set; }
        }
        public Form4E()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            con.CheckLanguage(this);
            ReName();
        }

        private void ReName()
        {
            if(frmLogin.ValueLanguage == "1")
            {
                f4ToolStripMenuItem.Text = "F4. Tính Toán Lại";
                f6ToolStripMenuItem.Text = "F6. Thanh toán";
            }
            else if(frmLogin.ValueLanguage == "2")
            {
                f4ToolStripMenuItem.Text = "F4. Heavy Rack";
                f6ToolStripMenuItem.Text = "F6. Payment";
            }
            else
            {
                txtTAX.Location = new Point(txtTAX.Location.X - 70, txtTAX.Location.Y);
                txtTAX.Size = new System.Drawing.Size(txtTAX.Size.Width + 70, txtTAX.Size.Height);

                txtCURRMON.Location = new Point(txtCURRMON.Location.X - 70, txtCURRMON.Location.Y);
                txtCURRMON.Size = new System.Drawing.Size(txtCURRMON.Size.Width + 70, txtCURRMON.Size.Height);

                txtCASH.Location = new Point(txtCASH.Location.X - 70, txtCASH.Location.Y);
                txtCASH.Size = new System.Drawing.Size(txtCASH.Size.Width + 70, txtCASH.Size.Height);

                txtCTOTAL.Location = new Point(txtCTOTAL.Location.X - 70, txtCTOTAL.Location.Y);
                txtCTOTAL.Size = new System.Drawing.Size(txtCTOTAL.Size.Width + 70, txtCTOTAL.Size.Height);

                txtDISCOUNT.Location = new Point(txtDISCOUNT.Location.X - 100, txtDISCOUNT.Location.Y);
                txtDISCOUNT.Size = new System.Drawing.Size(txtDISCOUNT.Size.Width + 100, txtDISCOUNT.Size.Height);

                txtLASTMON.Location = new Point(txtLASTMON.Location.X - 125, txtLASTMON.Location.Y);
                txtLASTMON.Size = new System.Drawing.Size(txtLASTMON.Size.Width + 125, txtLASTMON.Size.Height);

                txtTOTAL.Location = new Point(txtTOTAL.Location.X - 50, txtTOTAL.Location.Y);
                txtTOTAL.Size = new System.Drawing.Size(txtTOTAL.Size.Width + 50, txtTOTAL.Size.Height);

                cbMTRAN.Location = new Point(cbMTRAN.Location.X - 50, cbMTRAN.Location.Y);
                cbMTRAN.Size = new System.Drawing.Size(cbMTRAN.Size.Width + 50, cbMTRAN.Size.Height);

                txtACTMON.Location = new Point(txtACTMON.Location.X - 130, txtACTMON.Location.Y);
                txtACTMON.Size = new System.Drawing.Size(txtACTMON.Size.Width + 130, txtACTMON.Size.Height);

                txtNORECV.Location = new Point(txtNORECV.Location.X - 90, txtNORECV.Location.Y);
                txtNORECV.Size = new System.Drawing.Size(txtNORECV.Size.Width + 90, txtNORECV.Size.Height);

                //txtACTMON.Location = new Point(500, 584);
                //this.tabControl1.TabPages[0].Controls.Add(txtACTMON);
                f4ToolStripMenuItem.Text = "F4. 重 架";
                f6ToolStripMenuItem.Text = "F6. 付款";

            }
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4E_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadTextBox();
            loadinfo();
            bt.Text = "NÚT DUYỆT";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btnOK.Hide();
            btnClose.Hide();

            con.DGV(DGV1);
            con.DGV(DGV2);
            con.DGV(DGV3);
        }

        private void LoadTextBox()
        {
            txtCUTON.Text = currentRow["CUTON"].ToString();
            txtCUTOFF.Text = currentRow["CUTOFF"].ToString();
            txtC_NO.Text = currentRow["C_NO"].ToString();
            txtC_ANAME.Text = currentRow["C_ANAME"].ToString();
            txtLASTMON.Text = con.ConvertNumber(currentRow["LASTMON"].ToString());
            txtCTOTAL.Text = con.ConvertNumber(currentRow["CTOTAL"].ToString());
            txtTAX.Text = con.ConvertNumber(currentRow["TAX"].ToString());
            txtDISCOUNT.Text = con.ConvertNumber(currentRow["DISCOUNT"].ToString());
            txtCASH.Text = con.ConvertNumber(currentRow["CASH"].ToString());
            txtCURRMON.Text = con.ConvertNumber(currentRow["CURRMON"].ToString());
            txtTOTAL.Text = con.ConvertNumber(currentRow["TOTAL"].ToString());
            txtACTMON.Text = con.ConvertNumber(currentRow["ACTMON"].ToString());
            txtNORECV.Text = con.ConvertNumber(currentRow["NORECV"].ToString());
            txtAC_WS_NO.Text = currentRow["AC_WS_NO"].ToString();
            txtPERS.Text = currentRow["PERS"].ToString();
            txtM_TRAN_R.Text = currentRow["M_TRAN_R"].ToString();
            txtM01.Text = currentRow["M01"].ToString();
            txtM02.Text = currentRow["M02"].ToString();
            txtCHK_AC_NO.Text = currentRow["CHK_AC_NO"].ToString();
            txtCHK_AC_NAME.Text = currentRow["CHK_AC_NAME"].ToString();
            txtWS_DATE.Text = currentRow["WS_DATE"].ToString();

        }

        private void LoadDataGridView()
        {
            string sql = "SELECT NR,WS_DATE,DISCOUNT,CASH,WS_CHECK,CH_NO,TELCASH,TEL_NO,PREMONEY,M_TRAN,M_TRAN_R,MEMO,AC_WS_NO FROM PAYVB WHERE CUTON=N'" + txtCUTON.Text.Replace("/", "") + "' AND  CUTOFF=N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO=N'" + txtC_NO.Text + "'";
            string sql1 = "SELECT NR as NR1,INV_NO,INV_AMT,INV_TAX,INV_TOT,WS_DATE1,P_NAME,P_NAME3,BQTY,PRICE,AMOUNT,OR_NO,CA_NO,W_KIND,MEMO as MEMO1 FROM PAYVB1 WHERE CUTON=N'" + txtCUTON.Text.Replace("/", "") + "' AND  CUTOFF=N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO=N'" + txtC_NO.Text + "'";
            string sql2 = "SELECT NR AS NR_2,AC_NO,AC_NAME FROM PAYVB2 WHERE CUTON=N'" + txtCUTON.Text.Replace("/", "") + "' AND  CUTOFF=N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO=N'" + txtC_NO.Text + "'";

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt = con.readdata(sql);
            dt1 = con.readdata(sql1);
            dt2 = con.readdata(sql2);

            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }

            foreach (DataRow item in dt1.Rows)
            {
                item["WS_DATE1"] = con.formatstr2(item["WS_DATE1"].ToString());
            }
            DGV1.DataSource = dt;
            DGV2.DataSource = dt1;
            DGV3.DataSource = dt2;
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
        private void LoadData()
        {
            string counts = "SELECT COUNT(CUTON) AS counts FROM PAYV where 1=1 " + Getitem.Wheres;
            count = int.Parse(con.readdata(counts).Rows[0][0].ToString());

            string sql = "SELECT TOP 50 CUTON,CUTOFF,C_NO,C_NAME,C_ANAME,LASTMON,CTOTAL,TAX, DISCOUNT, CASH, CURRMON, TOTAL," +
                " ACTMON, NORECV, AC_WS_NO, PERS, M_TRAN_R,M_TRAN, M01, M02, CHK_AC_NO, CHK_AC_NAME, WS_DATE" +
                " FROM PAYV where 1=1 "+ Getitem.Wheres +"";

            sql = sql + " ORDER BY CUTON DESC,C_NO";
            dt = new DataTable();
            dt = con.readdata(sql);
            bindingSource.DataSource = dt;
        }

        void loadinfo()
        {
            lbUserName.Text = con.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
            Loadcb(currentRow["M_TRAN"].ToString());
            LoadTextBox();
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4EF7 frm = new Form4EF7();
            frm.ShowDialog();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string wheres = "";
            frmSelectDateFrm4E frm = new frmSelectDateFrm4E();
            frm.ShowDialog();
            if (SearchVENDC.ListItem.Count() > 0)
            {
                int count = 0;
                foreach (var item in SearchVENDC.ListItem)
                {
                    count++;
                    wheres = wheres + item.C_NO ;
                    if (count < SearchVENDC.ListItem.Count())
                    {
                        wheres = wheres + ",";
                    }
                    //string sql = "SELECT * FROM COMHC1 WHERE C_NO = N'"+ item.C_NO +"' AND CAL_YM='" + item.CAL_YM + "'";
                    //dt = con.readdata(sql);
                }
                string sql = "dbo.Insert4E @ListC_NO = N'" + wheres + "',@CAL_YM = N'" + SearchVENDC.SetItem.CAL_YM + "'";
                con.exedata(sql);
            }

            cbMTRAN.Enabled = false;
            LoadData();
            LoadTextBox();
        }

        public void Loadcb(string M_NO)
        {
            string wheres = " AND M_NO = '" + M_NO + "'";
            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1 " + wheres + "";
            DataTable data = con.readdata(sql);
            cbMTRAN.DataSource = data;
            cbMTRAN.DisplayMember = "M_NAME";
            cbMTRAN.ValueMember = "M_NO";
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
            LoadTextBox();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            LoadDataGridView();
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            LoadTextBox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            LoadDataGridView();
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            int position = bindingSource.Position;
            if (bindingSource.Count > count)
            {
                string sql1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY CUTON DESC,C_NO) AS ROWID, CUTON,CUTOFF,C_NO,C_NAME,C_ANAME,LASTMON,CTOTAL,TAX, DISCOUNT, CASH, CURRMON, TOTAL," +
                    "ACTMON, NORECV, AC_WS_NO, PERS, M_TRAN_R,M_TRAN, M01, M02, CHK_AC_NO, CHK_AC_NAME, WS_DATE FROM PAYV) a " +
                    " where 1=1 " + Getitem.Wheres + " AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize) + "";
                DataTable ds = new DataTable();
                ds = con.readdata(sql1);
                dt.Merge(ds);
                bindingSource.DataSource = dt;
                bindingSource.Position = position;
                pageIndex++;
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

            LoadDataGridView();
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            if (bindingSource.Count < count)
            {
                string sql1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY CUTON DESC,C_NO) AS ROWID, CUTON,CUTOFF,C_NO,C_NAME,C_ANAME,LASTMON,CTOTAL,TAX, DISCOUNT, CASH, CURRMON, TOTAL," +
                                "ACTMON, NORECV, AC_WS_NO, PERS, M_TRAN_R,M_TRAN, M01, M02, CHK_AC_NO, CHK_AC_NAME, WS_DATE FROM PAYV) a where 1=1 " + Getitem.Wheres + "";
                DataTable ds = new DataTable();
                ds = con.readdata(sql1);
                bindingSource.DataSource = ds;
            }

            bindingSource.MoveLast();
            LoadTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            LoadDataGridView();
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btnOK.Visible = true;
            btnClose.Visible = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;

            btnOK.Visible = false;
            btnClose.Visible = false;

            btdau.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bttruoc.Enabled = true;
            cbMTRAN.Enabled = false;

            //int index = bindingSource.Position;
            //LoadData();
            //bindingSource.Position = index;
            //LoadTextBox();
            LoadData();
            LoadTextBox();
            LoadDataGridView();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (f3ToolStripMenuItem.Checked == true)
            {
                string sql = "dbo.Delete4E @C_NO = N'" + txtC_NO.Text + "', @CUTON = N'" + txtCUTON.Text.Replace("/", "") + "', @CUTONOFF = N'" + txtCUTOFF.Text.Replace("/", "") + "'";
                con.exedata(sql);
            }

            if (f6ToolStripMenuItem.Checked == true)
            {
                string sql = "UPDATE PAYV SET CUTON='" + txtCUTON.Text.Replace("/", "") + "',CUTOFF='" + txtCUTOFF.Text.Replace("/", "") + "'," +
                            " LASTMON = " + float.Parse(txtLASTMON.Text) + ",CTOTAL = " + float.Parse(txtCTOTAL.Text) + ",TAX = " + float.Parse(txtTAX.Text) + ",DISCOUNT = " + float.Parse(txtDISCOUNT.Text) + ",CASH = " + float.Parse(txtCASH.Text) + ",CURRMON = " + float.Parse(txtCURRMON.Text) + ",TOTAL = " + float.Parse(txtTOTAL.Text) + "," +
                            " ACTMON = " + float.Parse(txtACTMON.Text) + ",NORECV = " + float.Parse(txtNORECV.Text) + ",AC_WS_NO = '',M_TRAN = '" + cbMTRAN.SelectedValue.ToString() + "',M_TRAN_R = " + txtM_TRAN_R.Text + ",USR_NAME = N'" + lbUserName.Text + "'," +
                            " COSTTOT = 0,PREMONEY = "+ PREMONEYS + ",M01 = '" + txtM01.Text + "',M02 = '" + txtM02.Text + "',CHK_AC_NO=N'"+txtCHK_AC_NO.Text+"',CHK_AC_NAME=N'"+txtCHK_AC_NAME.Text+"',WS_DATE='"+txtWS_DATE.Text.Replace("/","")+"',PERS= "+ float.Parse(txtPERS.Text)+"" +
                            " WHERE CUTON = N'" + txtCUTON.Text.Replace("/", "") + "' AND CUTOFF = N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO = N'" + txtC_NO.Text + "'";

                if (con.exedata(sql) == true)
                {
                    string sqlDelete = "DELETE dbo.PAYVB WHERE CUTON=N'" + txtCUTON.Text.Replace("/", "") + "' AND CUTOFF=N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO=N'" + txtC_NO.Text + "'";
                    string sqlDelete1 = "DELETE dbo.PAYVB1 WHERE CUTON=N'" + txtCUTON.Text.Replace("/", "") + "' AND CUTOFF=N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO=N'" + txtC_NO.Text + "'";
                    string sqlDelete2 = "DELETE dbo.PAYVB2 WHERE CUTON=N'" + txtCUTON.Text.Replace("/", "") + "' AND CUTOFF=N'" + txtCUTOFF.Text.Replace("/", "") + "' AND C_NO=N'" + txtC_NO.Text + "'";

                    if(con.exedata(sqlDelete))
                    {
                        foreach (DataGridViewRow item in DGV1.Rows)
                        {
                            string sqlInsert = "INSERT INTO PAYVB (CUTON,CUTOFF,C_NO,NR,WS_DATE,PREMONEY,DISCOUNT," +
                                                " CASH,WS_CHECK,CH_NO,TELCASH,TEL_NO,AC_WS_NO,M_TRAN,M_TRAN_R,MEMO) " +
                                                " VALUES(N'" + txtCUTON.Text.Replace("/", "") + "', N'" + txtCUTOFF.Text.Replace("/", "") + "', N'" + txtC_NO.Text + "'," +
                                                " N'001', N'" + item.Cells["WS_DATE"].Value.ToString().Replace("/", "") + "', " + item.Cells["PREMONEY"].Value.ToString() + "," +
                                                " " + item.Cells["DISCOUNT"].Value.ToString() + ", " + item.Cells["CASH"].Value.ToString() + ", " + item.Cells["WS_CHECK"].Value.ToString() + ", " +
                                                " N'" + item.Cells["CH_NO"].Value.ToString() + "', " + item.Cells["TELCASH"].Value.ToString() + ", N'" + item.Cells["TEL_NO"].Value.ToString() + "'," +
                                                " N'" + item.Cells["AC_WS_NO"].Value.ToString() + "', N'" + item.Cells["M_TRAN"].Value.ToString() + "', " + item.Cells["M_TRAN_R"].Value.ToString() + ", N'" + item.Cells["MEMO"].Value.ToString() + "')";
                            con.exedata(sqlInsert);
                        }
                    }
                    
                    if(con.exedata(sqlDelete1))
                    {
                        foreach (DataGridViewRow item in DGV2.Rows)
                        {
                            string sqlInsert1 = "INSERT INTO PAYVB1 (CUTON,CUTOFF,C_NO,NR,WS_DATE1,P_NAME,P_NAME3,BQTY,PRICE,AMOUNT,OR_NO," +
                                                " CA_NO,W_KIND,MEMO,INV_NO,INV_AMT,INV_TAX,INV_TOT) " +
                                                " VALUES(N'" + txtCUTON.Text.Replace("/", "") + "', N'" + txtCUTOFF.Text.Replace("/", "") + "', N'" + txtC_NO.Text + "'," +
                                                " N'" + item.Cells["NR1"].Value.ToString() + "', N'" + item.Cells["WS_DATE1"].Value.ToString().Replace("/", "") + "', N'" + item.Cells["P_NAME"].Value.ToString() + "', N'" + item.Cells["P_NAME3"].Value.ToString() + "'," +
                                                " " + item.Cells["BQTY"].Value.ToString() + ", " + item.Cells["PRICE"].Value.ToString() + ", " + item.Cells["AMOUNT"].Value.ToString() + ", N'" + item.Cells["OR_NO"].Value.ToString() + "'," +
                                                " N'" + item.Cells["CA_NO"].Value.ToString() + "', N'" + item.Cells["W_KIND"].Value.ToString() + "', N'" + item.Cells["MEMO1"].Value.ToString() + "', N'" + item.Cells["INV_NO"].Value.ToString() + "'," +
                                                " " + item.Cells["INV_AMT"].Value.ToString() + ", " + item.Cells["INV_TAX"].Value.ToString() + ", " + item.Cells["INV_TOT"].Value.ToString() + ")";
                            con.exedata(sqlInsert1);
                        }
                    }

                    if(con.exedata(sqlDelete2))
                    {
                        foreach (DataGridViewRow item in DGV3.Rows)
                        {
                            string sqlInsert3 = "INSERT INTO PAYVB2 (CUTON,CUTOFF,C_NO,NR,AC_NO,AC_NAME)" +
                                                " VALUES(N'" + txtCUTON.Text.Replace("/", "") + "', N'" + txtCUTOFF.Text.Replace("/", "") + "', N'" + txtC_NO.Text + "', N'" + item.Cells["NR_2"].Value.ToString() + "'," +
                                                " N'" + item.Cells["AC_NO"].Value.ToString() + "', N'" + item.Cells["AC_NAME"].Value.ToString() + "')";
                            con.readdata(sqlInsert3);
                        }
                    }

                }
            }

            btnClose.PerformClick();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn tính toán lại", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string Months = txtCUTON.Text.Replace("/", "");
                string sql = "dbo.Insert4E @ListC_NO = N'" + txtC_NO.Text + "',@CAL_YM = N'" + Months.Substring(0,6) + "'";
                con.exedata(sql);

                int index = bindingSource.Position;
                LoadData();
                bindingSource.Position = index;
                LoadTextBox();
            }
            else if (dialogResult == DialogResult.No)
            {
                int index = bindingSource.Position;
                LoadData();
                bindingSource.Position = index;
                LoadTextBox();
            }
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            cbMTRAN.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btnOK.Visible = true;
            btnClose.Visible = true;

            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1";
            DataTable data = con.readdata(sql);
            cbMTRAN.DataSource = data;
            cbMTRAN.DisplayMember = "M_NAME";
            cbMTRAN.ValueMember = "M_NO";

            cbMTRAN.SelectedValue = currentRow["M_TRAN"].ToString();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 1)
                {
                    FromCalender frm = new FromCalender();
                    frm.ShowDialog();
                    DGV1[1, DGV1.CurrentRow.Index].Value = FromCalender.getDate.ToString("yyyy/MM/dd");
                }
            }
        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    con.CreateMenuStrip(e, DGV1, DGV1_Mouse_Click);
                }
                else
                {
                    float sumDiscount = 0;
                    float sumCASH = 0;
                    float sumWS_CHECK = 0;
                    float sumTELCASH = 0;
                    //float sumTEL_NO = 0;
                    float sumPREMONEY = 0;
                    if (DGV1.Rows.Count > 0)
                    {
                        for (int i = 0; i < DGV1.Rows.Count; i++)
                        {
                            sumDiscount += (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["DISCOUNT"].Value.ToString()) ? float.Parse(DGV1.Rows[i].Cells["DISCOUNT"].Value.ToString()) : 0);
                            sumCASH += (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["CASH"].Value.ToString()) ? float.Parse(DGV1.Rows[i].Cells["CASH"].Value.ToString()) : 0);
                            sumWS_CHECK += (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["WS_CHECK"].Value.ToString()) ? float.Parse(DGV1.Rows[i].Cells["WS_CHECK"].Value.ToString()) : 0);
                            sumTELCASH += (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["TELCASH"].Value.ToString()) ? float.Parse(DGV1.Rows[i].Cells["TELCASH"].Value.ToString()) : 0);
                            //sumTEL_NO += (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["TEL_NO"].Value.ToString()) ? float.Parse(DGV1.Rows[i].Cells["TEL_NO"].Value.ToString()) : 0);
                            sumPREMONEY += (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["PREMONEY"].Value.ToString()) ? float.Parse(DGV1.Rows[i].Cells["PREMONEY"].Value.ToString()) : 0);
                        }
                        txtACTMON.Text = con.ConvertNumber((sumDiscount + sumCASH + sumWS_CHECK + sumTELCASH + sumPREMONEY).ToString());
                        PREMONEYS = sumPREMONEY;
                    }
                }
            }
        }

        private void txtACTMON_TextChanged(object sender, EventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                txtNORECV.Text = con.ConvertNumber((float.Parse(txtTOTAL.Text) - float.Parse(txtACTMON.Text)).ToString());
            }
        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        string STT = "";
        private void DGV1_Mouse_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    int NR1 = 1;
                    if (DGV1.RowCount > 0)
                    {
                        NR1 = DGV1.RowCount + 1;
                    }
                    DataTable dataTable = (DataTable)DGV1.DataSource;
                    STT = NR1.ToString("D" + 3);
                    DataRow drToAdd = dataTable.NewRow();
                    drToAdd["NR"] = STT;
                    drToAdd["WS_DATE"] = "    /  /  ";
                    drToAdd["DISCOUNT"] = 0;
                    drToAdd["CASH"] = 0;
                    drToAdd["WS_CHECK"] = 0;
                    drToAdd["CH_NO"] = "";
                    drToAdd["TELCASH"] = 0;
                    drToAdd["TEL_NO"] = 0;
                    drToAdd["PREMONEY"] = 0;
                    drToAdd["M_TRAN"] = cbMTRAN.SelectedValue.ToString();
                    drToAdd["M_TRAN_R"] = txtM_TRAN_R.Text;
                    drToAdd["MEMO"] = "";
                    drToAdd["AC_WS_NO"] = "";

                    dataTable.Rows.Add(drToAdd);
                    break;
                case "Delele":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < DGV1.Rows.Count; i++)
                            {
                                DGV1[0, i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                FromCalender frm = new FromCalender();
                frm.Show();
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
        
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchPAYV frm = new SearchPAYV();
            frm.ShowDialog();
            LoadData();
            bindingSource.Position = SearchPAYV.GetItem.index;
            txtCUTON.Text = SearchPAYV.GetItem.CUTON;
            txtCUTOFF.Text = SearchPAYV.GetItem.CUTOFF;
            txtC_NO.Text = SearchPAYV.GetItem.C_NO;
            txtC_ANAME.Text = SearchPAYV.GetItem.C_ANAME;

            LoadTextBox();
            LoadDataGridView();
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void cbMTRAN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                string money = "SELECT M_TRAN FROM dbo.MONEYT WHERE M_NO = '" + cbMTRAN.SelectedValue.ToString() + "'";
                DataTable dt = con.readdata(money);
                txtM_TRAN_R.Text = dt.Rows[0]["M_TRAN"].ToString();
            }
        }

        private void DGV2_MouseClick(object sender, MouseEventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    con.CreateMenuStrip(e, DGV2, DGV2_Mouse_Click);
                }
                else
                {
                    if (DGV2.Rows.Count > 0)
                    {
                        int Cur = int.Parse(DGV2.CurrentCell.ColumnIndex.ToString());
                        float SumTax = 0;
                        for (int i = 0; i < DGV2.Rows.Count; i++)
                        {
                            this.DGV2["INV_TOT", DGV2.CurrentRow.Index].Value = double.Parse(DGV2["INV_AMT", DGV2.CurrentRow.Index].Value.ToString()) + double.Parse(DGV2["INV_TAX", DGV2.CurrentRow.Index].Value.ToString());
                            SumTax += float.Parse(DGV2["INV_TAX", DGV2.CurrentRow.Index].Value.ToString());
                        }
                        txtTAX.Text = con.ConvertNumber(SumTax.ToString());
                        txtCURRMON.Text = con.ConvertNumber((float.Parse(txtLASTMON.Text) + float.Parse(txtCTOTAL.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text) - float.Parse(txtCASH.Text)).ToString());
                        txtNORECV.Text = con.ConvertNumber((float.Parse(txtLASTMON.Text) + float.Parse(txtCTOTAL.Text) + float.Parse(txtTAX.Text) - float.Parse(txtDISCOUNT.Text) - float.Parse(txtCASH.Text) - float.Parse(txtACTMON.Text)).ToString());
                    }
                }
            }
        }

        private void DGV2_Mouse_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    int NR1 = 1;
                    if (DGV2.RowCount > 0)
                    {
                        NR1 = DGV2.RowCount + 1;
                    }
                    DataTable dataTable = (DataTable)DGV2.DataSource;
                    STT = NR1.ToString("D" + 3);
                    DataRow drToAdd = dataTable.NewRow();
                    drToAdd["NR1"] = STT;
                    drToAdd["INV_NO"] = "";
                    drToAdd["INV_AMT"] = 0;
                    drToAdd["INV_TAX"] = 0;
                    drToAdd["INV_TOT"] = 0;
                    drToAdd["WS_DATE1"] = "    /  /  ";
                    drToAdd["P_NAME"] = "";
                    drToAdd["BQTY"] = 0;
                    drToAdd["PRICE"] = 0;
                    drToAdd["AMOUNT"] = 0;
                    drToAdd["OR_NO"] = "";
                    drToAdd["CA_NO"] = 0;
                    drToAdd["W_KIND"] = 0;
                    drToAdd["MEMO1"] = "";
                    drToAdd["P_NAME3"] = "";

                    dataTable.Rows.Add(drToAdd);
                    break;
                case "Delele":
                    foreach (DataGridViewCell oneCell in DGV2.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV2.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < DGV2.Rows.Count; i++)
                            {
                                DGV2[0, i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }

        private void DGV3_MouseClick(object sender, MouseEventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    con.CreateMenuStrip(e, DGV3, DGV3_Mouse_Click);
                }
            }
        }

        private void DGV3_Mouse_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    int NR1 = 1;
                    if (DGV3.RowCount > 0)
                    {
                        NR1 = DGV3.RowCount + 1;
                    }
                    DataTable dataTable = (DataTable)DGV3.DataSource;
                    STT = NR1.ToString("D" + 3);
                    DataRow drToAdd = dataTable.NewRow();
                    drToAdd["NR_2"] = STT;
                    drToAdd["AC_NO"] = "";
                    drToAdd["AC_NAME"] = "";

                    dataTable.Rows.Add(drToAdd);
                    break;
                case "Delele":
                    foreach (DataGridViewCell oneCell in DGV3.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV3.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < DGV3.Rows.Count; i++)
                            {
                                DGV3[0, i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }

        private void DGV2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
