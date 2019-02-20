<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="Ass2V0._2.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Edit Contacts</h4>
    <asp:ListBox ID="listbox" AutoPostBack="false" runat="server">
        <asp:ListItem>Hej</asp:ListItem>
        <asp:ListItem>då</asp:ListItem>
    </asp:ListBox>
    <asp:Button ID="btn_Edit" runat="server" Text="Edit" OnClick="btn_Edit_Click"/>
    <asp:Button ID="btn_Remove" runat="server" Text="Remove" />
    <h4>Change Contact</h4>
    <h5>Name</h5>
    <asp:TextBox ID="textbox_name" runat="server"></asp:TextBox>
    <h5>Address</h5>
    <asp:TextBox ID="textbox_address" runat="server"></asp:TextBox>
    <h5>Phone number</h5>
    <asp:TextBox ID="textbox_phone" runat="server"></asp:TextBox>
    <h5>Email</h5>
    <asp:TextBox ID="textbox_email" runat="server"></asp:TextBox>
    <asp:Button ID="btn_ok" runat="server" Text="OK" />

</asp:Content>
