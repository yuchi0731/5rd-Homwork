using Handshake_DBSoure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandShake_7715.Frontside
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var tableFirst = CreatDateTable();
            DataRow rowFirst = tableFirst.Rows[1];      //因為Table的取序列是用[1]開始
            var columnFirst = rowFirst[0];              //因為Row的取序列是用[0]開始
            this.ltlFirstaddNote.Text = $"{columnFirst.ToString()}";



            var tablefinal = CreatDateTable();      //所有人的CreateDate的table       
            int i = tablefinal.Rows.Count - 1;    //因為Row的取序列是用[0]開始，如果Row值要最後一筆，就要為table總筆數-1
            DataRow rowFinal = tablefinal.Rows[i];    //取得Row最後一筆資料 ( = table最後一筆)
            var columnFinal = rowFinal[0];                   //取最後一筆的第1項欄位
            this.ltlLastaddNote.Text = $"{columnFinal.ToString()}";


            var totalAccountsNote = CountTotalAccountsNote().Rows.Count;
            this.ltlTotalNote.Text = $"共 {totalAccountsNote.ToString()} 筆";

            var totalUser = CountTotalUsers().Rows.Count;
            this.ltlTotalUser.Text = $"共 {totalUser.ToString()} 人";
        }




        /// <summary>
        /// 取得只包含創建時間Table
        /// </summary>
        /// <returns></returns>
        public static DataTable CreatDateTable()
        {
            string connectionString = DBHelper.GetConnectionString();

            string daCommandString =
                 @"SELECT CreateDate
                   FROM AccountingNote";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(daCommandString, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 計算共多少資料
        /// </summary>
        /// <returns></returns>
        public static DataTable CountTotalAccountsNote()
        {
            string connectionString = DBHelper.GetConnectionString();

            string daCommandString =
                 @"SELECT CreateDate
                   FROM UserInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(daCommandString, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 計算使用者總數
        /// </summary>
        /// <returns></returns>
        public static DataTable CountTotalUsers()
        {
            string connectionString = DBHelper.GetConnectionString();

            string daCommandString =
                 @"SELECT ID
                   FROM UserInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(daCommandString, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
        }
    }
}