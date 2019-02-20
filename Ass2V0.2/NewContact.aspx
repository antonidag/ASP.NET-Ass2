<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewContact.aspx.cs" Inherits="Ass2V0._2.NewContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Add new contact</h4>
    <h5>Name</h5>
    <asp:TextBox ID="textbox_name" runat="server"></asp:TextBox>
    <h5>Address</h5>
    <asp:TextBox ID="textbox_address" runat="server" ></asp:TextBox>
    <h5>Phone number</h5>
    <asp:TextBox ID="textbox_phone" runat="server"></asp:TextBox>
    <h5>Email</h5>
    <asp:TextBox ID="textbox_email" runat="server"></asp:TextBox>
    <asp:Button ID="btn_create" Text="Create Contact" CssClass="btn btn-success" runat="server" OnClick="btn_create_Click"/>
</asp:Content>
