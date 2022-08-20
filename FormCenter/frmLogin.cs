using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace PURCHASE.MAINCODE
{
    public partial class frmLogin : Form
    {
        DataProvider con = new DataProvider();
        public frmLogin()
        {
            //con.choose_languege();
            InitializeComponent();
           // LoadCreadential();
        }
        //void SaveCredentials()
        //{
        //    if (checkBoxremem.Checked == true)
        //    {
        //        Properties.Settings.Default.Username = txtUser.Text;
        //        Properties.Settings.Default.Save();
        //    }
        //    else
        //    {
        //        Properties.Settings.Default.Username = "";
        //        Properties.Settings.Default.Save();
        //    }
        //}
        //void LoadCreadential()
        //{
        //    if(Properties.Settings.Default.Username != string.Empty)
        //    {
        //        txtUser.Text = Properties.Settings.Default.Username;
        //        checkBoxremem.Checked = true;
        //    }
        //}
        public static string ID_USER;
        public static string ValueLanguage;
        int dem = 0;
        string txtThongBao = "";
        string txtText = "";
        string txtText_Thoat = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = con.getID(txtUser.Text.Trim(), txtPassWord.Text.Trim());
            ValueLanguage = con.getValueLanguage();
            settxtThongBao();
            if (ID_USER != "")
            {
               // SaveCredentials();
                progressBar1.Visible = true;
                progressBar1.Maximum = 30;
                progressBar1.Step = 1;

                for (int j = 0; j <= 30; j++)
                {
                    double pow = Math.Pow(j, j); //Calculation
                    progressBar1.PerformStep();
                }
                //đăng nhập
                MAIN form8A = new MAIN();
                form8A.ShowDialog();
                this.Hide();
                this.Close();
            }
            else
            {
                dem++;
                MessageBox.Show(""+ txtText + "", ""+ txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Clear();
                txtPassWord.Focus();
                if (dem == 3)
                {
                    this.Close();
                }    
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
            settxtThongBao();
            DialogResult clo = MessageBox.Show(""+ txtText_Thoat + "", ""+ txtThongBao + "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (clo == DialogResult.OK)
            {
                con.Closeconnect();
                this.Close();
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            txtUser.ResetText();
            txtPassWord.ResetText();
            txtUser.Focus();
            lblName.Text = "";
        }
        
        void getNameID()
        {
            if(txtUser.Text != "")
            {
                string str = "Select USER_ID,NAME FROM USRH WHERE USER_ID ='" + txtUser.Text + "'";
                DataTable dt1 = con.readdata(str);
                foreach (DataRow dr in dt1.Rows)
                {
                    lblName.Text = "User: " + dr["NAME"].ToString();
                    txtUser.Text = dr["USER_ID"].ToString();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Closeconnect();
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //LoadCreadential();
            DataProvider.LG.rdEnglish = true;
            progressBar1.Visible = false;
        }
        private void txtPassWord_Click(object sender, EventArgs e)
        {
            getNameID();
        }
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                txtPassWord.Focus();
                getNameID();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
                lblName.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
  
        private void picEye_Click(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = (char)0;
            picEye.Visible = false;
            picLockEye.Visible = true;
        }

        private void picLockEye_Click(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '*';
            picEye.Visible = true;
            picLockEye.Visible = false;
        }
        private void picLockEye_MouseHover(object sender, EventArgs e)
        {

        }

        private void picEye_MouseHover(object sender, EventArgs e)
        {

        }
        public void settxtThongBao()
        {
            
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdChina == false && DataProvider.LG.rdEnglish == false)
            {
                txtText = "Tài khoảng và mật khẩu không đúng Lần : " + dem;
                txtThongBao = "Thông Báo";
                txtText_Thoat = "Bạn có muốn thoát chương trình không ?";
            } 
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Tài khoảng và mật khẩu không đúng Lần : " + dem ;
                txtThongBao = "Thông Báo";
                txtText_Thoat = "Bạn có muốn thoát chương trình không ?";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "Username and password are incorrect : " + dem;
                txtThongBao = "Nofication";
                txtText_Thoat = "Do you want to exit the program?";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "用戶名和密碼不正確 : " + dem;
                txtThongBao = "通知";
                txtText_Thoat = "您要退出程序嗎？";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = CN.getDateNowE() + " - " + CN.getTimeNow();
        }
    }
}
