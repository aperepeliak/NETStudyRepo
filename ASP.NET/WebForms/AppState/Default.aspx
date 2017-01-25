<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnShowCarOnSale" runat="server" OnClick="btnShowCarOnSale_Click" Text="Show Car On Sale" />
        <p>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </p>

        <asp:Label ID="Label1" runat="server" Text="Set new salesPerson"></asp:Label>
        <br />
        <asp:TextBox ID="txtNewSales" runat="server"></asp:TextBox>



        <asp:Button ID="btnSetNewSalesPerson" runat="server" OnClick="btnSetNewSalesPerson_Click" Text="Set" />



    </form>
</body>
</html>
