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
    public partial class Form1FF7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1FF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
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
        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
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
            conn.tab_Button(tb3t2, button3, sender, e);
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
            conn.tab_Button(tb5t3, button3, sender, e);
        }

    }
}
