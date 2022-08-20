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
using PURCHASE.MAINCODE;
using PURCHASE.MAINCODE.Modun4;
using PURCHASE.MAINCODE.Modun4.Search;
using PURCHASE.MAINCODE.Search;
using LibraryCalender;

namespace PURCHASE
{
    public partial class Form4D : Form
    {
        DataProvider con = new DataProvider();
        BindingSource bindingSource;
        DataTable dt;
        string C_ANAME, ADR1, PAY_CON, DEFA_MONEY, RCV_DATE;
        public Form4D()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            con.CheckLanguage(this);
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4D_Load(object sender, EventArgs e)
        {
            loadinfo();
            Loaddata();
            LoadTextBox();

            btok.Hide();
            btdong.Hide();
            bt.Text = "NÚT DUYỆT";

            f12ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            con.DGV(DGV1);
        }

        private void LoadTextBox()
        {
            this.txtWS_DATE.Text = currentRow["WS_DATE"].ToString();
            this.txtM_KIND.Text = currentRow["M_KIND"].ToString();
            this.txtWS_NO.Text = currentRow["WS_NO"].ToString();
            this.txtC_NO.Text = currentRow["C_NO"].ToString();
            this.txtOR_NO.Text = currentRow["OR_NO"].ToString();
            this.txtTOTAL.Text = currentRow["TOTAL"].ToString();
            this.txtRCV_MON.Text = currentRow["RCV_MON"].ToString();
            this.txtNRCV_MON.Text = currentRow["NRCV_MON"].ToString();
            this.txtTOT.Text = currentRow["TOT"].ToString();
            this.txtTAX.Text = currentRow["TAX"].ToString();
            this.txtDISCOUNT.Text = currentRow["DISCOUNT"].ToString();
            this.txtMEMO1.Text = currentRow["MEMO1"].ToString();
            this.txtM_TRAN_R.Text = currentRow["M_TRAN_R"].ToString();

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
        private void LoadDataGrid()
        {
            string sql = "select NR,P_NO,P_NAME,BQTY,BUNIT,PRICE,AMOUNT,'' AS M, MEMO,OR_NO,P_NAME1" +
                         " FROM CGBBC  where WS_NO = N'" + txtWS_NO.Text + "'";
            DataTable dt1 = new DataTable();
            dt1 = con.readdata(sql);
            DGV1.DataSource = dt1;
        }
        public void Loaddata()
        {
            string sql = "select * FROM CGBHC where 1=1 " + SearchCGBHC.Wheres + " ORDER BY WS_DATE DESC,WS_NO DESC";
            
            dt = new DataTable();
            dt = con.readdata(sql);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
        }
        void loadinfo()
        {
            lbUserName.Text = con.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCGBHC frm = new SearchCGBHC();
            frm.ShowDialog();
            Loaddata();
            bindingSource.Position = SearchCGBHC.Getitem.index;
            txtWS_NO.Text = SearchCGBHC.Getitem.WS_NO;
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV1.Refresh();
            f2ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btok.Visible = true;
            btdong.Visible = true;
            txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtM_KIND.Text = "1";
            txtWS_NO.Text = "";
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtOR_NO.Text = "";
            txtTOTAL.Text = "0.00";
            txtRCV_MON.Text = "";
            txtNRCV_MON.Text = "0.00";
            txtTOT.Text = "0.00";
            txtTAX.Text = "0";
            txtDISCOUNT.Text = "0.00";
            txtMEMO1.Text = "";
            cbM_TRAN.Enabled = true;

            btdau.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            bttruoc.Enabled = false;

            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1";
            DataTable data = con.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";

            cbM_TRAN.SelectedValue = currentRow["M_TRAN"].ToString();
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm4DF7 frm = new frm4DF7();
            frm.ShowDialog();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveFirst();
            LoadTextBox();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
            Loadcb(currentRow["M_TRAN"].ToString());
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            LoadTextBox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
            LoadTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
            LoadTextBox();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void cbM_TRAN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Loadcb(string M_NO)
        {
            string wheres = "";
            if (f2ToolStripMenuItem.Checked == false)
            {
                wheres = " AND M_NO = '" + M_NO + "'";
            }
            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT where 1=1 " + wheres + "";
            DataTable data = con.readdata(sql);
            cbM_TRAN.DataSource = data;
            cbM_TRAN.DisplayMember = "M_NAME";
            cbM_TRAN.ValueMember = "M_NO";
        }

        private void txtM_KIND_TextChanged(object sender, EventArgs e)
        {
            switch (txtM_KIND.Text)
            {
                case "1":
                    label3.Text = "化 料 - 台 灣";
                    break;
                case "2":
                    label3.Text = "化料-大陸";
                    break;
                case "3":
                    label3.Text = "開狀櫃化料-台灣";
                    break;
                case "4":
                    label3.Text = "總料-台灣";
                    break;
                case "5":
                    label3.Text = "總料-大陸";
                    break;
                case "6":
                    label3.Text = "化料-越南";
                    break;
                case "7":
                    label3.Text = "總料-越南";
                    break;
                case "8":
                    label3.Text = "化料-越南轉廠";
                    break;
            }
        }

        private void cbM_TRAN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string money = "SELECT M_TRAN FROM dbo.MONEYT WHERE M_NO = '" + cbM_TRAN.SelectedValue.ToString() + "'";
                DataTable dt = con.readdata(money);
                txtM_TRAN_R.Text = dt.Rows[0]["M_TRAN"].ToString();
            }
        }

