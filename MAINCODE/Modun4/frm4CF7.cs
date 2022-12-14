using CrystalDecisions.CrystalReports.Engine;
using PURCHASE.DataCenter;
using PURCHASE.MAINCODE.Modun4.Report;
using PURCHASE.MAINCODE.Modun4.Search;
using PURCHASE.MAINCODE.Search;
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
    public partial class Form4CF7 : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        public Form4CF7()
        {
            InitializeComponent();
            con.CheckLanguage(this);
        }

        private void Form4CF7_Load(object sender, EventArgs e)
        {

        }

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex ==0)
            {
                TabPage1();
            }else if(tabControl1.SelectedIndex ==1)
            {
                TabPage2();
            }else if(tabControl1.SelectedIndex == 2)
            {
                TabPage3();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                TabPage4();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                TabPage5();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                TabPage6();
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                TabPage7();
            }
        }

        private void TabPage7()
        {
            ReportDocument cryRpt = new ReportDocument();
            string where = "";
            string sql = "";

            if(rdbP_NO_Tab7.Checked == true)
            {
                if (txtWS_DATE_Tab7.MaskFull)
                {
                    where = where + " AND B.WS_DATE >= '" + txtWS_DATE_Tab7.Text.Replace("/", "") + "'";
                }
                if (txtWS_DATE1_Tab7.MaskFull)
                {
                    where = where + " AND B.WS_DATE <= '" + txtWS_DATE1_Tab7.Text.Replace("/", "") + "'";
                }
                sql = "SELECT CONVERT(VARCHAR(10),ROW_NUMBER() OVER(ORDER BY SUM(B.BQTY) DESC)) STT,B.P_NO,B.P_NAME,B.P_NAME1,B.P_NAME2,B.P_NAME3," +
                " B.BUNIT,SUM(B.BQTY) SUMBQTY,SUM(B.AMOUNT) SUMAMOUNT,H.M_TRAN,B.K_NO,K.K_NAME,m.M_NAME,P.DEPT,P1.PRICE" +
                " FROM COMBC1 B" +
                " JOIN COMHC1 H ON H.WS_NO = B.WS_NO" +
                " LEFT JOIN KIND1C K ON K.K_NO = B.K_NO" +
                " LEFT JOIN(SELECT DISTINCT M_NO, M_NAME FROM dbo.MONEYT" +
                " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.MONEYT)) M ON H.M_TRAN = m.M_NO" +
                " LEFT JOIN PROD1C P ON B.P_NO = P.P_NO" +
                " LEFT JOIN(SELECT DISTINCT ROUND(PRICE,0) PRICE, P_NO" +
                " FROM dbo.COMBC1 c1" +
                " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.COMBC1 where P_NO = c1.P_NO)) P1 ON B.P_NO = P1.P_NO" +
                " WHERE 1=1 " + where +
                " GROUP BY B.P_NO,B.P_NAME,B.P_NAME1,B.P_NAME2,B.P_NAME3,B.BUNIT,H.M_TRAN,B.K_NO,K.K_NAME,M.M_NAME,P.DEPT,P1.PRICE" +
                " ORDER BY SUM(B.BQTY) DESC";
                cryRpt = new cr_Frm4CF7_Tab7();
            }
            else if(rdbC_NO_Tab7.Checked == true) 
            {
                if (txtWS_DATE_Tab7.MaskFull)
                {
                    where = where + " AND WS_DATE >= '" + txtWS_DATE_Tab7.Text.Replace("/", "") + "'";
                }
                if (txtWS_DATE1_Tab7.MaskFull)
                {
                    where = where + " AND WS_DATE <= '" + txtWS_DATE1_Tab7.Text.Replace("/", "") + "'";
                }

                sql = "SELECT CONVERT(VARCHAR(10),ROW_NUMBER() OVER(ORDER BY SUM(C.AMOUNT) DESC)) STT,C.C_NO,SUM(C.AMOUNT)AMOUNT,V.C_ANAME,V.V_NAME,M.M_NAME" +
                    " FROM COMBC1 C" +
                    " LEFT JOIN VENDC V ON V.C_NO = C.C_NO" +
                    " LEFT JOIN(SELECT DISTINCT M_NO, M_NAME FROM dbo.MONEYT" +
                    " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.MONEYT)) M ON M.M_NO = V.DEFA_MONEY" +
                    " WHERE 2 > 1  "+  where +
                    " GROUP BY C.C_NO,V.C_ANAME,V.V_NAME,M.M_NAME" +
                    " ORDER BY SUM(C.AMOUNT) DESC";
                cryRpt = new cr_Frm4CF7_Tab7_C_NO();
            }
            else
            {
                if (txtWS_DATE_Tab7.MaskFull)
                {
                    where = where + " AND C.WS_DATE >= '" + txtWS_DATE_Tab7.Text.Replace("/", "") + "'";
                }
                if (txtWS_DATE1_Tab7.MaskFull)
                {
                    where = where + " AND C.WS_DATE <= '" + txtWS_DATE1_Tab7.Text.Replace("/", "") + "'";
                }
                if(!string.IsNullOrEmpty(txtC_NO_Tab7.Text))
                {
                    where = where + " AND C.C_NO >= '"+ txtC_NO_Tab7.Text +"'";
                }
                if (!string.IsNullOrEmpty(txtC_NO1_Tab7.Text))
                {
                    where = where + " AND C.C_NO <= '" + txtC_NO1_Tab7.Text + "'";
                }
                sql = "SELECT CONVERT(VARCHAR(10),ROW_NUMBER() OVER(ORDER BY C.C_NO ASC,P.K_NO ASC,SUM(C.BQTY)DESC)) STT," +
                    " C.C_NO,C.P_NO,SUM(C.BQTY) BQTY,SUM(C.AMOUNT) AMOUNT,P.K_NO,C1.PRICE,V.C_ANAME," +
                    " V.V_NAME,K.K_NAME,P.P_NAME,P.P_NAME1,P.P_NAME3,P.BUNIT,M.M_NAME" +
                    " FROM COMBC1 C" +
                    " JOIN PROD1C P ON C.P_NO = P.P_NO" +
                    " LEFT JOIN(SELECT DISTINCT ROUND(PRICE,0) PRICE, P_NO" +
                    " FROM dbo.COMBC1 c1" +
                    " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.COMBC1 where P_NO = c1.P_NO)) C1 ON C1.P_NO = C.P_NO" +
                    " LEFT JOIN VENDC V ON V.C_NO = C.C_NO" +
                    " LEFT JOIN KIND1C K ON K.K_NO = P.K_NO" +
                    " LEFT JOIN(SELECT DISTINCT M_NO, M_NAME FROM dbo.MONEYT" +
                    " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.MONEYT)) M ON P.M_TRAN = M.M_NO" +
                    " WHERE 1 = 1" + where +
                    " GROUP BY C.C_NO,C.P_NO,P.K_NO,C1.PRICE,V.C_ANAME,V.V_NAME,K.K_NAME,P.P_NAME,P.P_NAME1,P.P_NAME3,P.BUNIT,M.M_NAME" +
                    " ORDER BY C.C_NO ASC, P.K_NO ASC, SUM(C.BQTY)DESC";
                cryRpt = new cr_Frm4CF7_Tab7_C_NO1();
            }

            dt = new DataTable();
            dt = con.readdata(sql);

            cryRpt.SetDataSource(dt);
            cryRpt.DataDefinition.FormulaFields["Dates"].Text = " ' " + (txtWS_DATE_Tab7.Text + "-" + txtWS_DATE1_Tab7.Text).ToString() + " ' ";
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void TabPage6()
        {
            string sql = "SELECT * FROM COMBC,COMHC WHERE COMHC.WS_NO=COMBC.WS_NO ";
            if (rdbOpen1.Checked == true)
            {
                sql = sql + " AND COMBC.OVER0<>'Y' AND COMBC.HOVER<>'Y'";
            }
            else if(rdbClose1.Checked ==true)
            {
                sql = sql + " AND (COMBC.OVER0='Y' OR COMBC.HOVER='Y')";
            }

            if(txtWS_DATE_Tab6.MaskFull)
            {
                sql = sql + " AND COMBC.WS_DATE >= '"+ txtWS_DATE_Tab6.Text.Replace("/","") +"'";
            }
            if (txtWS_DATE1_Tab6.MaskFull)
            {
                sql = sql + " AND COMBC.WS_DATE <= '" + txtWS_DATE1_Tab6.Text.Replace("/", "") + "'";
            }
            if(!string.IsNullOrEmpty(txtWS_NO_Tab6.Text))
            {
                sql = sql + " AND COMHC.WS_NO >= '"+ txtWS_NO_Tab6.Text +"'";
            }
            if (!string.IsNullOrEmpty(txtWS_NO1_Tab6.Text))
            {
                sql = sql + " AND COMHC.WS_NO <= '" + txtWS_NO1_Tab6.Text + "'";
            }
            if(!string.IsNullOrEmpty(txtC_NO_Tab6.Text))
            {
                sql = sql + " AND COMBC.C_NO >= '"+txtC_NO_Tab6.Text+"'";
            }
            if (!string.IsNullOrEmpty(txtC_NO1_Tab6.Text))
            {
                sql = sql + " AND COMBC.C_NO <= '" + txtC_NO1_Tab6.Text + "'";
            }

            if (rdbC_NO_Tab6.Checked == true)
            {
                sql = sql + " ORDER BY COMBC.C_NO,COMHC.WS_DATE,COMHC.WS_NO,COMBC.FOB_DATE";
            }
            else if (rdbWS_DATE_Tab6.Checked == true)
            {
                sql = sql + " ORDER BY COMBC.WS_DATE,COMHC.WS_NO";
            }
            else
            {
                sql = sql + " ORDER BY COMHC.WS_NO,COMHC.WS_DATE,COMBC.FOB_DATE";
            }

            dt = new DataTable();
            dt = con.readdata(sql);

            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4CF7_Tab6();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void TabPage5()
        {
            string sql = "SELECT * FROM COMBC,COMHC " +
                       " WHERE COMHC.WS_NO = COMBC.WS_NO ";
            if (!string.IsNullOrEmpty(txtWS_NO_Tab5.Text))
            {
                sql = sql + " AND COMHC.WS_NO >= '"+ txtWS_NO_Tab5.Text +"'";
            }
            if (!string.IsNullOrEmpty(txtWS_NO1_Tab5.Text))
            {
                sql = sql + " AND COMHC.WS_NO <= '" + txtWS_NO1_Tab5.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO_Tab5.Text))
            {
                sql = sql + " AND COMBC.C_NO >= '" + txtC_NO_Tab5.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO1_Tab5.Text))
            {
                sql = sql + " AND COMBC.C_NO <= '" + txtC_NO1_Tab5.Text + "'";
            }
            if (txtFOB_DATE_Tab5.MaskFull)
            {
                sql = sql + " AND COMBC.FOB_DATE >= '" + txtFOB_DATE_Tab5.Text.Replace("/","") + "'";
            }
            if (txtFOB_DATE1_Tab5.MaskFull)
            {
                sql = sql + " AND COMBC.FOB_DATE <= '" + txtFOB_DATE1_Tab5.Text.Replace("/", "") + "'";
            }

            if (rdbOpen.Checked == true)
            {
                sql = sql + " AND COMBC.OVER0 <> 'Y' AND COMBC.HOVER <> 'Y'";
            }
            else if(rdbOpen.Checked == true)
            {
                sql = sql + " AND (COMBC.OVER0='Y' OR COMBC.HOVER='Y')";
            }

            if (rdbC_NO_Tab5.Checked == true)
            {
                sql = sql + " ORDER BY COMBC.C_NO,COMHC.WS_DATE,COMHC.WS_NO,COMBC.FOB_DATE";

            }
            else if (rdbWS_DATE_Tab5.Checked == true)
            {
                sql = sql + " ORDER BY COMBC.FOB_DATE,COMHC.WS_NO";
            }
            else
            {
                sql = sql + "ORDER BY COMHC.WS_NO,COMHC.WS_DATE,COMBC.FOB_DATE";
            }

            dt = new DataTable();
            dt = con.readdata(sql);

            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4CF7_Tab5();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void TabPage4()
        {
            string where = "";
            if (txtWS_DATE_Tab4.MaskFull)
            {
                where = where + " AND H.WS_DATE >= '"+ txtWS_DATE_Tab4.Text.Replace("/","") +"'";
            }
            if (txtWS_DATE1_Tab4.MaskFull)
            {
                where = where + " AND H.WS_DATE <= '" + txtWS_DATE1_Tab4.Text.Replace("/", "") + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO_Tab4.Text))
            {
                where = where + " AND C.C_NO >= '" + txtC_NO_Tab4.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO1_Tab4.Text))
            {
                where = where + " AND C.C_NO <= '" + txtC_NO1_Tab4.Text + "'";
            }

            string sql = "SELECT a.*,b.BQTY AS BQTY1,b.WS_DATE AS WS_DATE1 FROM (" +
                " SELECT H.C_NO,H.C_ANAME,H.WS_DATE,C.WS_NO,C.P_NO,C.P_NAME,C.BUNIT,C.BQTY,C.PRICE,C.AMOUNT,C.NR,H.FOB_DATE" +
                " FROM COMBC C, COMHC H" +
                " WHERE C.WS_NO = H.WS_NO " + where +
                " )a" +
                " LEFT JOIN" +
                " (SELECT H.C_NO, H.C_ANAME, H.WS_DATE, C.WS_NO, C.P_NO, C.P_NAME, C.BUNIT, C.BQTY, C.PRICE, C.AMOUNT, c.OR_NR, c.OR_NO" +
                " FROM COMBC1 C, COMHC1 H" +
                " WHERE C.WS_NO = H.WS_NO" +
                " )b ON b.OR_NO = a.WS_NO AND b.OR_NR = a.NR" +
                " ORDER BY a.C_NO,a.FOB_DATE,a.P_NO";
            dt = new DataTable();
            dt = con.readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
                item["FOB_DATE"] = con.formatstr2(item["FOB_DATE"].ToString());
                item["WS_DATE1"] = con.formatstr2(item["WS_DATE1"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4CF7_Tab4();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void TabPage3()
        {
            string Where = "";
            string Where1 = "";
            if(txtWS_DATE_Tab3.MaskFull)
            {
                Where = Where + " AND H.WS_DATE>='" + txtWS_DATE_Tab3.Text.Replace("/", "") + "'";
                Where1 = Where1 + " AND B.WS_DATE>='" + txtWS_DATE_Tab3.Text.Replace("/", "") + "'";
            }
            if (txtWS_DATE1_Tab3.MaskFull)
            {
                Where = Where + " AND H.WS_DATE <= '" + txtWS_DATE1_Tab3.Text.Replace("/", "") + "'";
                Where1 = Where1 + " AND B.WS_DATE <= '" + txtWS_DATE1_Tab3.Text.Replace("/", "") + "'";
            }
            if (!string.IsNullOrEmpty(txtK_NO_Tab3.Text))
            {
                Where = Where + " AND C.K_NO >= '" + txtK_NO_Tab3.Text + "'";
                Where1 = Where1 + " AND G.K_NO >= '" + txtK_NO_Tab3.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtK_NO1_Tab3.Text))
            {
                Where = Where + " AND C.K_NO <= '" + txtK_NO1_Tab3.Text + "'";
                Where1 = Where1 + " AND G.K_NO <= '" + txtK_NO1_Tab3.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtP_NO_Tab3.Text))
            {
                Where = Where + " AND C.P_NO >= '" + txtP_NO_Tab3.Text + "'";
                Where1 = Where1 + " AND G.P_NO >= '" + txtP_NO_Tab3.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtP_NO1_Tab3.Text))
            {
                Where = Where + " AND C.P_NO<= '" + txtP_NO1_Tab3.Text + "'";
                Where1 = Where1 + " AND G.P_NO<= '" + txtP_NO1_Tab3.Text + "'";
            }
            string SQL = "";
            if (rdbHangHoa.Checked == true)
            {
                SQL = "SELECT H.C_NO,H.C_ANAME,H.WS_DATE,C.WS_NO,C.P_NO,C.P_NAME," +
                " C.P_NAME1,C.P_NAME3,C.DEPT_NAME,C.BUNIT,C.BQTY,C.PRICE,C.AMOUNT,P.M_TRAN,M.M_NAME" +
                " FROM COMBC1 C, COMHC1 H, PROD1C P,(SELECT DISTINCT M_NO, M_NAME" +
                " FROM dbo.MONEYT" +
                " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.MONEYT)) M" +
                " WHERE C.WS_NO = H.WS_NO AND P.P_NO = C.P_NO AND M.M_NO = P.M_TRAN" + Where +
                " UNION ALL" +
                " SELECT B.C_NO,B.C_ANAME,B.WS_DATE,G.WS_NO,G.P_NO,G.P_NAME," +
                " G.P_NAME1,G.P_NAME3,G.DEPT_NAME,G.BUNIT,(-1) * G.BQTY,G.PRICE,(-1) * G.AMOUNT,p.M_TRAN,M.M_NAME" +
                " FROM CGBBC G, CGBHC B,PROD1C P,(SELECT DISTINCT M_NO, M_NAME" +
                " FROM dbo.MONEYT" +
                " WHERE WS_DATE IN(SELECT MAX(WS_DATE) FROM dbo.MONEYT))M" +
                " WHERE G.WS_NO = B.WS_NO AND P.P_NO = G.P_NO AND M.M_NO = P.M_TRAN" + Where1 +
                " ORDER BY C.P_NO,H.WS_DATE";
            } else if (rdbConHang.Checked == true)
            {
                SQL = "SELECT H.C_NO,H.C_ANAME,H.WS_DATE,C.WS_NO,C.P_NO,C.P_NAME,C.P_NAME1,C.P_NAME3,C.DEPT_NAME,C.BUNIT,C.BQTY,C.PRICE,C.AMOUNT " +
                    " FROM COMBC1 C,COMHC1 H" +
                    " WHERE C.WS_NO = H.WS_NO " + Where +
                    " ORDER BY P_NO";
            }
            else
            {
                SQL = "SELECT B.C_NO,B.C_ANAME,B.WS_DATE,G.WS_NO,G.P_NO,G.P_NAME,G.P_NAME1,G.P_NAME3,G.DEPT_NAME,G.BUNIT,G.BQTY,G.PRICE,G.AMOUNT " +
                    " FROM CGBBC G,CGBHC B" +
                    " WHERE G.WS_NO = B.WS_NO " + Where +
                    " ORDER BY P_NO";
            }

            dt = new DataTable();
            dt = con.readdata(SQL);
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4CF7_Tab3();
            cryRpt.SetDataSource(dt);

            var SumEUR = dt.AsEnumerable().Where(row => row.Field<string>("M_TRAN") == "ERU").Select(x => new { Amount = x.Field<double>("AMOUNT") }).Sum(x => x.Amount);
            var SumNTD = dt.AsEnumerable().Where(row => row.Field<string>("M_TRAN") == "NTD").Select(x => new { Amount = x.Field<double>("AMOUNT") }).Sum(x => x.Amount);
            var SumUSD = dt.AsEnumerable().Where(row => row.Field<string>("M_TRAN") == "USD").Select(x => new { Amount = x.Field<double>("AMOUNT") }).Sum(x => x.Amount);
            var SumHKD = dt.AsEnumerable().Where(row => row.Field<string>("M_TRAN") == "HKD").Select(x => new { Amount = x.Field<double>("AMOUNT") }).Sum(x => x.Amount);
            var SumRMB = dt.AsEnumerable().Where(row => row.Field<string>("M_TRAN") == "RMB").Select(x => new { Amount = x.Field<double>("AMOUNT") }).Sum(x => x.Amount);
            var SumVND = dt.AsEnumerable().Where(row => row.Field<string>("M_TRAN") == "VND").Select(x => new { Amount = x.Field<double>("AMOUNT") }).Sum(x => x.Amount);
            cryRpt.DataDefinition.FormulaFields["SumEUR"].Text = SumEUR.ToString();
            cryRpt.DataDefinition.FormulaFields["SumNTD"].Text = SumNTD.ToString();
            cryRpt.DataDefinition.FormulaFields["SumUSD"].Text = SumUSD.ToString();
            cryRpt.DataDefinition.FormulaFields["SumHKD"].Text = SumHKD.ToString();
            cryRpt.DataDefinition.FormulaFields["SumRMB"].Text = SumRMB.ToString();
            cryRpt.DataDefinition.FormulaFields["SumVND"].Text = SumVND.ToString();
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void TabPage2()
        {
            string sql = "SELECT * FROM COMBC1,COMHC1,VENDC " +
                " WHERE COMHC1.WS_NO = COMBC1.WS_NO AND COMHC1.C_NO = VENDC.C_NO";

            if(!string.IsNullOrEmpty(txtWS_NO_Tab2.Text))
            {
                sql = sql + " AND COMHC1.WS_NO>='"+txtWS_NO_Tab2.Text+"'";
            }

            if(!string.IsNullOrEmpty(txtWS_NO1_Tab2.Text))
            {
                sql = sql + " AND COMHC1.WS_NO<='"+txtWS_NO1_Tab2.Text+"'";
            }

            if(txtWS_DATE_Tab2.MaskFull)
            {
                sql = sql + " AND COMHC1.WS_DATE>='"+txtWS_DATE_Tab2.Text.Replace("/","")+"'";
            }
            if (txtWS_DATE1_Tab2.MaskFull)
            {
                sql = sql + " AND COMHC1.WS_DATE<='" + txtWS_DATE1_Tab2.Text.Replace("/", "") + "'";
            }

            if(!string.IsNullOrEmpty(txtC_NO_Tab2.Text))
            {
                sql = sql + " AND COMHC1.C_NO>='"+txtC_NO_Tab2.Text+"' ";
            }
            if (!string.IsNullOrEmpty(txtC_NO1_Tab2.Text))
            {
                sql = sql + " AND COMHC1.C_NO<='" + txtC_NO1_Tab2.Text + "' ";
            }

            if (rdbC_NO_Tab2.Checked == true)
            {
                sql = sql + " ORDER BY COMHC1.C_NO,COMHC1.WS_DATE,COMHC1.WS_NO";
            } 
            else if (rdbWS_DATE_Tab2.Checked == true)
            {
                sql = sql + " ORDER BY COMHC1.WS_DATE,COMHC1.WS_NO";
            }
            else
            {
                sql = sql + " ORDER BY COMHC1.WS_NO,COMHC1.WS_DATE";
            }

            dt = new DataTable();
            dt = con.readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_Frm4CF7_Tab2();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
            
        }

        public void TabPage1()
        {
            string sql = "SELECT '" + txtY_N.Text + "' as Y_N,HC.WS_NO,HC.C_NO,DC.TEL1,DC.FAX,HC.WS_DATE,HC.TOTAL,HC.RCV_MON,HC.NRCV_MON," +
                       " HC.TOT,HC.TAX,HC.DISCOUNT,HC.MEMO1,DC.PAY_CON,HC.CAR_COMPANY," +
                       " DC.C_NAME,HC.OR_NO,BC.NR,BC.P_NO,BC.P_NAME + BC.P_NAME1 AS P_NAME," +
                       " CAST(CAST(BC.BQTY AS float(20)) AS VARCHAR(20)) AS BQTY, BC.BUNIT,ISNULL(CAST(CAST(BC.PRICE AS float(20)) AS VARCHAR(20)), 0) AS PRICE," +
                       " ISNULL(CAST(CAST(AMOUNT AS float(20)) AS VARCHAR(20)), 0) AS AMOUNT, BC.MEMO,'' as MONEY_NAME" +
                       " FROM COMHC1 HC, VENDC DC,COMBC1 BC" +
                       " WHERE HC.C_NO = DC.C_NO AND BC.WS_NO = HC.WS_NO";

            if (!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                sql = sql + " AND HC.WS_NO >= '" + txtWS_NO.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtWS_NO1.Text))
            {
                sql = sql + " AND HC.WS_NO <= '" + txtWS_NO1.Text + "'";
            }
            sql = sql + " ORDER BY HC.WS_NO";
            DataTable dt = new DataTable();
            dt = con.readdata(sql);

            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
                if (!string.IsNullOrEmpty(item["BQTY"].ToString()))
                {
                    item["BQTY"] = con.ConvertNumber(item["BQTY"].ToString());
                }
                if (!string.IsNullOrEmpty(item["PRICE"].ToString()))
                {
                    item["PRICE"] = con.ConvertNumber(item["PRICE"].ToString());
                }
                if (!string.IsNullOrEmpty(item["AMOUNT"].ToString()))
                {
                    item["AMOUNT"] = con.ConvertNumber(item["AMOUNT"].ToString());
                }
            }
            ReportDocument cryRpt = new ReportDocument();
            if (rdb4CF7_tab1.Checked == true)
            {   report1.Load(@"D:\Untitled.frx");
                report1.Dictionary.Clear();
                report1.Dictionary.RegisterData(dt, "Table", true);
                ((DataBand)report1.FindObject("Data1")).DataSource = report1.Dictionary.DataSources[0];
                report1.Show();
            }
            else if (rdb4CF7_tab1_1.Checked == true)
            {
                cryRpt = new cr_Frm4CF7_Tab1_1();
            }
            else if (rdb4CF7_tab1_2.Checked == true)
            {
                cryRpt = new cr_Frm4CF7_Tab1_2();
            }
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report1 frm = new Report1();
            frm.ShowDialog();
        }

        private void txtWS_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchCOMHC1 frm = new FormSearchCOMHC1();
            frm.ShowDialog();
            txtWS_NO.Text = FormSearchCOMHC1.GetItem.WS_NO;
        }

        private void txtWS_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchCOMHC1 frm = new FormSearchCOMHC1();
            frm.ShowDialog();
            txtWS_NO1.Text = FormSearchCOMHC1.GetItem.WS_NO;
        }

        private void txtWS_DATE_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab3.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE1_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE1_Tab3.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab2.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE1_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE1_Tab2.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_NO_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchCOMHC1 frm = new FormSearchCOMHC1();
            frm.ShowDialog();
            txtWS_NO_Tab2.Text = FormSearchCOMHC1.GetItem.WS_NO;
        }

        private void txtWS_NO1_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchCOMHC1 frm = new FormSearchCOMHC1();
            frm.ShowDialog();
            txtWS_NO1_Tab2.Text = FormSearchCOMHC1.GetItem.WS_NO;
        }

        private void textBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtY_N.Text = (txtY_N.Text == "Y" ? "N" : "Y");
        }

        private void txtC_NO_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO_Tab2.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_Tab2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1_Tab2.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtK_NO_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C frm = new FormSeachKIND1C();
            frm.ShowDialog();
            txtK_NO_Tab3.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void txtK_NO1_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C frm = new FormSeachKIND1C();
            frm.ShowDialog();
            txtK_NO1_Tab3.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void txtP_NO_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchPROD1C_Select_OneItem frm = new SearchPROD1C_Select_OneItem();
            frm.ShowDialog();
            txtP_NO_Tab3.Text = SearchPROD1C_Select_OneItem.GetItem.P_NO;
        }

        private void txtP_NO1_Tab3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchPROD1C_Select_OneItem frm = new SearchPROD1C_Select_OneItem();
            frm.ShowDialog();
            txtP_NO1_Tab3.Text = SearchPROD1C_Select_OneItem.GetItem.P_NO;
        }
        private void txtWS_DATE1_Tab4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE1_Tab4.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE_Tab4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab4.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtC_NO_Tab4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO_Tab4.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_Tab4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1_Tab4.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtWS_DATE_Tab5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab5.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE_Tab6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab6.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE1_Tab6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE1_Tab6.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtC_NO_Tab6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO_Tab6.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_Tab6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1_Tab6.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtWS_DATE_Tab7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE_Tab7.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_DATE1_Tab7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender frm = new LibraryCalender.FromCalender();
            frm.ShowDialog();
            txtWS_DATE1_Tab7.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void rdbC_NO1_Tab7_CheckedChanged(object sender, EventArgs e)
        {
            txtC_NO_Tab7.Visible = true;
            txtC_NO1_Tab7.Visible = true;
            lbC_NO_Tab7.Visible = true;
            lbC_NO1_Tab7.Visible = true;
        }

        private void rdbP_NO_Tab7_CheckedChanged(object sender, EventArgs e)
        {
            txtC_NO_Tab7.Visible = false;
            txtC_NO1_Tab7.Visible = false;
            lbC_NO_Tab7.Visible = false;
            lbC_NO1_Tab7.Visible = false;
        }

        private void rdbC_NO_Tab7_CheckedChanged(object sender, EventArgs e)
        {
            txtC_NO_Tab7.Visible = false;
            txtC_NO1_Tab7.Visible = false;
            lbC_NO_Tab7.Visible = false;
            lbC_NO1_Tab7.Visible = false;
        }

        private void txtC_NO_Tab7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO_Tab7.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void txtC_NO1_Tab7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B frm = new SearchVENDC1B();
            frm.ShowDialog();
            txtC_NO1_Tab7.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
