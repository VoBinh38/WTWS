﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryCalender;

namespace PURCHASE
{
    public partial class Form1DF7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1DF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void tb1t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            tb1t1.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }
        private void tb2t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            tb2t1.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }
        private void tb3t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb3t1();
        }
        public void Get_tb3t1()
        {
            tb3t1.Text = Form1DF5.GUI.t1;
        }
        private void tb4t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb4t1();
        }
        public void Get_tb4t1()
        {
            tb4t1.Text = Form1DF5.GUI.t1;
        }

        private void tb7t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Get_tb7t1();
        }
        public void Get_tb7t1()
        {
            tb7t1.Text = FormSeachKIND.GUI_FORM1EF7.tx1;
        }

        private void tb8t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Get_tb8t1();
        }
        public void Get_tb8t1()
        {
            tb8t1.Text = FormSeachKIND.GUI_FORM1EF7.tx1;
        }

        private void tb1t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb1t2();
        }
        public void Get_tb1t2()
        {
            tb1t2.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb2t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb2t2();
        }
        public void Get_tb2t2()
        {
            tb2t2.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb3t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb3t2();
        }
        public void Get_tb3t2()
        {
            tb3t2.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void tb4t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb4t2();
        }
        public void Get_tb4t2()
        {
            tb4t2.Text = SearchVENDC1B.getDataTable.C_NO;
        }
        private void tb5t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb5t2();
        }
        public void Get_tb5t2()
        {
            tb5t2.Text = Form1DF5.GUI.t1;
        }

        private void tb6t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb6t2();
        }
        public void Get_tb6t2()
        {
            tb6t2.Text = Form1DF5.GUI.t1;
        }

        private void tb1t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb1t3();
        }
        public void Get_tb1t3()
        {
            tb1t3.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb2t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb2t3();
        }
        public void Get_tb2t3()
        {
            tb2t3.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }
        private void tb1t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb1t4();
        }
        public void Get_tb1t4()
        {
            tb1t4.Text = Form1DF5.GUI.t1;
        }

        private void tb2t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb2t4();
        }
        public void Get_tb2t4()
        {
            tb2t4.Text = Form1DF5.GUI.t1;
        }
        private void tb3t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb3t4();
        }
        public void Get_tb3t4()
        {
            tb3t4.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb4t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb4t4();
        }
        public void Get_tb4t4()
        {
            tb4t4.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb1t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb1t5();
        }
        public void Get_tb1t5()
        {
            tb1t5.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb2t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb2t5();
        }
        public void Get_tb2t5()
        {
            tb2t5.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb3t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb3t5();
        }
        public void Get_tb3t5()
        {
            tb3t5.Text = Form1DF5.GUI.t1;
        }

        private void tb4t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb4t5();
        }
        public void Get_tb4t5()
        {
            tb4t5.Text = Form1DF5.GUI.t1;
        }
        private void tb8t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb8t5();
        }
        public void Get_tb8t5()
        {
            tb8t5.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void tb9t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb9t5();
        }
        public void Get_tb9t5()
        {
            tb9t5.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void tb1t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb1t6();
        }
        public void Get_tb1t6()
        {
            tb1t6.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb2t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND1C fr = new FormSeachKIND1C();
            fr.ShowDialog();
            Get_tb2t6();
        }
        public void  Get_tb2t6()
        {
            tb2t6.Text = FormSeachKIND1C.Form1D_GUI.K1;
        }

        private void tb3t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb3t6();
        }

        public void Get_tb3t6()
        {
            tb3t6.Text = Form1DF5.GUI.t1;
        }
        private void tb4t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();
            Get_tb4t6();
        }
        public void Get_tb4t6()
        {
            tb4t6.Text = Form1DF5.GUI.t1;
        }

        private void tb5t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb5t6();
        }
        public void Get_tb5t6()
        {
            tb5t6.Text = SearchVENDC1B.getDataTable.C_NO;
        }
        private void tb6t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb6t6();
        }
        public void Get_tb6t6()
        {
            tb6t6.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void tb1t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Get_tb1t7();
        }
        public void Get_tb1t7()
        {
            tb1t7.Text = FormSeachKIND.GUI_FORM1EF7.tx1;
        }

        private void tb2t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Get_tb2t7();
        }
        public void Get_tb2t7()
        {
            tb2t7.Text = FormSeachKIND.GUI_FORM1EF7.tx1;
        }

        private void tb3t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb3t7();
        }
        public void Get_tb3t7()
        {
            tb3t7.Text = SearchVENDC1B.getDataTable.C_NO;
        }
        private void tb4t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SearchVENDC1B fr = new SearchVENDC1B();
            fr.ShowDialog();
            Get_tb4t7();
        }
        public void Get_tb4t7()
        {
            tb4t7.Text = SearchVENDC1B.getDataTable.C_NO;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Get_Tab1();
            Get_Tab2();
            Get_Tab3();
            Get_Tab4();
            Get_Tab5();
            Get_tab6();
            Get_tab7();
            Get_tab8();

            Get_RD_tab4();
            Get_RD_tab5();
            Get_RD_tab6();
            Get_RD_tab7();
            Get_RD_tab8();


            if(tabControl1.SelectedIndex == 0)
            {
                Form1DF7_Tab1 fr = new Form1DF7_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1DF7_Tab2 fr = new Form1DF7_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Form1DF7_Tab3 fr = new Form1DF7_Tab3();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                Form1DF7_Tab4 fr = new Form1DF7_Tab4();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                Form1DF7_Tab5 fr = new Form1DF7_Tab5();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 5) 
            {
                Form1DF7_Tab6 fr = new Form1DF7_Tab6();
                fr.ShowDialog();
            }
            else if(tabControl1.SelectedIndex == 6)
            {
                MessageBox.Show("Chức Năng Này Đang Được Phát Triển! \n Vui Lòng Liên Hệ Admin Để Được Hỗ Trợ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(tabControl1.SelectedIndex == 7)
            {
                MessageBox.Show("Chức Năng Này Đang Được Phát Triển! \n Vui Lòng Liên Hệ Admin Để Được Hỗ Trợ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public class DLT
        {
            public static string t1t1;
            public static string t2t1;
            public static string t3t1;
            public static string t4t1;
            public static string t5t1;
            public static string t6t1;
            public static string t7t1;
            public static string t8t1;

            public static string t1t2;
            public static string t2t2;
            public static string t3t2;
            public static string t4t2;
            public static string t5t2;
            public static string t6t2;

            public static string t1t3;
            public static string t2t3;

            public static string t1t4;
            public static string t2t4;
            public static string t3t4;
            public static string t4t4;

            public static string t1t5;
            public static string t2t5;
            public static string t3t5;
            public static string t4t5;
            public static string t5t5;
            public static string t6t5;
            public static string t7t5;
            public static string t8t5;
            public static string t9t5;

            public static string t1t6;
            public static string t2t6;
            public static string t3t6;
            public static string t4t6;
            public static string t5t6;
            public static string t6t6;
            public static string t7t6;

            public static string t1t7;
            public static string t2t7;
            public static string t3t7;
            public static string t4t7;
            public static string t5t7;

            public static string t1t8;
            public static string t2t8;
            public static string t3t8;
            public static string t4t8;
            public static string t5t8;
        }

        public class RD
        {
            public static bool r1t4;
            public static bool r2t4;

            public static bool r1t5;
            public static bool r2t5;

            public static bool r1t6;
            public static bool r2t6;
            public static bool r3t6;

            public static bool r1t7;
            public static bool r2t7;
            public static bool r3t7;
            public static bool r4t7;
            public static bool r5t7;

            public static bool r1t8;
            public static bool r2t8;
            public static bool r3t8;
            public static bool r4t8;
        }

        public void Get_Tab1()
        {
            DLT.t1t1 = tb1t1.Text;
            DLT.t2t1 = tb2t1.Text;
            DLT.t3t1 = tb3t1.Text;
            DLT.t4t1 = tb4t1.Text;
            DLT.t5t1 = tb5t1.Text;
            DLT.t6t1 = tb6t1.Text;
            DLT.t7t1 = tb7t1.Text;
            DLT.t8t1 = tb8t1.Text;
        }

        public void Get_Tab2()
        {
            DLT.t1t2 = tb1t2.Text;
            DLT.t2t2 = tb2t2.Text;
            DLT.t3t2 = tb3t2.Text;
            DLT.t4t2 = tb4t2.Text;
            DLT.t5t2 = tb5t2.Text;
            DLT.t6t2 = tb6t2.Text;
        }

        public void Get_Tab3()
        {
            DLT.t1t3 = tb1t3.Text;
            DLT.t2t3 = tb2t3.Text;
        }
        public void Get_Tab4()
        {
            DLT.t1t4 = tb1t4.Text;
            DLT.t2t4 = tb2t4.Text;
            DLT.t3t4 = tb3t4.Text;
            DLT.t4t4 = tb4t4.Text;
        }
        public void Get_Tab5()
        {
            DLT.t1t5 = tb1t5.Text;
            DLT.t2t5 = tb2t5.Text;
            DLT.t3t5 = tb3t5.Text;
            DLT.t4t5 = tb4t5.Text;
            DLT.t5t5 = tb5t5.Text;
            DLT.t6t5 = tb6t5.Text;
            DLT.t7t5 = tb7t5.Text;
            DLT.t8t5 = tb8t5.Text;
            DLT.t9t5 = tb9t5.Text;
        }

        public void Get_tab6()
        {
            DLT.t1t6 = tb1t6.Text;
            DLT.t2t6 = tb2t6.Text;
            DLT.t3t6 = tb3t6.Text;
            DLT.t4t6 = tb4t6.Text;
            DLT.t5t6 = tb5t6.Text;
            DLT.t6t6 = tb6t6.Text;
            DLT.t7t6 = tb7t6.Text;
        }
        public void Get_tab7()
        {
            DLT.t1t7 = tb1t7.Text;
            DLT.t2t7 = tb2t7.Text;
            DLT.t3t7 = tb3t7.Text;
            DLT.t4t7 = tb4t7.Text;
            DLT.t5t7 = tb5t1.Text;
        }
        public void Get_tab8()
        {
            DLT.t1t8 = tb1t8.Text;
            DLT.t2t8 = tb2t8.Text;
            DLT.t3t8 = tb3t8.Text;
            DLT.t4t8 = tb4t8.Text;
            DLT.t5t8 = tb5t1.Text;
        }

        public void Get_RD_tab4()
        {
            RD.r1t4 = rd1t4.Checked;
            RD.r2t4 = rd2t4.Checked;
        }

        public void Get_RD_tab5()
        {
            RD.r1t5 = rd1t5.Checked;
            RD.r2t5 = rd2t5.Checked;
        }
        public void Get_RD_tab6()
        {
            RD.r1t6 = rd1t6.Checked;
            RD.r2t6 = rd2t6.Checked;
            RD.r3t6 = rd3t6.Checked;
        }
       
        public void Get_RD_tab7()
        {
            RD.r1t7 = rd1t7.Checked;
            RD.r2t7 = rd2t7.Checked;
            RD.r3t7 = rd3t7.Checked;
            RD.r4t7 = rd4t7.Checked;
            RD.r5t7 = rd5t7.Checked;
        }
        public void Get_RD_tab8()
        {
            RD.r1t8 = rd1t8.Checked;
            RD.r2t8 = rd2t8.Checked;
            RD.r3t8 = rd3t8.Checked;
            RD.r4t8 = rd4t8.Checked;
        }

        private void Form1DF7_Load(object sender, EventArgs e)
        {
            tb1t6.Hide();
            tb2t6.Hide();
            tb3t6.Hide();
            tb4t6.Hide();
            tb5t6.Hide();
            tb6t6.Hide();
            tb7t6.Hide();

            l1t6.Hide();
            l2t6.Hide();
            l3t6.Hide();
            l4t6.Hide();
            l5t6.Hide();
            l6t6.Hide();
            l7t6.Hide();

        }

        private void rd2t6_CheckedChanged(object sender, EventArgs e)
        {
         
            if(rd2t6.Checked == true)
            {
                tb1t6.Show();
                tb2t6.Show();
                tb3t6.Show();
                tb4t6.Show();
                tb5t6.Show();
                tb6t6.Show();

                l1t6.Show();
                l2t6.Show();
                l3t6.Show();
                l4t6.Show();
                l5t6.Show();
                l6t6.Show();
            }
            else if(rd2t6.Checked == false)
            {
                tb1t6.Hide();
                tb2t6.Hide();
                tb3t6.Hide();
                tb4t6.Hide();
                tb5t6.Hide();
                tb6t6.Hide();

                l1t6.Hide();
                l2t6.Hide();
                l3t6.Hide();
                l4t6.Hide();
                l5t6.Hide();
                l6t6.Hide();
            }
        }
        private void rd3t6_CheckedChanged(object sender, EventArgs e)
        {
           
            if(rd3t6.Checked == true)
            {
                tb7t6.Show();
                l7t6.Show();
            }
            else if (rd3t6.Checked == false)
            {
                tb7t6.Hide();
                l7t6.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Get_Tab1();
            Get_Tab2();
            Get_Tab3();
            Get_Tab4();
            Get_Tab5();
            Get_tab6();
            Get_tab7();
            Get_tab8();

            Get_RD_tab4();
            Get_RD_tab5();
            Get_RD_tab6();
            Get_RD_tab7();
            Get_RD_tab8();


            if (tabControl1.SelectedIndex == 0)
            {
                Form1DF7_Tab1 fr = new Form1DF7_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1DF7_Tab2 fr = new Form1DF7_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Form1DF7_Tab3 fr = new Form1DF7_Tab3();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                Form1DF7_Tab4 fr = new Form1DF7_Tab4();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                Form1DF7_Tab5 fr = new Form1DF7_Tab5();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                Form1DF7_Tab6 fr = new Form1DF7_Tab6();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                MessageBox.Show("Chức Năng Này Đang Được Phát Triển! \n Vui Lòng Liên Hệ Admin Để Được Hỗ Trợ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                MessageBox.Show("Chức Năng Này Đang Được Phát Triển! \n Vui Lòng Liên Hệ Admin Để Được Hỗ Trợ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        //tab1
        private void tb1t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t1, tb2t1, sender, e);
        }

        private void tb2t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t1, tb3t1, sender, e);
        }

        private void tb3t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t1, tb4t1, sender, e);
        }

        private void tb4t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3t1, tb5t1, sender, e);
        }

        private void tb5t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4t1, tb6t1, sender, e);
        }

        private void tb6t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb5t1, tb7t1, sender, e);
        }
        private void tb7t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb6t1, tb8t1, sender, e);
        }

        private void tb8t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb7t1, button3, sender, e);
        }
        //tab 2
        private void tb1t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t2, tb2t2, sender, e);
        }

        private void tb2t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t2, tb3t2, sender, e);
        }

        private void tb3t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t2, tb4t2, sender, e);
        }

        private void tb4t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3t2, tb5t2, sender, e);
        }

        private void tb5t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4t2, tb6t2, sender, e);
        }

        private void tb6t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb5t2, button3, sender, e);
        }
        //tab 3
        private void tb1t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t3, tb2t3, sender, e);
        }

        private void tb2t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb1t3, button3, sender, e);
        }
        //tab 4
        private void tb1t4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t4, tb2t4, sender, e);
        }
        private void tb2t4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t4, tb3t4, sender, e);
        }
        private void tb3t4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t4, tb4t4, sender, e);
        }
        private void tb4t4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb3t4, button3, sender, e);
        }
        //tab 5
        private void tb5t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb5t5.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb6t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb6t5.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
