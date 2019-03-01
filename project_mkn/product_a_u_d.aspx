<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="product_a_u_d.aspx.cs" Inherits="product_a_u_d" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

      <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="page-wrapper">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
      <div>
            <table class="table-bordered table table-hover" aria-readonly="False">
                <thead>
                    <th>Product ID</th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Image</th>
                    <th>Description</th>
                    <th>Size</th>
                    <th>Item Id</th>
                    <th>Action</th>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("product_id") %></td>
                                <td><%#Eval("product_name") %></td>
                                <td><%#Eval("product_price") %></td>
                                <td>
                                     <asp:Image ID="Image1" Height="100" Width="100" runat="server" CssClass="img-responsive" ImageUrl='<%#Eval("product_image")%>'/>    

                                </td>
                                <td><%#Eval("product_description") %></td>
                                <td><%#Eval("product_size") %></td>
                                <td><%#Eval("item_id") %></td>
                                <td>
                                    <asp:LinkButton ID="update" runat="server" CommandName="update" CommandArgument='<%#Eval("product_id") %>'>Update</asp:LinkButton>
                                    <asp:LinkButton ID="delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("product_id") %>'>Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: lightblue;">
                                <td><%#Eval("product_id") %></td>
                                <td><%#Eval("product_name") %></td>
                                <td><%#Eval("product_price") %></td>
                                <td>
                                     <asp:Image ID="Image1" runat="server" Height="100" Width="100" CssClass="img-responsive" ImageUrl='<%#Eval("product_image")%>'/>    

                                </td>
                                <td><%#Eval("product_description") %></td>
                                <td><%#Eval("product_size") %></td>
                                <td><%#Eval("item_id") %></td>
                                <td>
                                    <asp:LinkButton ID="update" runat="server" CommandName="update" CommandArgument='<%#Eval("product_id") %>'>Update</asp:LinkButton>
                                    <asp:LinkButton ID="delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("product_id") %>'>Delete</asp:LinkButton>
                                </td>
                            </tr>




                        </AlternatingItemTemplate>
                    </asp:Repeater>
    
                </tbody>
            </table>
        </div>
                
                </div>
                    </div>
               </div>
        </div>
              
        
         
<asp:Button ID="new_item" runat="server" Text="Add New Item" OnClick="new_item_Click" CssClass="btn btn-default" />
    
   

</asp:Content>