        private void txtM_KIND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                if (txtM_KIND.Text == "8")
                {
                    txtM_KIND.Text = "1";
                }
                else
                {
                    txtM_KIND.Text = (int.Parse(txtM_KIND.Text) + 1).ToString();
                }
            }
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                if(!string.IsNullOrEmpty(txtC_NO.Text))
                {
                    string sql = "SELECT Top 1 * from dbo.VENDC WHERE 1 = 1 and C_NO LIKE N'" + txtC_NO.Text + "'";
                    DataTable dtnew = new DataTable();
                    dtnew = con.readdata(sql);

                    txtC_NO.Text = dtnew.Rows[0]["C_NO"].ToString();
                    txtC_NAME.Text = dtnew.Rows[0]["C_NAME"].ToString();
                    C_ANAME = dtnew.Rows[0]["C_ANAME"].ToString();
                    ADR1 = dtnew.Rows[0]["ADR1"].ToString();
                }

            }
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btok.Visible = false;
            btdong.Visible = false;

            Loaddata();
            LoadTextBox();

            btdau.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bttruoc.Enabled = true;
            cbM_TRAN.Enabled = false;
        }

        private void btok_Click(object sender, EventArgs e)
        {

        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                {
                    if (!string.IsNullOrEmpty(txtOR_NO.Text))
                    {
                        SearchPROD1C_M4 frm = new SearchPROD1C_M4();
                        frm.ShowDialog();

                        string sql = "SELECT C.WS_NO,C.C_NO,V.C_NAME,V.C_ANAME,V.ADR1,V.S_NO,V.ADR2,V.ADR3,V.ADR4,V.PAY_CON,V.DEFA_MONEY,V.RCV_DATE" +
                    " FROM COMHC C JOIN VENDC V ON V.C_NO = C.C_NO" +
                    " WHERE WS_NO = '" + txtOR_NO.Text + "'";
                        DataTable dt = new DataTable();
                        dt = con.readdata(sql);
                        txtC_NO.Text = dt.Rows[0]["C_NO"].ToString();
                        txtC_NAME.Text = dt.Rows[0]["C_NAME"].ToString();
                        C_ANAME = dt.Rows[0]["C_ANAME"].ToString();
                        ADR1 = dt.Rows[0]["ADR1"].ToString();
                        PAY_CON = dt.Rows[0]["PAY_CON"].ToString();
                        DEFA_MONEY = dt.Rows[0]["DEFA_MONEY"].ToString();
                        RCV_DATE = dt.Rows[0]["RCV_DATE"].ToString();

                        string sql1 = "SELECT B.P_NO,B.P_NAME,B.P_NAME1,B.P_NAME3,B.BQTY,B.PRICE,B.AMOUNT,B.WS_NO AS OR_NO,B.MEMO,'' AS SH_NAME, B.NR AS OR_NR," +
                            " '' AS PK_NO, B.SH_NO" +
                            " FROM COMHC H" +
                            " JOIN COMBC B ON B.WS_NO = H.WS_NO" +
                            " LEFT JOIN PROD1C P ON P.P_NO = B.P_NO" +
                            " WHERE H.WS_NO = '" + txtOR_NO.Text + "' AND (B.OVER0<>'Y'AND B.HOVER<>'Y')" +
                            " ORDER BY B.NR";
                        DataTable dt1 = new DataTable();
                        dt1 = con.readdata(sql1);
                        if (dt1.Rows.Count > 0)
                        {
                            int NR1 = 1;
                            DataTable dataTable = (DataTable)DGV1.DataSource;
                            foreach (DataRow item in dt1.Rows)
                            {
                                STT = NR1.ToString("D" + 3);
                                DataRow drToAdd = dataTable.NewRow();
                                drToAdd["NR"] = STT;
                                drToAdd["P_NO"] = item["P_NO"].ToString();
                                drToAdd["P_NAME"] = item["P_NAME"].ToString();
                                drToAdd["P_NAME1"] = item["P_NAME1"].ToString();
                                drToAdd["P_NAME3"] = item["P_NAME3"].ToString();
                                drToAdd["BQTY"] = item["BQTY"].ToString();
                                drToAdd["PRICE"] = item["PRICE"].ToString();

                                dataTable.Rows.Add(drToAdd);
                                NR1++;
                            }
                        }
                    }
                }
            }
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtWS_NO_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string WS_NO = "";
                string sql = "SELECT WS_NO FROM CGBHC WHERE WS_NO LIKE '" + DateTime.Now.ToString("yyyyMMdd") + "%' ORDER BY WS_NO desc";
                DataTable table = con.readdata(sql);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        WS_NO = DateTime.Now.ToString("yyyyMMdd") + (int.Parse(item[0].ToString().Substring(9, 3)) + 1);
                    }
                }
                else
                {
                    WS_NO = DateTime.Now.ToString("yyyyMMdd") + "001";
                }
                txtWS_NO.Text = WS_NO;
            }
        }
        string STT = "";
        private void txtOR_NO_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                SearchVENDC1B frm = new SearchVENDC1B();
                frm.ShowDialog();
                txtC_NO.Text = SearchVENDC1B.getDataTable.C_NO;
                txtC_NAME.Text = SearchVENDC1B.getDataTable.C_NAME; 
                C_ANAME = SearchVENDC1B.getDataTable.C_ANAME;
                ADR1 = SearchVENDC1B.getDataTable.ADR1;
            }
        }
    }
}
