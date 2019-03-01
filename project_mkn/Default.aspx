<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="Repeater1" runat="server" AutoGenerateColumns="False" DataKeyNames="email_id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="email_id" HeaderText="email_id" ReadOnly="True" SortExpression="email_id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="mobile_no" HeaderText="mobile_no" SortExpression="mobile_no" />
                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="pincode" HeaderText="pincode" SortExpression="pincode" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" DeleteCommand="DELETE FROM [user_tbl_mkn] WHERE [email_id] = @email_id" InsertCommand="INSERT INTO [user_tbl_mkn] ([email_id], [name], [mobile_no], [address], [password], [pincode]) VALUES (@email_id, @name, @mobile_no, @address, @password, @pincode)" ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" SelectCommand="SELECT [email_id], [name], [mobile_no], [address], [password], [pincode] FROM [user_tbl_mkn]" UpdateCommand="UPDATE [user_tbl_mkn] SET [name] = @name, [mobile_no] = @mobile_no, [address] = @address, [password] = @password, [pincode] = @pincode WHERE [email_id] = @email_id">
            <DeleteParameters>
                <asp:Parameter Name="email_id" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="email_id" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mobile_no" Type="Decimal" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="pincode" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mobile_no" Type="Decimal" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="pincode" Type="Decimal" />
                <asp:Parameter Name="email_id" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
