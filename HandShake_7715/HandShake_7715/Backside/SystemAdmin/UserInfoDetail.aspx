<%@ Page Title="" Language="C#" MasterPageFile="~/Backside/BackMain.Master" AutoEventWireup="true" CodeBehind="UserInfoDetail.aspx.cs" Inherits="HandShake_7715.Backside.UserInfo.UserInfoDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <h3>會員管理</h3>
            </td>

        </tr>
        <tr>
            <td>
                帳號
            </td>
            <td>
                <asp:Label ID="lblAcc" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                姓名
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                會員等級
            </td>
            <td>
                <asp:Label ID="lbluserlevel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                建立時間
            </td>
            <td>
                 <asp:Literal ID="ltltime" runat="server" Text=""></asp:Literal><br/>
            </td>
        </tr>
    </table>

        <asp:Button ID="btnsaveUser" runat="server" Text="Save" OnClick="btnsaveUser_Click"/> &nbsp;
        <asp:Button ID="btndeleteUser" runat="server" Text="Delete" OnClick="btndeleteUser_Click"/>&nbsp;
        <asp:Button ID="btnchangePWD" runat="server" Text="前往變更密碼" OnClick="btnchangePWD_Click" />&nbsp;
        <br/><asp:Literal ID="ltMsg" runat="server"></asp:Literal>



</asp:Content>
