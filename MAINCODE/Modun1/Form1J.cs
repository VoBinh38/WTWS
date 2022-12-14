using PURCHASE.MAINCODE;
using PURCHASE.MAINCODE.Search;
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
using LibraryCalender;
using PURCHASE.MAINCODE.Modun1.Print;

namespace PURCHASE
{
    public partial class Form1J : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        BindingSource bindingSource;
        string P_NAME2;
        public Form1J()
        {
            this.ShowInTaskbar = false;
            con.CheckLanguage(this);
            InitializeComponent();
        }

        private void Form1J_Load(object sender, EventArgs e)
        {
            con.CheckLoad(menuStrip1);
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            getInfo();
            btnOK.Hide();
            btnClose.Hide();

            LoadData();
            LoadTexBox();
            f10ToolStripMenuItem.Enabled = false;
        }

        private void LoadData()
        {
            string sql = "SELECT QDATE,Q.C_NO,V.C_NAME,Q.K_NO,K.K_NAME,Q.K_NO_O,K1.K_NAME AS K_NAME1,Q.DEPT,Q.P_NO," +
                        " Q.P_NAME,Q.P_NAME1,Q.P_NAME3,Q.UNIT,Q.BUNIT,Q.TRANS,Q.P_WEG,Q.PRICE,Q.MEMO1,Q.PRICE4,Q.QTY01,Q.PRICE5,Q.M_TRAN,Q.W_CHECK,Q.PRICE8,Q.PRICE3,Q.DKIND" +
                        " FROM QUVHC Q" +
                        " LEFT JOIN dbo.VENDC V ON V.C_NO = Q.C_NO" +
                        " LEFT JOIN dbo.KIND1C K ON K.K_NO = Q.K_NO" +
                        " LEFT JOIN dbo.KIND1C K1 ON K1.K_NO = Q.K_NO_O" +
                        " Where 1=1 " + SearchQUVHC.wheres +
                        " ORDER BY Q.QDATE DESC, Q.P_NO DESC";
            bindingSource = new BindingSource();
            bindingSource.DataSource = con.readdata(sql);
        }

