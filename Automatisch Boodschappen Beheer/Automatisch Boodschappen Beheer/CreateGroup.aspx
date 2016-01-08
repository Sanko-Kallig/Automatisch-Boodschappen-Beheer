<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateGroup.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.CreateGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxName" ErrorMessage="Dit veld is verplicht." ValidationGroup="UserName"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnCreateGroup" runat="server" Text="CreateGroup" CommandName="CreateGroup" OnClick="btnCreateGroup_Click" />
    </asp:Content>