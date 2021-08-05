<%@ Page Title="" Language="C#" MasterPageFile="~/Backside/BackMain.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HandShake_7715.Backside.UserInfo.UserList" %>

<%@ Register Src="~/Backside/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       <asp:Button ID="btnCreate" runat="server" Text="新建使用者" onclick="btnCreate_Click" />
        <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvUserList_RowDataBound" Width="700px"  >
            <Columns>
                <asp:BoundField DataField="Account" HeaderText="帳號"/>
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:BoundField DataField="Email" HeaderText="Email" />

                <asp:TemplateField HeaderText="會員等級" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>  
                     <asp:Label ID="lbluserlevel" runat="server"></asp:Label>
                                </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立時間" ItemStyle-HorizontalAlign="Center"/>

                <asp:TemplateField HeaderText="Act">

                     <ItemTemplate>
                                    <a href="/Backside/SystemAdmin/UserInfoDetail.aspx?ID=<%# Eval("Account") %>">Edit</a>
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

        <div>
            <uc1:ucpager runat="server" id="ucPager" PageSize="10"  Url="/Backside/SystemAdmin/UserList.aspx" />
        </div>

        <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data.
                        </p>
           
           
                    </asp:PlaceHolder>
    
</asp:Content>
