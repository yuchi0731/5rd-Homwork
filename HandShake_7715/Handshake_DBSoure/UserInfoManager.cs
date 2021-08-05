using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handshake_DBSoure
{
    public class UserInfoManager
    {
        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 @"SELECT [ID], [Account], [PWD], [Name], [Email], [UserLevel], [CreateDate]
                   FROM UserInfo
                   WHERE [Account] = @account
                 ";



            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }

        /// <summary>
        /// 取得目前所有使用者資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUserInfoList()
        {

            string connectionString = DBHelper.GetConnectionString();

            string daCommandString =
                 @"SELECT Account, Name, Email, UserLevel, CreateDate
                   FROM [UserInfo]";
                   

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
        /// 創造新使用者
        /// </summary>
        /// <param name="account"></param>
        /// <param name="PWD"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="userlevel"></param>
        public static void CreateNewUser(string account, string PWD, string name, string email, int userlevel)
        {


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" INSERT INTO [dbo].[UserInfo]
                (
                    ID
                   ,Account
                   ,PWD
                   ,Name
                   ,Email
                   ,UserLevel
                   ,CreateDate
                )
                 VALUES
                (
                    @ID
                   ,@account
                   ,@pwd
                   ,@name
                   ,@email
                   ,@userLevel
                   ,@createDate
                )
                ";

            string id = Guid.NewGuid().ToString();

            List<SqlParameter> createuserlist = new List<SqlParameter>();
            createuserlist.Add(new SqlParameter("@ID", id));
            createuserlist.Add(new SqlParameter("@account", account));
            createuserlist.Add(new SqlParameter("@pwd", PWD));
            createuserlist.Add(new SqlParameter("@name", name));
            createuserlist.Add(new SqlParameter("@email", email));
            createuserlist.Add(new SqlParameter("@userLevel", userlevel));
            createuserlist.Add(new SqlParameter("@createDate", DateTime.Now));

            try
            {
                DBHelper.CreatData(connStr, dbcommand, createuserlist);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);

            }


        }

        /// <summary>
        /// 修改使用者資訊
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="email"></param>
        public static void UpdateUserInfo(string id, string name, string email)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                @" UPDATE
                        [dbo].[UserInfo]
                   SET
                        Name = @name,
                        Email = @email

                   WHERE
                        ID = @id
                                        ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    //要插入的數值
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@email", email);

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery(); //ExecuteNonQuery不回傳值
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }

        }


        /// <summary>
        /// 修改使用者密碼
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        public static void UpdatePWD(string account, string pwd)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                @" UPDATE
                        [dbo].[UserInfo]
                   SET
                        PWD = @pwd
                   WHERE
                        Account = @account
                                        ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    //要插入的數值
                    comm.Parameters.AddWithValue("@account", account);
                    comm.Parameters.AddWithValue("@pwd", pwd);

                    try
                    {
                        conn.Open();
                        int effectRows = comm.ExecuteNonQuery(); //ExecuteNonQuery不回傳值
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }

        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteUserInfo(string id)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" DELETE [UserInfo]
                WHERE ID = @id
                ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", id));


            try
            {
                DBHelper.ModifyData(connStr, dbcommand, paramlist);

            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }


        }
    }
}


