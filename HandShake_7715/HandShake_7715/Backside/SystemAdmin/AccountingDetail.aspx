<%@ Page Title="" Language="C#" MasterPageFile="~/Backside/BackMain.Master" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="HandShake_7715.Backside.SystemAdmin.AccountingDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
          <tr>
              <td>
                  Type
              </td>
              <td>
                 <asp:DropDownList ID="ddlActType" runat="server">
                        <asp:ListItem Value="0">支出</asp:ListItem>
                        <asp:ListItem Value="1">收入</asp:ListItem>
                          </asp:DropDownList>
              </td>
          </tr>
        <tr>
              <td>
                  Amount
              </td>
              <td>
                   <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
              </td>
          </tr>
        <tr>
              <td>
                  Caption
              </td>
              <td>
                  <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
              </td>
          </tr>
        <tr>
              <td>
                  Desc
              </td>
              <td>
                  <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
              </td>
          </tr>
        
        </table>
      <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <br/>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>
</asp:Content>
