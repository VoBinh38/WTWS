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
    public partial class Form1L : Form
    {
        DataProvider conn = new DataProvider();
        public Form1L()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();
        #region Load Data
        private void Form1Lquanlithongtinnhanvien_Load(object sender, EventArgs e)
        {
            LoadFisrt();
            LoadData();
            hienthi();
        }

        private void LoadFisrt()
        {
            getInfo();
            conn.CheckLoad(menuStrip1);
            btok.Hide();
            btdong.Hide();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

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
        }
        public void LoadData()
        {

            string sql = "select S_NO, S_NAME, S_KIND, DEPT_NO, DEPT_NAME from SALE";
            datatable = conn.readdata(sql);
            bindingsource.DataSource = datatable;
            dataGridViewForm1L.DataSource = bindingsource;
            conn.DGV(dataGridViewForm1L);
            this.dataGridViewForm1L.Columns["DEPT_NO"].Visible = false;
            this.dataGridViewForm1L.Columns["DEPT_NAME"].Visible = false;
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells["S_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells["S_NAME"].Value.ToString();
            tb3.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells["S_KIND"].Value.ToString();
            tb4.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells["DEPT_NO"].Value.ToString();
            tb5.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells["DEPT_NAME"].Value.ToString();
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
        #region Change language
        //txtThongBao
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
       

        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        #region Tool 1->12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtThem+"";

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";

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
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtXoa+"";
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
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtSua+"";
            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            // khóa 
            tb1.Enabled = false;
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            bt.Text = "COPY";
            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show(""+txtNodata+"");
                return;
            }
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

            //reset text
            tb1.Text = "";
            tb2.ReadOnly = true;
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
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
            checkNofication();
            if(f2ToolStripMenuItem.Checked == true)
            {
                insertdata();
            }
            else if(f3ToolStripMenuItem.Checked == true) 
            {
                string Manhanvien = tb1.Text;
                if (Manhanvien == "")
                {
                    MessageBox.Show(""+txtNodata+"");
                    return;
                }
                else
                {
                    string sql = "delete from SALE where S_NO ='" + Manhanvien + "'";
                    bool a = conn.exedata(sql);
                    LoadFisrt();
                    LoadData();
                    hienthi();
                }    
            }
            else if(f4ToolStripMenuItem.Checked == true)
            {
               
                string st1 = "update dbo.SALE set S_NO = '"+ tb1.Text + "', S_NAME = '"+ tb2.Text + "', S_KIND = '"+ tb3.Text + "', DEPT_NO = '"+ tb4.Text + "', DEPT_NAME = '"+ tb5.Text + "' where S_NO = '" + tb1.Text + "'";
                bool a = conn.exedata(st1);
                    LoadFisrt();
                    LoadData();
                    hienthi();
                    // mở khóa 
                    tb1.Enabled = true;
            }
            else if(f6ToolStripMenuItem.Checked == true)
            {
                insertdata();
            }
        }
        private void insertdata()
        {
            try
            {
                if (string.IsNullOrEmpty(tb1.Text))
                {
                    MessageBox.Show("Vui lòng không bỏ trống!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (conn.checkExists("SELECT 1 FROM SALE WHERE S_NO = '" + tb1.Text + "'") == true)
                {
                    MessageBox.Show("Mã này đã tồn tại!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string st1 = "insert into dbo.SALE(S_NO, S_NAME, S_KIND, DEPT_NO, DEPT_NAME) " +
                        "SELECT '" + tb1.Text + "','" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "'";
                    bool a = conn.exedata(st1);
                }
                LoadFisrt();
                LoadData();
                hienthi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            LoadFisrt();
            LoadData();
            hienthi();
        }
        private void dataGridViewForm1L_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb1.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[3].Value.ToString();
            this.tb5.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[4].Value.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
           conn.tab(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb3, sender, e);
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
            conn.tab(tb4, tb1, sender, e);
        }
    }
}
