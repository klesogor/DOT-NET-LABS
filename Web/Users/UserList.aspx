<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Web.Users.UserList" %>
<%@ Import Namespace="HostingManagmentSystem.Domain.Model" %>

<asp:Content ID="UserList" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Users list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater runat="server" ID="Repeater"  onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <h5>Name: <%#Eval("Name") %></h5>
                    <h6>Surname:  <%#Eval("Surname") %></h6>
                    <h6>Phone:  <%#Eval("Phone") %></h6>
                    <h6>Secret:  <%#Eval("Secret") %></h6>
                </div>
                <asp:Button ID="btnUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
            </ItemTemplate>
          </asp:Repeater>
    </div>
</asp:Content>
