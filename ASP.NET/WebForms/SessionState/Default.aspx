<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Session State<asp:Label ID="lblUserId" runat="server"></asp:Label>
        </h1><hr />
        <asp:Label ID="Label1" runat="server" Text="Which Color? "></asp:Label>
        <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Which make? "></asp:Label>
            <asp:TextBox ID="txtMake" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="DownPayment? "></asp:Label>
        <asp:TextBox ID="txtDownPayment" runat="server"></asp:TextBox>
        <p>
            <asp:CheckBox ID="chkIsLeasing" runat="server" Text="Lease?" />
        </p>
        <asp:Label ID="Label4" runat="server" Text="Delivery Date:"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <p>
            <asp:Label ID="lblUserInfo" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
