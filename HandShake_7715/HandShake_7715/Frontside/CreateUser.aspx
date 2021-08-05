<%@ Page Title="" Language="C#" MasterPageFile="~/Frontside/FrontMain.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="HandShake_7715.Frontside.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table>
        <tr>
            <td>
                新創帳號
            </td>
            <td>
                <asp:TextBox ID="txtCreateAccount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                密碼
            </td>
            <td>
                <asp:TextBox ID="txtCreatePWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                確認密碼
            </td>
            <td>
                <asp:TextBox ID="txtCreateRePWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                姓名
            </td>
            <td>
                <asp:TextBox ID="txtCreateName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtCreateEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Button ID="btnNew" runat="server" Text="Save" OnClick="btnNew_Click" />
    <asp:Button ID="btnclearnew" runat="server" Text="Clear" OnClick="btnclearnew_Click" />
    <br />
    <asp:Label ID="lbMsg" runat="server"></asp:Label><br/>
    <asp:Label ID="lbMsg2" runat="server"></asp:Label>

</asp:Content>
