<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountManagement.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.AccountManagementForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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

    </form>
</body>
</html>

