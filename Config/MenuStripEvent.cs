using PURCHASE.MAINCODE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PURCHASE.Config
{
    class MenuStripEvent
    {
        int l = 1;
        Bitmap bitmap;
        DataProvider con = new DataProvider();
        public void CreateMenu(EventHandler ChildClick,MenuStrip MnuStrip)
        {
            string User = frmLogin.ID_USER;
            string sql1 = "SELECT top 1 LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = con.readdata(sql1);
            foreach (DataRow item in dataTable.Rows)
            {
                l = int.Parse(item["LANGUAGE"].ToString());
            }

            //string[] row = new string[] { "F1.Đăng ký", "F2.Thêm", "F3.Xoá", "F4.Sửa", "F5.Tìm kiếm", "F6.Sao chép", "F7.In", "F8.Lưu", "F9.Chọn", "F10.Lưu", "F11.Đóng", "F12.Kết thúc" };
            //string[] row1 = new string[] { "f1ToolStripMenuItem", "f2ToolStripMenuItem", "f3ToolStripMenuItem", "f4ToolStripMenuItem", "f5ToolStripMenuItem",
            //    "f6ToolStripMenuItem", "f7ToolStripMenuItem", "f8ToolStripMenuItem", "f9ToolStripMenuItem", "f10ToolStripMenuItem", "f11ToolStripMenuItem", "f12ToolStripMenuItem" };
            string sql = "SELECT keyWork,"+ checkedLanguage(l) + " FROM dbo.Choose_Language WHERE Position ='MenuF'";
            DataTable dt = con.readdata(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SetBitMap(dt.Rows[i][0].ToString());
                ToolStripMenuItem MnuStripItem = new ToolStripMenuItem(dt.Rows[i][1].ToString(), null, ChildClick, dt.Rows[i][0].ToString()) { Image = bitmap };
                MnuStrip.Items.Add(MnuStripItem);
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
                result = "LanguageVN";
            }
            return result;
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
                dt = con.readdata(sql);

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
        public void SetBitMap(string i)
        {
            switch (i)
            {
                case "f1ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.completed_task;
                    break;
                case "f2ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.add;
                    break;
                case "f3ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.close;
                    break;
                case "f4ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.up_arrow;
                    break;
                case "f5ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.list_search;
                    break;
                case "f6ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.copy;
                    break;
                case "f7ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.printer;
                    break;
                case "f8ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.eight;
                    break;
                case "f9ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.eight;
                    break;
                case "f10ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.save;
                    break;
                case "f11ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.translation;
                    break;
                case "f12ToolStripMenuItem":
                    bitmap = PURCHASE.Properties.Resources.shutdown;
                    break;
                default:
                    break;
            }
        }
    }
}
