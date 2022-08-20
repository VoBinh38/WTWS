﻿using PURCHASE.MAINCODE;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PURCHASE
{
    class DataProvider
    {
        public string LinkTemplate = @"\\192.168.0.5\Data weitai\IT\Hoang\Long\Template\";
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public string user_id = "";
        public int RowIndexs;
        public static string chooselanguage;

        public void Openconnect() // Open Connect SQL 
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }
        public void Closeconnect() // Close Connect SQL 
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public Boolean exedata(string cmd) // Check static UPDATE, INSERT , DELETE 
        {
            Openconnect();
            //SqlTransaction transaction;
            //////bắt đầu quá trình quản lý transaction
            //transaction = connect.BeginTransaction();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connect);
                //gắn transaction với đối tượng cmd
                //sc.Transaction = transaction;
                sc.ExecuteNonQuery();
                check = true;
                //transaction.Commit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //transaction.Rollback(); //quay lùi
                check = false;
            }
            Closeconnect();
            return check;
        }

        public DataTable readdata(string cmd) // fill DataTable
        {
            Openconnect();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connect);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(da);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                da = null;
            }
            Closeconnect();
            return da;
        }
        public string getValueLanguage()
        {
            return chooselanguage;
        }
        public string getID(string username, string pass) // Login And get ID Use 
        {
            string id = "";
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM USRH WHERE USER_ID ='" + username + "' and PAS_WORD='" + pass + "'", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["USER_ID"].ToString().Trim();
                        chooselanguage = dr["LANGUAGE"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return id;
        }

        public string getUser(string ID) // get User Name 
        {
            string USER = "";
            try
            {
                connect.Open();
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM USRH WHERE USER_ID ='" + ID + "'", connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        USER = dr["NAME"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return USER;
        }
        public string Check(string IDCheck, string SQL) // get User Name 
        {
            string Resultf = "";
            try
            {
                connect.Open();
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand(SQL, connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Resultf = dr[IDCheck].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return Resultf;
        }
        public string ID(string SQL, string ID) // get User Name 
        {
            string Result = "";
            try
            {
                connect.Open();
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand(SQL, connect);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Result = dr[ID].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                connect.Close();
            }
            return Result;
        }
        public bool IsNumber(string pValue) // Kiem Tra Số hay Không 
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public String getDateNow() // Get Date Now 
        {
            string today = "";
            string User = frmLogin.ID_USER;
            string sql = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["LANGUAGE"].ToString() == "1")
                {
                    today = "Năm: " + DateTime.Now.Year.ToString() + " Tháng: " + DateTime.Now.Month.ToString() + " Ngày: " + DateTime.Now.Day.ToString();
                }
                else if (dataRow["LANGUAGE"].ToString() == "2")
                {
                    today = "Year: " + DateTime.Now.Year.ToString() + " Month: " + DateTime.Now.Month.ToString() + " Day: " + DateTime.Now.Day.ToString();
                }
                else if (dataRow["LANGUAGE"].ToString() == "3")
                {
                    today = "五: " + DateTime.Now.Year.ToString() + " 月: " + DateTime.Now.Month.ToString() + " 日: " + DateTime.Now.Day.ToString();
                }
                else
                {
                    today = "Năm: " + DateTime.Now.Year.ToString() + " Tháng: " + DateTime.Now.Month.ToString() + " Ngày: " + DateTime.Now.Day.ToString();
                }
            }
            return today;
        }

        public string getTimeNow() //Get Time Now
        {
            string timenow = "";
            string User = frmLogin.ID_USER;
            string sql = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow["LANGUAGE"].ToString() == "1")
                    {
                        timenow = "Bây Giờ: " + DateTime.Now.Hour.ToString() + " Phút: " + DateTime.Now.Minute.ToString() + " Giây: " + DateTime.Now.Second.ToString();
                    }
                    else if (dataRow["LANGUAGE"].ToString() == "2")
                    {
                        timenow = "Now: " + DateTime.Now.Year.ToString() + " Minute: " + DateTime.Now.Month.ToString() + " Seconds: " + DateTime.Now.Day.ToString();
                    }
                    else if (dataRow["LANGUAGE"].ToString() == "3")
                    {
                        timenow = "現在: " + DateTime.Now.Year.ToString() + " 分鐘: " + DateTime.Now.Month.ToString() + " 第二: " + DateTime.Now.Day.ToString();
                    }
                    else
                    {
                        timenow = "Bây Giờ: " + DateTime.Now.Hour.ToString() + " Phút: " + DateTime.Now.Minute.ToString() + " Giây: " + DateTime.Now.Second.ToString();
                    }
                }
            }

            return timenow;
        }
        public string formatstr1(string str1) // Format YY  
        {
            string Result = str1;
            if (str1 == string.Empty)
            {
                return Result;
            }
            else if (Result.Length == 5)
            {
                //Format String yy/MM to yyMM
                Result = Result.Remove(Result.Length - 3, 1);
                return Result;
            }
            else if (Result.Length == 4)
            {
                //Format String yyMM to yy/MM
                Result = Result.Insert(Result.Length - 2, "/");
                return Result;
            }
            else if (Result.Length == 6)
            {
                //Format String yyMMdd to yyyy/MM/dd
                Result = Result.Insert(Result.Length - 2, "/");
                Result = Result.Insert(Result.Length - 5, "/");
                return Result;
            }
            else if (Result.Length == 8)
            {
                //Format String yy/MM/dd to yyMMdd
                Result = Result.Remove(Result.Length - 3, 1);
                Result = Result.Remove(Result.Length - 5, 1);
                return Result;
            }


            else
            {
                //essageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return Result = "";
            }
            //return Result;
        }
        public string formatstr2(string str1) // Format YYYY  
        {
            string Result = str1;
            if (str1 == string.Empty)
            {
                return Result = "";
            }
            else if (Result.Length == 6)
            {
                //Format String yyyyMM= to yyyy/MM
                Result = Result.Insert(Result.Length - 2, "/");
                return Result;
            }
            else if (Result.Length == 7)
            {
                //Format String yyyy/MM to yyyyMM
                Result = Result.Remove(Result.Length - 3, 1);
                return Result;
            }
            else if (Result.Length == 8)
            {
                //Format String yyMMyyyyMMdd to yyyy/MM/dd
                Result = Result.Insert(Result.Length - 2, "/");
                Result = Result.Insert(Result.Length - 5, "/");
                return Result;
            }
            else if (Result.Length == 10)
            {
                //Format String yyyy/MM/dd to yyyyMMdd
                Result = Result.Remove(Result.Length - 3, 1);
                Result = Result.Remove(Result.Length - 5, 1);
                return Result;
            }
            else
            {
                // MessageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại","Thông Báo",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return Result = str1;
            }
            // return Result;
        }
        public string formatstr3(string str1) // Format MM/dd
        {
            string Result = str1;
            if (str1 == string.Empty)
            {
                return Result = "";
            }
            else if (Result.Length > 4)
            {
                Result = Result.Substring(Result.Length - 4, 4);
                Result = Result.Insert(Result.Length - 2, "/");
                return Result;
            }
            else
            {
                // MessageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại","Thông Báo",MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return Result = str1;
            }
            // return Result;
        }
        public void DGV(DataGridView NameDGV)
        {
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);
            // NameDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void FormatDGV(DataGridView NameDGV, DataTable dt)
        {
            NameDGV.DataSource = dt;
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);
        }
        public void FormatDGVbindingsource(DataGridView NameDGV, BindingSource dt)
        {
            NameDGV.DataSource = dt;
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);
        }
        public void DGV1(DataGridView NameDGV)
        {
            NameDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameDGV.RowHeadersWidth = 20;
            NameDGV.EnableHeadersVisualStyles = false;
            NameDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            NameDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            NameDGV.DefaultCellStyle.Font = new Font("Tahoma", 11F);

        }
        public string Moneys(string n)
        {
            if (n == "EUR")
                n = "歐元";
            if (n == "NTD")
                n = "台幣";
            if (n == "USD")
                n = "美元";
            if (n == "VND")
                n = "越南盾";
            return n;
        }
        public string FormatNumber(string Number)
        {
            Number = string.Format("{0:#,##0.00}", Number);
            return Number;
        }
        public void tab_Combobox(TextBox txtUp, ComboBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }
        public void tab_Button(TextBox txtUp, Button txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        public void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        public void tab_UP(MaskedTextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        public void tab_DOWN(TextBox txtUp, MaskedTextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        public void tab_UP_DOWN(MaskedTextBox txtUp, MaskedTextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        public bool Check_MaskedText(MaskedTextBox maskedTextBox)
        {
            // string a = "";
            if (maskedTextBox.MaskFull)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Check_Decentralization(string cmd)
        {
            bool check = false;
            string ID_USER = frmLogin.ID_USER;
            string SQL = "SELECT TOP 1 case when USRH.SUPER = 0 " +
                " THEN(case when P_USE = 1 then 'True' else 'False' end) " +
                " ELSE 'True' end as PUSE from USRB_NEW " +
                " INNER join USRH on USRH.USER_ID = USRB_NEW.USER_ID" +
                " INNER JOIN FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                " WHERE USRH.USER_ID = '" + ID_USER + "' and Name_From = '" + cmd + "'";
            try
            {
                DataTable dataTable = readdata(SQL);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow data in dataTable.Rows)
                    {
                        if (data["PUSE"].ToString() == "False")
                        {
                            // bị khóa
                            check = true;
                        }
                    }
                }
                else
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }
        public class LG
        {
            public static bool rdVietNam;
            public static bool rdEnglish;
            public static bool rdChina;
        }
        public void choose_languege()
        {
            string User = frmLogin.ID_USER;
            string sql = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["LANGUAGE"].ToString() == "1")
                {
                    LG.rdVietNam = true;
                    LG.rdEnglish = false;
                    LG.rdChina = false;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
                }
                else if (dataRow["LANGUAGE"].ToString() == "2")
                {
                    LG.rdVietNam = false;
                    LG.rdEnglish = true;
                    LG.rdChina = false;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                }
                else if (dataRow["LANGUAGE"].ToString() == "3")
                {
                    LG.rdVietNam = false;
                    LG.rdEnglish = false;
                    LG.rdChina = true;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-TW");
                }
                else if (dataRow["LANGUAGE"].ToString() == string.Empty || dataRow["LANGUAGE"].ToString() == "")
                {
                    LG.rdVietNam = true;
                    LG.rdEnglish = false;
                    LG.rdChina = false;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");
                }
            }
        }
        public void Mousewheelscroll(DataGridView dataGridView, MouseEventArgs e)
        {
            int rowindex_New;
            int rowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            if (rowIndex != 0)
            {
                dataGridView.ClearSelection();
            }
            HandledMouseEventArgs handledE = (HandledMouseEventArgs)e;
            handledE.Handled = true;

            if (e.Delta < 0)
            {
                rowindex_New = dataGridView.CurrentRow.Index + 1;
            }
            else
            {
                rowindex_New = dataGridView.CurrentRow.Index - 1;
            }
            if (rowindex_New >= 0 && rowindex_New <= dataGridView.Rows.Count)
            {
                if (rowindex_New == dataGridView.Rows.Count)
                {
                    rowindex_New = rowindex_New - 1;
                    dataGridView.CurrentCell = dataGridView[2, rowindex_New];
                }
                else
                {
                    dataGridView.CurrentCell = dataGridView[2, rowindex_New];
                }
                dataGridView.Rows[rowindex_New].Selected = true;
                RowIndexs = rowindex_New;
            }

        }
        // create MenuStrip
        public DataGridView gridView;
        public void CreateMenuStrip(MouseEventArgs e, DataGridView DGV,ToolStripItemClickedEventHandler Menu_ItemClicked)
        {
            gridView = DGV;
            if (e.Button == MouseButtons.Left)
            {
                // MessageBox.Show("left");
            }
            else
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Insert").Name = "Insert";
                menu.Items.Add("Delele").Name = "Delele";
                menu.Items.Add("Edit").Name = "Edit";
                menu.Show(gridView, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
        //private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    switch (e.ClickedItem.Name.ToString())
        //    {
        //        case "Insert":
        //            MessageBox.Show(e.ClickedItem.Name.ToString());
        //            break;
        //        case "Delele":
        //            //DialogResult dr = MessageBox.Show("Bạn có chắc muốn xoá item này?", "Thong báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
        //            //switch (dr)
        //            //{
        //            //    case DialogResult.Yes:
        //            foreach (DataGridViewCell oneCell in gridView.SelectedCells)
        //            {
        //                if (oneCell.Selected)
        //                {
        //                    gridView.Rows.RemoveAt(oneCell.RowIndex);
        //                    //listdel.Add(new KeyValuePair<string, string>(txtWS_NO.Text, itemdel.ToString()));
        //                    if (Stts == true)
        //                    {
        //                        int NR = 1;
        //                        for (int i = 0; i < gridView.Rows.Count - 1; i++)
        //                        {
        //                            gridView[0, i].Value = NR.ToString("D" + 3);
        //                            NR++;
        //                        }
        //                    }
        //                }
        //            }
        //            //        break;
        //            //    case DialogResult.No:
        //            //        break;
        //            //}
        //            break;
        //    }
        //}
        public void MouseButtonsRightSelectDGV(DataGridViewCellMouseEventArgs e, DataGridView DGV)
        {
            DGV.ClearSelection();
            int rowIndex = e.RowIndex;
            DGV.Rows[rowIndex].Selected = true;
        }

        public void CheckPriceLock(string form_name, TextBox textBox)
        {
            string sql = "SELECT P_PRICE FROM dbo.USRB_NEW JOIN dbo.FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                    " WHERE [USER_ID] = '" + frmLogin.ID_USER + "' AND Name_From = '" + form_name + "'";
            DataTable dt = new DataTable();
            dt = readdata(sql);
            if (dt.Rows[0]["P_PRICE"].ToString() == "True")
            {
                textBox.Enabled = true;
            }
            else
            {
                textBox.Enabled = false;
            }
        }
        public void CheckLoad(MenuStrip menuStrip)
        {
            try
            {
                string form_name = "";
                var names = Application.OpenForms.Cast<Form>().Select(f => f.Name).ToList();
                for (int i = 0; i < names.Count; i++)
                {
                    if (i == names.Count - 1)
                    {
                        form_name = names[i].ToString();
                    }
                }
                string sql = "SELECT * FROM dbo.USRB_NEW JOIN dbo.FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                    " WHERE [USER_ID] = '" + frmLogin.ID_USER + "' AND Name_From = '" + form_name + "'";
                DataTable dt = new DataTable();
                dt = readdata(sql);

                //DataTable dt1 = dt.AsEnumerable().Where(x => x.Field<string>("Name_From").Contains(form_name)).CopyToDataTable();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SUPER"].ToString() == "True")
                    {
                        menuStrip.Items["f1ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f2ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f3ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f4ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f5ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f6ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f7ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f8ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f9ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f10ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f11ToolStripMenuItem"].Enabled = true;
                        menuStrip.Items["f12ToolStripMenuItem"].Enabled = true;

                    }
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["F1"].ToString() == "False")
                            {
                                menuStrip.Items["f1ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f1ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F2"].ToString() == "False")
                            {
                                menuStrip.Items["f2ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f2ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F3"].ToString() == "False")
                            {
                                menuStrip.Items["f3ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f3ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F4"].ToString() == "False")
                            {
                                menuStrip.Items["f4ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f4ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F5"].ToString() == "False")
                            {
                                menuStrip.Items["f5ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f5ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F6"].ToString() == "False")
                            {
                                menuStrip.Items["f6ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f6ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F7"].ToString() == "False")
                            {
                                menuStrip.Items["f7ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f7ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F8"].ToString() == "False")
                            {
                                menuStrip.Items["f8ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f8ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F9"].ToString() == "False")
                            {
                                menuStrip.Items["f9ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f9ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F10"].ToString() == "False")
                            {
                                menuStrip.Items["f10ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f10ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F11"].ToString() == "False")
                            {
                                menuStrip.Items["f11ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f11ToolStripMenuItem"].Enabled = true;
                            }
                            if (row["F12"].ToString() == "False")
                            {
                                menuStrip.Items["f12ToolStripMenuItem"].Enabled = false;
                            }
                            else
                            {
                                menuStrip.Items["f12ToolStripMenuItem"].Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public bool checkExists(string sql)
        {
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql);
            if (dataTable.Rows.Count > 0)
            {
                //có trùng mã
                return true;
            }
            else
            {
                // khong trung mã
                return false;
            }    
        }
        //public string CreateFilexcel()
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "Excel file |*.xls;*.xlsx;*.csv";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        var app1 = new Microsoft.Office.Interop.Excel.Application();
        //        var wb = app1.Workbooks.Add();
        //        wb.SaveAs(sfd.FileName);
        //        wb.Close();
        //    }
        //    return sfd.FileName;
        //}
        static int l = 1;
        public string checkedLanguage()
        {
            string User = frmLogin.ID_USER;
            string sql1 = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = readdata(sql1);

            foreach (DataRow item in dataTable.Rows)
            {
                l = int.Parse(item["LANGUAGE"].ToString());
            }

            string result;
            if (l == 3)
            {
                LG.rdVietNam = false;
                LG.rdEnglish = false;
                LG.rdChina = true;
                result = "LanguageCH";
            }
            else if (l == 2)
            {
                LG.rdVietNam = false;
                LG.rdEnglish = true;
                LG.rdChina = false;
                result = "LanguageEN";
            }
            else
            {
                LG.rdVietNam = true;
                LG.rdEnglish = false;
                LG.rdChina = false;
                result = "LanguageVN";
            }
            return result;
        }
        public DataTable dataCheckLanguage;
        public void GetDataCheckLanguage()
        {
            //string sql = "SELECT keyWork," + checkedLanguage() + " as ChooseLanguage,Position FROM dbo.Choose_Language";
            //dataCheckLanguage = readdata(sql);
        }
        public void CheckLanguage(Form form)
        {
            string sql = "SELECT keyWork," + checkedLanguage() + " as ChooseLanguage,Position FROM dbo.Choose_Language";
            dataCheckLanguage = readdata(sql);

            var values = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("Position") == "frm"
                            && item.Field<string>("KeyWork") == form.Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
            form.Text = values;

            foreach (Control x in form.Controls)
            {
                if (x is TabControl)
                {
                    // set text TabControl
                    SetLanguageTabControl(x);
                }
                else if (x is MenuStrip)
                {
                    // set text ItemMenuStrip
                    SetLanguageItemMenuStrip(x);
                }
                else if (x is StatusStrip)
                {
                    // set text ItemStatusStrip
                    SetLanguageItemStatusStrip(x);
                }else if (x is DataGridView)
                {
                    // set text DataGridView
                    SetLanguageDataGridView(x);
                }
                else if (x is GroupBox)
                {
                    SetLanguageGroupBox(x);
                }
                else
                {
                    SetLanguageText(x);
                }
            }
        }

        public void SetLanguageTabControl(Control x)
        {
            foreach (Control contr in x.Controls)
            {
                // set Text tab page
                SetLanguageTabControl((TabPage)contr);

                // set Text item in Tab Control
                foreach (Control control1 in contr.Controls)
                {
                    if (control1 is DataGridView)
                    {
                        // set text DataGridView
                        SetLanguageDataGridView(control1);
                    }
                    else if (control1 is Panel)
                    {
                        // set text Panel
                        SetLanguagePanel(control1);
                    }
                    else
                    {
                        // set text button,label...
                        SetLanguageText(control1);
                    }
                }
            }
        }
        public void SetLanguageText(Control control)
        {
            if (control.GetType() != typeof(TextBox))
            {
                var value = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("KeyWork").ToString() == (control).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
                if (!string.IsNullOrEmpty(value))
                {
                    //if (l == 3)
                    //{
                    //    (control).Font = new Font("SimSum", 14);
                    //    if(control is Label)
                    //    {
                    //        ((Label)control).TextAlign = ContentAlignment.MiddleRight;
                    //    }
                    //}
                    (control).Text = value;
                }
            }
        }

        public void SetLanguagePanel(Control control)
        {
            foreach (Control itempanel in control.Controls)
            {
                if (itempanel is GroupBox)
                {
                    SetLanguageGroupBox(itempanel);
                }
                else
                {
                    SetLanguageText(itempanel);
                }
            }
        }

        public void SetLanguageGroupBox(Control control)
        {
            var values = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("Position") == "gb"
                    && item.Field<string>("KeyWork") == (control).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
            if (!string.IsNullOrEmpty(values))
            {
                (control).Text = values;
            }
            foreach (Control itemGroup in control.Controls)
            {
                SetLanguageText(itemGroup);
            }
        }
        public void SetLanguageDataGridView(Control control)
        {
            foreach (var column in ((DataGridView)control).Columns)
            {
                if (column is DataGridViewTextBoxColumn)
                {
                    // set text GridViewTextBoxColumn
                    SetLanguageColumText((DataGridViewTextBoxColumn)column);
                }
                else if (column is DataGridViewCheckBoxColumn)
                {
                    // set text GridViewCheckBoxColumn
                    SetLanguageColumCheck((DataGridViewCheckBoxColumn)column);
                }
            }
        }
        public void SetLanguageColumText(DataGridViewTextBoxColumn column)
        {
            var values = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("Position") == "Colum"
               && item.Field<string>("KeyWork")==(column).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
            if (!string.IsNullOrEmpty(values))
            {
                (column).HeaderText = values;
            }
        }
        public void SetLanguageColumCheck(DataGridViewCheckBoxColumn column)
        {
            var values = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("Position") == "Colum"
               && item.Field<string>("KeyWork")==(column).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
            if (!string.IsNullOrEmpty(values))
            {
                (column).HeaderText = values;
            }
        }
        public void SetLanguageItemMenuStrip(Control control)
        {
            foreach (var menustrip in ((MenuStrip)control).Items)
            {
                var value = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("KeyWork")==((ToolStripMenuItem)menustrip).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
                if (!string.IsNullOrEmpty(value))
                {
                    ((ToolStripMenuItem)menustrip).Text = value;
                }
            }
        }
        public void SetLanguageItemStatusStrip(Control control)
        {

            foreach (var menustrip in ((StatusStrip)control).Items)
            {
                var value = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("KeyWork")==((ToolStripStatusLabel)menustrip).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
                if (!string.IsNullOrEmpty(value))
                {
                    ((ToolStripStatusLabel)menustrip).Text = value;
                }
            }
        }
        public void SetLanguageTabControl(TabPage column)
        {
            var nametabcontrol = dataCheckLanguage.AsEnumerable().Where(item => item.Field<string>("KeyWork")==(column).Name).Select(y => y.Field<string>("ChooseLanguage")).FirstOrDefault();
            if(!string.IsNullOrEmpty(nametabcontrol))
            {
                (column).Text = nametabcontrol;
            }
        }
        public void getMoney(ComboBox cb)
        {
            string sql = "SELECT DISTINCT M_NAME FROM MONEYT";
            DataTable dt = new DataTable();
            dt = readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                cb.Items.Add(item["M_NAME"].ToString());
            }
        }
        public string returnMoney_VND(string key)
        {
            string keyreturn = "";
            string sql = "SELECT DISTINCT M_NAME_E FROM MONEYT WHERE M_NAME = '"+key+"'";
            DataTable dt = new DataTable();
            dt = readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                keyreturn = item["M_NAME_E"].ToString();
            }
            return keyreturn;
        }
        public string returnMoney_TQ(string key)
        {
            string keyreturn = "";
            string sql = "SELECT DISTINCT M_NAME FROM MONEYT WHERE M_NAME_E = '" + key + "'";
            DataTable dt = new DataTable();
            dt = readdata(sql);
            foreach (DataRow item in dt.Rows)
            {
                keyreturn = item["M_NAME"].ToString();
            }
            return keyreturn;
        }

        public string ConvertNumber(string text)
        {
            string res = double.Parse(text).ToString("N2");
            return res;
        }
    }
}
