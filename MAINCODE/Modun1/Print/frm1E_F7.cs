using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PURCHASE
{
    public partial class Form1E_F7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1E_F7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void Form1E_F7_Load(object sender, EventArgs e)
        {

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

            public static string t1t3;
            public static string t2t3;
            public static string t3t3;
            public static string t4t3;
            public static string t5t3;
            public static string t6t3;
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
        }

        public void Get_Tab3()
        {
            DLT.t1t3 = tb1t3.Text;
            DLT.t2t3 = tb2t3.Text;
            DLT.t3t3 = tb3t3.Text;
            DLT.t4t3 = tb4t3.Text;
            DLT.t5t3 = tb5t3.Text;
            DLT.t6t3 = tb6t3.Text;
        }

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            Get_Tab1();
            Get_Tab2();
            Get_Tab3();

            if(tabControl1.SelectedIndex == 0)
            {
                Form1EF7_Tab1 fr = new Form1EF7_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1EF7_Tab2 fr = new Form1EF7_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Chức Năng Này Đang Được Phát Triển! \n Bạn Vui Lòng Liên Hệ Admin Để Được Hỗ Trợ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void tb3t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Get_tb3t1();
        }
        public void Get_tb3t1()
        {
            tb3t1.Text = Form1CF5.GUI_FORM1E.t1;
        }

        private void tb4t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Get_tb4t1();
        }

        public void Get_tb4t1()
        {
            tb4t1.Text = Form1CF5.GUI_FORM1E.t1;
        }

        private void tb7t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchSHOUSE fr = new FormSearchSHOUSE();
            fr.ShowDialog();
            Get_tb7t1();
        }
        public void Get_tb7t1()
        {
            tb7t1.Text = FormSearchSHOUSE.DL.t1;
        }

        private void tb8t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchSHOUSE fr = new FormSearchSHOUSE();
            fr.ShowDialog();
            Get_t8t1();
        }
        public void Get_t8t1()
        {
            tb8t1.Text = FormSearchSHOUSE.DL.t1;
        }

        private void tb1t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Get_t1t2();
        }

        public void Get_t1t2()
        {
            tb1t2.Text = FormSeachKIND.GUI_FORM1EF7.tx1;
        }

        private void tb2t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Get_tb2t2();
        }

        public void Get_tb2t2()
        {
            tb2t2.Text = FormSeachKIND.GUI_FORM1EF7.tx1;
        }

        private void tb3t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Get_tb3t2();
        }
        public void Get_tb3t2()
        {
            tb3t2.Text = Form1CF5.GUI_FORM1E.t1;
        }

        private void tb4t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Get_tb4t2();
        }
        public void Get_tb4t2()
        {
            tb4t2.Text = Form1CF5.GUI_FORM1E.t1;
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

            if (tabControl1.SelectedIndex == 0)
            {
                Form1EF7_Tab1 fr = new Form1EF7_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1EF7_Tab2 fr = new Form1EF7_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Chức Năng Này Đang Được Phát Triển! \n Bạn Vui Lòng Liên Hệ Admin Để Được Hỗ Trợ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            conn.tab_Button(tb7t1, btxemtruoc, sender, e);
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
            conn.tab_Button(tb3t2, btxemtruoc, sender, e);
        }
        //tab 3
        private void tb1t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t3, tb2t3, sender, e);
        }
        private void tb2t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t3, tb3t3, sender, e);
        }
        private void tb3t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t3, tb4t3, sender, e);
        }
        private void tb4t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3t3, tb5t3, sender, e);
        }
        private void tb5t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4t3, tb6t3, sender, e);
        }
        private void tb6t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb5t3, btxemtruoc, sender, e);
        }
    }
}
