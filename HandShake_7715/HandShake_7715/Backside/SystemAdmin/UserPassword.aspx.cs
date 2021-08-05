using Handshake_Auth;
using Handshake_DBSoure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HandShake_7715.Backside.UserInfo
{
    public partial class UserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///<summary>檢查是否登入</summary>
            if (!AuthManager.IsLogined())           //如果尚未登入，導致登入頁
            {
                Response.Redirect("/Frontside/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)                 //如果帳號不存在，導至登入頁
            {
                Response.Redirect("/Frontside/Login.aspx");
                return;
            }

            this.ltlAccount.Text = currentUser.Account;  //顯示當前帳號
            
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            string pwd = this.txtPWD.Text;
            string ckpwd = this.txtPWDCheck.Text;
            string newpwd = this.txtNewPWD.Text;
            string cknewpwd = this.txtNewPWDCheck.Text;
            string msg;
            string msg2;
            int newpwdL = this.txtNewPWD.Text.Length;



            var currentpwd = AuthManager.GetCurrentUserPWD();
            string dbpwd = currentpwd.PWD;


            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Frontside/Login.aspx");
            }
            string account = currentUser.Account;

           



            if (pwd.ToString() != dbpwd.ToString())
            {                               
                this.ltlMsg.Text = "原密碼與資料不符，請確認後重新輸入";                
                this.txtPWD.Text = null;
                this.txtPWDCheck.Text = null;
                this.txtNewPWD.Text = null;
                this.txtNewPWDCheck.Text = null;
            }

            
            else
            {

                if (newpwdL < 8 || newpwdL > 16)//檢查密碼長度
                {
                    this.ltlMsg.Text = "密碼需介於8～16個字";
                }

                if (newpwdL > 8 && newpwdL < 16)
                {
                    if (!AuthManager.TryChangePassword(pwd, ckpwd,newpwd, cknewpwd, out msg, out msg2))
                    {
                        this.ltlMsg.Visible = true;
                        this.ltlMsg2.Visible = true;
                        this.ltlMsg.Text = msg;
                        this.ltlMsg2.Text = msg2;
                        return;
                    }

                    else
                    {

                        UserInfoManager.UpdatePWD(account, newpwd);
                        MessageBox.Show($"密碼修改成功！", "～修改成功～");
                        Response.Redirect("/Backside/SystemAdmin/UserInfo.aspx");
                    }
                }
            }

        }
    }
}