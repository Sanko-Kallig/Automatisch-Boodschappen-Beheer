<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Login ID="LoginControl" runat="server" OnLoggingIn="OnLoggingIn">
                <LayoutTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text="Username"></asp:Label>
                    &nbsp;<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Dit veld is verplicht." ValidationGroup="UserName" ControlToValidate="UserName"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    &nbsp;<asp:TextBox ID="Password" TextMode="Password" runat="server" ValidationGroup="Password"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Dit veld is verplicht." ValidationGroup="Password" ControlToValidate="Password"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Literal runat="server"  ID="FailureText" Text="" EnableViewState="False"></asp:Literal>
                    <br  />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CommandName="Login" />

                </LayoutTemplate>
            </asp:Login> 
        </div>
</asp:Content>

