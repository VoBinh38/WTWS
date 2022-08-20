using PURCHASE.MAINCODE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PURCHASE.FormCenter
{
    public partial class Language : Form
    {
        DataProvider conn = new DataProvider();
        public Language()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string User = frmLogin.ID_USER;
            string check = "";
            try
            {
                if (txtThongBao.ToString() == "")
                {
                    txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
                }
                if (rdVN.Checked == true)
                {
                    check = "1";
                }
                else if (rdEN.Checked == true)
                {
                    check = "2";
                }
                else if (rdCH.Checked == true)
                {
                    check = "3";
                }
                string sql = "UPDATE USRH set LANGUAGE = '" + check + "' from USRH where USER_ID = '" + User + "'";
                bool kiemtra = conn.exedata(sql);
                if (kiemtra == true)
                {
                    CaluculateAll(progressBar1);
                    DialogResult dialog = MessageBox.Show(txtThongBao, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
                else
                {
                    CaluculateAll(progressBar1);
                    MessageBox.Show(txtThongBao1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void check()
        {
            string User = frmLogin.ID_USER;
            string sql = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["LANGUAGE"].ToString() == "1")
                {
                    txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
                    txtThongBao1 = "Chuyển Đổi Ngôn Ngữ Thất Bại";
                    rdVN.Text = "Tiếng Việt";
                    rdEN.Text = "Tiếng Anh";
                    rdCH.Text = "Tiếng Trung";
                    this.Text = "Thay Đổi Ngôn Ngữ";
                    groupBox1.Text = "Ngôn Ngữ";
                    btnOK.Text = "Đồng Ý";
                    rdVN.Checked = true;
                }
                else if (dataRow["LANGUAGE"].ToString() == "2")
                {
                    txtThongBao = "Language Switch Successfully";
                    txtThongBao1 = "Language Switch Failed";
                    rdVN.Text = "Vietnamese";
                    rdEN.Text = "English";
                    rdCH.Text = "Chinese";
                    this.Text = "Change Language";
                    groupBox1.Text = "Language";
                    btnOK.Text = "OK";
                    rdEN.Checked = true;
                }
                else if (dataRow["LANGUAGE"].ToString() == "3")
                {
                    txtThongBao = "語言切換成功";
                    txtThongBao1 = "語言切換失敗";
                    rdVN.Text = "越南語";
                    rdEN.Text = "英語";
                    rdCH.Text = "中國人";
                    this.Text = "改變語言";
                    groupBox1.Text = "語";
                    btnOK.Text = "同意";
                    rdCH.Checked = true;
                }
                else
                {
                    txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
                    txtThongBao1 = "Chuyển Đổi Ngôn Ngữ Thất Bại";
                    rdVN.Text = "Tiếng Việt";
                    rdEN.Text = "Tiếng Anh";
                    rdCH.Text = "Tiếng Trung";
                    this.Text = "Thay Đổi Ngôn Ngữ";
                    groupBox1.Text = "Ngôn Ngữ";
                    btnOK.Text = "Đồng Ý";
                    rdVN.Checked = true;
                }
            }
        }
        private void CaluculateAll(System.Windows.Forms.ProgressBar progressBar)
        {
            progressBar1.Visible = true;
            progressBar.Maximum = 30;
            progressBar.Step = 1;

            for (int j = 0; j <= 30; j++)
            {
                double pow = Math.Pow(j, j); //Calculation
                progressBar.PerformStep();

            }
        }
        string txtThongBao = "";
        string txtThongBao1 = "";
        private void rdVN_CheckedChanged(object sender, EventArgs e)
        {
            txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
            txtThongBao1 = "Chuyển Đổi Ngôn Ngữ Thất Bại";
            rdVN.Text = "Tiếng Việt";
            rdEN.Text = "Tiếng Anh";
            rdCH.Text = "Tiếng Trung";
            this.Text = "Thay Đổi Ngôn Ngữ";
            groupBox1.Text = "Ngôn Ngữ";
            btnOK.Text = "Đồng Ý";
        }

        private void rdEN_CheckedChanged(object sender, EventArgs e)
        {
            txtThongBao = "Language Switch Successfully";
            txtThongBao1 = "Language Switch Failed";
            rdVN.Text = "Vietnamese";
            rdEN.Text = "English";
            rdCH.Text = "Chinese";
            this.Text = "Change Language";
            groupBox1.Text = "Language";
            btnOK.Text = "OK";
        }

        private void rdCH_CheckedChanged(object sender, EventArgs e)
        {
            txtThongBao = "語言切換成功";
            txtThongBao1 = "語言切換失敗";
            rdVN.Text = "越南語";
            rdEN.Text = "英語";
            rdCH.Text = "中國人";
            this.Text = "改變語言";
            groupBox1.Text = "語";
            btnOK.Text = "同意";
        }

        private void Language_Load(object sender, EventArgs e)
        {
            check();
        }
    }
}
