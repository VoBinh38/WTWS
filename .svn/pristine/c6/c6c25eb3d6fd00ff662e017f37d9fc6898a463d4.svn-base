using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Modun8.Envent
{
    public partial class frmCheckQtyShouse : Form
    {
        DataProvider conn = new DataProvider();
        public frmCheckQtyShouse()
        {
            InitializeComponent();
        }
        private void frmCheckQtyShouse_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_P_NO.Text = Form8A.frm8A.P_NO;
                lbl_P_NAME_C.Text = Form8A.frm8A.P_NAME_C;
                lbl_P_NAME_E.Text = Form8A.frm8A.P_NAME_E;
                string sql = "SELECT TOP 1 QTY FROM PSHQTY WHERE P_NO='" + Form8A.frm8A.P_NO + "' AND SH_NO = 'A'";
                DataTable dt = new DataTable();
                dt = conn.readdata(sql);
                if (dt.Rows.Count > 0)
                {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["QTY"].ToString()))
                        {
                            txtKhoTN.Text = dt.Rows[0]["QTY"].ToString();
                        } 
                        else
                        {
                            txtKhoTN.Text = "0";
                        }    
                }
                else
                {
                    txtKhoTN.Text = "0";
                }    
                string sql1 = "SELECT TOP 1 QTY FROM PSHQTY WHERE P_NO='" + Form8A.frm8A.P_NO + "' AND SH_NO = 'B'";
                DataTable dt1 = new DataTable();
                dt1 = conn.readdata(sql1);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow item in dt1.Rows)
                    {
                        if (!string.IsNullOrEmpty(item["QTY"].ToString()))
                        {
                            txtKhoNN.Text = item["QTY"].ToString();
                        }
                        else
                        {
                            txtKhoNN.Text = "0";
                        }    
                    }
                }
                else
                {
                    txtKhoNN.Text = "0";
                }
                setUpdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setUpdata()
        {
            if (string.IsNullOrEmpty(Form8A.frm8A.ShouseType))
            {
                txtLanhTN.Text = "0";
                txtLanhNC.Text = "0";
            }    
            else if (Form8A.frm8A.ShouseType == "A")
            {
                txtLanhTN.Text = Form8A.frm8A.ShouseA;
                txtLanhNC.Text = "0";
            }
            else if (Form8A.frm8A.ShouseType == "B")
            {
                txtLanhTN.Text = "0";
                txtLanhNC.Text = Form8A.frm8A.ShouseB.ToString();
            }
            else
            {
                txtLanhTN.Text = Form8A.frm8A.ShouseA.ToString();
                txtLanhNC.Text = Form8A.frm8A.ShouseB.ToString();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLanhTN.Text) || string.IsNullOrEmpty(txtLanhNC.Text))
            {
                MessageBox.Show("Không được để trống!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (int.Parse(txtKhoNN.Text) < int.Parse(txtLanhNC.Text))
            {
                MessageBox.Show("Số lượng trong kho không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (int.Parse(txtKhoTN.Text) < int.Parse(txtLanhTN.Text))
            {
                MessageBox.Show("Số lượng trong kho không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int sum = int.Parse(txtLanhTN.Text) + int.Parse(txtLanhNC.Text);
                DataCheckQTyShouse.QtyShouse = sum.ToString();
                if (txtLanhTN.Text != "0" && txtLanhNC.Text == "0")
                {
                    DataCheckQTyShouse.QtyType = "A";
                    DataCheckQTyShouse.QtyShouseA = txtLanhTN.Text.ToString();
                }    
                else if (txtLanhNC.Text != "0" && txtLanhTN.Text == "0")
                {
                    DataCheckQTyShouse.QtyType = "B";
                    DataCheckQTyShouse.QtyShouseA = txtLanhNC.Text.ToString();
                }    
                else
                {
                    DataCheckQTyShouse.QtyType = "AB";
                    DataCheckQTyShouse.QtyShouseA = txtLanhTN.Text.ToString();
                    DataCheckQTyShouse.QtyShouseB = txtLanhNC.Text.ToString();
                }
                this.Hide();
                this.Close();
            }    
                
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void txtLanhTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtLanhNC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        public class DataCheckQTyShouse
        {
            public static string QtyShouse;
            public static string QtyShouseA;
            public static string QtyShouseB;
            public static string QtyType;
        }
    }
}
