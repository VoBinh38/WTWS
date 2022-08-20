using PURCHASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Modun8
{
    public partial class frmSearchOrder : Form
    {
        DataProvider con = new DataProvider();
        public frmSearchOrder()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }

        private void frmSearchOrder_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        void LoadDGV()
        {
            //txtCustNo.Text = frm2C_1.F2c.MaKH;
            string SQL = "SELECT OR_NO, WS_DATE, COLOR_C, COLOR_E, P_NAME_C, P_NAME_E, THICK, QTY, NR, C_NO, C_NAME_C, C_NAME_E, BRAND, MODEL_C, MODEL_E, P_NO, PATT_C, PATT_E, K_NO  FROM ORDB WHERE C_NO = '" + txtCustNo.Text + "' AND OVER0 = 'N' ORDER BY  OR_NO DESC";
            DataTable dt = con.readdata(SQL);
            foreach (DataRow dr in dt.Rows)
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            DGV3.DataSource = dt;
            DGV3.MyDGV();
        }
        void Search()
        {
            string SQL1 = "SELECT OR_NO, WS_DATE, COLOR_C, COLOR_E, P_NAME_C, P_NAME_E, THICK, QTY, NR, C_NO, C_NAME_C, C_NAME_E, BRAND, MODEL_C, MODEL_E, P_NO, PATT_C, PATT_E, K_NO  FROM ORDB WHERE 1=1 ";
            if (txtDate.Text != string.Empty)
                SQL1 = SQL1 + " AND WS_DATE LIKE '%" + txtDate.Text + "%' ";
            if (txtSoDH.Text != string.Empty)
                SQL1 = SQL1 + " AND OR_NO LIKE '%" + txtSoDH.Text + "%' ";

            DataTable dt1= con.readdata(SQL1);
            DGV3.DataSource = dt1;
            DGV3.MyDGV();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<string> ds = new List<string>();
        public class LV
        {
            public static List<string> L1 = new List<string>();
            public static List<string> L2 = new List<string>();
            public static List<string> L3 = new List<string>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LV.L1.Clear();
            LV.L2.Clear();
            LV.L3.Clear();
            for(int i = 0; i < DGV3.Rows.Count -1; i++)
            {
                bool Selectet = Convert.ToBoolean(DGV3.Rows[i].Cells[0].Value);
                if(Selectet == true)
                {
                    string add2 = DGV3.Rows[i].Cells[1].Value.ToString();
                    LV.L1.Add(DGV3.Rows[i].Cells[1].Value.ToString());
                    LV.L2.Add(DGV3.Rows[i].Cells[9].Value.ToString());
                    LV.L3.Add(DGV3.Rows[i].Cells[19].Value.ToString());
                    ds.Add(add2);
                }
            }
            for(int i=0; i>= LV.L1.Count; i++)
            MessageBox.Show(LV.L1[i]);


           // frm2C.Share2C.dsInt = ds;
            this.Close();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtSoDH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search();
        }

      
    }
}