        private void LoadTexBox()
        {
            this.txtQDATE.Text = currentRow["QDATE"].ToString();
            this.txtC_NO.Text = currentRow["C_NO"].ToString();
            this.txtC_NAME.Text = currentRow["C_NAME"].ToString();
            this.txtK_NO.Text = currentRow["K_NO"].ToString();
            this.txtK_NAME.Text = currentRow["K_NAME"].ToString();
            this.txtK_NO_O.Text = currentRow["K_NO_O"].ToString();
            this.txtK_NAME1.Text = currentRow["K_NAME1"].ToString();
            this.txtDEPT.Text = currentRow["DEPT"].ToString();
            this.txtP_NO.Text = currentRow["P_NO"].ToString();
            this.txtP_NAME.Text = currentRow["P_NAME"].ToString();
            this.txtP_NAME1.Text = currentRow["P_NAME1"].ToString();
            this.txtP_NAME3.Text = currentRow["P_NAME3"].ToString();
            this.txtUNIT.Text = currentRow["UNIT"].ToString();
            this.txtBUNIT.Text = currentRow["BUNIT"].ToString();
            this.txtTRANS.Text = currentRow["TRANS"].ToString();
            this.txtP_WEG.Text = currentRow["P_WEG"].ToString();
            this.txtPRICE.Text = con.ConvertNumber(currentRow["PRICE"].ToString());
            this.txtMEMO1.Text = currentRow["MEMO1"].ToString();
            this.txtPRICE4.Text = currentRow["PRICE4"].ToString();
            this.txtQTY01.Text = currentRow["QTY01"].ToString();
            this.txtPRICE5.Text = currentRow["PRICE5"].ToString();
            this.txtW_CHECK.Text = currentRow["W_CHECK"].ToString();
            this.txtPRICE8.Text = currentRow["PRICE8"].ToString();
            this.txtPRICE3.Text = currentRow["PRICE3"].ToString();
            this.txtDKIND.Text = currentRow["DKIND"].ToString();
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
            btndateNow.Text = con.getDateNow(); // get DateNow
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        public void Loadcb(string M_NO)
        {
            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1";
            DataTable data = con.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";

            cbM_TRAN.SelectedValue = currentRow["M_TRAN"].ToString();
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

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
            LoadTexBox();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            LoadTexBox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
            LoadTexBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
            LoadTexBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt.Text = "Thêm";
            txtQDATE.Text = DateTime.Now.ToString("yyyyMMdd");
            txtW_CHECK.Text = "N";
            f2ToolStripMenuItem.Checked = true;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;


            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnClose.Show();
            btnOK.Show();

            this.txtQDATE.Text = "";
            this.txtC_NO.Text = "";
            this.txtC_NAME.Text = "";
            this.txtK_NO.Text = "";
            this.txtK_NAME.Text = "";
            this.txtK_NO_O.Text = "";
            this.txtK_NAME1.Text = "";
            this.txtDEPT.Text = "";
            this.txtP_NO.Text = "";
            this.txtP_NAME.Text = "";
            this.txtP_NAME1.Text = "";
            this.txtP_NAME3.Text = "";
            this.txtUNIT.Text = "";
            this.txtBUNIT.Text = "";
            this.txtTRANS.Text = "";
            this.txtP_WEG.Text = "";
            this.txtPRICE.Text = "";
            this.txtMEMO1.Text = "";
            this.txtPRICE4.Text = "";
            this.txtQTY01.Text = "";
            this.txtPRICE5.Text = "";
            this.txtW_CHECK.Text = "";
            this.txtPRICE8.Text = "";
            this.txtPRICE3.Text = "";
            this.txtDKIND.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bt.Text = "NÚT DUYỆT";
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btnClose.Hide();
            btnOK.Hide();

            txtQDATE.Enabled = true;
            txtC_NO.Enabled = true;
            txtC_NAME.Enabled = true;
            txtK_NO.Enabled = true;
            txtK_NAME.Enabled = true;
            txtP_NO.Enabled = true;
            txtP_NAME.Enabled = true;

            LoadData();
            LoadTexBox();
        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                SearchVENDC1B frm = new SearchVENDC1B();
                frm.ShowDialog();
                txtC_NO.Text = SearchVENDC1B.getDataTable.C_NO;
                txtC_NAME.Text = SearchVENDC1B.getDataTable.C_NAME;
            }
        }

