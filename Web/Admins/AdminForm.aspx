<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Web.Admins.AdminForm" %>
<asp:Content ID="UserFormPage" ContentPlaceHolderID="MainContent" runat="server">
        <h2>
            <asp:Label ID="Label" runat="server" Text="Create admin"></asp:Label>
        </h2>
        <hr>
          <label>Input name</label>
          <asp:TextBox ID="adminName" runat="server" Text=""></asp:TextBox><br />
          <label>Input ip</label>
          <asp:TextBox ID="adminIp" runat="server" Text=""></asp:TextBox><br />
          <label>Input description</label>
          <asp:TextBox ID="adminDescription" runat="server" Text=""></asp:TextBox><br />
          <asp:HiddenField ID="adminId" runat="server" />
          <asp:Button ID="btnSave" runat="server" class='btn btn-info' Text="Save" OnClick="btnSave_Click" />           
</asp:Content>
