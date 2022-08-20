using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using LibraryCalender;
using PURCHASE.MAINCODE;

namespace PURCHASE
{
    public partial class Form1Q : Form
    {
        DataProvider conn = new DataProvider();
        public Form1Q()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        string check = "";
        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();
        #region Load Data
        private void Form1QquanlydulieuHSBC_Load(object sender, EventArgs e)
        {
            LoadFisrt();
            LoadData();
            hienthi();
        }
        private void LoadFisrt()
        {
            getInfo();
            conn.CheckLoad(menuStrip1);
            checkTextReadOnly(true);

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            bt.Text = "'"+txtDuyet+"'";
            btok.Hide();
            btdong.Hide();
        }
        private void checkTextReadOnly(bool check)
        {
            tb1.ReadOnly = check;
            tb2.ReadOnly = check;
            tb3.ReadOnly = check;
            tb4.ReadOnly = check;
            tb5.ReadOnly = check;
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
        }
        public void LoadData()
        {
            string sql  = "select WS_DATE, M_NO, M_NAME, M_NAME_E, M_TRAN from MONEYT";
            datatable = conn.readdata(sql);
            foreach (DataRow item in datatable.Rows)
            {
                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString()); 
            }
            bindingsource.DataSource = datatable;
            dataGridViewForm1Q.DataSource = bindingsource;
            conn.DGV(dataGridViewForm1Q);

        }
        public void hienthi()
        {
            tb1.Text = conn.formatstr2(dataGridViewForm1Q.Rows[0].Cells["WS_DATE"].Value.ToString());
            tb2.Text = dataGridViewForm1Q.Rows[0].Cells["M_NO"].Value.ToString();
            tb3.Text = dataGridViewForm1Q.Rows[0].Cells["M_NAME"].Value.ToString();
            tb4.Text = dataGridViewForm1Q.Rows[0].Cells["M_NAME_E"].Value.ToString();
            tb5.Text = dataGridViewForm1Q.Rows[0].Cells["M_TRAN"].Value.ToString();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();
            hienthi();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void bttruoc_Click(object sender, EventArgs e)
        {

            bindingsource.MovePrevious();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btsau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveNext();
            hienthi();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();
            hienthi();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void dataGridViewForm1Q_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb1.Text = conn.formatstr2(dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[0].Value.ToString());
            this.tb2.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[3].Value.ToString();
            this.tb5.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[4].Value.ToString();
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
               
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
               
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
            }
        }
        #endregion
        #region Tool 1 -> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtThem+"";
            btok.Show();
            btdong.Show();

            checkTextReadOnly(false);

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "0";

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtXoa+"";
            btok.Show();
            btdong.Show();

            checkTextReadOnly(false);

            tb1.ReadOnly = true;
            tb2.ReadOnly = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtSua+"";
            btok.Show();
            btdong.Show();

            checkTextReadOnly(false);

            tb1.ReadOnly = true;
            tb2.ReadOnly = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            checkTextReadOnly(false);
            bt.Text = "COPY";

            tb1.Text = "";
            tb2.Text = "";

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion     
        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                checkNofication();
                Check();
                if (f2ToolStripMenuItem.Checked == true)
                {
                    adddata();
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    string sql = "DELETE FROM MONEYT WHERE WS_DATE = '"+conn.formatstr2(tb1.Text)+"' AND M_NO = '"+tb2.Text+"'";
                    bool check = conn.exedata(sql);
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    string sql = "UPDATE MONEYT SET WS_DATE = '" + conn.formatstr2(tb1.Text) + "',M_NO = '" + tb2.Text + "',M_NAME = '"+tb3.Text+"', M_NAME_E = '"+tb4.Text+"', M_TRAN = '"+tb5.Text+"', USR_NAME = '"+lbUserName.Text+"' FROM MONEYT WHERE WS_DATE = '" + conn.formatstr2(tb1.Text) + "' AND M_NO = '" + tb2.Text + "'";
                    bool check = conn.exedata(sql);
                }
                else if (f6ToolStripMenuItem.Checked == true)
                {
                    adddata();
                }
                LoadData();
                hienthi();
                LoadFisrt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void adddata()
        {
            if (string.IsNullOrEmpty(tb1.Text) || tb1.MaskFull == false || string.IsNullOrEmpty(tb2.Text))
            {
                MessageBox.Show("Bạn nhập sai dữ liệu, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (conn.checkExists("SELECT * FROM MONEYT WHERE WS_DATE = '" + conn.formatstr2(tb1.Text) + "' AND M_NO = '" + tb2.Text + "'") == true)
            {
                MessageBox.Show("Mã này đã tồn tại!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb1.Text = "";
                tb2.Text = "";
                tb3.Text = "";
                tb4.Text = "";
                tb5.Text = "0";
            }
            else
            {
                string sql = "INSERT INTO dbo.MONEYT(WS_DATE, M_NO, M_NAME, M_NAME_E, M_TRAN, USR_NAME) " +
                "SELECT '" + conn.formatstr2(tb1.Text) + "','" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "','" + lbUserName.Text + "'";
                bool check = conn.exedata(sql);
            }    
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            checkNofication();
            LoadData();
            hienthi();
            LoadFisrt();
        }
        public void Check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                check = tb1.Text;
                check = conn.formatstr2(check.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3, tb5, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb4, tb1, sender, e);
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender from = new FromCalender();
            from.ShowDialog();
            tb1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
