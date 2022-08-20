using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PURCHASE
{
    public static class MyExtension
    {
        public static string Nam4So(this TextBox txt)
        {
            string Result = txt.Text;
            if (Result == string.Empty)
            {
                return Result;
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
                MessageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return Result;
            }
        }
        public static string Nam2So(this TextBox txt)
        {
            string Result = txt.Text;
            if (Result == string.Empty)
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
                MessageBox.Show("Định dạng ngày tháng năm sai, vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return Result;
            }
        }
        public static void MyDGV(this DataGridView DGV)
        {
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowHeadersWidth = 20;
            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            DGV.DefaultCellStyle.Font = new Font("Tahoma", 12F);
            DGV.BackgroundColor = Color.White;
            DGV.DefaultCellStyle.Format = "#,##0.00";
        }
        
        public static bool isNumber(this TextBox txt)
        {
            string s1 = txt.Text;
            bool Result= false;
            foreach (Char c in s1)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Dữ liệu nhập phải là số !");
                    txt.Text = "";
                    txt.Focus();
                    Result = false;
                    break;
                }  
                else
                    Result = true;
            }
            return Result;
        }
        public static void KetnoiSQL(this SqlConnection conn)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public static double MyTexbox(this TextBox txt)
        {
            double x = 0;
            double.TryParse(txt.Text, out x);
            return x;
        }
        public static bool CheckText(this TextBox txt, DataTable dt, string Col)
        {
            bool Results = dt.AsEnumerable().Any(row => txt.Text == row.Field<String>(Col));
            return Results;
        }

    }
}
