<%@ Page Title="" Language="C#" MasterPageFile="~/Backside/BackMain.Master" AutoEventWireup="true" CodeBehind="UserPassword.aspx.cs" Inherits="HandShake_7715.Backside.UserInfo.UserPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
        <table>
            <tr>
                <td>
                    <h2>會員管理</h2>
                </td>
            </tr>
            <tr>
                <td>帳號</td>
                <td class="auto-style2">
                    <asp:Literal ID="ltlAccount" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>原密碼</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>確認密碼</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPWDCheck" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>新密碼</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNewPWD" runat="server" TextMode="Password" MaxLength="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>新密碼確認</td>
                <td>
                    <asp:TextBox ID="txtNewPWDCheck" runat="server" TextMode="Password" MaxLength="16"></asp:TextBox>
                </td>
            </tr>
               </table>
                    <asp:Button ID="btnChange" runat="server" Text="變更密碼" OnClick="btnChange_Click" />
    <br/>
            <asp:Literal ID="ltlMsg" runat="server" ></asp:Literal><br/>
    <asp:Literal ID="ltlMsg2" runat="server"></asp:Literal>

</asp:Content>
