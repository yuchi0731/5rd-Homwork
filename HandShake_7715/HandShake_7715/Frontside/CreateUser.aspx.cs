using Handshake_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Handshake_DBSoure;
using System.Windows.Forms;

namespace HandShake_7715.Frontside
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthManager.Logout();
            this.lbMsg.Text = string.Empty;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {

            string txtAccount = this.txtCreateAccount.Text;
            string txtPWD = this.txtCreatePWD.Text;
            string txtRePWD = this.txtCreateRePWD.Text;
            string txtName = this.txtCreateName.Text;
            string txtEmail = this.txtCreateEmail.Text;
            int userlevel = 1;
            string msg;
            string msg2;
            int pwdL = this.txtCreatePWD.Text.Length;
            int rpwdL = this.txtCreateRePWD.Text.Length;


            //取得輸入帳號，檢查帳號是否已存在 
            var drexist = UserInfoManager.GetUserInfoByAccount(txtAccount);
            if (drexist == null)
            {

                if (pwdL < 8 || rpwdL > 16)//檢查密碼長度
                {
                    this.lbMsg.Text = "密碼需介於8～16個字";
                }

                if (pwdL > 8 && rpwdL < 16)
                {
                    if (!AuthManager.TryCreateUser(txtAccount, txtPWD, txtRePWD, txtName, txtEmail, out msg, out msg2))
                    {
                        this.lbMsg.Text = msg;
                        this.lbMsg2.Text = msg2;
                        return;
                    }

                    else
                    {
                        UserInfoManager.CreateNewUser(txtAccount, txtPWD, txtName, txtEmail, userlevel);
                        AuthManager.TryLogin(txtAccount, txtPWD, out msg);

                        MessageBox.Show($"歡迎使用7715流水帳系統！請多指教{txtName}！", "～建立成功～");
                        Response.Redirect("/Backside/SystemAdmin/UserInfo.aspx");
                        
                    }
                }
            }

            else
            {
                this.lbMsg.Text = "此帳號已有人使用";
                this.txtCreateAccount.Text = null;
                this.txtCreatePWD.Text = null;
                this.txtCreateRePWD.Text = null;
                this.txtCreateName.Text = null;
                this.txtCreateEmail.Text = null;
            }

           

            
            

        }

        protected void btnclearnew_Click(object sender, EventArgs e)
        {
            this.txtCreateAccount.Text = null;
            this.txtCreatePWD.Text = null;
            this.txtCreateRePWD.Text = null;
            this.txtCreateName.Text = null;
            this.txtCreateEmail.Text = null;
        }
    }
}