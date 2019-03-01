<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="view_order.aspx.cs" Inherits="view_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div id="page-wrapper">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
      <div>
            <table class="table-bordered table table-hover" aria-readonly="False">
                <thead>
                    <th>Order Id</th>
                    <th>Email Id</th>
                    <th>Product Id</th>
                    <th>Product Amount</th>
                    <th>Product Quantity</th>
                    <th>Product Status</th>
                    <th>Date</th>
                    <th>Size</th>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater2" runat="server" >
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("order_id") %></td>
                                <td><%#Eval("email_id") %></td>
                                <td><%#Eval("fk_product_id") %></td>
                                <td><%#Eval("product_amount") %></td>
                                <td><%#Eval("product_quantity") %></td>
                                <td><%#Eval("product_status") %></td>
                                <td><%#Eval("date") %></td>
                                <td><%#Eval("size") %></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: lightblue;">
                                <td><%#Eval("order_id") %></td>
                                <td><%#Eval("email_id") %></td>
                                <td><%#Eval("fk_product_id") %></td>
                                <td><%#Eval("product_amount") %></td>
                                <td><%#Eval("product_quantity") %></td>
                                <td><%#Eval("product_status") %></td>
                                <td><%#Eval("date") %></td>
                                <td><%#Eval("size") %></td>
                            </tr>




                        </AlternatingItemTemplate>
                    </asp:Repeater>
    
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" DeleteCommand="DELETE FROM [order_tbl_mkn] WHERE [order_id] = @order_id" InsertCommand="INSERT INTO [order_tbl_mkn] ([email_id], [fk_product_id], [product_amount], [product_quantity], [product_status], [date], [size]) VALUES (@email_id, @fk_product_id, @product_amount, @product_quantity, @product_status, @date, @size)" ProviderName="<%$ ConnectionStrings:DatabaseConnectionString1.ProviderName %>" SelectCommand="SELECT [order_id], [email_id], [fk_product_id], [product_amount], [product_quantity], [product_status], [date], [size] FROM [order_tbl_mkn]" UpdateCommand="UPDATE [order_tbl_mkn] SET [email_id] = @email_id, [fk_product_id] = @fk_product_id, [product_amount] = @product_amount, [product_quantity] = @product_quantity, [product_status] = @product_status, [date] = @date, [size] = @size WHERE [order_id] = @order_id">
                        <DeleteParameters>
                            <asp:Parameter Name="order_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="email_id" Type="String" />
                            <asp:Parameter Name="fk_product_id" Type="String" />
                            <asp:Parameter Name="product_amount" Type="Decimal" />
                            <asp:Parameter Name="product_quantity" Type="Int32" />
                            <asp:Parameter Name="product_status" Type="Int32" />
                            <asp:Parameter Name="date" Type="String" />
                            <asp:Parameter Name="size" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="email_id" Type="String" />
                            <asp:Parameter Name="fk_product_id" Type="String" />
                            <asp:Parameter Name="product_amount" Type="Decimal" />
                            <asp:Parameter Name="product_quantity" Type="Int32" />
                            <asp:Parameter Name="product_status" Type="Int32" />
                            <asp:Parameter Name="date" Type="String" />
                            <asp:Parameter Name="size" Type="String" />
                            <asp:Parameter Name="order_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
    
                </tbody>
            </table>
        </div>
                
                </div>
                    </div>
               </div>
        </div>
</asp:Content>

