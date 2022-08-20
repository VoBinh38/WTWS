﻿using LibraryCalender;
using PURCHASE.MAINCODE;
using PURCHASE.MAINCODE.Modun8.Envent;
using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class Form8A : Form
    {
        DataProvider conn = new DataProvider();
        DataTable table = new DataTable();
        BindingSource source = new BindingSource();
        public Form8A()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5ToolStripMenuItem.Checked = true;
            Form8AF5 f5 = new Form8AF5();
            f5.ShowDialog();
            tb3.Text = Form8AF5.shareData8AF5.WS_NO;
            LoadData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult ccl = MessageBox.Show("Bạn Có muốn thoát chương trình không? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (ccl == DialogResult.OK)
            this.Close();
        }

        private void Form8A_Load(object sender, EventArgs e)
        {
            LoadFisrt();
            LoadData();
        }
        string TextDate = "";
        private void checkMaskText()
        {
            if (txtNgayLayHang.MaskFull == true)
            {
                TextDate = conn.formatstr2(txtNgayLayHang.Text);
            }    
            
        }
        private void LoadData()
        {
            if (f5ToolStripMenuItem.Checked == true)
            {
                source = Form8AF5.shareData8AF5.binding;
            }
            else
            {
                string sql = "SELECT TOP 1000 WS_NO,WS_DATE,SH_NO,SH_NAME,S_NO,S_NAME,MEMO,OR_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,QTY,BQTY,OUTQTY,OUTBQTY," +
                "OVER0,USR_NAME,SGN_NAME1,SGN_NAME2,SGN_NAME3,SGN_NAME4,K_NO,UPDATEKIND,WS_KIND FROM COLH ORDER BY WS_DATE DESC,WS_NO DESC";
                table = conn.readdata(sql);
                source.DataSource = table;
                ShareData.datashare = table;
            }
            ShowData();
        }
        private void ShowData()
        {
            txtNgayLayHang.Text = conn.formatstr2(currenRow["WS_DATE"].ToString());
            tb2.Text = currenRow["WS_KIND"].ToString();
            tb3.Text = currenRow["WS_NO"].ToString();
            tb4.Text = currenRow["S_NO"].ToString();
            tb5.Text = currenRow["S_NAME"].ToString();
            tb6.Text = currenRow["MEMO"].ToString();
        }
        private void tb3_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT NR,P_NO,P_NAME,P_NAME1,P_NAME3,BUNIT,BQTY,MEMO1,MEMO,SH_NO,P1_NO,P1_NAME,K_NO_O FROM COLB WHERE WS_NO = '" + tb3.Text + "'";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            if (f5ToolStripMenuItem.Checked == true)
            {
                dataF8A.DataSource = data;
                conn.DGV(dataF8A);
            }
            else
            {
                if (f2ToolStripMenuItem.Checked == true)
                {
                    if (data.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btok.Enabled = false;
                    }
                    else
                    {
                        dataF8A.DataSource = data;
                        conn.DGV(dataF8A);
                        btok.Enabled = true;
                    }
                }
                else
                {
                    dataF8A.DataSource = data;
                    conn.DGV(dataF8A);
                    btok.Enabled = true;
                }
            }
        }
        private DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[source].Position;
                if (position > -1)
                {
                    return ((DataRowView)source.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        private void LoadFisrt()
        {
            //phan quyền
            conn.CheckLoad(menuStrip1);
            loadinfo();
            btok.Hide();
            btdong.Hide();
            conn.DGV(dataF8A);
            toolTip1.SetToolTip(tb2, "Bạn chỉ nhập số 1 hoặc 2");
            ReadOnlyData(true);
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.Show();
            btdong.Show();
            //check lock
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            // check open
            f2ToolStripMenuItem.Checked = true;
            //resert
            ResetDataTextbox();
            ReadOnlyData(false);
            //lock Enable
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Không Có Dữ Liệu");
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.Show();
            btdong.Show();
            //check lock
            f3ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            // check open
            f4ToolStripMenuItem.Checked = true;
            //resert
            ReadOnlyData(false);
            //lock Enable
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f9CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    MessageBox.Show("Không Có Dữ Liệu");
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            LoadFisrt();
            LoadData();
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

        private void btdau_MouseClick(object sender, MouseEventArgs e)
        {
            source.MoveFirst();
            ShowData();

            btdau.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            source.MovePrevious();
            ShowData();

            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            source.MoveNext();
            ShowData();

            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            source.MoveLast();
            ShowData();

            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        //Share data
        public class ShareData
        {
            public static DataTable datashare;
        }
        private void txtNgayLayHang_MouseClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender from = new LibraryCalender.FromCalender();
                from.ShowDialog();
                txtNgayLayHang.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }

        }
        private void ResetDataTextbox()
        {
            txtNgayLayHang.Text = DateTime.Now.ToString("yyyyMMdd");
            tb2.Text = "1";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
        }
        private void ReadOnlyData(bool check)
        {
            txtNgayLayHang.ReadOnly = check;
            tb2.ReadOnly = check;
            tb3.ReadOnly = check;
            tb4.ReadOnly = check;
            tb5.ReadOnly = check;
            dataF8A.ReadOnly = check;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tb2_MouseClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                if (tb2.Text == "")
                {
                    tb2.Text = "1";
                    lblLoai.Text = "化料";
                }
                else if (tb2.Text == "1")
                {
                    tb2.Text = "2";
                    lblLoai.Text = "總料";
                }
                else if (tb2.Text == "2")
                {
                    tb2.Text = "1";
                    lblLoai.Text = "化料";
                }
            }
        }
        private void btok_Click(object sender, EventArgs e)
        {
            checkMaskText();
            if (f2ToolStripMenuItem.Checked == true)
            {
                InsertData();
            }    
        }
        private void InsertData()
        {
            try
            {
                //insert
                string sql = "INSERT INTO COLH (WS_NO,WS_DATE,SH_NO,SH_NAME,S_NO,S_NAME,MEMO,OR_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,QTY,BQTY,OUTQTY,OUTBQTY,OVER0,USR_NAME,SGN_NAME1,SGN_NAME2,SGN_NAME3,SGN_NAME4,K_NO,WS_KIND) " +
                    "SELECT '" + tb3.Text + "','" + TextDate + "',N'',N'','" + tb4.Text + "','" + tb5.Text + "',N'"+tb6.Text+"',N'',N'',N'',N'',N'',N'',0,0,0,0,N'N',N'" + lbUserName.Text + "',N'',N'',N'',N'',N'',N'" + tb2.Text + "'";
                bool check = conn.exedata(sql);
                if (check == true)
                {
                    InsertDataDGV();
                    InsertIntoCARD();
                    UpdatePSHQTY();
                    UpdatePro1c();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePro1c()
        {
            for (int i = 0; i < dataF8A.RowCount; i++)
            {
                var P_NO = dataF8A.Rows[i].Cells["P_NO"].Value;
                var QTY = dataF8A.Rows[i].Cells["BQTY"].Value;
                string sql1 = "SELECT QTY - " + QTY + " QTY FROM dbo.PSHQTY WHERE P_NO = '" + P_NO + "'";
                DataTable dataTable = new DataTable();
                dataTable = conn.readdata(sql1);
                string sql = " UPDATE PROD1C SET QTYSTORE = '"+ dataTable.Rows[0]["QTY"].ToString() + "' WHERE P_NO = '"+ P_NO + "'";
                conn.exedata(sql);
            }
        }
        private void UpdatePSHQTY()
        {
            for (int i = 0; i < dataF8A.RowCount; i++)
            {
                
                var SH_NO = dataF8A.Rows[i].Cells["SH_NO"].Value;
                var P_NO = dataF8A.Rows[i].Cells["P_NO"].Value;
                var K_NO = dataF8A.Rows[i].Cells["P_NO"].Value.ToString().Substring(0, 2);
                var QTY = dataF8A.Rows[i].Cells["BQTY"].Value;
                string sql1 = "SELECT QTY - "+ QTY + " QTY FROM dbo.PSHQTY WHERE P_NO = '" + P_NO + "'";
                DataTable dataTable = new DataTable();
                dataTable = conn.readdata(sql1);
                string sql = "UPDATE PSHQTY SET P_NO = '"+ P_NO + "', SH_NO = '"+ SH_NO + "', K_NO = '"+ K_NO + "', QTY = '"+ dataTable.Rows[0]["QTY"].ToString() + "' WHERE P_NO = '"+ P_NO + "' AND SH_NO = '"+ SH_NO + "'";
                conn.exedata(sql);
            } 
        }
        private void InsertIntoCARD()
        {
            for (int i = 0; i < dataF8A.RowCount; i++)
            {
                //lay data
                var WS_NO = tb3.Text;
                var WS_DATE = TextDate;
                var NR = dataF8A.Rows[i].Cells["NR"].Value;
                var SH_NO = dataF8A.Rows[i].Cells["SH_NO"].Value;
                var P_NO = dataF8A.Rows[i].Cells["P_NO"].Value;
                var QTYP = 0;
                var QTY = dataF8A.Rows[i].Cells["BQTY"].Value;
                //insert
                string sql = "INSERT INTO CARD (WS_NO,NR,SH_NO,P_NO,QTY,QTYP,WS_DATE) " +
                  "SELECT '" + WS_NO + "','"+ NR + "','"+ SH_NO + "','"+ P_NO + "','"+QTY+"','"+ QTYP + "','"+ WS_DATE + "'";
                bool check = conn.exedata(sql);
            }
        }
        private void InsertDataDGV()
        {
            for (int i = 0; i < dataF8A.RowCount; i++)
            {
                //lay data
                var WS_NO = tb3.Text;
                var WS_DATE = TextDate;

                var NR = dataF8A.Rows[i].Cells["NR"].Value;
                var P_NO = dataF8A.Rows[i].Cells["P_NO"].Value;
                var P_NAME = dataF8A.Rows[i].Cells["P_NAME"].Value;
                var P_NAME1 = dataF8A.Rows[i].Cells["P_NAME1"].Value;
                var P_NAME2 = "";
                var P_NAME3 = dataF8A.Rows[i].Cells["P_NAME3"].Value;
                var UNIT = "";
                var BUNIT = dataF8A.Rows[i].Cells["BUNIT"].Value;
                var QTY = 0;
                var BQTY = dataF8A.Rows[i].Cells["BQTY"].Value;
                var SH_NO = dataF8A.Rows[i].Cells["SH_NO"].Value;
                var MEMO1 = dataF8A.Rows[i].Cells["MEMO1"].Value;
                var MEMO = dataF8A.Rows[i].Cells["MEMO"].Value;
                var K_NO = dataF8A.Rows[i].Cells["P_NO"].Value.ToString().Substring(0,2);
                var P1_NO = dataF8A.Rows[i].Cells["P1_NO"].Value;
                var P1_NAME = dataF8A.Rows[i].Cells["P1_NAME"].Value;
                var K_NO_O = dataF8A.Rows[i].Cells["K_NO_O"].Value;
                //insert
                string sql = "INSERT INTO COLB (WS_NO,NR,WS_DATE,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,UNIT,BUNIT,QTY,BQTY,SH_NO,MEMO1,MEMO,K_NO,P1_NO,P1_NAME,K_NO_O) " +
                             "SELECT '" + WS_NO + "','"+ NR + "','"+ WS_DATE + "','"+ P_NO + "','" + P_NAME + "','" + P_NAME1 + "','" + P_NAME2 + "','" + P_NAME3 + "','" + UNIT + "','" + BUNIT + "','" + QTY + "',"+
                             "'"+ BQTY + "','"+ SH_NO + "','"+ MEMO1 + "','"+ MEMO + "','"+ K_NO + "','"+ P1_NO + "','"+ P1_NAME + "','"+ K_NO_O + "'";
                conn.exedata(sql);
            }
                
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                if (tb2.Text == "1")
                {
                    lblLoai.Text = "化料";
                }
                else if (tb2.Text == "2")
                {
                    lblLoai.Text = "總料";
                }
                else
                {
                    lblLoai.Text = "";
                }
            }
        }

        private void tb2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                if (int.Parse(tb2.Text) < 1 || int.Parse(tb2.Text) > 2)
                {
                    errorProvider1.SetError(tb2, "Vui lòng nhập số 1 hoặc số 2!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(tb2, null);
                }
            }
        }

        private void tb4_DoubleClick(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frmSearchSale frmSearch = new frmSearchSale();
                frmSearch.ShowDialog();
                tb4.Text = frmSearchSale.getSale.mabophan;
                tb5.Text = frmSearchSale.getSale.tenbophan;
            }
        }

        private void dataF8A_MouseClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    int position_xy_mouse_row = dataF8A.HitTest(e.X, e.Y).RowIndex;
                    menu.Items.Add("Insert").Name = "Insert";
                    menu.Items.Add("Edit").Name = "Edit";
                    menu.Items.Add("Del").Name = "Del";

                    menu.Show(dataF8A, new Point(e.X, e.Y));
                    menu.ItemClicked += Menu_ItemClicked;
                }
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    try
                    {
                        if (!string.IsNullOrEmpty(tb3.Text))
                        {
                            ClickInsertDataGridview();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số yêu cầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Del":
                    foreach (DataGridViewCell oneCell in dataF8A.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            dataF8A.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < dataF8A.Rows.Count - 1; i++)
                            {
                                dataF8A[0, i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }
        private void tb6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmSearchMemo frmSearch = new frmSearchMemo();
            frmSearch.ShowDialog();
            tb6.Text = frmSearchMemo.getMeMo.M_NAME;
        }
        string STT = "";
        private void ClickInsertDataGridview()
        {
            DataGridViewRow dr = new DataGridViewRow();
            int NR1 = 1;
            if (dataF8A.RowCount > 0)
            {
                NR1 = dataF8A.RowCount + 1;
            }
                frmSearchOrder fm = new frmSearchOrder();
                fm.ShowDialog();
                DataTable dataTable = (DataTable)dataF8A.DataSource;
                foreach (var item in frmSearchOrder.ID.list)
                {
                    STT = NR1.ToString("D" + 3);
                    DataRow drToAdd = dataTable.NewRow();
                    drToAdd["NR"] = STT;
                    drToAdd["P_NO"] = item.P_NO;
                    drToAdd["P_NAME"] = item.P_NAME;
                    drToAdd["P_NAME1"] = item.P_NAME1;
                    drToAdd["P_NAME3"] = item.P_NAME3;
                    drToAdd["BUNIT"] = item.BUNIT;
                    drToAdd["BQTY"] = "0.00";
                    drToAdd["MEMO1"] = "";
                    drToAdd["MEMO"] = "";
                     if (tb2.Text == "1")
                     {
                        drToAdd["SH_NO"] = "B";
                     }
                     else
                     {
                         drToAdd["SH_NO"] = "A";
                     }    
                    drToAdd["P1_NO"] = "";
                    drToAdd["P1_NAME"] = "";
                    drToAdd["K_NO_O"] = item.K_NO_O;
                    dataTable.Rows.Add(drToAdd);
                    NR1++;
                }
                dataF8A.DataSource = dataTable;
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string str1 = "SELECT TOP 1 S_NO, S_NAME FROM SALE WHERE S_NO = '" + tb4.Text + "'";
                DataTable dt = conn.readdata(str1);
                foreach (DataRow item in dt.Rows)
                {
                    tb4.Text = item["S_NO"].ToString();
                    tb5.Text = item["S_NAME"].ToString();
                }
            }    

        }

        private void dataF8A_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                int Cur = int.Parse(dataF8A.CurrentCell.ColumnIndex.ToString());
                if (Cur == 1 || Cur == 2)
                {
                    ClickInsertDataGridview();
                }
                else if (Cur == 6)
                {
                    frm8A.P_NO = dataF8A.CurrentRow.Cells["P_NO"].Value.ToString();
                    frm8A.P_NAME_C = dataF8A.CurrentRow.Cells["P_NAME"].Value.ToString();
                    frm8A.P_NAME_E = dataF8A.CurrentRow.Cells["P_NAME1"].Value.ToString();
                    frm8A.QTY = dataF8A.CurrentRow.Cells["BQTY"].Value.ToString();
                    if (f2ToolStripMenuItem.Checked == true)
                    {
                        frm8A.ShouseA = frmCheckQtyShouse.DataCheckQTyShouse.QtyShouseA;
                        frm8A.ShouseB = frmCheckQtyShouse.DataCheckQTyShouse.QtyShouseB;
                        frm8A.ShouseType = frmCheckQtyShouse.DataCheckQTyShouse.QtyType;
                    }
                    if (f4ToolStripMenuItem.Checked == true)
                    {
                        if (this.dataF8A[9, dataF8A.CurrentRow.Index].Value.ToString() == "A")
                        {
                            frm8A.ShouseA = this.dataF8A[6, dataF8A.CurrentRow.Index].Value.ToString();
                            frm8A.ShouseType = "A";
                        }
                        else
                        {
                            frm8A.ShouseB = this.dataF8A[6, dataF8A.CurrentRow.Index].Value.ToString();
                            frm8A.ShouseType = "B";
                        }    
                    }    
                    frmCheckQtyShouse frm = new frmCheckQtyShouse();
                    frm.ShowDialog();
                    this.dataF8A[6, dataF8A.CurrentRow.Index].Value = int.Parse(frmCheckQtyShouse.DataCheckQTyShouse.QtyShouse);
                }    
            }    
        }
        public class frm8A
        {
            public static string P_NO;
            public static string P_NAME_C;
            public static string P_NAME_E;
            public static string QTY;
            public static string ShouseA;
            public static string ShouseB;
            public static string ShouseType;
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            try
            {
                source.MoveFirst();
                ShowData();
                btdau.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                source.MovePrevious();
                ShowData();
                btdau.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                source.MoveNext();
                ShowData();
                btdau.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                source.MoveLast();
                ShowData();
                btdau.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
