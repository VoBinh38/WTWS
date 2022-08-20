﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE.Search
{
    public partial class SearchPROD1C_Select_OneItem : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt;
        public static string wheres;
        public SearchPROD1C_Select_OneItem()
        {
            InitializeComponent();
        }

        private void SearchPROD1C_Select_OneItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string sql = "SELECT P_NO,P_NAME,P_NAME1,P_NAME3,QTYSTORE,BUNIT,P_NAME2 FROM PROD1C where 1 = 1 " + wheres;
            if(string.IsNullOrEmpty(txtP_NO.Text))
            {
                sql = sql + " AND P_NO LIKE '%"+ txtP_NO.Text +"%'";
            }
            if(string.IsNullOrEmpty(txtP_NAME.Text))
            {
                sql = sql + " AND P_NAME LIKE '%"+ txtP_NAME.Text +"%'";
            }
            if(string.IsNullOrEmpty(txtP_NAME1.Text))
            {
                sql = sql + " AND P_NAME3 LIKE '%"+ txtP_NAME3.Text +"%'";
            }
            if(string.IsNullOrEmpty(txtP_NAME1.Text))
            {
                sql = sql + " AND P_NAME1 LIKE '%"+ txtP_NAME1.Text +"%'";
            }

            dt = new DataTable();
            dt = con.readdata(sql);
            DGV1.DataSource = dt;
        }

        public class GetItem
        {
            public static string P_NO;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            GetItem.P_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NO"].Value.ToString();
            this.Close();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GetItem.P_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NO"].Value.ToString();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
