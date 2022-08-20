using LibraryCalender;
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
using static PURCHASE.Form1SF5;

namespace PURCHASE
{
    public partial class Form1S : Form
    {
        DataProvider conn = new DataProvider();
        DataTable table = new DataTable();
        BindingSource source = new BindingSource();
        public Form1S()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.CheckLanguage(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }

        private void Form1S_Load(object sender, EventArgs e)
        {
            loadfisrt();
            LoadData();
        }
        public class Data1S
        {
            public static DataTable Datashare;
        }
        private void LoadData()
        {
            if (f5ToolStripMenuItem.Checked == false)
            {
                string sql = "select * FROM STOH ORDER BY WS_DATE DESC,WS_NO DESC";
                table = conn.readdata(sql);
                source.DataSource = table;
                ShowDataText();
            }
            else
            {
                table = ShareData1SF5.table;
                source.DataSource = table;
                source.Position = ShareData1SF5.index;
                ShowDataText();
            }    
            Data1S.Datashare = table;
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
        private void ShowDataText()
        {
            textBox1.Text = conn.formatstr2(currenRow["WS_DATE"].ToString());
            textBox2.Text = currenRow["WS_NO"].ToString();
            textBox3.Text = currenRow["S_NO"].ToString();
            textBox4.Text = currenRow["S_NAME"].ToString();
            textBox5.Text = currenRow["OVER0"].ToString();
            textBox6.Text = currenRow["K_NO_S"].ToString();
            textBox7.Text = currenRow["K_NAME_S"].ToString();
            textBox8.Text = currenRow["SH_NO"].ToString();
            textBox9.Text = currenRow["SH_NAME"].ToString();
            textBox10.Text = currenRow["MEMO"].ToString();
        }
        private void LoadDataGribView()
        {
            string sql = "select * FROM STOB WHERE WS_NO = '" + textBox2.Text + "'";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            dataGridView1.DataSource = data;
            conn.DGV(dataGridView1);
        }
        private void loadfisrt()
        {
            getInfo();
            conn.CheckLoad(menuStrip1);
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;

            button2.Hide();
            button3.Hide();
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
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(textBox1, textBox2, sender, e);
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(textBox1, textBox3, sender, e);
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox2, textBox4, sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox3, textBox5, sender, e);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox4, textBox6, sender, e);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox5, textBox7, sender, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox6, textBox8, sender, e);
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox7, textBox9, sender, e);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox8, textBox10, sender, e);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox9, textBox1, sender, e);
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            textBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btdau_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
            ShowDataText();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void bttruoc_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
            ShowDataText();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btsau_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowDataText();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btketthuc_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowDataText();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LoadDataGribView();
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5ToolStripMenuItem.Checked = true;
            Form1SF5 form1SF = new Form1SF5();
            form1SF.ShowDialog();
            LoadData();
        }
    }
}
