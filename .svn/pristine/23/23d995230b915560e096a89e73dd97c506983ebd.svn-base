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
using PURCHASE.MAINCODE;

namespace PURCHASE
{
    public partial class Form1H : Form
    {
        DataProvider conn = new DataProvider();
        public Form1H()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();

        #region LOAD DATA
        private void Form1Hquanlydulieukho_Load(object sender, EventArgs e)
        {
            loadfisrt();
            LoadData();
            hienthi();
        }
        private void loadfisrt()
        {
            conn.CheckLoad(menuStrip1);
            checkNofication();
            getInfo();
            tb1.ReadOnly = true;
            tb2.ReadOnly = true;

            btok.Hide();
            btdong.Hide();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "" + txtDuyet + "";
         

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
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
            btndateNow.Text = conn.getDateNow(); // get DateNow


        }
        public void LoadData()
        {
            string sql = "select SH_NO, SH_NAME from SHOUSE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = conn.readdata(sql);
            bindingsource.DataSource = datatable;
            dataGridViewForm1H.DataSource = bindingsource;
            conn.DGV(dataGridViewForm1H);
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells["SH_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells["SH_NAME"].Value.ToString();
        }
        private void dataGridViewForm1H_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb1.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells["SH_NO"].Value.ToString();
            this.tb2.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells["SH_NAME"].Value.ToString();
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
        #endregion
        #region Tool 1 -> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtThem+"";

            tb1.ReadOnly = false;
            tb2.ReadOnly = false;

            this.tb1.Text = "";
            this.tb2.Text = "";


            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btok.Show();
            btdong.Show();

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

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btok.Show();
            btdong.Show();
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

            tb1.ReadOnly = true;
            tb2.ReadOnly = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btok.Show();
            btdong.Show();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            bt.Text = "COPY";
            
            tb1.ReadOnly = false;
            tb2.Enabled = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btok.Show();
            btdong.Show();
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
        #region Change language
        //txtThongBao
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        private void adddata()
        {
            if (string.IsNullOrEmpty(tb1.Text))
            {
                MessageBox.Show("Bạn nhập sai dữ liệu, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (conn.checkExists("SELECT 1 FROM SHOUSE WHERE SH_NO = '" + tb1.Text + "'") == true)
            {
                MessageBox.Show("Mã này đã tồn tại!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string st1 = "insert into dbo.SHOUSE(SH_NO, SH_NAME) values(@SH_NO, @SH_NAME) SELECT '" + tb1.Text + "','" + tb2.Text + "'";
                bool a = conn.exedata(st1);
            }
            LoadData();
            hienthi();
            loadfisrt();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                checkNofication();
                if (f2ToolStripMenuItem.Checked == true)
                {
                    adddata();
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    string Makho = tb1.Text;
                    if (Makho == "")
                    {
                        MessageBox.Show("" + txtNodata + "");
                        return;
                    }
                    string sql = "delete from SHOUSE where SH_NO ='" + Makho + "'";
                    bool a = conn.exedata(sql);
                    LoadData();
                    hienthi();
                    loadfisrt();
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    string st1 = "update dbo.SHOUSE set SH_NO = '" + tb1.Text + "', SH_NAME = '" + tb2.Text + "' where SH_NO = '" + tb1.Text + "'";
                    bool a = conn.exedata(st1);

                    LoadData();
                    hienthi();
                    loadfisrt();
                }
                else if (f6ToolStripMenuItem.Checked == true)
                {
                    adddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            loadfisrt();
            LoadData();
            hienthi();
            
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        private void tb1_KeyDown_1(object sender, KeyEventArgs e)
        {
            tab(tb2, tb1, sender, e);
        }
        private void tb2_KeyDown_1(object sender, KeyEventArgs e)
        {
            tab(tb2, tb1, sender, e);
        }
    }
}
