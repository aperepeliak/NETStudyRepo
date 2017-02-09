<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DDLPerson.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1
            style="font-family: 'Segoe UI', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif; color: mediumpurple; font-style: italic">Справочник персонала
        </h1>
        <hr />

        <label style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">Выберите сотрудника: </label>
        <asp:DropDownList ID="ddlPerson" runat="server" AutoPostBack="True" Height="25px" Width="167px"></asp:DropDownList>

        <br />
        <br />

        <label style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-weight: bold">
            Детальная информация:</label>
        <br />
        <label style="font-family: 'Segoe UI'">Имя :</label>
        <asp:Label runat="server" ID="lblFirstName" Style="font-family: 'Segoe UI'"></asp:Label>
        <br />
        <label style="font-family: 'Segoe UI'">Фамилия :</label>
        <asp:Label runat="server" ID="lblLastName" Style="font-family: 'Segoe UI'"></asp:Label>
        <br />
        <label style="font-family: 'Segoe UI'">Дата рождения :</label>
        <asp:Label runat="server" ID="lblBirthday" Style="font-family: 'Segoe UI'"></asp:Label>
        <br />
        <label style="font-family: 'Segoe UI'">ИНН :</label>
        <asp:Label runat="server" ID="lblINN" Style="font-family: 'Segoe UI'"></asp:Label>
        <br />
    </form>
</body>
</html>
