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
    public partial class Form1E : Form
    {
        DataProvider conn = new DataProvider();
        public Form1E()
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
        #region Load
        private void Form1ecosodanhmucsanphamkh_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            checkLanguageDataGribView();
            getInfo();
            LoadData();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            btok.Hide();
            btdong.Hide();

            conn.DGV(dataGridViewkhothanhpham);
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        public void checkLanguageDataGribView()
        {
            conn.choose_languege();

            if (DataProvider.LG.rdEnglish == true)
            {
                dataGridViewkhothanhpham.Columns[0].HeaderText = "Category Code";
                dataGridViewkhothanhpham.Columns[1].HeaderText = "Category Name";
            }
            if (DataProvider.LG.rdChina == true)
            {
                dataGridViewkhothanhpham.Columns[0].HeaderText = "類別代碼";
                dataGridViewkhothanhpham.Columns[1].HeaderText = "名單";
            }
        }
        public void LoadData()
        {
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select K_NO, K_NAME from KIND";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewkhothanhpham.DataSource = bindingsource;
        }

        public void hienthi()
        {
            tb1.Text = dataGridViewkhothanhpham.Rows[0].Cells["K_NO"].Value.ToString();
            tb2.Text = dataGridViewkhothanhpham.Rows[0].Cells["K_NAME"].Value.ToString();
        }
        public void hienthi2()
        {
            this.tb1.Text = dataGridViewkhothanhpham.Rows[dataGridViewkhothanhpham.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewkhothanhpham.Rows[dataGridViewkhothanhpham.CurrentRow.Index].Cells[1].Value.ToString();
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
        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewkhothanhpham.ClearSelection();
            dataGridViewkhothanhpham.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewkhothanhpham.DataSource = bindingsource;
            bindingsource.MoveFirst();

            hienthi2();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewkhothanhpham.CurrentRow.Index;
                if (dataGridViewkhothanhpham.Rows.Count > IndexNow)
                {
                    dataGridViewkhothanhpham.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewkhothanhpham.DataSource = bindingsource;
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


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewkhothanhpham.CurrentRow.Index;
                if (dataGridViewkhothanhpham.Rows.Count > IndexNow)
                {
                    dataGridViewkhothanhpham.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewkhothanhpham.DataSource = bindingsource;
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridViewkhothanhpham.ClearSelection();
            int so = dataGridViewkhothanhpham.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewkhothanhpham.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewkhothanhpham.DataSource = bindingsource;
            bindingsource.MoveLast();

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        #endregion
        #region Changuage Language
        //txtThongBao
        string txtThongBao = "";
        string txtText = "";
        string txtText1 = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        string txtText5 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Số Sản Phẩm Với 16 Ký Tự";
                txtText2 = "Mã Danh Mục Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập mã hạng mục";
                txtText4 = "Bạn chưa nhập tên phân loại";
                txtText5 = "Mã Danh Mục Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Bạn không thể sửa mã danh mục";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Danh Mục Với 10 Ký Tự";
                txtText2 = "Mã Danh Mục Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập mã hạng mục";
                txtText4 = "Bạn chưa nhập tên phân loại";
                txtText5 = "Mã Danh Mục Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "You cannot edit the category code";
                txtThongBao = "Nofication";
                txtText1 = "You need to change the 10 character category code";
                txtText2 = "Catalog Code Exists";
                txtText3 = "You have not entered the item code";
                txtText4 = "You have not entered a category name";
                txtText5 = "Category Code Exists \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "您不能編輯類別代碼";
                txtThongBao = "通知";
                txtText1 = "您需要更改 10 個字符的類別代碼";
                txtText2 = "存在目錄代碼";
                txtText3 = "您尚未輸入商品代碼";
                txtText4 = "您尚未輸入類別名稱";
                txtText5 = "類別代碼存在\n 請單擊確定，[關閉] 並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        #region tool 1-> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";
            tb1.Enabled = true;
            tb2.Enabled = true;
            this.tb1.Text = "";
            this.tb2.Text = "";

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
            btok.Show();
            btdong.Show();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtXoa + "";
            tb1.Enabled = true;
            tb2.Enabled = true;

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
            btok.Show();
            btdong.Show();


        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtSua + "";
            tb1.Enabled = true;
            tb2.Enabled = true;

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

            btok.Show();
            btdong.Show();
            DialogResult dr = MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                tb1.Enabled = false;
            }
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;
            MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bt.Text = "COPY";
            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }

            tb1.Enabled = true;
            tb2.Enabled = true;

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

            btok.Show();
            btdong.Show();

        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1E_F7 fr = new Form1E_F7();
            fr.ShowDialog();

        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        #endregion

        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select K_NO from KIND";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["K_NO"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText2 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }

                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.KIND(K_NO, K_NAME) values(@K_NO, @K_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                cm.Parameters.AddWithValue("@K_NAME", tb2.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
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
                    cm.CommandText = "delete from KIND where K_NO ='" + madanhmuc + "'";
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
                    f8ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
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
            else if (f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.KIND set K_NO = @K_NO, K_NAME = @K_NAME where K_NO = @K_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                cm.Parameters.AddWithValue("@K_NAME", tb2.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
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
                    f8ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
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

                    //mở khóa
                    tb1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select K_NO from KIND";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["K_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText5 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb1.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.KIND(K_NO, K_NAME) values(@K_NO, @K_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                cm.Parameters.AddWithValue("@K_NAME", tb2.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
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
                    f8ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
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
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            LoadData();
            hienthi();

            tb1.Enabled = false;
            tb2.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            btok.Hide();
            btdong.Hide();
            bt.Text = "NÚT DUYỆT";
        }



        private void dataGridViewkhothanhpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridViewkhothanhpham.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox

                this.tb1.Text = row.Cells[0].Value.ToString();
                this.tb2.Text = row.Cells[1].Value.ToString();
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
