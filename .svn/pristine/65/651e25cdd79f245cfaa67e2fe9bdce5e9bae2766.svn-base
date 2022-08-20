using CrystalDecisions.CrystalReports.Engine;
using LibraryCalender;
using PURCHASE.Config;
using PURCHASE.MAINCODE;
using PURCHASE.MAINCODE.Modun6.Search;
using PURCHASE.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace PURCHASE
{
    public partial class Form6A : Form
    {
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        DataProvider conn = new DataProvider();
        MenuStripEvent stripEvent = new MenuStripEvent();
        public Form6A()
        {
            InitializeComponent();
            conn.CheckLanguage(this);
        }


        public void Set_Data()
        {
            txtWS_DATE.Text = Form6AF5.Get_data.t2;
            txtWSNO.Text = Form6AF5.Get_data.t1;
            txtUSER_ID.Text = Form6AF5.Get_data.t3;
            txtNAME.Text = Form6AF5.Get_data.t4;
        }


        public void loadDataNull()
        {

            string sql = "SELECT NR_Form,Name_From,NameMenu,0 AS P_USE,0 AS F1," +
                        "0 AS F2,0 AS F3,0 AS F4,0 AS F5,0 AS F6,0 AS f7," +
                        "0 AS f8,0 AS F9,0 AS F10,0 AS f11,0 AS f12,0 AS P_PRICE FROM FORM_NAME";
            DataTable dt = conn.readdata(sql);
            DGV1.DataSource = dt;
        }
        private void frm6A_Load(object sender, EventArgs e)
        {
            chkSupervisor.Checked = false;
            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btnClose.Hide();
            checkNofication();
            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

        }
        string txtText1 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtXoa = "";
        string txtSua = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText1 = "Bạn Chưa Nhập Mã Số Tài Khoản";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText1 = "You Have Not Entered Account Number";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText1 = "You have not entered the order number?";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtSua = "EDIT";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText1 = "您尚未輸入帳號";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtSua = "使固定";
                txtNodata = "沒有數據";
            }
        }
        public void Load_Dataview()
        {
            string SQL = "SELECT USRB_NEW.NR_Form,Name_From,NameMenu,P_USE,F1,F2,F3,F4,F5,F6,f7,f8,F9,F10,f11,f12,P_PRICE FROM dbo.USRB_NEW " +
                " JOIN FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                " WHERE USER_ID = '" + txtUSER_ID.Text + "'";
            datatable = conn.readdata(SQL);
            conn.FormatDGV(DGV1, datatable);
            DGV1.Columns[0].Frozen = true;
            DGV1.Columns[1].Frozen = true;
            //Change_Cell_Value();
        }
        public void Load_Data()
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();

            string sql = "select WSNO, WSDATE, USER_ID, NAME, SUPER from USRH";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();

            foreach (DataRow row in datatable.Rows)
                bindingsource.Add(row);
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = conn.getDateNow();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        public void Show_data()
        {
            DataRow currenRow = (DataRow)bindingsource.Current;

            txtWS_DATE.Text = conn.formatstr2(currenRow["WSDATE"].ToString());
            txtWSNO.Text = currenRow["WSNO"].ToString();
            txtUSER_ID.Text = currenRow["USER_ID"].ToString();
            txtNAME.Text = currenRow["NAME"].ToString();
            if (currenRow["SUPER"].ToString() == "1")
                chkSupervisor.Checked = true;
            else if (currenRow["SUPER"].ToString() == "0")
                chkSupervisor.Checked = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            checkNofication();
            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btnClose.Hide();
            bt.Text = "" + txtDuyet + "";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            txtWSNO.Enabled = true;
        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM USRH WHERE USER_ID = '" + txtUSER_ID.Text + "'";
            DataTable dt = conn.readdata(sql);

            if (dt.Rows.Count > 0)
            {
                txtWS_DATE.Text = dt.Rows[0]["WSDATE"].ToString();
                txtWSNO.Text = dt.Rows[0]["WSNO"].ToString();
                txtNAME.Text = dt.Rows[0]["NAME"].ToString();
                txtUSERNAME.Text = dt.Rows[0]["USR_NAME"].ToString();
                if (dt.Rows[0]["SUPER"].ToString() == "True")
                    chkSupervisor.Checked = true;
                else
                    chkSupervisor.Checked = false;
                Load_Dataview();
            }
            else
            {
                txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtWSNO.Text = "";
                txtNAME.Text = "";
                loadDataNull();
            }
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MoveNext();

                Show_data();
                Load_Dataview();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();

            Show_data();
            Load_Dataview();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MovePrevious();

                Show_data();
                Load_Dataview();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();

            Show_data();
            Load_Dataview();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                checkNofication();
                if (f2ToolStripMenuItem.Checked == true)
                {
                    if (checkExist() == true)
                    {
                        MessageBox.Show("Đã tồn tại tài khoản này!");
                    }
                    else
                    {
                        Add_Data();
                        f2ToolStripMenuItem.Checked = false;
                    }
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    Delete_DGV();
                    f3ToolStripMenuItem.Checked = false;
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    Update_data(); 
                    f4ToolStripMenuItem.Checked = false;
                }
                else if (f6ToolStripMenuItem.Checked == true)
                {
                    if (checkExist() == true)
                    {
                        MessageBox.Show("Đã tồn tại tài khoản này!");
                    }
                    else
                    {
                        Insert_Data();
                        f6ToolStripMenuItem.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Insert_Data()
        {
            checkNofication();
            check();
            string st1 = "insert into dbo.USRH(WSDATE, WSNO, USER_ID, NAME, SUPER)" +
                " values('" + a + "', '" + txtWSNO.Text + "', '" + txtUSER_ID.Text + "', '" + txtNAME.Text + "', '" + chkSupervisor.Checked + "')";

            if (txtWSNO.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }
            try
            {
                if (conn.exedata(st1) == true)
                {
                    Add_DGV();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btnClose.Hide();
        }

        public void Update_data()
        {
            checkNofication();
            check();
            string st1 = "update dbo.USRH set WSDATE ='"+txtWS_DATE.Text.Replace("/","").ToString()+"', WSNO ='"+txtWSNO.Text+"', USER_ID ='"+txtUSER_ID.Text+"', NAME ='"+txtNAME.Text+"', SUPER ='"+ Covert_boot(chkSupervisor.Checked)+"' where WSNO= '"+ txtWSNO.Text + "'";
            if (txtWSNO.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }
            try
            {
                conn.exedata(st1);
                updatadatagridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Load_Data();
            //Show_data();
            Load_Dataview();

            btok.Hide();
            btnClose.Hide();

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            txtWSNO.Enabled = true;
        }
        public void updatadatagridview()
        {
            for (int i = 0; i < DGV1.Rows.Count - 1; i++)
            {
                string sql = "UPDATE dbo.USRB_NEW SET P_USE = " + ConvertStringToInt(DGV1.Rows[i].Cells["P_USE"].Value.ToString()) + "," +
                    "F1=" + ConvertStringToInt(DGV1.Rows[i].Cells["F1"].Value.ToString()) +
                    ",F2=" + ConvertStringToInt(DGV1.Rows[i].Cells["F2"].Value.ToString()) +
                    ",F3=" + ConvertStringToInt(DGV1.Rows[i].Cells["F3"].Value.ToString()) +
                    ",F4=" + ConvertStringToInt(DGV1.Rows[i].Cells["F4"].Value.ToString()) +
                    ",F5=" + ConvertStringToInt(DGV1.Rows[i].Cells["F5"].Value.ToString()) +
                    ",F6=" + ConvertStringToInt(DGV1.Rows[i].Cells["F6"].Value.ToString()) +
                    ",F7=" + ConvertStringToInt(DGV1.Rows[i].Cells["F7"].Value.ToString()) +
                    ",F8=" + ConvertStringToInt(DGV1.Rows[i].Cells["F8"].Value.ToString()) +
                    ",F9=" + ConvertStringToInt(DGV1.Rows[i].Cells["F9"].Value.ToString()) +
                    ",F10=" + ConvertStringToInt(DGV1.Rows[i].Cells["F10"].Value.ToString()) +
                    ",F11=" + ConvertStringToInt(DGV1.Rows[i].Cells["F11"].Value.ToString()) +
                    ",F12=" + ConvertStringToInt(DGV1.Rows[i].Cells["F12"].Value.ToString()) +
                    ",P_PRICE=" + ConvertStringToInt(DGV1.Rows[i].Cells["P_PRICE"].Value.ToString()) +
                    " WHERE USER_ID = '" + txtUSER_ID.Text + "' AND NR_Form = " + DGV1.Rows[i].Cells["NR_Form"].Value.ToString() + "";
                conn.exedata(sql);
            }
        }
        public int ConvertStringToInt(string d)
        {
            if (d == "True")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Delete_DGV()
        {
            checkNofication();
            Delete_Data();
            conn.exedata("delete from USRB_NEW where USER_ID ='" + txtUSER_ID.Text + "'");

            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btnClose.Hide();

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            txtWSNO.Enabled = true;

        }
        public void Delete_Data()
        {
            checkNofication();
            string Matk = txtWSNO.Text;
            if (Matk == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
            try
            {
                string sql = "delete from USRH where USER_ID ='" + txtUSER_ID.Text + "'";
                conn.exedata(sql);

            }
            catch { }
        }
        public string a = "";
        public void check()
        {
            if (conn.Check_MaskedText(txtWS_DATE) == true)
            {
                a = conn.formatstr2(txtWS_DATE.Text);
            }
        }
        public void Add_Data()
        {
            checkNofication();
            check();
            string st1 = "INSERT INTO dbo.USRH(WSNO,WSDATE,USER_ID,NAME,PAS_WORD,SUPER,USR_NAME,UPDATEKIND,LANGUAGE)" +
            "VALUES(N'"+txtWSNO.Text+"', '"+DateTime.Now.ToString("yyyyMMdd").ToString()+"', '"+txtUSER_ID.Text+"', '"+txtNAME.Text+"', '123',"+(chkSupervisor.Checked == true ? 1 : 0)+", '"+txtUSERNAME.Text+"', NULL, '1')";
            if (txtWSNO.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }
            try
            {
                if(conn.exedata(st1))
                {
                    Add_DGV();
                }else
                {
                    MessageBox.Show("Insert thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btnClose.Hide();

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;
        }
        private bool checkExist()
        {
            string sql = "SELECT TOP 1 * FROM USRH WHERE USER_ID = '" + txtUSER_ID.Text + "'";
            DataTable dt = conn.readdata(sql);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Add_DGV()
        {
            for (int i = 0; i < DGV1.RowCount - 1; i++)
            {
                string sql = "INSERT INTO dbo.USRB_NEW(USER_ID, SUPER, NR_Form, P_USE, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,P_PRICE) " +
                            "VALUES('" + txtUSER_ID.Text + "','" + Covert_boot(chkSupervisor.Checked) + "'," + DGV1.Rows[i].Cells["NR_Form"].Value.ToString() +
                            "," + DGV1.Rows[i].Cells["P_USE"].Value.ToString() + "," + DGV1.Rows[i].Cells["F1"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F2"].Value.ToString() + "," + DGV1.Rows[i].Cells["F3"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F4"].Value.ToString() + "," + DGV1.Rows[i].Cells["F5"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F6"].Value.ToString() + "," + DGV1.Rows[i].Cells["F7"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F8"].Value.ToString() + "," + DGV1.Rows[i].Cells["F9"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F10"].Value.ToString() + "," + DGV1.Rows[i].Cells["F11"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F12"].Value.ToString() + "," + DGV1.Rows[i].Cells["P_PRICE"].Value.ToString() + ")";
                try
                {
                    conn.exedata(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        public int Covert_boot(bool b)
        {
            int c;
            if (b == true)
            {
                c = 1;
            }
            else c = 0;

            return c;
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            checkNofication();
            bt.Text = "" + txtThem + "";
            f2ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            txtWS_DATE.Text = d1.ToString("yyyy/MM/dd");
            txtWSNO.Text = "";
            txtUSER_ID.Text = "";
            txtNAME.Text = "";
            chkSupervisor.Checked = false;

            btok.Show();
            btnClose.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            loadDataNull();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true;
            checkNofication();
            bt.Text = "" + txtXoa + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btok.Show();
            btnClose.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            checkNofication();
            bt.Text = "" + txtSua + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;


            txtWS_DATE.Enabled = false;
            txtWSNO.Enabled = false;
            txtUSER_ID.Enabled = true;
            txtNAME.Enabled = true;
            txtUSERNAME.Enabled = true;

            btok.Show();
            btnClose.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5ToolStripMenuItem.Checked = true;
            Form6AF5 frm = new Form6AF5();
            frm.ShowDialog();

            string dl1 = Form6AF5.Get_data.t1;
            if (dl1 != string.Empty)
            {
                Set_Data();
                Load_Dataview();
            }

            if (txtWSNO.Text == "")
            {
                Load_Data();
                Show_data();
                Load_Dataview();
            }
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;


            txtWS_DATE.Enabled = true;
            txtWSNO.Enabled = true;
            txtUSER_ID.Enabled = true;
            txtNAME.Enabled = true;

            btok.Show();
            btnClose.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReportDocument cryRpt = new Cr_Form2D_Tab8();
            //string st = "select USRH.WSNO, USRH.USER_ID, USRH.NAME, USRH.SUPER, USRB.PROG_NO, USRB.PROG_NAME, USRB.PUSE, USRB.PADD, USRB.PRET, USRB.PMODI, USRB.PDEL, USRB.PBROW, USRB.PPRT, USRB.PPRICE, USRB.PCHECK, USRB.PCHK01, USRB.PCHK02, USRB.PCHK03 from USRB inner join USRH on USRB.WSNO = USRH.WSNO where USRH.USER_ID ='" + tb3.Text + "'";
            //System.Data.DataTable dt = conn.readdata(st);
            //cryRpt.SetDataSource(dt);
            //cryRpt.SetDataSource(dt);
            //ShareReport.repo = cryRpt;
            //Report frm = new Report();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        int NR1 = 1; 
        string STT = "";
        private void txtWSNO_Click(object sender, EventArgs e)
        {
            string WS_NO_NEW = "";
            string sql = "SELECT WSNO FROM dbo.USRH WHERE WSNO LIKE '" + DateTime.Now.ToString("yyyyMMdd") + "%'";
            DataTable dtnew = new DataTable();
            dtnew = conn.readdata(sql);
            if (dtnew.Rows.Count > 0)
            {
                NR1 = int.Parse(dtnew.Rows[0][0].ToString().Substring(10, 3)) + 1;
                WS_NO_NEW = dtnew.Rows[0][0].ToString().Substring(0,9) + NR1.ToString("D" + 3);
            }
            else
            {
                WS_NO_NEW = "Z" + DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            txtWSNO.Text = WS_NO_NEW;
        }
    }
}
