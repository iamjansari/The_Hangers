<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="view_user.aspx.cs" Inherits="view_user" %>

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
                    <th>Email Id</th>
                    <th>Name</th>
                    <th>Mobile No</th>
                    <th>Address</th>
                    <th>Password</th>
                    <th>Pincode</th>
                    </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("email_id") %></td>
                                <td><%#Eval("name") %></td>
                                <td><%#Eval("mobile_no") %></td>
                                <td><%#Eval("address") %></td>
                                <td><%#Eval("password") %></td>
                                <td><%#Eval("pincode") %></td>
                                <td>
                               
                                    <asp:LinkButton ID="delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("email_id") %>'>Delete</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: lightblue;">
                                <td><%#Eval("email_id") %></td>
                                <td><%#Eval("name") %></td>
                                <td><%#Eval("mobile_no") %></td>
                                <td><%#Eval("address") %></td>
                                <td><%#Eval("password") %></td>
                                <td><%#Eval("pincode") %></td>
                                <td>
                               
                                    <asp:LinkButton ID="delete" runat="server" CommandName="delete" CommandArgument='<%#Eval("email_id") %>'>Delete</asp:LinkButton>
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
</asp:Content>

