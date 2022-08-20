using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class frmSearchOrder : Form
    {
        DataProvider conn = new DataProvider();
        string SQL1 = "";
        public frmSearchOrder()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void frmSearchOrder_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        void LoadDGV()
        {
            //txtCustNo.Text = frm2C_1.F2c.MaKH;
            string SQL = "SELECT C_ANAME,P_NO,P_NAME,P_NAME1,P_NAME3,QTYSTORE,PRICE,K_NO_O,UNIT,PLACE,M_NAME,BUNIT FROM dbo.PROD1C INNER JOIN VENDC ON VENDC.C_NO = PROD1C.C_NO INNER JOIN(SELECT DISTINCT M_NO, M_NAME FROM " +
                "dbo.MONEYT WHERE WS_DATE in (SELECT B.WS_DATE FROM (SELECT M_NO, MAX(WS_DATE) AS WS_DATE FROM MONEYT GROUP BY M_NO) AS B)) AS MONEYT ON MONEYT.M_NO = PROD1C.M_TRAN WHERE QTYSTORE>0 ORDER BY QDATE";
            DataTable dt = conn.readdata(SQL);
            DGV3.DataSource = dt;
            conn.DGV(DGV3);
            this.DGV3.Columns["BUNIT"].Visible = false;
        }
        void Search()
        {
            SQL1 = "SELECT C_ANAME,P_NO,P_NAME,P_NAME1,P_NAME3,QTYSTORE,PRICE,K_NO_O,UNIT,PLACE,M_NAME,BUNIT FROM dbo.PROD1C INNER JOIN VENDC ON VENDC.C_NO = PROD1C.C_NO INNER JOIN(SELECT DISTINCT M_NO, M_NAME FROM " +
                "dbo.MONEYT WHERE WS_DATE in (SELECT B.WS_DATE FROM (SELECT M_NO, MAX(WS_DATE) AS WS_DATE FROM MONEYT GROUP BY M_NO) AS B)) AS MONEYT ON MONEYT.M_NO = PROD1C.M_TRAN WHERE QTYSTORE>0 AND 1=1";
            checkIF();
             SQL1 = SQL1 + " ORDER BY QDATE";
            DataTable dt1 = conn.readdata(SQL1);
            DGV3.DataSource = dt1;
            conn.DGV(DGV3);
            this.DGV3.Columns["BUNIT"].Visible = false;
           
        }
        private void checkIF()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                SQL1 = SQL1 + " AND PLACE LIKE '%" + textBox1.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                SQL1 = SQL1 + " AND P_NO LIKE '%" + textBox2.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                SQL1 = SQL1 + " AND P_NAME LIKE '%" + textBox3.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                SQL1 = SQL1 + " AND P_NAME3 LIKE '%" + textBox4.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                SQL1 = SQL1 + " AND P_NAME1 LIKE '%" + textBox5.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                SQL1 = SQL1 + " AND C_NO LIKE '%" + textBox6.Text + "%'";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ID.list.Clear();
            this.Close();
        }
        public class List1
        {
            public string P_NO { get; set; }
            public string P_NAME { get; set; }
            public string P_NAME1 { get; set; }
            public string P_NAME3 { get; set; }
            public string BUNIT { get; set; }
            public string K_NO_O { get; set; }
        }
        public class ID
        {
            public static List<List1> list = new List<List1>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ID.list.Clear();
            //DataTable da = new DataTable();
            var da = DGV3.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells[0].Value) == true).ToList();
            for (int i = 0; i <= da.Count - 1; i++)
            {
                ID.list.Add(new List1
                {
                    P_NO = DGV3.Rows[da[i].Index].Cells["P_NO"].Value.ToString(),
                    P_NAME = DGV3.Rows[da[i].Index].Cells["P_NAME"].Value.ToString(),
                    P_NAME1 = DGV3.Rows[da[i].Index].Cells["P_NAME1"].Value.ToString(),
                    P_NAME3 = DGV3.Rows[da[i].Index].Cells["P_NAME3"].Value.ToString(),
                    BUNIT = DGV3.Rows[da[i].Index].Cells["BUNIT"].Value.ToString(),
                    K_NO_O = DGV3.Rows[da[i].Index].Cells["K_NO_O"].Value.ToString(),
                });
                this.Hide();
                this.Close();
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }
        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox4.Focus();
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox5.Focus();
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox6.Focus();
        }
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox1.Focus();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void DGV3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Convert.ToBoolean(DGV3.CurrentRow.Cells["NR"].Value) == true)
            {
                DGV3.CurrentRow.Cells["NR"].Value = false;
            } 
            else
            {
                DGV3.CurrentRow.Cells["NR"].Value = true;
            }    
        }
    }
}
