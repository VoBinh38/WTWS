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
    public partial class Form1F : Form
    {
        DataProvider conn = new DataProvider();
        public Form1F()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        #region Load data , button
        private void Form1Fcosodanhmucsanphamdoanhnghiep_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            getInfo();
            LoadData();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            btok.Hide();
            btdong.Hide();
            bt.Text = "NÚT DUYỆT";

            conn.DGV(dataGridViewForm1F);

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
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select K_NO, K_NAME, PACK_NO, CUNO from KIND1C";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1F.DataSource = bindingsource;
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1F.Rows[0].Cells["K_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1F.Rows[0].Cells["K_NAME"].Value.ToString();
            tb3.Text = dataGridViewForm1F.Rows[0].Cells["PACK_NO"].Value.ToString();
            tb4.Text = dataGridViewForm1F.Rows[0].Cells["CUNO"].Value.ToString();
        }
        public void hienthi2()
        {
            this.tb1.Text = dataGridViewForm1F.Rows[dataGridViewForm1F.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1F.Rows[dataGridViewForm1F.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewForm1F.Rows[dataGridViewForm1F.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataGridViewForm1F.Rows[dataGridViewForm1F.CurrentRow.Index].Cells[3].Value.ToString();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1F.ClearSelection();
            dataGridViewForm1F.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1F.DataSource = bindingsource;
            bindingsource.MoveFirst();

            hienthi2();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewForm1F.CurrentRow.Index;
                if (dataGridViewForm1F.Rows.Count > IndexNow)
                {
                    dataGridViewForm1F.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1F.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }

            hienthi2();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewForm1F.CurrentRow.Index;
                if (dataGridViewForm1F.Rows.Count > IndexNow)
                {
                    dataGridViewForm1F.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1F.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btketthuc_Click(object sender, EventArgs e)
        {
            dataGridViewForm1F.ClearSelection();
            int so = dataGridViewForm1F.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1F.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1F.DataSource = bindingsource;
            bindingsource.MoveLast();

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        #endregion
        #region Change Language
        //txtThongBao
        string txtThongBao = "";
        string txtText = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Mã Danh Mục Đã Tồn Tại";
                txtThongBao = "Thông Báo";
                txtText2 = "Bạn chưa nhập mã hạng mục";
                txtText3 = "Bạn chưa nhập tên phân loại";
                txtText4 = "Mã Số Danh Mục Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Mã Danh Mục Đã Tồn Tại";
                txtThongBao = "Thông Báo";
                txtText2 = "Bạn chưa nhập mã hạng mục";
                txtText3 = "Bạn chưa nhập tên phân loại";
                txtText4 = "Mã Số Danh Mục Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "Catalog Code Exists";
                txtThongBao = "Nofication";
                txtText2 = "You have not entered the item code";
                txtText3 = "You have not entered a category name";
                txtText4 = "Category Code Exists \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
                txtText = "存在目錄代碼";
                txtThongBao = "通知";
                txtText2 = "您尚未輸入商品代碼";
                txtText3 = "您尚未輸入類別名稱";
                txtText4 = "類別代碼存在\n 請單擊確定，[關閉] 並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }

        }
        #endregion

        #region tool 1 - > 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtThem+"";

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;

            this.tb1.Text = "";
            this.tb2.Text = "";
            this.tb3.Text = "";
            this.tb4.Text = "";

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btok.Show();
            btdong.Show();
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
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btok.Show();
            btdong.Show();

        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = ""+txtSua+"";
            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btok.Show();
            btdong.Show();
            DialogResult dr = MessageBox.Show("Bạn không thể sửa mã danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                tb1.Enabled = false;
            }
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
            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btok.Show();
            btdong.Show();
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1E_F7 frm = new Form1E_F7();
            frm.ShowDialog();
            this.Close();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        #endregion

        private void dataGridViewForm1F_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridViewForm1F.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox

                this.tb1.Text = row.Cells[0].Value.ToString();
                this.tb2.Text = row.Cells[1].Value.ToString();
                this.tb3.Text = row.Cells[2].Value.ToString();
                this.tb4.Text = row.Cells[3].Value.ToString();
            }
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            LoadData();
            hienthi();
            hienthi2();

            tb1.Enabled = false;
            tb2.Enabled = false;
            tb3.Enabled = false;
            tb4.Enabled = false;

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            btok.Hide();
            btdong.Hide();
            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        private void btok_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                checkNofication();
                string a = tb1.Text;
                string SQL = "select K_NO from KIND1C";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["K_NO"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }

                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.KIND1C(K_NO, K_NAME, PACK_NO, CUNO) values(@K_NO, @K_NAME, @PACK_NO, @CUNO)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                cm.Parameters.AddWithValue("@K_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@PACK_NO", tb3.Text);
                cm.Parameters.AddWithValue("@CUNO", tb4.Text);
                if (tb1.Text == string.Empty)
                {

                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }

                try
                {
                    cm.ExecuteNonQuery();
                    con.Close();
                    LoadData();
                    hienthi();
                    hienthi2();

                    tb1.Enabled = false;
                    tb2.Enabled = false;
                    tb3.Enabled = false;
                    tb4.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    btok.Hide();
                    btdong.Hide();
                    bt.Text = "" + txtDuyet + "";


                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string madanhmuc = tb1.Text;
                if (madanhmuc == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from KIND1C where K_NO ='" + madanhmuc + "'";
                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();
                    hienthi2();

                    tb1.Enabled = false;
                    tb2.Enabled = false;
                    tb3.Enabled = false;
                    tb4.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;

                    btok.Hide();
                    btdong.Hide();
                    bt.Text = "" + txtDuyet + "";


                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.KIND1C set K_NO = @K_NO, K_NAME = @K_NAME , PACK_NO = @PACK_NO, CUNO = @CUNO where K_NO = @K_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                cm.Parameters.AddWithValue("@K_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@PACK_NO", tb3.Text);
                cm.Parameters.AddWithValue("@CUNO", tb4.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show(""+txtText2+"");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();
                    hienthi2();

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;

                    btok.Hide();
                    btdong.Hide();
                    bt.Text = ""+txtDuyet+"";

                    f2ToolStripMenuItem.Checked = false; 
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                    //mở khóa
                    tb1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if(f6ToolStripMenuItem.Checked == true)
            {

                string a = tb1.Text;
                string SQL = "select K_NO from KIND1C";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["K_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show(""+txtText4+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb1.Focus();
                        }
                    }
                }
                catch
                {

                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.KIND1C(K_NO, K_NAME, PACK_NO, CUNO) values(@K_NO, @K_NAME, @PACK_NO, @CUNO)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                cm.Parameters.AddWithValue("@K_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@PACK_NO", tb3.Text);
                cm.Parameters.AddWithValue("@CUNO", tb4.Text);
                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show(""+txtText2+"");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show(""+txtText3+"");
                    return;
                }
                try
                {
                    cm.ExecuteNonQuery();
                    con.Close();
                    LoadData();
                    hienthi();
                    hienthi2();

                    tb1.Enabled = false;
                    tb2.Enabled = false;
                    tb3.Enabled = false;
                    tb4.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;

                    btok.Hide();
                    btdong.Hide();
                    bt.Text = ""+txtDuyet+"";


                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
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

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb4, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb3, tb1, sender, e);
        }
    }
}
