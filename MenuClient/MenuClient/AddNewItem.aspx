<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AddNewItem.aspx.cs"
    Inherits="MenuClient.AddNewItem" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <table style="width:100%; color:Black; font-family:Segoe UI; font-size:14px; float:left; text-align:left;">
            <tr>
                <td colspan="2">
                    <asp:Label class="text" ID="lblMsg" runat="server" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text">Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="textBox form-control text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text">Description</td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" CssClass="textBox form-control text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text">Price</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="textBox form-control text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text">Category</td>
                <td>
                    <asp:TextBox ID="txtCg" runat="server" CssClass="textBox form-control text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text">Type</td>
                <td>
                    <asp:RadioButtonList ID="rbtnTp" runat="server" RepeatColumns="2" CssClass="textBox">
                        <asp:ListItem Selected="True" class="col text">Veg</asp:ListItem>
                        <asp:ListItem class="col text">Non-veg</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="text">Status</td>
                <td>
                    <asp:RadioButtonList ID="rbtnSt" runat="server" RepeatColumns="2" CssClass="textBox">
                        <asp:ListItem Selected="True" class="col text">Available</asp:ListItem>
                        <asp:ListItem class="col text">Not Available</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="mt-2">
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-danger"
                        onclick="btnSave_Click" />
                    <asp:Button ID="bntReset" runat="server" Text="Reset" CssClass="ml-2 btn btn-danger"
                        onclick="bntReset_Click" />
                </td>
            </tr>

        </table>
    </asp:Content>