<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuildCar.aspx.cs" Inherits="BuildCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Build Your Car<asp:Wizard ID="wizard" runat="server" ActiveStepIndex="0" OnFinishButtonClick="txtPickName_FinishButtonClick" Width="354px">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" title="Pick Your Model">
                <asp:TextBox ID="txtPickModel" runat="server" Width="158px"></asp:TextBox>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" title="Pick Your Color">
                <asp:ListBox ID="lbxPickColor" runat="server">
                    <asp:ListItem>Green</asp:ListItem>
                    <asp:ListItem>Blue</asp:ListItem>
                    <asp:ListItem>Pink</asp:ListItem>
                    <asp:ListItem>Black</asp:ListItem>
                    <asp:ListItem>Navy</asp:ListItem>
                    <asp:ListItem>White</asp:ListItem>
                    <asp:ListItem>Red</asp:ListItem>
                </asp:ListBox>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Name Your Car">
                <asp:TextBox ID="txtPickName" runat="server"></asp:TextBox>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep4" runat="server" Title="Delivery Date">
                <asp:Calendar ID="calendarChooseDate" runat="server"></asp:Calendar>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    <asp:Label ID="lblOrder" runat="server"></asp:Label>
</asp:Content>

