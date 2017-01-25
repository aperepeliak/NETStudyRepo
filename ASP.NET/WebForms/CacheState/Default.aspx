<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Add New Car</h1>
        <hr />
        <asp:Label ID="Label1" runat="server" Text="Make  "></asp:Label>
        <asp:TextBox ID="txtMake" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Color  "></asp:Label>
            <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="PetName  "></asp:Label>
        <asp:TextBox ID="txtPetName" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnAddCar" runat="server" Text="Add this car" OnClick="btnAddCar_Click" />
        </p>
        <hr />
        <h1>Cars Table</h1>
        <asp:GridView ID="dgvCars" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
