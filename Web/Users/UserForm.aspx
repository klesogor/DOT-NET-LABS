<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserForm.aspx.cs" Inherits="Web.Users.UserForm" %>

<asp:Content ID="UserFormPage" ContentPlaceHolderID="MainContent" runat="server">
        <h2>
            <asp:Label ID="Label" runat="server" Text="Create user"></asp:Label>
        </h2>
        <hr>
          <label>Input name</label>
          <asp:TextBox ID="userName" runat="server" Text=""></asp:TextBox><br />
          <label>Input surname</label>
          <asp:TextBox ID="userSurname" runat="server" Text=""></asp:TextBox><br />
          <label>Input phone</label>
          <asp:TextBox ID="userPhone" runat="server" Text=""></asp:TextBox><br />
          <label>Input secret</label>
          <asp:TextBox ID="userSecret" runat="server" Text=""></asp:TextBox><br />
          <asp:HiddenField ID="userId" runat="server" />
          <asp:Button ID="btnSave" runat="server" class='btn btn-info' Text="Save" OnClick="btnSave_Click" />           
</asp:Content>