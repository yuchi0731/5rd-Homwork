using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Handshake_Auth;
using Handshake_DBSoure;
using System.Windows.Forms;

namespace HandShake_7715.Backside.UserInfo
{
    public partial class UserList : System.Web.UI.Page
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
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Frontside/Login.aspx");
                return;
            }

            

            //read Users data
            var dt = UserInfoManager.GetAllUserInfoList();
            int a = dt.Rows.Count; //15筆
            this.Label1.Text = a.ToString();

            if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            {

                var dtpaged = this.GetPagedDataTable(dt);

                this.ucPager.Totaluser = dt.Rows.Count;
                this.ucPager.BindUserList();


                string result = string.Empty;
                //取得UserInfo資料跑Rows和Columns資料
                foreach (DataRow dr in dt.Rows)
                {
                    result = result + "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        result = result + "<td>" + dr[dc] + "</td>";
                    }
                    result = result + "</tr>";
                }


                this.gvUserList.DataSource = dtpaged;
                this.gvUserList.DataBind();


            }
            else
            {
                this.gvUserList.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("若要建立新的使用者，將登出現在使用者資料", "提示",
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Exclamation);

               if(MsgBoxResult == DialogResult.OK)
                { 
                Response.Redirect("/Frontside/CreateUser.aspx");
                AuthManager.Logout();  
                }
               else
               { 
                return;
               }
        }

        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }


        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            int pageSize = this.ucPager.PageSize;


            int startIndex = (this.GetCurrentPage() - 1) * 10;
            int endIndex = (this.GetCurrentPage()) * 10;

            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }

            return dtPaged;
        }



        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lbl = row.FindControl("lbluserlevel") as System.Web.UI.WebControls.Label;


                var dr = row.DataItem as DataRowView; //DataItem本身是object要轉型別
                int userlevel = dr.Row.Field<int>("UserLevel");


                if (userlevel == 0)
                {
                    lbl.Text = "管理者";
                    lbl.ForeColor = Color.White;
                    lbl.BackColor = Color.Red;

                }
                if (userlevel == 1)
                {
                    lbl.Text = "一般會員";
                    lbl.ForeColor = Color.Green;
                    
                }

                if (userlevel == 2)
                {
                    lbl.Text = "尊榮會員";
                    lbl.ForeColor = Color.Blue;
                }

            }
        }

       
    }
}