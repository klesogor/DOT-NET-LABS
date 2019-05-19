<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VpsForm.aspx.cs" Inherits="Web.Vps.VpsForm" MasterPageFile="~/Site.Master"%>
<asp:Content ID="VpsFormPage" ContentPlaceHolderID="MainContent" runat="server">
        <h2>
            <asp:Label ID="Label" runat="server" Text="Create vps"></asp:Label>
        </h2>
        <hr>
          <label>Input OS</label>
          <asp:TextBox ID="vpsOs" runat="server" Text=""></asp:TextBox><br />
          <label>Input RAM</label>
          <asp:TextBox ID="vpsRam" runat="server" Text=""></asp:TextBox><br />
          <label>Input CPU</label>
          <asp:TextBox ID="vpsCpu" runat="server" Text=""></asp:TextBox><br />
          <label>Select owner</label>
          <asp:DropDownList ID="vpsOwner" runat="server" DataValueField="Value" DataTextField="Text">
              <asp:ListItem Text="- Select an owner -" />
          </asp:DropDownList><br />
          <label>Select admin</label>
          <asp:DropDownList ID="vpsAdmin" runat="server" DataValueField="Value" DataTextField="Text"></asp:DropDownList><br />
          <asp:HiddenField ID="vpsId" runat="server" />
          <asp:Button ID="btnSave" runat="server" class='btn btn-info' Text="Save" OnClick="btnSave_Click" />           
</asp:Content>