<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductManagementForm.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.ProductManagementForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    
        <asp:ListBox ID="lbxProducts" runat="server"></asp:ListBox>
        <asp:Button ID="btnDeleteProduct" runat="server" Text="Button" />
    
    </div>
</asp:Content>