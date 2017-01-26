<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Learning Cookies</h1><hr />

        <asp:Label ID="Label1" runat="server" Text="Cookie Name:"></asp:Label>
        <asp:TextBox ID="txtCookieName" runat="server"></asp:TextBox>


        <p>
            <asp:Label ID="Label2" runat="server" Text="Cookie Value:"></asp:Label>
            <asp:TextBox ID="txtCookieValue" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnWriteCookie" runat="server" Text="Write This Cookie" OnClick="btnWriteCookie_Click" />
        <hr />
        <p>
            <asp:Button ID="btnShowCookie" runat="server" Text="Show Cookie Data" OnClick="btnShowCookie_Click" />
        </p>
        <asp:Label ID="lblCookieData" runat="server"></asp:Label>
    </form>
</body>
</html>
