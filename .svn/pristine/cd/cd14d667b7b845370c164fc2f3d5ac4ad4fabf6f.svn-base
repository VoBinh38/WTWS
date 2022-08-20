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
    public partial class Form1G : Form
    {
        DataProvider conn = new DataProvider();
        public Form1G()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();
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
                txtXoa = "Không có dữ liệu";
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
        #region LOAD DATA
        private void Form1Gquanlydlcumtu_Load(object sender, EventArgs e)
        {
            
            LoadData();
            hienthi();
            loadfirts();
           
        }
        private void loadfirts()
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
            string sql = "select M_NO, M_NAME from MEMO";
            datatable = conn.readdata(sql);
            bindingsource.DataSource = datatable;
            dataGridViewForm1G.DataSource = bindingsource;
            conn.DGV(dataGridViewForm1G);
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1G.Rows[dataGridViewForm1G.CurrentRow.Index].Cells["M_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1G.Rows[dataGridViewForm1G.CurrentRow.Index].Cells["M_NAME"].Value.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            bindingsource.MovePrevious();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingsource.MoveNext();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
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
            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

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

            tb1.ReadOnly = true;
            tb2.ReadOnly = true;

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

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

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;
            bt.Text = "COPY";
            string a = tb1.Text;

            tb1.ReadOnly = true;
            tb2.ReadOnly = true;

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridViewForm1G_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridViewForm1G.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox

                this.tb1.Text = row.Cells[0].Value.ToString();
                this.tb2.Text = row.Cells[1].Value.ToString();
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
            else if (conn.checkExists("SELECT 1 FROM MEMO WHERE M_NO = '" + tb1.Text + "'") == true)
            {
                MessageBox.Show("Mã này đã tồn tại!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           else
            {
                string st1 = "insert into dbo.MEMO(M_NO, M_NAME) values(@M_NO, @M_NAME)";
                bool a = conn.exedata(st1);
            }
            LoadData();
            hienthi();
            loadfirts();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            try
            {
                if (f2ToolStripMenuItem.Checked == true)
                {
                    adddata();
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    string tenma = tb1.Text;
                    if (tenma == "")
                    {
                        MessageBox.Show("" + txtNodata + "");
                        return;
                    }
                    else
                    {
                        string st1 = "delete from MEMO where M_NO ='" + tenma + "'";
                        bool a = conn.exedata(st1);
                    }
                    LoadData();
                    hienthi();
                    loadfirts();
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                   
                    string st1 = "update dbo.MEMO set M_NO = '"+ tb1.Text + "', M_NAME = '"+ tb2.Text + "' where M_NO = '"+ tb1.Text + "'";
                    bool a = conn.exedata(st1);
                    LoadData();
                    hienthi();
                    loadfirts();
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
        private void btdong_Click(object sender, EventArgs e)
        {
            loadfirts();
            LoadData();
            hienthi();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb1, sender, e);
        }
    }
}
