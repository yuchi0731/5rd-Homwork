using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Handshake_DBSoure;

namespace Handshake_Auth
{
    public class AuthManager
    {
        /// <summary>
        /// 檢查登入狀況
        /// </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {

            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);


            if (dr == null) //一旦發現是空的就要清除資料
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();
            model.UserLevel = dr["UserLevel"].ToString();
            model.CreateDate = dr["CreateDate"].ToString();


            return model;

        }

        /// <summary>
        /// 登出
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null; //清除登入資料，導向登入頁
        }

        /// <summary>
        /// 嘗試登入
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            //check empty
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "Account / PWD is required.";
                return false;
            }

            //read db and check
            var dr = UserInfoManager.GetUserInfoByAccount(account);

            //check null
            if (dr == null)
            {
                errorMsg = $"Account:{account} doesn't exist.";
                return false;
            }

            //check account / pwd  Compare:比對前兩數值，第三參數為true不分大小寫，false表示區分大小寫
            if (string.Compare(dr["Account"].ToString(), account, true) == 0 && string.Compare(dr["PWD"].ToString(), pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString();
                errorMsg = string.Empty;
                return true;
            }

            else
            {
                errorMsg = "Login fail. Please check Account / PWD.";
                return false;
            }

        }


        /// <summary>
        /// 取得使用者密碼
        /// </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUserPWD()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);


            if (dr == null) //一旦發現是空的就要清除資料
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            UserInfoModel model = new UserInfoModel();
            model.PWD = dr["PWD"].ToString();


            return model;

        }

        /// <summary>
        /// 嘗試建立新使用者
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="Repwd"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="errorMsg"></param>
        /// <param name="errorMsg2"></param>
        /// <returns></returns>
        public static bool TryCreateUser(string account, string pwd, string Repwd, string name, string email, out string errorMsg, out string errorMsg2)
        {



            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(Repwd) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                //check empty
                if (string.IsNullOrWhiteSpace(account))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "帳號為必填";
                    return false;
                }

                else if (string.IsNullOrWhiteSpace(pwd))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "密碼為必填";
                    return false;
                }

                else if (string.IsNullOrWhiteSpace(Repwd))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "密碼不一致，請確認密碼";
                    return false;
                }

                else if (string.IsNullOrWhiteSpace(name))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "姓名為必填";
                    return false;
                }

                else if (string.IsNullOrWhiteSpace(email))
                {
                    errorMsg = "尚有未填選項!請確認資料";
                    errorMsg2 = "Email為必填";
                    return false;
                }

                else
                {
                    errorMsg = string.Empty;
                    errorMsg2 = "資料不正確，請確認資料";
                    return false;
                }

            }



            if (string.Compare(pwd, Repwd, false) != 0)
            {
                errorMsg = string.Empty;
                errorMsg2 = "密碼不一致，請確認密碼";
                return false;
            }






            //密碼相符且姓名信箱皆有填寫
            if (string.Compare(pwd, Repwd, false) == 0 && name != null && email != null)
            {
                errorMsg = string.Empty;
                errorMsg2 = string.Empty;
                return true;

            }

            else
            {
                errorMsg = "資料不正確，請確認資料";
                errorMsg2 = string.Empty;
                return false;
            }


        }

        /// <summary>
        /// 嘗試修改
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="Repwd"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="errorMsg"></param>
        /// <param name="errorMsg2"></param>
        /// <returns></returns>
        public static bool TryChangePassword(string pwd, string repwd, string newpwd, string renewpwd, out string errorMsg, out string errorMsg2)
        {


            if (string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(repwd) || string.IsNullOrWhiteSpace(newpwd) || string.IsNullOrWhiteSpace(renewpwd))
            {
                errorMsg = "尚有未填選項!請確認資料";
                errorMsg2 = "密碼為必填";
                return false;
            }



            if (string.Compare(pwd, repwd, false) != 0)
            {
                errorMsg = string.Empty;
                errorMsg2 = "原密碼不一致，請確認密碼";
                return false;
            }


            if (string.Compare(newpwd, renewpwd, false) != 0)
            {
                errorMsg = string.Empty;
                errorMsg2 = "新創密碼不一致，請確認密碼";
                return false;
            }



            else
            {

                
                if (string.Compare(pwd, repwd, false) == 0 && string.Compare(pwd, repwd, false) == 0)
                {
                    errorMsg = string.Empty;
                    errorMsg2 = string.Empty;
                    return true;
                }

                else
                {
                    errorMsg = "資料不正確，請確認資料";
                    errorMsg2 = string.Empty;
                    return false;
                }

            }


        }

    }
}
