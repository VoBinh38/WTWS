﻿using PURCHASE.FormCenter;
using PURCHASE.MAINCODE.Modun4;
using PURCHASE.MAINCODE.Modun6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PURCHASE.MAINCODE
{
    public partial class MAIN : Form
    {
        DataProvider conn = new DataProvider();
        public MAIN()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.GetDataCheckLanguage();
            conn.CheckLanguage(this);
        }
        DataTable menuparent;
        Bitmap bitmap;
        Bitmap bitmap1;
        int l = 1;
        private void MAIN_Load(object sender, EventArgs e)
        {
            string User = frmLogin.ID_USER;
            string sql1 = "SELECT top 1 LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql1);
            foreach (DataRow item in dataTable.Rows)
            {
                l = int.Parse(item["LANGUAGE"].ToString());
            }

            string sql = "SELECT " + checkedLanguage(l) + ",STT FROM MenuParent WHERE IDSof = 2 ORDER BY STT";
            menuparent = new DataTable();
            menuparent = conn.readdata(sql);

            foreach (DataRow rw in menuparent.Rows)
            {
                SetBitMap(int.Parse(rw["STT"].ToString()));
                ToolStripMenuItem MnuStripItem = new ToolStripMenuItem(rw[0].ToString(), null, ChangeLanguage, rw["STT"].ToString()) { Image = bitmap };
                if(l == 3)
                {
                    menuStrip1.Font = new Font("SimSum", 14);
                }
                menuStrip1.Items.Add(MnuStripItem);
                SubMenu(MnuStripItem, rw["STT"].ToString());
            }
        }
        public void SubMenu(ToolStripMenuItem MnuItems, string var)
        {
            ///string sql1 = "SELECT * FROM Menu WHERE IDParent ='" + var + "'";
            string sql1 = "SELECT b." + checkedLanguage(l) + ",a.IDMenu_Parent,a.IDPro,b.Name_From,SUBSTRING(b.Crl_shortcuts,5,1) AS Images" +
                " FROM Menu_Program a" +
                " JOIN MenuParent c ON c.STT = a.IDMenu_Parent" +
                " JOIN dbo.FORM_NAME b ON a.IDMenu = b.NR_Parent_Menu AND b.Parent_Menu = a.IDMenu_Parent" +
                " WHERE a.IDMenu_Parent = '" + var + "' AND a.IDPro =2";
            DataTable dt = new DataTable();
            dt = conn.readdata(sql1);
            foreach (DataRow rw in dt.Rows)
            {
                SetBitMapMenu(rw["Images"].ToString());
                ToolStripMenuItem SSMenu = new ToolStripMenuItem(rw[0].ToString(), null, ChildClick, rw["Name_From"].ToString()) { Image = bitmap1 };
                MnuItems.DropDownItems.Add(SSMenu);
            }
        }
        public void ChangeLanguage(object sender, System.EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Name == "10")
            {
                Language language = new Language();
                language.ShowDialog();
            }
            else if ((sender as ToolStripMenuItem).Name == "11")
            {
                ImportKeyWork language = new ImportKeyWork();
                language.ShowDialog();
            }

        }
        public void ChildClick(object sender, System.EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Name == "Form9C")
            {
                this.Close();
            }
            else if ((sender as ToolStripMenuItem).Name == "Form9X")
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
            else
            {
                string sql = "SELECT CASE WHEN a.SUPER =0 THEN (CASE WHEN a.P_USE = 1 THEN 'True' ELSE 'Fales' END) ELSE 'True' END AS PUSE" +
                " FROM USRB_NEW a" +
                " JOIN dbo.FORM_NAME b ON a.NR_Form = b.NR_Form" +
                " WHERE b.Name_From = '" + (sender as ToolStripMenuItem).Name + "' AND a.USER_ID = '" + frmLogin.ID_USER + "'";
                DataTable dt = new DataTable();
                dt = conn.readdata(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        if (data["PUSE"].ToString() == "True")
                        {
                            //OpentForm((sender as ToolStripMenuItem).Name);
                            var form = Activator.CreateInstance(Type.GetType("PURCHASE." + (sender as ToolStripMenuItem).Name)) as Form;
                            form.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền truy cập");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
            }
        }
        public void SetBitMapMenu(string image)
        {
            switch (image)
            {
                case "A":
                    bitmap1 = PURCHASE.Properties.Resources.letter_a;
                    break;
                case "B":
                    bitmap1 = PURCHASE.Properties.Resources.letter_b;
                    break;
                case "C":
                    bitmap1 = PURCHASE.Properties.Resources.letter_c;
                    break;
                case "D":
                    bitmap1 = PURCHASE.Properties.Resources.letter_d;
                    break;
                case "E":
                    bitmap1 = PURCHASE.Properties.Resources.letter_e;
                    break;
                case "F":
                    bitmap1 = PURCHASE.Properties.Resources.letter_f;
                    break;
                case "G":
                    bitmap1 = PURCHASE.Properties.Resources.letter_g;
                    break;
                case "H":
                    bitmap1 = PURCHASE.Properties.Resources.letter_h;
                    break;
                case "I":
                    bitmap1 = PURCHASE.Properties.Resources.letter_i;
                    break;
                case "J":
                    bitmap1 = PURCHASE.Properties.Resources.letter_j;
                    break;
                case "L":
                    bitmap1 = PURCHASE.Properties.Resources.letter_l;
                    break;
                case "Q":
                    bitmap1 = PURCHASE.Properties.Resources.letter_q;
                    break;
                case "S":
                    bitmap1 = PURCHASE.Properties.Resources.letter_s;
                    break;
                case "T":
                    bitmap1 = PURCHASE.Properties.Resources.letter_t;
                    break;
                case "R":
                    bitmap1 = PURCHASE.Properties.Resources.letter_r;
                    break;
                case "X":
                    bitmap1 = PURCHASE.Properties.Resources.letter_x;
                    break;
                default:
                    break;
            }
        }
        public void SetBitMap(int i)
        {
            switch (i)
            {
                case 1:
                    bitmap = PURCHASE.Properties.Resources.one;
                    break;
                case 2:
                    bitmap = PURCHASE.Properties.Resources.two;
                    break;
                case 3:
                    bitmap = PURCHASE.Properties.Resources.three;
                    break;
                case 4:
                    bitmap = PURCHASE.Properties.Resources.four;
                    break;
                case 5:
                    bitmap = PURCHASE.Properties.Resources.five;
                    break;
                case 6:
                    bitmap = PURCHASE.Properties.Resources.six;
                    break;
                case 7:
                    bitmap = PURCHASE.Properties.Resources.seven;
                    break;
                case 8:
                    bitmap = PURCHASE.Properties.Resources.eight;
                    break;
                case 9:
                    bitmap = PURCHASE.Properties.Resources.nine;
                    break;
                case 10:
                    bitmap = PURCHASE.Properties.Resources.translation;
                    break;
                default:
                    break;
            }
        }
        public string checkedLanguage(int language)
        {
            string result;
            if (language == 3)
            {
                result = "LanguageCH";
            }
            else if (language == 2)
            {
                result = "LanguageEN";
            }
            else
            {
                result = "NameMenu";
            }
            return result;
        }
    }
}