using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handshake_DBSoure
{
    public class AccountingManager
    {

        /// <summary>
        /// 取得使用者目前的收支資料
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    ID,
                    UserID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate,
                    Body
                FROM [AccountingNote]
                WHERE UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary>
        /// 利用id查有沒有流水帳資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    ID,
                    UserID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate,
                    Body
                FROM [AccountingNote]
                WHERE id = @id AND UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataRow(connStr, dbcommand, list);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }


        }




        /// <summary>
        /// 新建流水帳
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            //<<<<check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" INSERT INTO [dbo].[AccountingNote]
                (
                    UserID
                   ,Caption
                   ,Amount
                   ,ActType
                   ,CreateDate
                   ,Body
                )
                 VALUES
                (
                    @userID
                   ,@caption
                   ,@amount
                   ,@actType
                   ,@createDate
                   ,@body
                )
                ";

            List<SqlParameter> createlist = new List<SqlParameter>();
            createlist.Add(new SqlParameter("@userID", userID));
            createlist.Add(new SqlParameter("@caption", caption));
            createlist.Add(new SqlParameter("@amount", amount));
            createlist.Add(new SqlParameter("@actType", actType));
            createlist.Add(new SqlParameter("@createDate", DateTime.Now));
            createlist.Add(new SqlParameter("@body", body));

            try
            {
                DBHelper.CreatData(connStr, dbcommand, createlist);

                //此方法不需要回傳結果
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);

            }



        }
        /// <summary>
        /// 修改流水帳
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {
            //<<<<check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" UPDATE [AccountingNote]
                    SET
                    UserID = @userID
                   ,Caption = @caption
                   ,Amount = @amount
                   ,ActType = @actType
                   ,CreateDate = @createDate
                   ,Body = @body              
                 WHERE
                    ID = @id
                
                 ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", ID));
            paramlist.Add(new SqlParameter("@userID", userID));
            paramlist.Add(new SqlParameter("@caption", caption));
            paramlist.Add(new SqlParameter("@amount", amount));
            paramlist.Add(new SqlParameter("@actType", actType));
            paramlist.Add(new SqlParameter("@createDate", DateTime.Now));
            paramlist.Add(new SqlParameter("@body", body));


            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbcommand, paramlist);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }




        }
        /// <summary>
        /// 刪除一筆流水帳
        /// </summary>
        /// <param name="ID"></param>
        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" DELETE [dbo].[AccountingNote]
                WHERE ID = @id
                ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", ID));



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
