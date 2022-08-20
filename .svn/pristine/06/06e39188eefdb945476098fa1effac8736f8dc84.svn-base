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
using LibraryCalender;
using PURCHASE.MAINCODE.Modun1;
using PURCHASE.MAINCODE;

namespace PURCHASE
{
    public partial class Form1C : Form
    {
        DataProvider conn = new DataProvider();
        public Form1C()
        {
            conn.choose_languege();
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        //check 
        string a = "";
        string b = "";
        string c = "";
        private void Form1Cqldlsanphamkhachhang_Load(object sender, EventArgs e)
        {
            Loadfisrt();
            LoadData();
            hienthidata();
            LoadData1c();
            show_lb();
            
        }
        private void Loadfisrt()
        {
            checkNofication();
            getInfo();
            conn.CheckLoad(menuStrip1);
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            btok.Hide();
            btdong.Hide();
        }
        public class getDataTable1C
        {
            public static DataTable data;
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
        #region Change language
        string txtThongBao = "";
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
                txtThongBao = "Thông Báo";
                txtText2 = "Bạn chưa nhập danh mục sản phẩm";
                txtText3 = "Bạn chưa nhập mã số sản phẩm ";
                txtText4 = "Mã Số Sản Phẩm Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                //txtText = "Bạn Không Thể Sửa 'Danh Mục Sản Phẩm' Và 'Mã Số Sản Phẩm";
                txtThongBao = "Thông Báo";
               // txtText1 = "Bạn Cần Thay Đổi Mã Số Sản Phẩm Với 16 Ký Tự";
                txtText2 = "Bạn chưa nhập danh mục sản phẩm";
                txtText3 = "Bạn chưa nhập mã số sản phẩm ";
                txtText4 = "Mã Số Sản Phẩm Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
               // txtText = "You Can't Edit 'Product Category' and 'Product Number'";
                txtThongBao = "Nofication";
               // txtText1 = "You Need To Change Product Code With 16 Characters";
                txtText2 = "You have not entered the product category";
                txtText3 = "You have not entered the product number";
                txtText4 = "Product Code Existing \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
               // txtText = "您不能編輯“產品類別”和“產品編號”";
                txtThongBao = "通知";
               // txtText1 = "您需要更改 16 個字符的產品代碼";
                txtText2 = "您尚未輸入產品類別";
                txtText3 = "您尚未輸入產品編號";
                txtText4 = "產品代碼已存在 \n 請單擊確定，[關閉] 並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }

        }
        #endregion
        public void LoadData()
        {
            if (f5ToolStripMenuItem.Checked == false)
            {
                string SQL = "SELECT PROD.K_NO, KIND.K_NAME, P_NO, P_NAME, P_NAME1, P_NAME3, P_NAME2, UNIT, TRANS, BUNIT, CUNIT, ISNULL(PRICE, 0) PRICE, ISNULL(P_WEG, 0) P_WEG, ISNULL(QTYKG, 0) QTYKG, ISNULL(QTYSTORE, 0) QTYSTORE, ISNULL(QTYPIC, 0) QTYPIC, BASEDATE,  ISNULL(QTYFT, 0) QTYFT, INDATE, " +
                    "ISNULL(QTYORD, 0) QTYORD, ISNULL(OUTDATE, 0) OUTDATE, ISNULL(QTYBAT, 0) QTYBAT, ISNULL(QTYPROD, 0) QTYPROD, MEMO1, MEMO2, MEMO3, MEMO4, ISNULL(COST, 0) COST, ISNULL(COST_NEW, 0) COST_NEW, ISNULL(COST_AVG, 0) COST_AVG, " +
                    "ISNULL(PM_DATE, 0) PM_DATE, ISNULL(TN_DATE, 0) TN_DATE, ISNULL(DY_DATE, 0) DY_DATE, ISNULL(GD_DATE, 0) GD_DATE, ISNULL(TN_DATE1, 0) TN_DATE1, ISNULL(DY_DATE1, 0) DY_DATE1, ISNULL(GD_DATE1, 0) GD_DATE1, ISNULL(PT_DATE, 0) PT_DATE, ISNULL(PT_FT, 0) PT_FT, ISNULL(PK_DATE, 0) PK_DATE" +
                    " FROM PROD full outer join KIND on PROD.K_NO = KIND.K_NO";
                datatable = conn.readdata(SQL);
              
                bindingsource.DataSource = datatable;
                getDataTable1C.data = datatable;
            }
            else
            {
                datatable = Form1CF5.ID.datatable1CF5;
                bindingsource.DataSource = datatable;
                bindingsource.Position = Form1CF5.ID.index;
            }
            hienthidata();

        }
        public void LoadData1c()
        {
            DataTable dt = new DataTable();
            BindingSource source = new BindingSource();
            try
            {
                if (tb3.Text != string.Empty)
                {
                    string sql1;
                    sql1 = "SELECT SH_NO, SH_NAME1, C_NAME, P_NAME, THICK, QTYFT, QTYPIC, QTYKG, QTYPACK, IN_DATE, OR_NO, OR_NR, K_NAME, MK_NO1 FROM PSHQTYP WHERE P_NO = '" + tb3.Text + "' ORDER BY SH_NO ASC";
                    dt = conn.readdata(sql1);
                    source.DataSource = dt;
                    data1C.DataSource = source;
                    conn.DGV(data1C);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[bindingsource].Position;
                if (position > -1)
                {
                    return ((DataRowView)bindingsource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        public void hienthidata()
        {
            tb1.Text = currenRow["K_NO"].ToString();
            tb2.Text = currenRow["K_NAME"].ToString();
            tb3.Text = currenRow["P_NO"].ToString();
            tb4.Text = currenRow["P_NAME"].ToString();
            tb5.Text = currenRow["P_NAME1"].ToString();

            tb6.Text = currenRow["P_NAME3"].ToString();
            tb7.Text = currenRow["P_NAME2"].ToString();
            tb8.Text = currenRow["UNIT"].ToString();
            tb9.Text = currenRow["TRANS"].ToString();
            tb10.Text = currenRow["BUNIT"].ToString();

            tb11.Text = currenRow["CUNIT"].ToString();
            tb12.Text = currenRow["UNIT"].ToString();
            tb13.Text = currenRow["PRICE"].ToString();
            tb14.Text = conn.FormatNumber(currenRow["P_WEG"].ToString());
            tb15.Text = conn.FormatNumber(currenRow["QTYKG"].ToString());

            tb16.Text = conn.FormatNumber((float.Parse(currenRow["QTYSTORE"].ToString()) * float.Parse(currenRow["PRICE"].ToString())).ToString());
            tb17.Text = conn.FormatNumber(currenRow["QTYPIC"].ToString());
            tb18.Text = conn.formatstr2(currenRow["BASEDATE"].ToString());
           
            tb19.Text = conn.FormatNumber((float.Parse(currenRow["QTYSTORE"].ToString()) - float.Parse(currenRow["QTYORD"].ToString())).ToString());
            if (double.Parse(tb19.Text) < 0)
            {
                label2.Text = "低於庫存量";
            }
            else if (double.Parse(tb19.Text) >= 0)
            {
                label2.Text = "";
            }    
            tb20.Text = conn.FormatNumber(currenRow["QTYFT"].ToString());

            tb21.Text = conn.formatstr2(currenRow["INDATE"].ToString());
            //tb22.Text = conn.FormatNumber(currenRow["QTYORD"].ToString());
            tb22.Text = Math.Round(decimal.Parse(currenRow["QTYORD"].ToString())).ToString();
            tb23.Text = conn.formatstr2(currenRow["OUTDATE"].ToString());
            tb24.Text = currenRow["QTYBAT"].ToString();
            cb1.Text = currenRow["CUNIT"].ToString();

            tb25.Text = currenRow["QTYPROD"].ToString();
            tb26.Text = currenRow["MEMO1"].ToString();
            tb27.Text = currenRow["MEMO2"].ToString();
            tb28.Text = currenRow["MEMO3"].ToString();
            tb29.Text = currenRow["MEMO4"].ToString();

            tb30.Text = currenRow["PM_DATE"].ToString();

            tb31.Text = currenRow["TN_DATE"].ToString();
            tb32.Text = currenRow["DY_DATE"].ToString();
            tb33.Text = currenRow["GD_DATE"].ToString();
            tb34.Text = currenRow["TN_DATE1"].ToString();
            tb35.Text = currenRow["DY_DATE1"].ToString();

            tb36.Text = currenRow["GD_DATE1"].ToString();
            tb37.Text = currenRow["PT_DATE"].ToString();
            tb38.Text = currenRow["PT_FT"].ToString();
            tb39.Text = currenRow["PK_DATE"].ToString();
        }
        #region tool 1 -> 12
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            
            bindingsource.MoveFirst();
            hienthidata();
            show_lb();


            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MovePrevious();
                hienthidata();
                show_lb();

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
                bindingsource.MoveNext();
                hienthidata();
                show_lb();

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
            hienthidata();
            show_lb();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";
            btok.Show();
            btdong.Show();

            this.tb1.Text = "";
            this.tb2.Text = "";
            this.tb3.Text = "";
            this.tb4.Text = "";
            this.tb5.Text = "";

            this.tb6.Text = "";
            this.tb7.Text = "";
            this.tb8.Text = "";
            this.tb9.Text = "0";
            this.tb10.Text = "";

            this.tb11.Text = "";
            this.tb12.Text = "";
            this.tb13.Text = "0";
            this.tb14.Text = "0";
            this.tb15.Text = "0";

            this.tb16.Text = "0";
            this.tb17.Text = "0";
            this.tb18.Text = "";
            this.tb19.Text = "";
            this.tb20.Text = "0";

            this.tb22.Text = "0";
            this.tb23.Text = "";
            this.tb24.Text = "0";
            this.cb1.Text = "";
            this.tb25.Text = "0";

            this.tb26.Text = "";
            this.tb27.Text = "";
            this.tb28.Text = "";
            this.tb29.Text = "";

            this.tb30.Text = "0";
            this.tb31.Text = "0";
            this.tb32.Text = "0";
            this.tb33.Text = "0";
            this.tb34.Text = "0";
            this.tb35.Text = "0";

            this.tb36.Text = "0";
            this.tb37.Text = "0";
            this.tb38.Text = "0";
            this.tb39.Text = "0";


            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtXoa + "";
            btok.Show();
            btdong.Show();

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtSua + "";
            btok.Show();
            btdong.Show();

            tb1.Enabled = false;
            tb3.Enabled = false;
            tb2.Enabled = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5ToolStripMenuItem.Checked = true;
            checkNofication();
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            LoadData();
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            bt.Text = "COPY";
            btok.Show();
            btdong.Show();

            this.tb1.Enabled = true;
            this.tb2.Enabled = true;
            this.tb3.Enabled = true;
            this.tb4.Enabled = true;
            this.tb5.Enabled = true;

            this.tb6.Enabled = true;
            this.tb7.Enabled = true;
            this.tb8.Enabled = true;
            this.tb9.Enabled = true;
            this.tb10.Enabled = true;

            this.tb11.Enabled = true;
            this.tb12.Enabled = false;
            this.tb13.Enabled = true;
            this.tb14.Enabled = true;
            this.tb15.Enabled = true;

            this.tb16.Enabled = true;
            this.tb17.Enabled = true;
            this.tb18.Enabled = true;
            this.tb19.Enabled = false;
            this.tb20.Enabled = true;

            this.tb21.Enabled = true;
            this.tb22.Enabled = true;
            this.tb23.Enabled = true;
            this.tb24.Enabled = true;
            this.cb1.Enabled = false;
            this.tb25.Enabled = true;

            this.tb26.Enabled = true;
            this.tb27.Enabled = true;
            this.tb28.Enabled = true;
            this.tb29.Enabled = true;

            this.tb30.Enabled = true;
            this.tb31.Enabled = true;
            this.tb32.Enabled = true;
            this.tb33.Enabled = true;
            this.tb34.Enabled = true;
            this.tb35.Enabled = true;

            this.tb36.Enabled = true;
            this.tb37.Enabled = true;
            this.tb38.Enabled = true;
            this.tb39.Enabled = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1CF7 fr = new Form1CF7();
            //this.Hide();
            //fr.ShowDialog();
            //this.Close();
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            Loadfisrt();
            LoadData();
            hienthidata();
            LoadData1c();
            show_lb();
        }
        #endregion
        private void btok_Click(object sender, EventArgs e)
        {

            check();
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                Adddata();
                
            }
            else if(f3ToolStripMenuItem.Checked == true)
            {
                string masanpham = tb3.Text;
                if (masanpham == "")
                {
                    MessageBox.Show(""+txtNodata+"");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from PROD where P_NO ='" + masanpham + "'";
                        cm.ExecuteNonQuery();
                        con.Close();
                        LoadData();
                        hienthidata();
                        

                        btok.Hide();
                        btdong.Hide();

                        f1ToolStripMenuItem.Enabled = false;
                        f2ToolStripMenuItem.Enabled = true;
                        f3ToolStripMenuItem.Enabled = true;
                        f4ToolStripMenuItem.Enabled = true;
                        f5ToolStripMenuItem.Enabled = true;
                        f6ToolStripMenuItem.Enabled = true;
                        f7ToolStripMenuItem.Enabled = true;
                        f8ToolStripMenuItem.Enabled = false;
                        f10ToolStripMenuItem.Enabled = true;

                        btdau.Enabled = true;
                        bttruoc.Enabled = true;
                        btsau.Enabled = true;
                        btketthuc.Enabled = true;
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

            else if(f4ToolStripMenuItem.Checked == true)
            {
                
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.PROD set K_NO= @K_NO, P_NO= @P_NO, P_NAME= @P_NAME, P_NAME1= @P_NAME1, P_NAME3= @P_NAME3, P_NAME2= @P_NAME2, UNIT= @UNIT, TRANS= @TRANS, BUNIT= @BUNIT, CUNIT= @CUNIT, PRICE= @PRICE, P_WEG= @P_WEG, QTYKG= @QTYKG, QTYSTORE= @QTYSTORE, QTYPIC= @QTYPIC, BASEDATE= @BASEDATE, QTYFT= @QTYFT, INDATE= @INDATE," +
                    " QTYORD= @QTYORD, OUTDATE= @OUTDATE, QTYBAT= @QTYBAT, QTYPROD= @QTYPROD, MEMO1= @MEMO1, MEMO2= @MEMO2, MEMO3= @MEMO3, MEMO4= @MEMO4, COST= @COST, COST_NEW= @COST_NEW, COST_AVG= @COST_AVG, PM_DATE= @PM_DATE, TN_DATE= @TN_DATE, DY_DATE= @DY_DATE, GD_DATE= @GD_DATE, TN_DATE1= @TN_DATE1, DY_DATE1= @DY_DATE1, GD_DATE1= @GD_DATE1, PT_DATE= @PT_DATE, PT_FT= @PT_FT, PK_DATE= @PK_DATE where P_NO = @P_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                //cm.Parameters.AddWithValue("@K_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@P_NO", tb3.Text);
                cm.Parameters.AddWithValue("@P_NAME", tb4.Text);
                cm.Parameters.AddWithValue("@P_NAME1", tb5.Text);

                cm.Parameters.AddWithValue("@P_NAME3", tb6.Text);
                cm.Parameters.AddWithValue("@P_NAME2", tb7.Text);
                cm.Parameters.AddWithValue("@UNIT", tb8.Text);
                cm.Parameters.AddWithValue("@TRANS", float.Parse(tb9.Text));
                cm.Parameters.AddWithValue("@BUNIT", tb10.Text);

                cm.Parameters.AddWithValue("@CUNIT", tb11.Text);
                //cm.Parameters.AddWithValue("@", tb12.Text);
                cm.Parameters.AddWithValue("@PRICE", float.Parse(tb13.Text));
                cm.Parameters.AddWithValue("@P_WEG", float.Parse(tb14.Text));
                cm.Parameters.AddWithValue("@QTYKG", float.Parse(tb15.Text));

                cm.Parameters.AddWithValue("@QTYSTORE", float.Parse(tb16.Text));
                cm.Parameters.AddWithValue("@QTYPIC", float.Parse(tb17.Text));
                cm.Parameters.AddWithValue("@BASEDATE", conn.formatstr2(a));
                //cm.Parameters.AddWithValue("@", tb19.Text);
                cm.Parameters.AddWithValue("@QTYFT", float.Parse(tb20.Text));

                cm.Parameters.AddWithValue("@INDATE", conn.formatstr2(b));
                cm.Parameters.AddWithValue("@QTYORD", float.Parse(tb22.Text));
                cm.Parameters.AddWithValue("@OUTDATE", conn.formatstr2(c));
                cm.Parameters.AddWithValue("@QTYBAT", float.Parse(tb24.Text));
                // cm.Parameters.AddWithValue("", cb1.Text);
                cm.Parameters.AddWithValue("@QTYPROD", float.Parse(tb25.Text));

                cm.Parameters.AddWithValue("@MEMO1", tb26.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb27.Text);
                cm.Parameters.AddWithValue("@MEMO3", tb28.Text);
                cm.Parameters.AddWithValue("@MEMO4", tb29.Text);

                cm.Parameters.AddWithValue("@PM_DATE", float.Parse(tb30.Text));
                cm.Parameters.AddWithValue("@TN_DATE", float.Parse(tb31.Text));
                cm.Parameters.AddWithValue("@DY_DATE", float.Parse(tb32.Text));
                cm.Parameters.AddWithValue("@GD_DATE", float.Parse(tb33.Text));
                cm.Parameters.AddWithValue("@TN_DATE1", float.Parse(tb34.Text));

                cm.Parameters.AddWithValue("@DY_DATE1", float.Parse(tb35.Text));
                cm.Parameters.AddWithValue("@GD_DATE1", float.Parse(tb36.Text));
                cm.Parameters.AddWithValue("@PT_DATE", float.Parse(tb37.Text));
                cm.Parameters.AddWithValue("@PT_FT", float.Parse(tb38.Text));
                cm.Parameters.AddWithValue("@PK_DATE", float.Parse(tb39.Text));

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show(""+txtText2+"");
                    return;
                }
                else if (tb3.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }

                try
                {
                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthidata();
                    

                    btok.Hide();
                    btdong.Hide();

                    f1ToolStripMenuItem.Enabled = false;
                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = ""+txtDuyet+"";


                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;

                    tb1.Enabled = true;
                    tb3.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if(f6ToolStripMenuItem.Checked == true)
            {
              
                string a = tb3.Text;
                string SQL = "select P_NO from PROD";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["P_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show(""+txtText4+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb3.Focus();
                        }
                    }
                }
                catch
                {

                }
                con = new SqlConnection(st);
                con.Open();

                string st1 = "insert into dbo.PROD(K_NO, P_NO, P_NAME, P_NAME1, P_NAME3, P_NAME2, UNIT, TRANS, BUNIT, CUNIT, PRICE, P_WEG, QTYKG, QTYSTORE, QTYPIC, BASEDATE, QTYFT, INDATE, QTYORD, OUTDATE, QTYBAT, QTYPROD, MEMO1, MEMO2, MEMO3, MEMO4, COST, COST_NEW, COST_AVG, PM_DATE, TN_DATE, DY_DATE, GD_DATE, TN_DATE1, DY_DATE1, GD_DATE1, PT_DATE, PT_FT, PK_DATE) values" +
                    "(@K_NO, @P_NO, @P_NAME, @P_NAME1, @P_NAME3, @P_NAME2, @UNIT, @TRANS, @BUNIT, @CUNIT, @PRICE, @P_WEG, @QTYKG, @QTYSTORE, @QTYPIC, @BASEDATE, @QTYFT, @INDATE, @QTYORD, @OUTDATE, @QTYBAT, @QTYPROD, @MEMO1, @MEMO2, @MEMO3, @MEMO4, @COST, @COST_NEW, @COST_AVG, @PM_DATE, @TN_DATE, @DY_DATE, @GD_DATE, @TN_DATE1, @DY_DATE1, @GD_DATE1, @PT_DATE, @PT_FT, @PK_DATE)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                //cm.Parameters.AddWithValue("@K_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@P_NO", tb3.Text);
                cm.Parameters.AddWithValue("@P_NAME", tb4.Text);
                cm.Parameters.AddWithValue("@P_NAME1", tb5.Text);

                cm.Parameters.AddWithValue("@P_NAME3", tb6.Text);
                cm.Parameters.AddWithValue("@P_NAME2", tb7.Text);
                cm.Parameters.AddWithValue("@UNIT", tb8.Text);
                cm.Parameters.AddWithValue("@TRANS", float.Parse(tb9.Text));
                cm.Parameters.AddWithValue("@BUNIT", tb10.Text);

                cm.Parameters.AddWithValue("@CUNIT", tb11.Text);
                //cm.Parameters.AddWithValue("@", tb12.Text);
                cm.Parameters.AddWithValue("@PRICE", float.Parse(tb13.Text));
                cm.Parameters.AddWithValue("@P_WEG", float.Parse(tb14.Text));
                cm.Parameters.AddWithValue("@QTYKG", float.Parse(tb15.Text));

                cm.Parameters.AddWithValue("@QTYSTORE", float.Parse(tb16.Text));
                cm.Parameters.AddWithValue("@QTYPIC", float.Parse(tb17.Text));
                cm.Parameters.AddWithValue("@BASEDATE", conn.formatstr2(a));
                //cm.Parameters.AddWithValue("@", tb19.Text);
                cm.Parameters.AddWithValue("@QTYFT", float.Parse(tb20.Text));

                cm.Parameters.AddWithValue("@INDATE", conn.formatstr2(b));
                cm.Parameters.AddWithValue("@QTYORD", float.Parse(tb22.Text));
                cm.Parameters.AddWithValue("@OUTDATE", conn.formatstr2(c));
                cm.Parameters.AddWithValue("@QTYBAT", float.Parse(tb24.Text));
                // cm.Parameters.AddWithValue("", cb1.Text);
                cm.Parameters.AddWithValue("@QTYPROD", float.Parse(tb25.Text));

                cm.Parameters.AddWithValue("@MEMO1", tb26.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb27.Text);
                cm.Parameters.AddWithValue("@MEMO3", tb28.Text);
                cm.Parameters.AddWithValue("@MEMO4", tb29.Text);

               
                cm.Parameters.AddWithValue("@PM_DATE", float.Parse(tb30.Text));
                cm.Parameters.AddWithValue("@TN_DATE", float.Parse(tb31.Text));
                cm.Parameters.AddWithValue("@DY_DATE", float.Parse(tb32.Text));
                cm.Parameters.AddWithValue("@GD_DATE", float.Parse(tb33.Text));
                cm.Parameters.AddWithValue("@TN_DATE1", float.Parse(tb34.Text));

                cm.Parameters.AddWithValue("@DY_DATE1", float.Parse(tb35.Text));
                cm.Parameters.AddWithValue("@GD_DATE1", float.Parse(tb36.Text));
                cm.Parameters.AddWithValue("@PT_DATE", float.Parse(tb37.Text));
                cm.Parameters.AddWithValue("@PT_FT", float.Parse(tb38.Text));
                cm.Parameters.AddWithValue("@PK_DATE", float.Parse(tb39.Text));

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show(""+txtText2+"");
                    return;
                }
                else if (tb3.Text == string.Empty)
                {
                    MessageBox.Show(""+txtText3+"");
                    return;
                }

                try
                {
                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthidata();
                  

                    btok.Hide();
                    btdong.Hide();

                    f1ToolStripMenuItem.Enabled = false;
                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
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

        private void Adddata()
        {
            try
            {
                if (string.IsNullOrEmpty(tb1.Text))
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (string.IsNullOrEmpty(tb3.Text))
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else
                {
                    con = new SqlConnection(st);
                    con.Open();
                    string st1 = "insert into dbo.PROD(K_NO, P_NO, P_NAME, P_NAME1, P_NAME3, P_NAME2, UNIT, TRANS, BUNIT, CUNIT, PRICE, P_WEG, QTYKG, QTYSTORE, QTYPIC, BASEDATE, QTYFT, INDATE, QTYORD, OUTDATE, QTYBAT, QTYPROD, MEMO1, MEMO2, MEMO3, MEMO4, COST, COST_NEW, COST_AVG, PM_DATE, TN_DATE, DY_DATE, GD_DATE, TN_DATE1, DY_DATE1, GD_DATE1, PT_DATE, PT_FT, PK_DATE) values" +
                        "(@K_NO, @P_NO, @P_NAME, @P_NAME1, @P_NAME3, @P_NAME2, @UNIT, @TRANS, @BUNIT, @CUNIT, @PRICE, @P_WEG, @QTYKG, @QTYSTORE, @QTYPIC, @BASEDATE, @QTYFT, @INDATE, @QTYORD, @OUTDATE, @QTYBAT, @QTYPROD, @MEMO1, @MEMO2, @MEMO3, @MEMO4, @COST, @COST_NEW, @COST_AVG, @PM_DATE, @TN_DATE, @DY_DATE, @GD_DATE, @TN_DATE1, @DY_DATE1, @GD_DATE1, @PT_DATE, @PT_FT, @PK_DATE)";
                    SqlCommand cm = new SqlCommand(st1, con);

                    cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                    //cm.Parameters.AddWithValue("@K_NAME", tb2.Text);
                    cm.Parameters.AddWithValue("@P_NO", tb3.Text);
                    cm.Parameters.AddWithValue("@P_NAME", tb4.Text);
                    cm.Parameters.AddWithValue("@P_NAME1", tb5.Text);

                    cm.Parameters.AddWithValue("@P_NAME3", tb6.Text);
                    cm.Parameters.AddWithValue("@P_NAME2", tb7.Text);
                    cm.Parameters.AddWithValue("@UNIT", tb8.Text);
                    cm.Parameters.AddWithValue("@TRANS", float.Parse(tb9.Text));
                    cm.Parameters.AddWithValue("@BUNIT", tb10.Text);

                    cm.Parameters.AddWithValue("@CUNIT", tb11.Text);
                    //cm.Parameters.AddWithValue("@", tb12.Text);
                    cm.Parameters.AddWithValue("@PRICE", float.Parse(tb13.Text));
                    cm.Parameters.AddWithValue("@P_WEG", float.Parse(tb14.Text));
                    cm.Parameters.AddWithValue("@QTYKG", float.Parse(tb15.Text));

                    cm.Parameters.AddWithValue("@QTYSTORE", float.Parse(tb16.Text));
                    cm.Parameters.AddWithValue("@QTYPIC", float.Parse(tb17.Text));
                    cm.Parameters.AddWithValue("@BASEDATE", conn.formatstr2(a));
                    //cm.Parameters.AddWithValue("@", tb19.Text);
                    cm.Parameters.AddWithValue("@QTYFT", float.Parse(tb20.Text));

                    cm.Parameters.AddWithValue("@INDATE", conn.formatstr2(b));
                    cm.Parameters.AddWithValue("@QTYORD", float.Parse(tb22.Text));
                    cm.Parameters.AddWithValue("@OUTDATE", conn.formatstr2(c));
                    cm.Parameters.AddWithValue("@QTYBAT", float.Parse(tb24.Text));
                    // cm.Parameters.AddWithValue("", cb1.Text);
                    cm.Parameters.AddWithValue("@QTYPROD", float.Parse(tb25.Text));

                    cm.Parameters.AddWithValue("@MEMO1", tb26.Text);
                    cm.Parameters.AddWithValue("@MEMO2", tb27.Text);
                    cm.Parameters.AddWithValue("@MEMO3", tb28.Text);
                    cm.Parameters.AddWithValue("@MEMO4", tb29.Text);


                    cm.Parameters.AddWithValue("@PM_DATE", float.Parse(tb30.Text));
                    cm.Parameters.AddWithValue("@TN_DATE", float.Parse(tb31.Text));
                    cm.Parameters.AddWithValue("@DY_DATE", float.Parse(tb32.Text));
                    cm.Parameters.AddWithValue("@GD_DATE", float.Parse(tb33.Text));
                    cm.Parameters.AddWithValue("@TN_DATE1", float.Parse(tb34.Text));

                    cm.Parameters.AddWithValue("@DY_DATE1", float.Parse(tb35.Text));
                    cm.Parameters.AddWithValue("@GD_DATE1", float.Parse(tb36.Text));
                    cm.Parameters.AddWithValue("@PT_DATE", float.Parse(tb37.Text));
                    cm.Parameters.AddWithValue("@PT_FT", float.Parse(tb38.Text));
                    cm.Parameters.AddWithValue("@PK_DATE", float.Parse(tb39.Text));
                    if (cm.ExecuteNonQuery() > 0)
                    {
                        AddPSHQTYP();
                        Loadfisrt();
                        LoadData();
                        hienthidata();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddPSHQTYP()
        {
            //string sql = "INSERT INTO PSHQTYP(P_NO, C_NO, THICK, OR_NO, OR_NR, SH_NO, QTYKG, QTYFT, QTYPIC, K_NO, P_NAME, MK_NO1, SH_NO1, IN_DATE, QTYPACK) " +
            //    "SELECT '"+tb3.Text+"',";
        }
        public void show_lb()
        {
            lb.Text = tb3.Text + " " + tb4.Text + "  " + tb5.Text;
            lb.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSeachKIND fr = new FormSeachKIND();
                fr.ShowDialog();
                tb1.Text = FormSeachKIND.GUI_FORM1C.tx1;
                tb2.Text = FormSeachKIND.GUI_FORM1C.tx2;
            }
        

        }
        private void tb13_TextChanged(object sender, EventArgs e)
        {
           // tb13.Text = string.Format("{0:#,##0.00}", tb13.Text);
        }

        private void tb14_TextChanged(object sender, EventArgs e)
        {
           //tb14.Text = string.Format("{0:#,##0.00}", tb14.Text);
        }

        private void tb15_TextChanged(object sender, EventArgs e)
        {
            //tb15.Text = string.Format("{0:#,##0.00}", tb15.Text);
        }

        private void tb16_TextChanged(object sender, EventArgs e)
        {
           // tb16.Text = string.Format("{0:#,##0.00}", tb16.Text);
        }

        private void tb17_TextChanged(object sender, EventArgs e)
        {
           // tb17.Text = string.Format("{0:#,##0.00}", tb17.Text);
        }

        private void tb19_TextChanged(object sender, EventArgs e)
        {
            //tb19.Text = string.Format("{0:#,##0.00}", tb19.Text);
        }

        private void tb20_TextChanged(object sender, EventArgs e)
        {
            //tb20.Text = string.Format("{0:#,##0.00}", tb20.Text);
        }

        private void tb22_TextChanged(object sender, EventArgs e)
        {
          //  tb22.Text = string.Format("{0:#,##0.00}", tb22.Text);
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
            tab(tb39, tb2, sender, e);
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
            tab(tb3, tb5, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb4, tb6, sender, e);
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb5, tb7, sender, e);
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb8, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb7, tb9, sender, e);
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb8, tb10, sender, e);
        }

        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb9, tb11, sender, e);
        }

        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb10, tb12, sender, e);
        }

        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb11, tb13, sender, e);
        }

        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb12, tb14, sender, e);
        }

        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb15, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb14, tb16, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb16, tb18, sender, e);
        }

        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb17, tb19, sender, e);
        }

        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb18, tb20, sender, e);
        }

        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb19, tb21, sender, e);
        }

        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb20, tb22, sender, e);
        }

        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP_DOWN(tb21, tb23, sender, e);
        }

        private void tb23_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb22, tb24, sender, e);
        }

        private void tb24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cb1.Focus();
            }
        }

        private void cb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb25.Focus();
            }
        }
        private void tb25_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb24, tb1, sender, e);
        }

        private void tb26_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb25, tb27, sender, e);
        }

        private void tb27_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb26, tb28, sender, e);
        }

        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb27, tb29, sender, e);
        }

        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb28, tb26, sender, e);
        }
        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb30, tb32, sender, e);
        }

        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb31, tb33, sender, e);
        }

        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb32, tb34, sender, e);
        }

        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb33, tb35, sender, e);
        }

        private void tb35_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb34, tb36, sender, e);
        }

        private void tb36_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb35, tb37, sender, e);
        }

        private void tb37_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb36, tb38, sender, e);
        }

        private void tb38_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb37, tb39, sender, e);
        }
        private void tb39_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb38, tb30, sender, e);
        }

        private void tb26_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if((f2ToolStripMenuItem.Checked==true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            //{
            //    FormSearchLeather2 fr = new FormSearchLeather2();
            //    fr.ShowDialog();
            //}

            //string dl1 = FormSearchLeather2.FORM1C_DL.T1;
            //if (dl1 != string.Empty)
            //    Get_tb1();

            //if (tb26.Text == string.Empty)
            //{
            //    LoadData();
            //    hienthidata();
            //}

        }

        private void tb27_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            //{
            //    FormSearchLeather2 fr = new FormSearchLeather2();
            //    fr.ShowDialog();
            //}
            //string dl1 = FormSearchLeather2.FORM1C_DL.T1;
            //if (dl1 != string.Empty)
            //    Get_tb1();

            //if (tb27.Text == string.Empty)
            //{
            //    LoadData();
            //    hienthidata();
            //}
        }

        private void tb28_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            //{
            //    FormSearchLeather2 fr = new FormSearchLeather2();
            //    fr.ShowDialog();
            //}
            //string dl1 = FormSearchLeather2.FORM1C_DL.T1;
            //if (dl1 != string.Empty)
            //    Get_tb1();

            //if (tb28.Text == string.Empty)
            //{
            //    LoadData();
            //    hienthidata();
            //}
        }

        private void tb29_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            //{
            //    FormSearchLeather2 fr = new FormSearchLeather2();
            //    fr.ShowDialog();
            //}
            //string dl1 = FormSearchLeather2.FORM1C_DL.T1;
            //if (dl1 != string.Empty)
            //    Get_tb1();

            //if (tb29.Text == string.Empty)
            //{
            //    LoadData();
            //    hienthidata();
            //}
        }

        private void tb19_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true)
            {
                tb19.Text = (float.Parse(tb16.Text) - float.Parse(tb25.Text)).ToString();
            }
            
        }

        private void tb43_Click(object sender, EventArgs e)
        {
            //if (f2ToolStripMenuItem.Checked == true)
            //{
            //    tb43.Text = (float.Parse(tb41.Text) * float.Parse(tb16.Text)).ToString();
            //}        
        }
       private void tb18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb18.Text = FromCalender.getDate.ToString("yyyyMMdd");

        }
        private void tb21_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb21.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb23_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb23.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
        private void check()
        {
            if (conn.Check_MaskedText(tb18) == true)
            {
                a = tb18.Text;
            }
            if (conn.Check_MaskedText(tb21) == true)
            {
                b = tb21.Text;
            }
            if (conn.Check_MaskedText(tb21) == true)
            {
                c = tb23.Text;
            }
        }

        private void btnTimeNow_Click(object sender, EventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {
            LoadData1c();
        }

        private void tb8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                frmSearchMemo frmSearchMe = new frmSearchMemo();
                frmSearchMe.ShowDialog();
                tb8.Text = frmSearchMemo.getMeMo.M_NAME;
            }
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                string sql = "SELECT TOP 1 * FROM KIND WHERE K_NAME = '" + tb1.Text + "'";
                DataTable data = new DataTable();
                data = conn.readdata(sql);
                tb1.Text = data.Rows[0]["K_NO"].ToString();
                tb2.Text = data.Rows[0]["K_NAME"].ToString();
            }
        }

        private void tb10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                frmSearchMemo frmSearchMe = new frmSearchMemo();
                frmSearchMe.ShowDialog();
                tb10.Text = frmSearchMemo.getMeMo.M_NAME;
            }
        }

        private void tb11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
