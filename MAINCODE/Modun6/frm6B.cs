using PURCHASE.MAINCODE;
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

namespace PURCHASE
{
    public partial class Form6B : Form
    {
        DataProvider conn = new DataProvider();
        public Form6B()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.CheckLanguage(this);
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb2.Enabled = false;
            tb3.Enabled = false;
            tb4.Enabled = false;
            Check_Text(tb1.Text);
        }
        public void Check_Text(string s)
        {
            string SQL = "select USER_ID, NAME from USRH Where USER_ID ='" + s + "' ";
            DataTable dt = conn.readdata(SQL);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (s.ToString() == dr["USER_ID"].ToString())
                    {
                        tb2.Enabled = true;
                        tb2.Text = dr["NAME"].ToString();
                        tb3.Enabled = true;
                        tb4.Enabled = true;
                        break;
                    }
                    else
                    {
                        DialogResult dlr = MessageBox.Show("Tài Khoản Này Không Tồn Tại!, Vui lòng nhập lại.. ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (dlr == DialogResult.OK)
                        {
                            tb1.Clear();
                            tb1.Focus();
                            tb2.Text = "";
                            break;

                        }
                    }
                }
            }
            catch
            {
               
            }
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb1.Text == "")
                {
                    MessageBox.Show("Bạn Chưa Nhập Dữ Liệu!", "Thông Báo", MessageBoxButtons.OK);
                    tb1.Focus();
                }
                else
                {
                    Check_Text(tb1.Text);
                }
            }
        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {

        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up();
        }
        void up()
        {
            string ID_USER = conn.getID(tb1.Text.Trim(), tb3.Text.Trim());
            if (ID_USER != "")
            {
                string st1 = "update dbo.USRH set PAS_WORD = '" + tb4.Text + "' where USER_ID = '" + tb1.Text + "'";
                bool kq = conn.exedata(st1);
                Load_data();
            }
            else
            {
                MessageBox.Show("Mật Khẩu Cũ Chưa Chính Xác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb3.Text = "";
                tb4.Text = "";
                tb3.Focus();
            }
        }
        public void Load_data()
        {
            tb1.Enabled = true;
            tb2.Enabled = false;
            tb3.Enabled = false;
            tb4.Enabled = false;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";

        }

        private void Form6B_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            Load_data();
            loadinfo();
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
    }
}
