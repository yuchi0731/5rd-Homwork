<%@ Page Title="" Language="C#" MasterPageFile="~/Frontside/FrontMain.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HandShake_7715.Frontside.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:PlaceHolder runat="server" ID="plcLogin" Visible="true">
    <table>
        <tr>
            <td>
                登入
            </td>
        </tr>
        <tr>
            <td>
                帳號
            </td>
            <td>
                <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td>
                密碼
            </td>
            <td>
                <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
       <p></p>
       
           
           <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /> 
           <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
       </asp:PlaceHolder>

</asp:Content>
