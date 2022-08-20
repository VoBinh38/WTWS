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
using LibraryCalender;

namespace PURCHASE.MAINCODE.Modun4
{
    public partial class Form4EF7 : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        public Form4EF7()
        {
            InitializeComponent();
            con.CheckLanguage(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                PrintTabPage1();
            }else if(tabControl1.SelectedIndex == 1)
            {
                PrintTabPage2();
            }
            else
            {
                PrintTabPage3();
            }
        }

        private void PrintTabPage1()
        {
            string Wheres = "";
            string Wheres1 = "";
            string Wheres2 = "";
            string Wheres3 = "";
            string sql = "";

            ReportDocument cryRpt = new ReportDocument();
            if (txtCUTON.MaskFull)
            {
                Wheres = Wheres + " AND V.CUTON='" + txtCUTON.Text.Replace("/", "") + "'";
                Wheres1 = Wheres1 + " AND B.CUTON='" + txtCUTON.Text.Replace("/", "") + "'";
                Wheres2 = Wheres2 + " AND B1.CUTON='" + txtCUTON.Text.Replace("/", "") + "'";
                Wheres3 = Wheres3 + " AND B2.CUTON='" + txtCUTON.Text.Replace("/", "") + "'";
            }
            if (txtCUTOFF.MaskFull)
            {
                Wheres = Wheres + " AND V.CUTOFF='"+txtCUTOFF.Text.Replace("/","")+"'";
                Wheres1 = Wheres1 + " AND B.CUTOFF='" + txtCUTOFF.Text.Replace("/", "") + "'";
                Wheres2 = Wheres2 + " AND B1.CUTOFF='" + txtCUTOFF.Text.Replace("/", "") + "'";
                Wheres3 = Wheres3 + " AND B2.CUTOFF='" + txtCUTOFF.Text.Replace("/", "") + "'";
            }
            if(!string.IsNullOrEmpty(txtC_NO.Text))
            {
                Wheres = Wheres + " AND V.C_NO >= N'"+txtC_NO.Text+"'";
                Wheres3 = Wheres3 + " AND B2.C_NO >= N'" + txtC_NO.Text + "'";
            }
            if(!string.IsNullOrEmpty(txtC_NO1.Text))
            {
                Wheres = Wheres + " AND V.C_NO <='" + txtC_NO1.Text + "'";
                Wheres3 = Wheres3 + " AND B2.C_NO <='" + txtC_NO1.Text + "'";
            }

            if (rdbUniversal.Checked == true)
            {
                sql = "SELECT V.C_NO, C.C_NAME + C.V_NAME AS C_NAME, V.M01, V.M02,V.CHK_AC_NAME,B1.WS_DATE1,B1.P_NAME,B1.P_NAME3,B1.BQTY,B1.PRICE," +
                " B1.AMOUNT,B1.OR_NO,B1.CA_NO,B1.INV_NO,B1.INV_AMT,B1.INV_TAX,B1.INV_TOT,B1.MEMO,V.WS_DATE,V.C_NAME" +
                " FROM PAYV V" +
                " LEFT JOIN VENDC C ON C.C_NO = V.C_NO" +
                " LEFT JOIN PAYVB B ON B.C_NO = V.C_NO" + Wheres1 +
                " JOIN PAYVB1 B1 ON B1.C_NO = V.C_NO" + Wheres2 +
                //" LEFT JOIN PAYVB2 B2 ON B2.C_NO = V.C_NO" + Wheres3 +
                " WHERE 2 > 1 " + Wheres;

                string sqlSub = "SELECT * FROM PAYVB2 AS B2 WHERE 1=1 " + Wheres3;
                DataTable dtsub = new DataTable();
                dtsub = con.readdata(sqlSub);
                cryRpt = new cr_Frm4EF7_Tab1();

                cryRpt.Subreports["Sub"].SetDataSource(dtsub);
            }
            else
            {
                sql = "SELECT V.C_NO, C.C_NAME + C.V_NAME AS C_NAME, V.M01, V.M02,V.CHK_AC_NAME,B1.WS_DATE1,B1.P_NAME,B1.P_NAME3,B1.BQTY,B1.PRICE," +
                     " B1.AMOUNT,RIGHT(B1.OR_NO,8) OR_NO,B1.CA_NO,B1.INV_NO,B1.INV_AMT,B1.INV_TAX,B1.INV_TOT,B1.MEMO,V.WS_DATE,V.C_NAME,(SELECT TOP 1 WS_DATE FROM COMBC WHERE WS_NO = B1.OR_NO) AS WS_DATEO,B.TELCASH" +
                     " FROM PAYV V" +
                     " LEFT JOIN VENDC C ON C.C_NO = V.C_NO" +
                     " LEFT JOIN PAYVB B ON B.C_NO = V.C_NO" + Wheres1 +
                     " JOIN PAYVB1 B1 ON B1.C_NO = V.C_NO" + Wheres2 +
                     //" LEFT JOIN PAYVB2 B2 ON B2.C_NO = V.C_NO" + Wheres3 +
                     " WHERE 2 > 1 " + Wheres;
                cryRpt = new cr_Frm4EF7_Tab1_1();
            }


            sql = sql + " ORDER BY V.C_NO";

            dt = new DataTable();
            dt = con.readdata(sql);

            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE1"] = con.formatstr2(item["WS_DATE1"].ToString());
                if(rdbOverseas.Checked == true)
                {
                    item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
                    item["WS_DATEO"] = con.formatstr2(item["WS_DATEO"].ToString());
                }
            }

