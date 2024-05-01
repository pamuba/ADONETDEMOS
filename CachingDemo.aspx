<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CachingDemo.aspx.cs" Inherits="ADONETDEMOS.CachingDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="BtnLoad" runat="server" Text="Load Data" OnClick="BtnLoad_Click" /><asp:Button ID="ClrCache" runat="server" Text="Clear Cache" OnClick="ClrCache_Click" />
            <asp:GridView ID="Gridview1" runat="server"></asp:GridView>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CustomerID" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                    <asp:CheckBoxField DataField="NameStyle" HeaderText="NameStyle" SortExpression="NameStyle" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Suffix" HeaderText="Suffix" SortExpression="Suffix" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                    <asp:BoundField DataField="SalesPerson" HeaderText="SalesPerson" SortExpression="SalesPerson" />
                    <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:SSISConnectionString %>" DeleteCommand="DELETE FROM [Customer] WHERE [CustomerID] = @original_CustomerID AND [NameStyle] = @original_NameStyle AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL)) AND [FirstName] = @original_FirstName AND (([MiddleName] = @original_MiddleName) OR ([MiddleName] IS NULL AND @original_MiddleName IS NULL)) AND [LastName] = @original_LastName AND (([Suffix] = @original_Suffix) OR ([Suffix] IS NULL AND @original_Suffix IS NULL)) AND [CompanyName] = @original_CompanyName AND [SalesPerson] = @original_SalesPerson AND [EmailAddress] = @original_EmailAddress AND [Phone] = @original_Phone" InsertCommand="INSERT INTO [Customer] ([CustomerID], [NameStyle], [Title], [FirstName], [MiddleName], [LastName], [Suffix], [CompanyName], [SalesPerson], [EmailAddress], [Phone]) VALUES (@CustomerID, @NameStyle, @Title, @FirstName, @MiddleName, @LastName, @Suffix, @CompanyName, @SalesPerson, @EmailAddress, @Phone)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Customer]" UpdateCommand="UPDATE [Customer] SET [NameStyle] = @NameStyle, [Title] = @Title, [FirstName] = @FirstName, [MiddleName] = @MiddleName, [LastName] = @LastName, [Suffix] = @Suffix, [CompanyName] = @CompanyName, [SalesPerson] = @SalesPerson, [EmailAddress] = @EmailAddress, [Phone] = @Phone WHERE [CustomerID] = @original_CustomerID AND [NameStyle] = @original_NameStyle AND (([Title] = @original_Title) OR ([Title] IS NULL AND @original_Title IS NULL)) AND [FirstName] = @original_FirstName AND (([MiddleName] = @original_MiddleName) OR ([MiddleName] IS NULL AND @original_MiddleName IS NULL)) AND [LastName] = @original_LastName AND (([Suffix] = @original_Suffix) OR ([Suffix] IS NULL AND @original_Suffix IS NULL)) AND [CompanyName] = @original_CompanyName AND [SalesPerson] = @original_SalesPerson AND [EmailAddress] = @original_EmailAddress AND [Phone] = @original_Phone">
                <DeleteParameters>
                    <asp:Parameter Name="original_CustomerID" Type="Int16" />
                    <asp:Parameter Name="original_NameStyle" Type="Boolean" />
                    <asp:Parameter Name="original_Title" Type="String" />
                    <asp:Parameter Name="original_FirstName" Type="String" />
                    <asp:Parameter Name="original_MiddleName" Type="String" />
                    <asp:Parameter Name="original_LastName" Type="String" />
                    <asp:Parameter Name="original_Suffix" Type="String" />
                    <asp:Parameter Name="original_CompanyName" Type="String" />
                    <asp:Parameter Name="original_SalesPerson" Type="String" />
                    <asp:Parameter Name="original_EmailAddress" Type="String" />
                    <asp:Parameter Name="original_Phone" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CustomerID" Type="Int16" />
                    <asp:Parameter Name="NameStyle" Type="Boolean" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="MiddleName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="Suffix" Type="String" />
                    <asp:Parameter Name="CompanyName" Type="String" />
                    <asp:Parameter Name="SalesPerson" Type="String" />
                    <asp:Parameter Name="EmailAddress" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="NameStyle" Type="Boolean" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="MiddleName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="Suffix" Type="String" />
                    <asp:Parameter Name="CompanyName" Type="String" />
                    <asp:Parameter Name="SalesPerson" Type="String" />
                    <asp:Parameter Name="EmailAddress" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="original_CustomerID" Type="Int16" />
                    <asp:Parameter Name="original_NameStyle" Type="Boolean" />
                    <asp:Parameter Name="original_Title" Type="String" />
                    <asp:Parameter Name="original_FirstName" Type="String" />
                    <asp:Parameter Name="original_MiddleName" Type="String" />
                    <asp:Parameter Name="original_LastName" Type="String" />
                    <asp:Parameter Name="original_Suffix" Type="String" />
                    <asp:Parameter Name="original_CompanyName" Type="String" />
                    <asp:Parameter Name="original_SalesPerson" Type="String" />
                    <asp:Parameter Name="original_EmailAddress" Type="String" />
                    <asp:Parameter Name="original_Phone" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <table class="table-bordered" style="width: 100%;">
                <tr>
                    <td>AddressID</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Address Line 1</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Address Line 2</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>City</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>State Province</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Country Region</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Postal Code</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button OnClick="Button1_Click" ID="Button1" runat="server" Text="Fetch" />
                        <asp:Button OnClick="Button2_Click" ID="Button2" runat="server" Text="Update" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
