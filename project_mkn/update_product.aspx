<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="update_product.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    
    <style type="text/css">
        .auto-style2 {
            width: 432px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
 
    <div>
    
        <table>
            <tr>
                <td>Item Id</td>
                <td>
                    <asp:TextBox ID="uitid" runat="server" CssClass="form-control" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Name</td>
                <td>
                    <asp:TextBox ID="pnm" runat="server" CssClass="form-control form-control-static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Image</td>
                <td style="margin-left: 40px">&nbsp;<asp:Image ID="Image1" runat="server" Height="92px" style="margin-right: 5px" Width="100px" />
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="glyphicon-open-file" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Price</td>
                <td>
                    <asp:TextBox ID="pp" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Description</td>
                <td>
                    <asp:TextBox ID="pd" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Size</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>X</asp:ListItem>
                        <asp:ListItem>L</asp:ListItem>
                        <asp:ListItem>XL</asp:ListItem>
                        <asp:ListItem>ALL</asp:ListItem>
                        <asp:ListItem>XXL</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <tr><td></td>
                <td>
                    <asp:Button ID="proupdate" runat="server" OnClick="proupdate_Click" CssClass="btn btn-default btn-primary"  Text="OK" />
                </td>
            </tr></tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
 </div></div></div></div> 

</asp:Content>

