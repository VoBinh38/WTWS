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
    public partial class Form8R : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        BindingSource bindingSource;
        public Form8R()
        {
            con.CheckLanguage(this);
            InitializeComponent(); 
            this.DGV1.MouseWheel += new MouseEventHandler(mousewheel);
        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            con.Mousewheelscroll(DGV1, e);
            BindingData(con.RowIndexs);
        }
        public void BindingData(int index)
        {
            if (index == -1)
            {
                index = DGV1.CurrentRow.Index;
            }
            txtDEPT_NO.Text = DGV1.Rows[index].Cells["DEPT_NO"].Value.ToString();
            txtDEPT_NAME.Text = DGV1.Rows[index].Cells["DEPT_NAME"].Value.ToString();
            txtSH_NO.Text = DGV1.Rows[index].Cells["SH_NO"].Value.ToString();
            txtSH_NAME.Text = DGV1.Rows[index].Cells["SH_NAME"].Value.ToString();
        }
        private void Form8R_Load(object sender, EventArgs e)
        {
            getInfo();
            LoadData();
            BindingData(-1);
        }

        private void LoadData()
        {
            string sql = "SELECT DEPT_NO,DEPT_NAME,SH_NAME,SH_NO FROM DEPT";
            bindingSource = new BindingSource();
            bindingSource.DataSource = con.readdata(sql);
            DGV1.DataSource = bindingSource;
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
            lbUserName.Text = con.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
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

        private void btdau_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            DGV1.Rows[0].Selected = true;
            bindingSource.MoveFirst();

            BindingData(-1);

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            BindingData(-1);

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
            BindingData(-1);

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();

            BindingData(-1);

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingData(-1);
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt.Text = "Thêm";
            txtDEPT_NAME.Text = "";
            txtDEPT_NO.Text = "";
            txtSH_NAME.Text = "";
            txtSH_NO.Text = "";

            f2ToolStripMenuItem.Checked = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btnok.Show();
            btnClose.Show();
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt.Text = "Xoá";
            f3ToolStripMenuItem.Checked = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btnok.Show();
            btnClose.Show();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDEPT_NO.Enabled = false;
            bt.Text = "Sửa";
            f4ToolStripMenuItem.Checked = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btnok.Show();
            btnClose.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bt.Text = "NÚT DUYỆT";
            txtDEPT_NO.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            btnok.Hide();
            btnClose.Hide(); 
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true; 

            LoadData();
            BindingData(-1);
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked ==true)
            {
                string sql = "INSERT INTO DEPT (DEPT_NO,DEPT_NAME,SH_NO,SH_NAME,USR_NAME) VALUES (N'"+txtDEPT_NO.Text+"',N'"+txtDEPT_NAME.Text+"',N'"+txtSH_NO.Text+ "',N'" + txtSH_NAME.Text + "',N'"+lbUserName.Text+"')";
                con.exedata(sql);
            }
            if(f3ToolStripMenuItem.Checked == true)
            {
                string sql = "DELETE DEPT WHERE DEPT_NO=N'"+txtDEPT_NO.Text+"'";
                con.exedata(sql);
            }
            if(f4ToolStripMenuItem.Checked == true)
            {
                string sql = "UPDATE DEPT SET DEPT_NO=N'"+txtDEPT_NO.Text+"',DEPT_NAME=N'"+txtDEPT_NAME.Text+"',SH_NO=N'"+txtSH_NO.Text+"',SH_NAME=N'"+txtSH_NAME.Text+"',USR_NAME=N'"+lbUserName.Text+"' WHERE DEPT_NO=N'"+txtDEPT_NO.Text+"'";
                con.exedata(sql);
            }
            if(f6ToolStripMenuItem.Checked ==true)
            {
                string sql = "INSERT INTO DEPT (DEPT_NO,DEPT_NAME,SH_NO,SH_NAME,USR_NAME) VALUES (N'" + txtDEPT_NO.Text + "',N'" + txtDEPT_NAME.Text + "',N'" + txtSH_NO.Text + "',N'" + txtSH_NAME.Text + "',N'" + lbUserName.Text + "')";
                con.exedata(sql);
            }
            btnClose.PerformClick();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt.Text = "Sao chép";
            txtDEPT_NO.Text = "";

            f2ToolStripMenuItem.Checked = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            btnok.Show();
            btnClose.Show();
        }

        private void f12ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbDEPT_NO_Click(object sender, EventArgs e)
        {

        }
    }
}
