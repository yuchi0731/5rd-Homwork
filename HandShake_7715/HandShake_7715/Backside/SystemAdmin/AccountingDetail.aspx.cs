using Handshake_Auth;
using Handshake_DBSoure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HandShake_7715.Backside.SystemAdmin
{
    public partial class AccountingDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check logined
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Frontside/Login.aspx");
                return;
            }
            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null) //如果帳號不存在，導向登入頁
            {
                Response.Redirect("/Frontside/Login.aspx");
                return;
            }


            if (!this.IsPostBack)
            {
                //check is create mode or edit mode //看是甚麼模式
                if (this.Request.QueryString["ID"] == null) //如果是空的就是進入新增模式
                {
                    this.btnSave.Visible = true;
                }
                else
                {

                    string idText = this.Request.QueryString["ID"];
                    int id;
                    if (int.TryParse(idText, out id))//檢查能不能轉型成數字
                    {
                        var drAccounting = AccountingManager.GetAccounting(id, currentUser.ID); //查id有沒有//並多加一項目確認是否為自己資料而不會窺看得以別的使用者資料

                        if (drAccounting == null)
                        {
                            this.ltMsg.Text = "Data doesn't exist.";
                            this.btnSave.Visible = false;
                            //this.btnEdit.Visible = false;
                        }

                        else
                        {
                            //   if (drUserInfo["UserID"] == drUserInfo["ID"]) //另一種保護資料不被窺看的方法//寫錯  改一下
                            //{ 
                            //如果查得出來就把值放入控制項
                            this.ddlActType.SelectedValue = drAccounting["ActType"].ToString();
                            this.txtAmount.Text = drAccounting["Amount"].ToString();
                            this.txtCaption.Text = drAccounting["Caption"].ToString();
                            this.txtDesc.Text = drAccounting["Body"].ToString();
                            //}
                        }
                    }


                    else
                    {
                        this.ltMsg.Text = "ID is required";
                        this.btnSave.Visible = false;
                    }

                }
            }



        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
            }


            string userID = currentUser.ID;
            string caption = this.txtCaption.Text;
            string amountText = this.txtAmount.Text;
            string actTypeText = this.ddlActType.SelectedValue;
            string body = this.txtDesc.Text;


            int amount = Convert.ToInt32(amountText);
            int actType = Convert.ToInt32(actTypeText);

            string idText = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idText))
            {
                //Execute 'Insert into db'
                AccountingManager.CreateAccounting(userID, caption, amount, actType, body);
                MessageBox.Show($"已成功新增資料", "新增成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                int id;
                if (int.TryParse(idText, out id))
                {
                    //Execute 'Update db'//如果今天是修改，如何拿到使用者id
                    AccountingManager.UpdateAccounting(id, userID, caption, amount, actType, body);
                    MessageBox.Show($"已成功修改資料", "修改成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Response.Redirect("/Backside/SystemAdmin/AccountingList.aspx");


        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            //Type
            if (this.ddlActType.SelectedValue != "0" && this.ddlActType.SelectedValue != "1")
            {
                msgList.Add("Type must be 0 or 1.");
            }

            //Amount
            if (string.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                msgList.Add("Amount is required.");
            }
            else
            {
                int tempInt;
                if (!int.TryParse(this.txtAmount.Text, out tempInt))
                {
                    msgList.Add("Amount must be a number.");
                }

                if (tempInt < 0 || tempInt > 1000000)
                {
                    msgList.Add("Amount must between 0 and 1,000,000.");
                }
            }

            //if (Convert.ToInt32(this.txtAmount.Text) < 0)
            //{
            //    msgList.Add("Amount can't lower than zero.");
            //}


            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;

            int id;
            if (int.TryParse(idText, out id))
            {
                //Execute 'delete db'
                AccountingManager.DeleteAccounting(id);
            }

            Response.Redirect("/Backside/SystemAdmin/AccountingList.aspx");

        }
    }
}