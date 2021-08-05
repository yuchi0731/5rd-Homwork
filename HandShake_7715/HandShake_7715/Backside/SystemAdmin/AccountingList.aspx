<%@ Page Title="" Language="C#" MasterPageFile="~/Backside/BackMain.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="HandShake_7715.Backside.SystemAdmin.AccountingList" %>


<%@ Register Src="~/Backside/UserControl/ucPager.ascx" TagPrefix="uc2" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
                    <br/>
                    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAccountingList_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="400px">
                        <Columns>
                            <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立日期" />          
                            <asp:BoundField DataField="Caption" HeaderText="標題" />
                            <asp:TemplateField HeaderText="收入/支出">
                                <ItemTemplate>
                                  <%--  <%# ((int)Eval("ActType")==0) ? "支出" : "收入" %>--%>

                                   <%-- <asp:Literal ID="ltActType" runat="server"></asp:Literal>--%>
                                    <asp:Label ID="lblActType" runat="server"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Amount" HeaderText="金額" />          
                            <asp:TemplateField HeaderText="修改資料">
                                <ItemTemplate>
                                    <a href="/Backside/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>                    
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>

    <uc2:ucPager runat="server" id="ucPager"  PageSize="10" Url="/Backside/SystemAdmin/AccountingList.aspx" />

    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data in your Accounting Note.
                        </p>
                    </asp:PlaceHolder>
</asp:Content>
