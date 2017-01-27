<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dynamic Controls</h1>
            <asp:Panel ID="myPanel" runat="server" BorderColor="Pink" BorderStyle="Solid" Width="300px">
                <br /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="Button1" runat="server" Text="Button" /><br /><br />
                <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink><br /><br />
            </asp:Panel>
            <br />
            <br />

            <asp:Button ID="btnAddWidgets" runat="server" Text="Add widgets" OnClick="btnAddWidgets_Click" />
            <asp:Button ID="btnClearPanel" runat="server" Text="Clear Panel" OnClick="btnClearPanel_Click" />
            <br />
            
            <asp:Button ID="btnGetTxtData" runat="server" Text="Get Txt Data" OnClick="btnGetTxtData_Click" />
            <br />
            <asp:Label ID="lblTextBoxData" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblControlInfo" runat="server" Text="[result]"></asp:Label>
        </div>
    </form>
</body>
</html>
