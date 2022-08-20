﻿using CrystalDecisions.CrystalReports.Engine;
using PURCHASE.DataCenter;
using PURCHASE.MAINCODE.Modun4.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PURCHASE.DataCenter.Report1;

namespace PURCHASE.MAINCODE.Modun4
{
    public partial class frm4DF7 : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        ReportDocument cryRpt;
        public frm4DF7()
        {
            InitializeComponent();
            con.CheckLanguage(this);
        }

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex ==0)
            {
                PrintTab1();
            }
            else
            {
                PrintTab2();
            }
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void PrintTab2()
        {
            cryRpt = new cr_Frm4DF7_Tab2();
            string sql = "SELECT CGBBC.WS_NO,CGBBC.WS_DATE,CGBHC.C_NAME,CGBHC.C_ANAME,P_NO,P_NAME,BUNIT,BQTY,PRICE,AMOUNT " +
                         " FROM CGBBC,CGBHC,VENDC WHERE CGBHC.WS_NO=CGBBC.WS_NO AND CGBHC.C_NO=VENDC.C_NO";

            if(string.IsNullOrEmpty(txtWS_NO_Tab2.Text))
            {
                sql = sql + " AND CGBHC.WS_NO>='" + txtWS_NO_Tab2.Text + "'";
            }
            if (string.IsNullOrEmpty(txtWS_NO1_Tab2.Text))
            {
                sql = sql + " AND CGBHC.WS_NO<='" + txtWS_NO1_Tab2.Text + "'";
            }
            if(txtWS_DATE_Tab2.MaskFull)
            {
                sql = sql + " AND CGBHC.WS_DATE>='"+txtWS_DATE_Tab2.Text.Replace("/","")+"'";
            }
            if (txtWS_DATE1_Tab2.MaskFull)
            {
                sql = sql + " AND CGBHC.WS_DATE<='" + txtWS_DATE1_Tab2.Text.Replace("/", "") + "'";
            }
            if(string.IsNullOrEmpty(txtC_NO_tab2.Text))
            {
                sql = sql + " AND CGBHC.C_NO>='"+txtC_NO_tab2.Text+"'";
            }
            if (string.IsNullOrEmpty(txtC_NO1_tab2.Text))
            {
                sql = sql + " AND CGBHC.C_NO<='" + txtC_NO1_tab2.Text + "'";
            }

            if (rbC_NO_Tab2.Checked == true)
            {
                sql = sql + " ORDER BY CGBHC.C_NO,CGBHC.WS_DATE,CGBHC.WS_NO";
            }
            else if (rbWS_DATE_Tab2.Checked == true)
            {
                sql = sql + " ORDER BY CGBHC.WS_DATE,CGBHC.WS_NO";
            }
            else
            {
                sql = sql + " ORDER BY CGBHC.WS_NO,CGBHC.WS_DATE";
            }
            

            dt = new DataTable();
            dt = con.readdata(sql); 
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
        }

        private void PrintTab1()
        {
            cryRpt = new ReportDocument();
            string sql="";

            if(txtPrintPrice.Text == "N")
            {
                sql = "SELECT CGBBC.WS_NO,CGBBC.C_NO,CGBHC.C_NAME,CGBHC.C_ANAME,CGBBC.WS_DATE,ADDR,CGBHC.OR_NO,CGBBC.C_OR_NO,NR," +
                    " P_NO,P_NAME,BQTY,BUNIT,'' AS PRICE,'' AS AMOUNT, MEMO,'' AS TAX,'' AS DISCOUNT,'' AS RCV_MON,'' AS TOT,'' AS TOTAL,'' AS NRCV_MON, M_TRAN, M_TRAN_R, TEL1, CGBHC.MEMO1,CAR_COMPANY" +
                    " FROM dbo.CGBHC,dbo.VENDC,dbo.CGBBC" +
                    " WHERE CGBHC.C_NO = VENDC.C_NO  AND CGBBC.WS_NO = CGBHC.WS_NO";
            }
            else
            {
                sql = "SELECT CGBBC.WS_NO,CGBBC.C_NO,CGBHC.C_NAME,CGBHC.C_ANAME,CGBBC.WS_DATE,ADDR,CGBHC.OR_NO,CGBBC.C_OR_NO,NR," +
                      " P_NO,P_NAME,BQTY,BUNIT,PRICE,AMOUNT,MEMO,TAX,DISCOUNT,RCV_MON,TOT,TOTAL,NRCV_MON,M_TRAN,M_TRAN_R,TEL1,CGBHC.MEMO1,CAR_COMPANY" +
                      " FROM dbo.CGBHC,dbo.VENDC,dbo.CGBBC" +
                      " WHERE CGBHC.C_NO = VENDC.C_NO  AND CGBBC.WS_NO = CGBHC.WS_NO";
            }
            if (radioButton1.Checked ==true)
            {
                cryRpt = new cr_Frm4DF7_Tab1();
            }
            else if(radioButton2.Checked == true)
            {
                cryRpt = new cr_Frm4DF7_Tab1_2();
            }
            else
            {

            }
            if (!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                sql = sql + " AND CGBHC.WS_NO >= '" + txtWS_NO.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtWS_NO1.Text))
            {
                sql = sql + " AND CGBHC.WS_NO <= '" + txtWS_NO.Text + "'";
            }
            dt = new DataTable();
            dt = con.readdata(sql);
        }

        private void txtPrintPrice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(txtPrintPrice.Text == "N")
            {
                txtPrintPrice.Text = "Y";
            }
            else
            {
                txtPrintPrice.Text = "N";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm4DF7_Load(object sender, EventArgs e)
        {

        }
    }
}
