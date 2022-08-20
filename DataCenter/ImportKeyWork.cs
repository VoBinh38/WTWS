using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class ImportKeyWork : Form
    {
        DataProvider conn = new DataProvider();
        public ImportKeyWork()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        bool checkAdd = false;
        bool checkEdit = false;
        bool checkDelelte = false;
        private void ImportKeyWork_Load(object sender, EventArgs e)
        {
            loadData();
            btnOke.Hide();
            btnHuy.Hide();

           
        }
        private void loadData()
        {
            string sql = "SELECT * FROM Choose_Language ORDER BY ID ASC";
            DataTable dt = new DataTable();
            dt = conn.readdata(sql);
            if (dt.Rows.Count > 0)
            {
                BindingSource binding = new BindingSource();
                binding.DataSource = dt;
                DGV1.DataSource = binding;
                conn.DGV(DGV1);
            }
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnSua.Enabled = true;
            btnReload.Enabled = true;
            btnXoaTrang.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            int CurrentIndex = DGV1.CurrentCell.RowIndex;
            txtTuNgu.Text = DGV1.Rows[CurrentIndex].Cells[1].Value.ToString();
            txtTiengVN.Text = DGV1.Rows[CurrentIndex].Cells[2].Value.ToString();
            txtTiengAnh.Text = DGV1.Rows[CurrentIndex].Cells[3].Value.ToString();
            txtTiengTrung.Text = DGV1.Rows[CurrentIndex].Cells[4].Value.ToString();
            txtTypeControl.Text = DGV1.Rows[CurrentIndex].Cells[5].Value.ToString();
        }

        private void btnXoaTrang_MouseClick(object sender, MouseEventArgs e)
        {
            ResertTextbox();
        }
        private void ResertTextbox()
        {
            txtTuNgu.Text = "";
            txtTiengVN.Text = "";
            txtTiengAnh.Text = "";
            txtTiengTrung.Text = "";
            txtTypeControl.Text = "";
        }

        private void btnThoat_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            this.Hide();
        }
        private void btnThem_MouseClick(object sender, MouseEventArgs e)
        {
            checkAdd = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnSua.Enabled = false;
            btnReload.Enabled = false;
            btnXoaTrang.Enabled = false;
            btnXoa.Enabled = false;

            btnOke.Show();
            btnHuy.Show();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            checkDelelte = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnSua.Enabled = false;
            btnReload.Enabled = false;
            btnXoaTrang.Enabled = false;
            btnXoa.Enabled = false;

            btnOke.Show();
            btnHuy.Show();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            checkEdit = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnSua.Enabled = false;
            btnReload.Enabled = false;
            btnXoaTrang.Enabled = false;
            btnXoa.Enabled = false;

            btnOke.Show();
            btnHuy.Show();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            if (checkAdd == true)
            {
                string a = txtTuNgu.Text.Trim();
                string b = txtTiengVN.Text.Trim();
                string c = txtTiengAnh.Text.Trim();
                string d = txtTiengTrung.Text.Trim();
                string f = txtTypeControl.Text.Trim();
                
                if (conn.checkExists("SELECT TOP 1 KeyWork FROM Choose_Language WHERE KeyWork = '"+ a + "'") == true)
                {
                    MessageBox.Show("Đã có mã từ này rồi!");
                }    
                else
                {
                    string sql = "INSERT INTO dbo.Choose_Language(KeyWork,LanguageVN,LanguageEN,LanguageCH,Position) " +
                   "SELECT N'" + a + "',N'" + b + "',N'" + c + "',N'" + d + "',N'" + f + "'";
                    bool check = conn.exedata(sql);
                    DGV1.Refresh();
                    btnOke.Hide();
                    btnHuy.Hide();
                }    
            }
            else if (checkDelelte == true)
            {
                string a = txtTuNgu.Text.Trim();
                string b = txtTiengVN.Text.Trim();
                string c = txtTiengAnh.Text.Trim();
                string d = txtTiengTrung.Text.Trim();
                string f = txtTypeControl.Text.Trim();
                string sql = "DELETE FROM Choose_Language WHERE KeyWork = '" + a + "' AND Position = '" + f + "'";
                bool check = conn.exedata(sql);
                DGV1.Refresh();
                btnOke.Hide();
                btnHuy.Hide();
            }
            else if (checkEdit == true)
            {
                string a = txtTuNgu.Text.Trim();
                string b = txtTiengVN.Text.Trim();
                string c = txtTiengAnh.Text.Trim();
                string d = txtTiengTrung.Text.Trim();
                string f = txtTypeControl.Text.Trim();
                string sql = "UPDATE Choose_Language SET KeyWork = N'" + a + "',LanguageVN = N'" + b + "',LanguageEN = N'" + c + "',LanguageCH = N'" + d + "',Position = N'" + f + "' FROM Choose_Language WHERE KeyWork = '" + a + "' AND Position = '" + f + "'";
                bool check = conn.exedata(sql);
                DGV1.Refresh();
                btnOke.Hide();
                btnHuy.Hide();
            }
            loadData();
            ResertTextbox();
        }

        private void txtTuNgu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtTiengVN.Focus();
            }    
            
        }

        private void txtTiengVN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtTiengAnh.Focus();
            }
        }

        private void txtTiengAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtTiengTrung.Focus();
            }
        }

        private void txtTiengTrung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtTypeControl.Focus();
            }
        }

        private void txtTypeControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtTuNgu.Focus();
            }
        }
    }
}
