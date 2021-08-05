<%@ Page Title="" Language="C#" MasterPageFile="~/Backside/BackMain.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="HandShake_7715.Backside.UserInfo.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <h3>個人資訊</h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                              帳號
                            </td>
                            <td>
                                <asp:Literal ID="ltAccount" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                姓名
                            </td>
                            <td>
                                <asp:Literal ID="ltName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                信箱
                            </td>
                            <td>
                                <asp:Literal ID="ltEmail" runat="server"></asp:Literal>
                            </td>
                        </tr>
                           <tr>
                            <td>
                                會員等級
                            </td>
                            <td>
                                <asp:Literal ID="ltlUserLevel" runat="server"></asp:Literal>
                                <asp:Label ID="lbUserLevel" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
    <br/>
    <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
</asp:Content>
