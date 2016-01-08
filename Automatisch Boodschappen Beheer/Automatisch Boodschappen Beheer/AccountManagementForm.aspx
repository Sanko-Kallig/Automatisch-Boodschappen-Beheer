<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AccountManagementForm.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.AccountManagementForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div style="border: 1px solid #D3D3D3; margin-bottom: 16px">
           <asp:ListBox ID="lbxAccounts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbxAccounts_SelectedIndexChanged"></asp:ListBox> 
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        <br />
        <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        <br />
            
        <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblRole" runat="server" Text="Role:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlRole" runat="server">
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
        <br />
        <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm password:"></asp:Label>
        <br />
        <asp:TextBox ID="tbxConfirmPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnModifyAccount" runat="server" Text="Modify Account" OnClick="btnModifyAccount_Click" />
    
            <asp:Button ID="btnDisableAccount" runat="server" OnClick="btnDisableAccount_Click" Text="Disable Account" />
    
        </div>
</asp:Content>

