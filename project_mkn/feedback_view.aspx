<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="feedback_view.aspx.cs" Inherits="feedback_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div id="page-inner">
            <div class="row">
                <div class="col-md-12">
            

                          <div>
            <table class="table-bordered table table-hover" aria-readonly="False">
                <thead>
                    <th>Feedback Id</th>
                    <th>Feedback </th>
                    <th>Email Id</th>
                    
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater2" runat="server" >
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("feedback_id") %></td>
                                <td><%#Eval("feedback") %></td>
                                <td><%#Eval("fk_email_id") %></td>
                               
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: lightblue;">
                                <td><%#Eval("feedback_id") %></td>
                                <td><%#Eval("feedback") %></td>
                                <td><%#Eval("fk_email_id") %></td>
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