            cryRpt.SetDataSource(dt);
            cryRpt.DataDefinition.FormulaFields["Dates"].Text = "'"+ DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日" + "'";
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }
        private void PrintTabPage2()
        {
            string sql = "SELECT V.*,C.V_ANAME FROM PAYV V " +
                " JOIN dbo.VENDC C ON C.C_NO = V.C_NO" +
                " WHERE 1 = 1 ";
            if(txtCUTOFF_Tab2.MaskFull)
            {
                sql = sql + " AND V.CUTOFF >='"+ txtCUTOFF_Tab2.Text.Replace("/","")+ "' + '01' AND V.CUTOFF<='" + txtCUTOFF_Tab2.Text.Replace("/", "") + "' + '31'";
            }
            if(!string.IsNullOrEmpty(txtC_NO_tab2.Text))
            {
                sql = sql + " AND V.C_NO >='"+txtC_NO_tab2.Text+"'";
            }
            if (!string.IsNullOrEmpty(txtC_NO1_tab2.Text))
            {
                sql = sql + " AND V.C_NO <='" + txtC_NO1_tab2.Text + "'";
            }

            sql = sql + " ORDER BY V.C_NO,V.CUTOFF";
            DataTable dt = new DataTable();
            dt = con.readdata(sql);

            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4EF7_Tab2();
            cryRpt.SetDataSource(dt);
            cryRpt.DataDefinition.FormulaFields["Dates"].Text = "'" +txtCUTOFF_Tab2.Text+"'";
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void PrintTabPage3()
        {
            string sql = "SELECT *, TELCASH + CASH + CH_NO as AMOUNT FROM PAYVB,VENDC WHERE PAYVB.C_NO=VENDC.C_NO ";

            if(txtWS_DATE_Tab3.MaskFull)
            {
                sql = sql + " AND PAYVB.WS_DATE>='"+txtWS_DATE_Tab3.Text.Replace("/","")+"'";
            }
            if(txtWS_DATE1_Tab3.MaskFull)
            {
                sql = sql + " AND PAYVB.WS_DATE<='" + txtWS_DATE1_Tab3.Text.Replace("/", "") + "'";
            }
            if(string.IsNullOrEmpty(txtC_NO_tab3.Text))
            {
                //sql = sql + " AND PAYVB.WS_DATE>='" + txtWS_DATE_Tab3.Text.Replace("/", "") + "'";
            }
            if (string.IsNullOrEmpty(txtC_NO1_tab3.Text))
            {

            }

            sql = sql + " ORDER BY PAYVB.WS_DATE,PAYVB.C_NO";
            DataTable dt = new DataTable();
            dt = con.readdata(sql);

            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4EF7_Tab3();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCUTON_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtCUTON.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtCUTOFF_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtCUTOFF.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtCUTOFF_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtCUTOFF_Tab2.Text = FromCalender.getDate.ToString("yyyy/MM");
        }

        private void txtWS_DATE_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab3.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtWS_DATE1_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtWS_DATE1_Tab3.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtC_NO_tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO_tab3.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO_tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO_tab2.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1_tab2.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1_tab3.Text = SearchVENDC1B.getDataTable.C_NO;
        }
    }
}
