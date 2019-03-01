<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="insert_productm.aspx.cs" Inherits="insert_productm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 427px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div id="page-wrapper">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
 

       <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Item Id</td>
                <td>
                    <asp:TextBox ID="itid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Name</td>
                <td>
                    <asp:TextBox ID="proname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Price</td>
                <td>
                    <asp:TextBox ID="propri" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Imgage</td>
                <td>
                    <asp:FileUpload ID="proimg" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Descripsion</td>
                <td>
                    <asp:TextBox ID="prodis" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Product Size</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
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
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="inser_submit" runat="server" OnClick="Button1_Click" Text="OK" />
                </td>
            </tr>
        </table>
    
    </div>
 </div></div></div></div>
</asp:Content>

