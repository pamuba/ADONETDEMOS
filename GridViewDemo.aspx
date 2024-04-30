<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridViewDemo.aspx.cs" Inherits="ADONETDEMOS.GridViewDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        AutoGenerateColumns="false" DataKeyNames="ID" AllowPaging="true" PageSize="10" GridLines="None"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnPageIndexChanged="GridView1_PageIndexChanged"
        OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

        <Columns>
           
            <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" SortExpression="Name" />

            <asp:TemplateField HeaderText="FIRST NAME" SortExpression="Firstname">
                <ItemTemplate><%# Eval("First_name") %></ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="FirstnameTB" runat="server" Text=<%# Bind("First_name") %>></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

        
            <asp:BoundField DataField="Last_name" HeaderText="Last Name" SortExpression="LastName" />

            <asp:TemplateField HeaderText="EMAIL" SortExpression="Email">
                <ItemTemplate><%# Eval("Email") %></ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EmailTB" runat="server" Text=<%# Bind("Email") %>></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="GENDER" SortExpression="Gender">
                <ItemTemplate> <asp:Label runat="server" Text=<%# Eval("Gender") %>></asp:Label></ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="EmailDD" runat="server">
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                        <asp:ListItem>O</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:CommandField HeaderText="ACTIONS" ShowCancelButton="true" ShowDeleteButton="true" ShowSelectButton="true" ShowEditButton="true"/>

        </Columns>

    </asp:GridView>
</asp:Content>
