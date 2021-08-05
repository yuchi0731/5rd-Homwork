using Handshake_Auth;
using Handshake_DBSoure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HandShake_7715.Backside.UserInfo
{
    public partial class UserInfoDetail : System.Web.UI.Page
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



                this.lblAcc.Text = currentUser.Account;    //當前使用者名稱                
                this.ltltime.Text = currentUser.CreateDate;//時間還要再改

                string userlevel = currentUser.UserLevel;
                this.lbluserlevel.Text = currentUser.UserLevel;

                if (userlevel == "0")
                {
                    this.lbluserlevel.Text = "管理者";
                    this.lbluserlevel.ForeColor = Color.White;

                }
                if (userlevel == "1")
                {
                    this.lbluserlevel.Text = "一般會員";
                    this.lbluserlevel.ForeColor = Color.Green;

                }

                if (userlevel == "2")
                {
                    this.lbluserlevel.Text = "尊榮會員";
                    this.lbluserlevel.ForeColor = Color.Blue;
                }

                

            }
        }

        protected void btnsaveUser_Click(object sender, EventArgs e)

        {
            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Frontside/Login.aspx");
            }

            string id = currentUser.ID;
            string newName = this.txtName.Text;
            string newEmail = this.txtEmail.Text;
            int nameL = newName.Length;
            int emailL = newEmail.Length;

            if (nameL == 0 || emailL == 0)
            {
                this.ltMsg.Text = "尚有選項未填寫";
            }

            else
            {
                UserInfoManager.UpdateUserInfo(id, newName , newEmail);
                MessageBox.Show($"已成功修改資料", "修改成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Response.Redirect("/Backside/SystemAdmin/UserList.aspx");
            }






        }

        protected void btndeleteUser_Click(object sender, EventArgs e)
        {

            var currentUser = AuthManager.GetCurrentUser();
            var id = currentUser.ID;

            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("若刪除使用者將無法復原，繼續請按確定", "刪除使用者資料？",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error);

            if (MsgBoxResult == DialogResult.OK)
            {
                AuthManager.Logout();
                UserInfoManager.DeleteUserInfo(id);
                Response.Redirect("/Frontside/Login.aspx");
            }
            else
            {
                return;
            }

        }


        protected void btnchangePWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Backside/SystemAdmin/UserPassword.aspx");

        }
    }
}
    