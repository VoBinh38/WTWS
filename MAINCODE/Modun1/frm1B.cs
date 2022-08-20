using DocumentFormat.OpenXml.Office.CustomUI;
using PURCHASE.MAINCODE;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class Form1B : Form
    {
        DataProvider conn = new DataProvider();
        public Form1B()
        {
            InitializeComponent();
            conn.CheckLanguage(this);

        }
        DataTable DataTable;
        BindingSource source;
        private void Form1B_Load(object sender, EventArgs e)
        {
            lbFAX.Width = 150;
            getInfo();
            LoadData();
        }
        private void LoadData()
        {
            if (f5ToolStripMenuItem.Checked == false)
            {
                DataTable = new DataTable();
                string sql = "SELECT C_NO, C_NAME, V_NAME, C_ANAME, BOSS, SPEAK, ACCOUNT, NUMBER, TEL1, TEL2, FAX, ACT, BBCALL, ADR1ZIP, ADR1, ADR2ZIP, ADR2, ADR3ZIP, ADR3, ADR4ZIP, ADR4, PRE_RCV, " +
                    "EAR_MON, S_NO, BA_NO, RCV_AC_NO, CHK_AC_NO, RCV_DATE, PAY_CON, MEMO1, MEMO2, MEMO3, OUTPER," +
                    " EMAIL, EMAIL1, TAX_YN, TAX_KIND, BANK_AC_NO, a.M_NAME as DEFA_MONEY,USR_NAME,C_NO_W,W_PASWORD,UPDATEKIND,V_ANAME " +
                    "FROM VENDC AS B LEFT JOIN(SELECT DISTINCT M_NO, M_NAME FROM MONEYT) AS A ON B.DEFA_MONEY = a.M_NO";
                DataTable = new DataTable();
                DataTable = conn.readdata(sql);
                source = new BindingSource();
                source.DataSource = DataTable;
                ShowTextBox();
                //ẩn nút function
                btok.Hide();
                btdong.Hide();
                //load function
                btdau.Enabled = false;
                bttruoc.Enabled = false;
                tb33.Enabled = false;
                
            }
            else
            {

                source.DataSource = SearchVENDC1B.getDataTable.data2;
                source.Position = SearchVENDC1B.getDataTable.index;
                ShowTextBox();
                //ẩn nút function
                btok.Hide();
                btdong.Hide();
                //load function
                btdau.Enabled = false;
                bttruoc.Enabled = false;
                tb33.Enabled = false;
                //trả lại trạng thái
                f5ToolStripMenuItem.Checked = false;
            }
        }
        private void LoadCombobox()
        {
            string sql = "SELECT DISTINCT M_NO,M_NAME FROM MONEYT";
            DataTable = new DataTable();
            DataTable = conn.readdata(sql);
            foreach(DataRow data in DataTable.Rows)
            {
                cb1.Items.Add(data["M_NAME"]);
            }
            cb1.DisplayMember = "M_NAME";
            cb1.ValueMember = "M_NO";
        }
        // bring data
        public DataRow currenRow
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
        private void ShowTextBox()
        {
          try
            {
                tb1.Text = currenRow["C_NO"].ToString();
                tb2.Text = currenRow["C_NAME"].ToString();
                tb3.Text = currenRow["C_ANAME"].ToString();
                tb4.Text = currenRow["V_NAME"].ToString();
                tb5.Text = currenRow["V_ANAME"].ToString();

                tb6.Text = currenRow["NUMBER"].ToString();
                tb7.Text = currenRow["BOSS"].ToString();
                tb8.Text = currenRow["SPEAK"].ToString();
                tb9.Text = currenRow["TEL1"].ToString();
                tb10.Text = currenRow["TEL2"].ToString();

                tb11.Text = currenRow["FAX"].ToString();
                tb12.Text = currenRow["ACT"].ToString();
                tb13.Text = currenRow["EMAIL"].ToString();
                tb14.Text = currenRow["S_NO"].ToString();
                tb15.Text = ""; // không biết truyền dữ liệu

                tb16.Text = currenRow["ADR1ZIP"].ToString();
                tb17.Text = currenRow["ADR1"].ToString();
                tb18.Text = currenRow["ADR2ZIP"].ToString();
                tb19.Text = currenRow["ADR2"].ToString();
                tb20.Text = currenRow["ADR3ZIP"].ToString();
                tb21.Text = currenRow["ADR3"].ToString();

                tb22.Text = currenRow["ADR4ZIP"].ToString();
                tb23.Text = currenRow["ADR4"].ToString();
                tb24.Text = currenRow["MEMO1"].ToString();
                tb25.Text = currenRow["MEMO2"].ToString();
                tb26.Text = currenRow["MEMO3"].ToString();

                tb27.Text = currenRow["ACCOUNT"].ToString();
                tb28.Text = currenRow["PRE_RCV"].ToString();
                tb29.Text = currenRow["EAR_MON"].ToString();
                tb30.Text = currenRow["TAX_KIND"].ToString();
                tb31.Text = currenRow["BA_NO"].ToString();

                tb32.Text = ""; // không biết truyền dữ liệu
                tb33.Text = currenRow["TAX_YN"].ToString();
                tb34.Text = currenRow["PAY_CON"].ToString();
                tb35.Text = currenRow["RCV_DATE"].ToString();
                cb1.Text = currenRow["DEFA_MONEY"].ToString();
           }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            try
            {
                source.MoveFirst();
                ShowTextBox();
                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                source.MovePrevious();
                ShowTextBox();
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                source.MoveNext();
                ShowTextBox();
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btketthuc_Click(object sender, EventArgs e)
        {
            try
            {
                source.MoveLast();
                ShowTextBox();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = false;
                btketthuc.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tieu de
            bt.Text = "THÊM";
            LoadStripMenu();
            ResetTextbox();
            LoadCombobox();
            //mở chức năng
            f2ToolStripMenuItem.Checked = true;
            tb33.Enabled = true;
        }
        private void LoadStripMenu()
        {
            //xoa nut
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            //hieenr thi button
            btok.Show();
            btdong.Show();
            //chức năng
            cb1.Enabled = true;
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }
        private void tb33_DoubleClick(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                tb33.Enabled = true;
                if (tb33.Text == "")
                {
                    tb33.Text = "Y";
                }
                else
                {
                    if (tb33.Text == "Y")
                    {
                        tb33.Text = "N";
                    }
                    else
                    {
                        tb33.Text = "Y";
                    }
                }
            }
        }
        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                if (f2ToolStripMenuItem.Checked == true)
                {
                    InsertData();
                }
                if (f3ToolStripMenuItem.Checked == true)
                {
                    DeleteData();
                }
                if (f4ToolStripMenuItem.Checked == true)
                {
                    EditData();
                }
                if (f6ToolStripMenuItem.Checked == true)
                {
                    InsertData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        private void EditData()
        {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        SqlConnection sqlConnection = new SqlConnection();
                        sqlCommand.CommandText = "Update_Table_VENDC_1B";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("@C_NO", SqlDbType.NVarChar).Value = tb1.Text;
                        sqlCommand.Parameters.Add("@C_NAME", SqlDbType.NVarChar).Value = tb2.Text;
                        sqlCommand.Parameters.Add("@V_NAME", SqlDbType.NVarChar).Value = tb4.Text;
                        sqlCommand.Parameters.Add("@C_ANAME", SqlDbType.NVarChar).Value = tb3.Text;
                        sqlCommand.Parameters.Add("@BOSS", SqlDbType.NVarChar).Value = tb7.Text;
                        sqlCommand.Parameters.Add("@SPEAK", SqlDbType.NVarChar).Value = tb8.Text;
                        sqlCommand.Parameters.Add("@ACCOUNT", SqlDbType.NVarChar).Value = tb27.Text;
                        sqlCommand.Parameters.Add("@NUMBER", SqlDbType.NVarChar).Value = tb6.Text;
                        sqlCommand.Parameters.Add("@TEL1", SqlDbType.NVarChar).Value = tb9.Text;
                        sqlCommand.Parameters.Add("@TEL2", SqlDbType.NVarChar).Value = tb10.Text;
                        sqlCommand.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = tb11.Text;
                        sqlCommand.Parameters.Add("@ACT", SqlDbType.NVarChar).Value = tb12.Text;
                        sqlCommand.Parameters.Add("@ADR1ZIP", SqlDbType.NVarChar).Value = tb16.Text;
                        sqlCommand.Parameters.Add("@ADR1", SqlDbType.NVarChar).Value = tb17.Text;
                        sqlCommand.Parameters.Add("@ADR2ZIP", SqlDbType.NVarChar).Value = tb18.Text;
                        sqlCommand.Parameters.Add("@ADR2", SqlDbType.NVarChar).Value = tb19.Text;
                        sqlCommand.Parameters.Add("@ADR3ZIP", SqlDbType.NVarChar).Value = tb20.Text;
                        sqlCommand.Parameters.Add("@ADR3", SqlDbType.NVarChar).Value = tb21.Text;
                        sqlCommand.Parameters.Add("@ADR4ZIP", SqlDbType.NVarChar).Value = tb22.Text;
                        sqlCommand.Parameters.Add("@ADR4", SqlDbType.NVarChar).Value = tb23.Text;
                        sqlCommand.Parameters.Add("@PRE_RCV", SqlDbType.Float).Value = tb28.Text;
                        sqlCommand.Parameters.Add("@EAR_MON", SqlDbType.Float).Value = tb29.Text;
                        sqlCommand.Parameters.Add("@S_NO", SqlDbType.NVarChar).Value = tb14.Text;
                        sqlCommand.Parameters.Add("@BA_NO", SqlDbType.NVarChar).Value = tb31.Text;
                        sqlCommand.Parameters.Add("@RCV_DATE", SqlDbType.NVarChar).Value = tb34.Text;
                        sqlCommand.Parameters.Add("@PAY_CON", SqlDbType.NVarChar).Value = tb32.Text;
                        sqlCommand.Parameters.Add("@MEMO1", SqlDbType.NVarChar).Value = tb24.Text;
                        sqlCommand.Parameters.Add("@MEMO2", SqlDbType.NVarChar).Value = tb25.Text;
                        sqlCommand.Parameters.Add("@MEMO3", SqlDbType.NVarChar).Value = tb26.Text;
                        sqlCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = tb13.Text;
                        sqlCommand.Parameters.Add("@TAX_YN", SqlDbType.NVarChar).Value = tb33.Text;
                        sqlCommand.Parameters.Add("@TAX_KIND", SqlDbType.NVarChar).Value = tb30.Text;
                        //kiểm tra combobox đã chọn hay chưa?
                        if (string.IsNullOrEmpty(cb1.Text) || cb1.SelectedIndex == -1)
                        {
                            sqlCommand.Parameters.Add("@DEFA_MONEY", SqlDbType.NVarChar).Value = (string)cb1.Items[0]; ;
                        }
                        else
                        {
                            sqlCommand.Parameters.Add("@DEFA_MONEY", SqlDbType.NVarChar).Value = "1";
                        }
                        //sqlCommand.Parameters.Add("@USR_NAME", SqlDbType.NVarChar).Value = lbUserName.Text;
                        //sqlCommand.Parameters.Add("@V_ANAME", SqlDbType.NVarChar).Value = tb5.Text;
                        //conn.connect_SQL(sqlConnection, sqlCommand);
                        //sqlCommand.ExecuteNonQuery();
                        //conn.Disconnect_SQL(sqlConnection, sqlCommand);
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFunction();
                        //tắt button
                        btok.Hide();
                        btdong.Hide();
                        // khóa lại chức năng
                        f2ToolStripMenuItem.Checked = false;
                        //mo lại tb1
                        tb1.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        private void DeleteData()
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (tb1.Text == "")
                {
                    MessageBox.Show("Bạn không được để trống mã nhà cung cấp");
                    tb1.Focus();
                }
                else
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        SqlConnection sqlConnection = new SqlConnection();
                        sqlCommand.CommandText = "Delete_Table_VENDC_1B";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add("C_NO", SqlDbType.NVarChar).Value = tb1.Text;
                        //conn.connect_SQL(sqlConnection, sqlCommand);
                        //sqlCommand.ExecuteNonQuery();
                        //conn.Disconnect_SQL(sqlConnection, sqlCommand);
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // LoadFunction();
                        LoadData();
                        //tắt button
                        btok.Hide();
                        btdong.Hide();
                        // khóa lại chức năng
                        f3ToolStripMenuItem.Checked = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } 
        }
        private void InsertData()
        {
        if (tb1.Text == "")
        {
            MessageBox.Show("Bạn không được để trống mã nhà cung cấp");
            tb1.Focus();
        }
        else
        {
            //string table = "VENDC";
            //string dk1 = "C_NO";
                try
                {
                    //if (conn.checkID_Exist(table,dk1,tb1.Text))
                    //{
                    //    SqlCommand sqlCommand = new SqlCommand();
                    //    SqlConnection sqlConnection = new SqlConnection();
                    //    sqlCommand.CommandText = "Insert_Table_VENDC_1B";
                    //    sqlCommand.CommandType = CommandType.StoredProcedure;
                    //    sqlCommand.Parameters.Add("@C_NO", SqlDbType.NVarChar).Value = tb1.Text;
                    //    sqlCommand.Parameters.Add("@C_NAME", SqlDbType.NVarChar).Value = tb2.Text;
                    //    sqlCommand.Parameters.Add("@V_NAME", SqlDbType.NVarChar).Value = tb4.Text;
                    //    sqlCommand.Parameters.Add("@C_ANAME", SqlDbType.NVarChar).Value = tb3.Text;
                    //    sqlCommand.Parameters.Add("@BOSS", SqlDbType.NVarChar).Value = tb7.Text;
                    //    sqlCommand.Parameters.Add("@SPEAK", SqlDbType.NVarChar).Value = tb8.Text;
                    //    sqlCommand.Parameters.Add("@ACCOUNT", SqlDbType.NVarChar).Value = tb27.Text;
                    //    sqlCommand.Parameters.Add("@NUMBER", SqlDbType.NVarChar).Value = tb6.Text;
                    //    sqlCommand.Parameters.Add("@TEL1", SqlDbType.NVarChar).Value = tb9.Text;
                    //    sqlCommand.Parameters.Add("@TEL2", SqlDbType.NVarChar).Value = tb10.Text;
                    //    sqlCommand.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = tb11.Text;
                    //    sqlCommand.Parameters.Add("@ACT", SqlDbType.NVarChar).Value = tb12.Text;
                    //    sqlCommand.Parameters.Add("@BBCALL", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@ADR1ZIP", SqlDbType.NVarChar).Value = tb16.Text;
                    //    sqlCommand.Parameters.Add("@ADR1", SqlDbType.NVarChar).Value = tb17.Text;
                    //    sqlCommand.Parameters.Add("@ADR2ZIP", SqlDbType.NVarChar).Value = tb18.Text;
                    //    sqlCommand.Parameters.Add("@ADR2", SqlDbType.NVarChar).Value = tb19.Text;
                    //    sqlCommand.Parameters.Add("@ADR3ZIP", SqlDbType.NVarChar).Value = tb20.Text;
                    //    sqlCommand.Parameters.Add("@ADR3", SqlDbType.NVarChar).Value = tb21.Text;
                    //    sqlCommand.Parameters.Add("@ADR4ZIP", SqlDbType.NVarChar).Value = tb22.Text;
                    //    sqlCommand.Parameters.Add("@ADR4", SqlDbType.NVarChar).Value = tb23.Text;
                    //    sqlCommand.Parameters.Add("@PRE_RCV", SqlDbType.Float).Value = tb28.Text;
                    //    sqlCommand.Parameters.Add("@EAR_MON", SqlDbType.Float).Value = tb29.Text;
                    //    sqlCommand.Parameters.Add("@S_NO", SqlDbType.NVarChar).Value = tb14.Text;
                    //    sqlCommand.Parameters.Add("@BA_NO", SqlDbType.NVarChar).Value = tb31.Text;
                    //    sqlCommand.Parameters.Add("@RCV_AC_NO", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@CHK_AC_NO", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@RCV_DATE", SqlDbType.NVarChar).Value = tb34.Text;
                    //    sqlCommand.Parameters.Add("@PAY_CON", SqlDbType.NVarChar).Value = tb32.Text;
                    //    sqlCommand.Parameters.Add("@MEMO1", SqlDbType.NVarChar).Value = tb24.Text;
                    //    sqlCommand.Parameters.Add("@MEMO2", SqlDbType.NVarChar).Value = tb25.Text;
                    //    sqlCommand.Parameters.Add("@MEMO3", SqlDbType.NVarChar).Value = tb26.Text;
                    //    sqlCommand.Parameters.Add("@OUTPER", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = tb13.Text;
                    //    sqlCommand.Parameters.Add("@EMAIL1", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@TAX_YN", SqlDbType.NVarChar).Value = tb33.Text;
                    //    sqlCommand.Parameters.Add("@TAX_KIND", SqlDbType.NVarChar).Value = tb30.Text;
                    //    sqlCommand.Parameters.Add("@BANK_AC_NO", SqlDbType.NVarChar).Value = "";
                    //    //kiểm tra combobox đã chọn hay chưa?
                    //    if (string.IsNullOrEmpty(cb1.Text) || cb1.SelectedIndex == -1)
                    //    {
                    //        sqlCommand.Parameters.Add("@DEFA_MONEY", SqlDbType.NVarChar).Value = (string)cb1.Items[0]; ;
                    //    }
                    //    else
                    //    {
                    //        sqlCommand.Parameters.Add("@DEFA_MONEY", SqlDbType.NVarChar).Value = "1";
                    //    }
                    //    sqlCommand.Parameters.Add("@USR_NAME", SqlDbType.NVarChar).Value = lbUserName.Text;
                    //    sqlCommand.Parameters.Add("@C_NO_W", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@W_PASWORD", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@UPDATEKIND", SqlDbType.NVarChar).Value = "";
                    //    sqlCommand.Parameters.Add("@V_ANAME", SqlDbType.NVarChar).Value = tb5.Text;
                    //    //conn.connect_SQL(sqlConnection, sqlCommand);
                    //    //sqlCommand.ExecuteNonQuery();
                    //    //conn.Disconnect_SQL(sqlConnection, sqlCommand);
                    //    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    LoadFunction();
                    //    //tắt button
                    //    btok.Hide();
                    //    btdong.Hide();
                    //    // khóa lại chức năng
                    //    f2ToolStripMenuItem.Checked = false;
                    //}  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void LoadFunction()
        {
            //chức năng
            cb1.Enabled = false;
            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;
            //Tieu de
            bt.Text = "DUYỆT";
            //xoa nut
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void tb1_Click(object sender, EventArgs e)
        {
          if (tb1.Text == "")
           {
                    MessageBox.Show("Bạn không được để trống");
           }
        }
        private void ResetTextbox()
        {
            this.tb1.Text = "";
            this.tb2.Text = "";
            this.tb3.Text = "";
            this.tb4.Text = "";
            this.tb5.Text = "";

            this.tb6.Text = "";
            this.tb7.Text = "";
            this.tb8.Text = "";
            this.tb9.Text = "";
            this.tb10.Text = "";

            this.tb11.Text = "";
            this.tb12.Text = "";
            this.tb13.Text = "";
            this.tb14.Text = "";
            this.tb15.Text = "";

            this.tb16.Text = "";
            this.tb17.Text = "";
            this.tb18.Text = "";
            this.tb19.Text = "";
            this.tb20.Text = "";

            this.tb21.Text = "";
            this.tb22.Text = "";
            this.tb23.Text = "";
            this.tb24.Text = "";
            this.tb25.Text = "";

            this.tb26.Text = "";
            this.tb27.Text = "";
            this.tb28.Text = "0";
            this.tb29.Text = "0";
            this.tb30.Text = "";


            this.tb31.Text = "";

            this.tb32.Text = "";
            this.tb33.Text = "";
            this.tb34.Text = "";
            this.tb35.Text = "";
            this.cb1.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
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
        private void tb14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                SearchDept1A searchDept1A = new SearchDept1A();
                searchDept1A.ShowDialog();
                tb14.Text = SearchDept1A.DEPT.S_NAME;
            }
        }
        private void btdong_MouseClick(object sender, MouseEventArgs e)
        {
            LoadData();
            LoadFunction();
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadStripMenu();
            tb33.Enabled = true;
            tb1.Enabled = false;
            f4ToolStripMenuItem.Checked = true;
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {//Tieu de
            bt.Text = "XÓA";
            LoadStripMenu();
            f3ToolStripMenuItem.Checked = true;
        }
        #region tool KeyDown
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb2, sender, e);
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3, tb5, sender, e);
        }
        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4, tb6, sender, e);
        }
        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb5, tb7, sender, e);
        }
        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb8, tb9, sender, e);
        }
        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb7, tb9, sender, e);
        }
        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb8, tb10, sender, e);
        }
        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb9, tb11, sender, e);
        }
        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb10, tb12, sender, e);
        }
        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb11, tb13, sender, e);
        }
        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb12, tb14, sender, e);
        }
        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb13, tb15, sender, e);
        }
        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb14, tb16, sender, e);
        }
        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb15, tb17, sender, e);
        }
        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb16, tb18, sender, e);
        }
        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb17, tb19, sender, e);
        }
        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb18, tb20, sender, e);
        }
        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb19, tb21, sender, e);
        }
        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb20, tb22, sender, e);
        }
        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb21, tb23, sender, e);
        }
        private void tb23_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb22, tb24, sender, e);
        }
        private void tb24_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb23, tb25, sender, e);
        }
        private void tb25_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb24, tb26, sender, e);
        }
        private void tb26_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb25, tb26, sender, e);
        }
        private void tb27_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb27, tb28, sender, e);
        }
        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb27, tb29, sender, e);
        }
        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb28, tb30, sender, e);
        }
        private void tb30_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb29, tb31, sender, e);
        }
        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb30, tb32, sender, e);
        }
        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb31, tb33, sender, e);
        }
        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb32, tb34, sender, e);
        }
        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb33, tb35, sender, e);
        }
        private void tb35_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb34.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                cb1.Focus();
            if (e.KeyCode == Keys.Left)
                tb34.Focus();
            if (e.KeyCode == Keys.Right)
                cb1.Focus();
        }

        private void cb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb35.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                cb1.Focus();
            if (e.KeyCode == Keys.Left)
                tb35.Focus();
            if (e.KeyCode == Keys.Right)
                cb1.Focus();
        }
        #endregion
        private void tb30_TextChanged(object sender, EventArgs e)
        {
            if (tb30.Text != "")
            {
                if (Convert.ToInt32(tb30.Text) > 2 || Convert.ToInt32(tb30.Text) < 1)
                {
                    MessageBox.Show("Sai dữ liệu");
                }
            }    
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //trả dữ liệu về
            SearchVENDC1B searchVENDC = new SearchVENDC1B();
            searchVENDC.ShowDialog();
            f5ToolStripMenuItem.Checked = true;
            LoadData();
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tieu de
            bt.Text = "SAO CHÉP";
            LoadStripMenu();
            LoadCombobox();
            //mở chức năng
            f6ToolStripMenuItem.Checked = true;
            tb33.Enabled = true;
            tb1.Text = "";
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //trả dữ liệu về
            Form1BF7 form1BF = new Form1BF7();
            form1BF.ShowDialog();
        }
    }
}
