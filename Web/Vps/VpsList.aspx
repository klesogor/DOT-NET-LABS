<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VpsList.aspx.cs" Inherits="Web.Vps.VpsList" MasterPageFile="~/Site.Master" %>
<%@ Import Namespace="HostingManagmentSystem.Domain.Model" %>

<asp:Content ID="VpsList" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Vps list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater runat="server" ID="Repeater"  onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <h5>OS: <%#Eval("OperatingSystem") %></h5>
                    <h6>Ram:  <%#Eval("RAM") %></h6>
                    <h6>Cpu:  <%#Eval("CPU") %></h6>
                </div>
                <asp:Button ID="btnUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
            </ItemTemplate>
          </asp:Repeater>
    </div>
</asp:Content>