        private void txtK_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSeachKIND1C frm = new FormSeachKIND1C();
                frm.ShowDialog();
                txtK_NO.Text = FormSeachKIND1C.Form1D_GUI.K1;
                txtK_NAME.Text = FormSeachKIND1C.Form1D_GUI.K2;
            }
        }

        private void txtK_NO_O_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSeachKIND1C frm = new FormSeachKIND1C();
                frm.ShowDialog();
                txtK_NO_O.Text = FormSeachKIND1C.Form1D_GUI.K1;
                txtK_NAME1.Text = FormSeachKIND1C.Form1D_GUI.K2;
            }
        }

        private void txtUNIT_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txtMEMO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmSearchMemo frm = new frmSearchMemo();
            frm.ShowDialog();
            txtMEMO1.Text = frmSearchMemo.getMeMo.M_NAME;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true)
            {
                AddData();
            }
            if(f3ToolStripMenuItem.Checked ==true)
            {
                DeleteData();
            }
            if (f4ToolStripMenuItem.Checked == true)
            {
                UpData();
            }
            if(f6ToolStripMenuItem.Checked == true)
            {
                AddData();
            }
            if (f9ToolStripMenuItem.Checked == true)
            {
                UpDataCheck();
            }
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            LoadData();
            LoadTexBox();
        }

        private void UpDataCheck()
        {
            string sql = "UPDATE dbo.QUVHC SET W_CHECK = '"+txtW_CHECK.Text+"' WHERE QDATE = N'"+txtQDATE.Text.Replace("/","")+"' AND K_NO = N'"+txtK_NO.Text+"' AND P_NO = N'"+txtP_NO.Text+"'";
            con.exedata(sql);
        }

        private void UpData()
        {
            string sql = "UPDATE QUVHC SET QDATE=N'"+txtQDATE.Text.Replace("/","")+"',K_NO=N'"+txtK_NO.Text+ "',P_NO=N'" + txtP_NO.Text + "',P_NAME=N'" + txtP_NAME.Text + "',P_NAME1=N'" + txtP_NAME1.Text + "',P_NAME2=N'" +P_NAME2 + "'," +
                "P_NAME3 = N'" + txtP_NAME3.Text + "',UNIT = N'" + txtUNIT.Text + "',BUNIT = N'" + txtBUNIT.Text + "',TRANS = N'" + txtTRANS.Text + "',C_NO = N'" + txtC_NO.Text + "',PRICE = N'" + txtPRICE.Text + "',QDATE1 = N''," +
                "QDATE2 = N'',QDATE3 = N'',QDATE4 = N'',QDATE5 = N'',QDATE6 = N'',QDATE7 = N''," +
                "QDATE8 = N'',QDATE9 = N'',MEMO1 = N'"+txtMEMO1.Text+ "',MEMO2 = N'',PRICE1 = 0,PRICE2 = 0," +
                "PRICE3 = "+txtPRICE3.Text+ ",PRICE4 = " + txtPRICE4.Text + ",PRICE5 = " + txtPRICE5.Text + ",PRICE6 = 0,PRICE7 = 0,PRICE8 = " + txtPRICE8.Text + "," +
                "PRICE9 = 0,P_WEG = "+txtP_WEG.Text+",OUTDATE = N'',USR_NAME = N'"+lbUserName.Text+"',QTY01 = "+txtQTY01.Text+",DKIND = N'"+txtDKIND.Text+"'," +
                "W_CHECK = N'"+txtW_CHECK.Text+"',K_NO_O = N'"+txtK_NO_O.Text+"',DEPT = N'"+txtDEPT.Text+"',M_TRAN = N'"+cbM_TRAN.SelectedValue.ToString()+"'" +
                "WHERE QDATE = N'"+txtQDATE.Text.Replace("/","")+"' AND K_NO = N'"+txtK_NO.Text+"' AND P_NO = N'"+txtP_NO.Text+"'";
            con.exedata(sql);
        }

        private void DeleteData()
        {
            string sql = "DELETE QUVHC WHERE QDATE=N'" + txtQDATE.Text.Replace("/", "").ToString() + "' AND K_NO=N'" + txtK_NO.Text + "' AND P_NO=N'" + txtP_NO.Text + "'";
            con.exedata(sql);
        }

        private void AddData()
        {
            string sql = "INSERT INTO QUVHC (QDATE,K_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,UNIT,BUNIT,TRANS," +
                        " C_NO,PRICE,QDATE1,QDATE2,QDATE3,QDATE4,QDATE5,QDATE6,QDATE7,QDATE8,QDATE9,MEMO1,MEMO2," +
                        " PRICE1,PRICE2,PRICE3,PRICE4,PRICE5,PRICE6,PRICE7,PRICE8,PRICE9,P_WEG,OUTDATE,USR_NAME," +
                        " QTY01,DKIND,W_CHECK,K_NO_O,DEPT,CUSR_NAME,M_TRAN) " +
                        " VALUES(N'" + txtQDATE.Text.Replace("/", "") + "', N'" + txtK_NO.Text + "', N'" + txtP_NO.Text + "', N'" + txtP_NAME.Text + "', N'" + txtP_NAME1.Text + "'," +
                        " N'" + P_NAME2 + "', N'" + txtP_NAME3.Text + "', N'" + txtUNIT.Text + "', N'" + txtUNIT.Text + "', " + txtTRANS.Text + ", N'" + txtC_NO.Text + "'," +
                        " " + float.Parse(txtPRICE.Text) + ", N'', N'', N'', N'', N'', N'', N'', N'', N'', N'" + txtMEMO1.Text + "', N'', 0, 0, " +
                        " " + float.Parse(txtPRICE3.Text) + ", " + float.Parse(txtPRICE4.Text) + ", " + float.Parse(txtPRICE5.Text) + ", 0, 0, " + float.Parse(txtPRICE8.Text) + ", " +
                        " 0, " + txtP_WEG.Text + ", N'', N'" + lbUserName.Text + "', " + txtQTY01.Text + ", N'" + txtDKIND.Text + "', N'" + txtW_CHECK.Text + "', N'" + txtK_NO_O.Text + "', N'" + txtDEPT.Text + "', N'', N'" + cbM_TRAN.SelectedValue.ToString() + "')";
            con.exedata(sql);
        }

        private void txtP_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                SearchPROD1C_Select_OneItem frm = new SearchPROD1C_Select_OneItem();
                SearchPROD1C_Select_OneItem.wheres = " AND C_NO = N'"+txtC_NO.Text+"' AND K_NO = N'"+txtK_NO.Text+"'";
                frm.ShowDialog();
                txtP_NO.Text = SearchPROD1C_Select_OneItem.GetItem.P_NO;
                string sql1 = "SELECT * FROM PROD1C WHERE P_NO ='"+ SearchPROD1C_Select_OneItem.GetItem.P_NO + "'";
                DataTable dtnew = new DataTable();
                dtnew = con.readdata(sql1);
                txtP_NAME.Text = dtnew.Rows[0]["P_NAME"].ToString();
                txtP_NAME1.Text = dtnew.Rows[0]["P_NAME1"].ToString();
                txtP_NAME3.Text = dtnew.Rows[0]["P_NAME3"].ToString();
                P_NAME2 = dtnew.Rows[0]["P_NAME2"].ToString();
                txtUNIT.Text = dtnew.Rows[0]["UNIT"].ToString();
                txtBUNIT.Text = dtnew.Rows[0]["BUNIT"].ToString();
                txtTRANS.Text = dtnew.Rows[0]["TRANS"].ToString();
                txtPRICE.Text = dtnew.Rows[0]["PRICE"].ToString();

            }
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt.Text = "Sửa";
            txtQDATE.Enabled = false;
            txtC_NO.Enabled = false;
            txtC_NAME.Enabled = false;
            txtK_NO.Enabled = false;
            txtK_NAME.Enabled = false;
            txtP_NO.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnClose.Show();
            btnOK.Show();
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchQUVHC frm = new SearchQUVHC();
            frm.ShowDialog();
            LoadData();
            bindingSource.Position = SearchQUVHC.GetItem.index;
            LoadTexBox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void txtK_NO_TextChanged(object sender, EventArgs e)
        {

        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true;

            bt.Text = "Xoá";
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btnClose.Show();
            btnOK.Show();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void txtQDATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtQDATE.Text = FromCalender.getDate.ToString("yyyyMMdd") ;
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1JF7 frm = new Form1JF7();
            frm.ShowDialog();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;
            bt.Text = "Sao chép";
            txtQDATE.Enabled = false;
            txtC_NO.Enabled = false;
            txtC_NAME.Enabled = false;
            txtK_NO.Enabled = false;
            txtK_NAME.Enabled = false;
            txtP_NO.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnClose.Show();
            btnOK.Show();

            txtP_NO.Text = "";
            txtPRICE.Text = "0";
            txtPRICE4.Text = "";
            txtPRICE5.Text = "";
            txtPRICE8.Text = "";
            txtPRICE3.Text = "";
            txtQTY01.Text = "";
            txtDKIND.Text = "";

            txtW_CHECK.Text = "N";
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClose.Show();
            btnOK.Show();
            txtW_CHECK.Text = "Y";
        }

        private void txtW_CHECK_TextChanged(object sender, EventArgs e)
        {
            if(txtW_CHECK.Text == "N")
            {
                f9ToolStripMenuItem.Enabled = true;
            }
            else
            {
                f9ToolStripMenuItem.Enabled = false;
            }
        }
    }
}