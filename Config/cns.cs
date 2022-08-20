using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PURCHASE
{
    public class CN
    {
        
        public static string str = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        public static String getDateNowE()
        {
            string today = "";
                today =
                "Year " + DateTime.Now.Year.ToString() +
                " Month " + DateTime.Now.Month.ToString() +
                " Day " + DateTime.Now.Day.ToString();
            return today;
        }
        //Get Time
        public static string getTimeNowE()
        {
            string timenow = "";
            timenow = "Now Hour: " + DateTime.Now.Hour.ToString() + " Minute " + DateTime.Now.Minute.ToString() + " seconds " + DateTime.Now.Second.ToString();
            return timenow;
        }
        public static String getDateNow()
        {
            string today = "";
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                 today =
                 "Năm " + DateTime.Now.Year.ToString() +
                 " Tháng " + DateTime.Now.Month.ToString() +
                 " Ngày " + DateTime.Now.Day.ToString();
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                 today =
                  "Năm " + DateTime.Now.Year.ToString() +
                  " Tháng " + DateTime.Now.Month.ToString() +
                  " Ngày " + DateTime.Now.Day.ToString();
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                 today =
                 "Year " + DateTime.Now.Year.ToString() +
                 " Month " + DateTime.Now.Month.ToString() +
                 " Day " + DateTime.Now.Day.ToString();
            }
            if (DataProvider.LG.rdChina == true)
            {
                 today =
                  "五 " + DateTime.Now.Year.ToString() +
                  " 月 " + DateTime.Now.Month.ToString() +
                  " 日 " + DateTime.Now.Day.ToString();
            }
            return today;
        }
        //Get Time
        public static string getTimeNow()
        {
            string timenow = "";
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                timenow = "Bây Giờ : " + DateTime.Now.Hour.ToString() + " Phút " + DateTime.Now.Minute.ToString() + " Giây " + DateTime.Now.Second.ToString();
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                 timenow = "Bây Giờ : " + DateTime.Now.Hour.ToString() + " Phút " + DateTime.Now.Minute.ToString() + " Giây " + DateTime.Now.Second.ToString();
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                 timenow = "Now Hour: " + DateTime.Now.Hour.ToString() + " Minute " + DateTime.Now.Minute.ToString() + " seconds " + DateTime.Now.Second.ToString();
            }
            if (DataProvider.LG.rdChina == true)
            {
                 timenow = "現在 : " + DateTime.Now.Hour.ToString() + " 分鐘 " + DateTime.Now.Minute.ToString() + " 第二 " + DateTime.Now.Second.ToString();
            }
            return timenow;
        }


        public static string change(string st)
        {
            string str1 = "";
            string sc1, sc2, sc3;
            try
            {
                if (st.Length < 8)
                {
                    str1 = st;
                }
                else if (st.ToString() != String.Empty)
                {
                    sc1 = st.Substring(0, 4);
                    sc2 = st.Substring(st.Length - 2, 2);
                    sc3 = st.Substring(4, 2);
                    str1 = sc1 + "/" + sc3 + "/" + sc2;
                }
                else str1 = "    /  /  ";

            }
            catch
            {

            }
            return str1;
        }
        public static string change2(string st)
        {
            string str1 = "";
            string sc1, sc2, sc3;
            try
            {
                if (st.Length < 12)
                {
                    str1 = st;
                }
                else if (st.ToString() != string.Empty)
                {
                    sc1 = st.Substring(0, 4);
                    sc2 = st.Substring(st.Length - 2, 2);
                    sc3 = st.Substring(5, 2);
                    str1 = sc1 + sc3 + sc2;
                }
                else str1 = "";

            }
            catch
            {

            }
            return str1;
        }

    }

}
