<%@ Page Language="C#" AutoEventWireup="true" 
    CodeFile="Default.aspx.cs" Inherits="_Default"
    EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="lbxInput" runat="server">
        </asp:ListBox>
        <asp:Button ID="btnPostback" runat="server" Text="Post" />
    </div>
    </form>
</body>
</html>
