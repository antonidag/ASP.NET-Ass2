<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DisplayPage.aspx.cs" Inherits="Ass2V0._2.DisplayPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Display Contacts</h4>
    <asp:TextBox ID="textbox_search" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
    <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click"  Text="Search"/>
    <br />
    <br />
    <asp:ListBox ID="listbox" runat="server" Width="50%" Height="500px"></asp:ListBox>
</asp:Content>
