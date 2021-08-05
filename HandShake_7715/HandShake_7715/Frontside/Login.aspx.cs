using Handshake_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HandShake_7715.Frontside
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (this.Session["UserLogin"] != null)
            {
                this.plcLogin.Visible = true;
                Response.Redirect("/Backside/SystemAdmin/UserInfo.aspx");
            }
           
            
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text;
            string inp_PWD = this.txtPWD.Text;

            string msg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.ltlMsg.Text = msg;
                return;
            }

            else
            {
                var currentUser = AuthManager.GetCurrentUser();
                var currentUserName = currentUser.Name;
                MessageBox.Show($"歡迎回來{currentUserName}！", "～歡迎～");
            Response.Redirect("/Backside/SystemAdmin/UserInfo.aspx");
            }
        }
    }
}