<%@ Page Title="" Language="C#" MasterPageFile="~/Frontside/FrontMain.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandShake_7715.Frontside.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            <td class="auto-style2" align="center">
                初次記帳
            </td>
            <td class="auto-style1">
                <asp:Literal ID="ltlFirstaddNote" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" align="center">
                最後記帳
            </td>
            <td class="auto-style1">
                <asp:Literal ID="ltlLastaddNote" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" align="center">
                記帳數量
            </td>
            <td class="auto-style1">
                <asp:Literal ID="ltlTotalNote" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" align="center">
                會員人數
            </td>
            <td class="auto-style1">
                <asp:Literal ID="ltlTotalUser" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
