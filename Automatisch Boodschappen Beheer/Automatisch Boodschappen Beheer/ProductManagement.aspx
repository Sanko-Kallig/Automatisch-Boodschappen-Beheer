<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.ProductManagementForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="lbxProducts" runat="server"></asp:ListBox>
        <asp:Button ID="btnDeleteProduct" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>
