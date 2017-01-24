<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Learning Validation Controls</h1>
            <asp:Label ID="Label1" runat="server" Text="Required Field:"></asp:Label>
            <br />
            <asp:TextBox ID="txtReqField" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Oops! Need to enter data." ControlToValidate="txtReqField" Display="None"></asp:RequiredFieldValidator>
            <br /><br />
            
            <asp:Label ID="Label2" runat="server" Text="Range 0-100"></asp:Label>
            <br />
            <asp:TextBox ID="txtRange" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter a number between 0 and 100" ControlToValidate="txtRange" Display="None" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            <br /><br />

            <asp:Label ID="Label3" runat="server" Text="Enter your US SSN"></asp:Label>
            <br />
            <asp:TextBox ID="txtRegexCheck" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid US SSN" ControlToValidate="txtRegexCheck" Display="None" ValidationExpression="\d{3}-\d{2}-\d{4}"></asp:RegularExpressionValidator>
            <br /><br />

            <asp:Label ID="Label4" runat="server" Text="Value < 20"></asp:Label>
            <br />
            <asp:TextBox ID="txtCompareValid" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="You must enter value less than 20" ControlToValidate="txtCompareValid" Display="None" Operator="LessThan" Type="Integer" ValueToCompare="20"></asp:CompareValidator>
            <br /><br />

            <asp:Button ID="btnPost" runat="server" Text="Post back" OnClick="btnPost_Click" />
            <asp:Label ID="lblValidResult" runat="server" Text=""></asp:Label>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Wrong data:" />
    </form>
</body>
</html>
