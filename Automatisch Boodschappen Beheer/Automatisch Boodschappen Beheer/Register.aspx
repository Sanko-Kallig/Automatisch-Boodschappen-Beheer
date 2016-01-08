<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="lncRegister" runat="server" OnLoggingIn="OnRegister">
                <LayoutTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Dit veld is verplicht." ValidationGroup="UserName" ControlToValidate="tbxEmail"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblEmail0" runat="server" Text="Naam"></asp:Label>
                    <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxName" ErrorMessage="Dit veld is verplicht." ValidationGroup="UserName"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbxPassword" TextMode="Password" runat="server" ValidationGroup="Password"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Dit veld is verplicht." ValidationGroup="Password" ControlToValidate="tbxPassword"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblPassword0" runat="server" Text="Confirm"></asp:Label>
                    <asp:TextBox ID="tbxConfirmPassword" runat="server" TextMode="Password" ValidationGroup="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxConfirmPassword" ErrorMessage="Dit veld is verplicht." ValidationGroup="Password"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="PassValidator" runat="server" ErrorMessage="Passwords do not match." ControlToCompare="tbxPassword" ControlToValidate="tbxConfirmPassword" Type="String"></asp:CompareValidator>
                    <br />
                    <asp:Literal runat="server"  ID="FailureText" Text="" EnableViewState="False"></asp:Literal>
                    <br  />
                    <asp:Button ID="btnRegister" runat="server" Text="Login" CommandName="Login" />

                </LayoutTemplate>
            </asp:Login> 
        </div>
    </form>
</body>
</html>
