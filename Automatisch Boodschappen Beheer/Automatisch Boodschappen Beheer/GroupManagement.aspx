<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupManagement.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.GroupManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid #D3D3D3; margin-bottom: 16px">
            <asp:Label ID="lblGroups" runat="server" Text="Group"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblUsers" runat="server" Text="Users"></asp:Label>
            <br />
            <asp:ListBox ID="lbxGroups" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lbxGroups_SelectedIndexChanged"></asp:ListBox>
            &nbsp;&nbsp;
           <asp:ListBox ID="lbxAccounts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbxAccounts_SelectedIndexChanged"></asp:ListBox> 
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
        <br />
        <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
        <br />
        <br />  
        <br />
        <br />
        <asp:Button ID="btnModifyGroup" runat="server" Text="Modify Group" OnClick="btnModifyGroup_Click" />
    
            <asp:Button ID="btnDisableGroup" runat="server" OnClick="btnDisableGroup_Click" Text="Disable Account" />
    
        </div>

    </form>
</body>
</html>

