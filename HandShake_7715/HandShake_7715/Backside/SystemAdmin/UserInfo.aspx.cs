using Handshake_Auth;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandShake_7715.Backside.UserInfo
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)                     //可能是按鈕跳回本頁，所以要判斷 postback
            {
                if (!AuthManager.IsLogined())          //如果尚未登入，導致登入頁
                {
                    Response.Redirect("/Frontside/Login.aspx");
                    return;
                }

                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null)                                //如果帳號不存在，導致登入頁
                {
                    Response.Redirect("/Frontside/Login.aspx");
                    return;
                }

                this.ltAccount.Text = currentUser.Account;    //當前使用者
                this.ltName.Text = currentUser.Name;
                this.ltEmail.Text = currentUser.Email;

                var userL = currentUser.UserLevel;
                if (userL == "2")
                {
                    this.lbUserLevel.Text = "尊榮會員";
                    this.lbUserLevel.ForeColor = Color.Blue;
                }
                if (userL == "1")
                {
                    this.lbUserLevel.Text = "一般會員";
                    this.lbUserLevel.ForeColor = Color.Green;
                }
                if (userL == "0")
                {
                    this.lbUserLevel.Text = "管理者";
                    this.lbUserLevel.ForeColor = Color.Red;
                    
                }

            }

        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();              //清除登入資訊，導致登入頁
            Response.Redirect("/Frontside/Login.aspx");
        }
    }
}