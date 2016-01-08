<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Automatisch_Boodschappen_Beheer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            color: #333;
            font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
            font-size: 14px;
            line-height: 20px;
        }

        h1, h2, h3 {
            margin-bottom: 10px;
            margin-top: 20px;
        }

        .container {
            margin: 0px auto;
            max-width: 970px;
        }

        a {
            color: #428bca;
            text-decoration: none;
        }

            a:hover {
                text-decoration: underline;
            }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px;
            text-align: left;
        }

        thead th {
            border-bottom: 2px solid #ccc;
        }

        td {
            border-top: 1px solid #ccc;
        }

        input[type="submit"] {
            background-color: #428bca;
            border-color: #357ebd;
            border-radius: 4px;
            border: 1px solid transparent;
            color: #fff;
            cursor: pointer;
            display: block;
            font-size: 14px;
            line-height: 20px;
            padding: 6px 12px;
            margin: 3px 0px;
        }

            input[type="submit"]:hover {
                background-color: #3071a9;
                border-color: #285e8e;
                color: #fff;
            }

        input[type="text"] {
            background-color: #fff;
            border-radius: 4px;
            border: 1px solid #ccc;
            color: #555;
            font-size: 14px;
            line-height: 20px;
            padding: 6px 12px;
        }

        label {
            display: block;
            font-weight: bold;
        }

        form {
            padding: 0px 8px;
        }

            form p {
                color: #737373;
                display: inline-block;
                margin: 0px;
            }

        .hidden {
            display: none;
            visibility: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>

