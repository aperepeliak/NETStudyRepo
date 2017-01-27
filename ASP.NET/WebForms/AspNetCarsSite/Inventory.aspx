<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" CodeFile="Inventory.aspx.cs" 
    Inherits="Default2" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <p style="width: 329px; height: 30px">Filter by: 
    <asp:DropDownList ID="cboMake" SelectMethod="GetMakes"
        AppendDataBoundItems="true" AutoPostBack="true"
        DataTextField="Make" DataValueField="Make" 
        runat="server">
        <asp:ListItem Value="" Text="(All)" />
    </asp:DropDownList>
     </p>

    <asp:GridView ID="carsGrid" runat="server"
        AllowPaging="true" PageSize="2"
        AllowSorting="true"  
        CellPadding="4" AutoGenerateColumns="false" 
        DataKeyNames="CarID"
        ItemType="AutoLotDAL.Models.Inventory"
        SelectMethod="GetData" 
        DeleteMethod="GridView1_DeleteItem"
        UpdateMethod="GridView1_UpdateItem"
        EmptyDataText="There are no data records to display."
        ForeColor="#333"
        
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" GridLines="None">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />

        <Columns>
            <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" />
            <asp:BoundField DataField="CarID" 
                HeaderText="CarID" ReadOnly="true" SortExpression="CarID" />
            <asp:BoundField DataField="Make" 
                HeaderText="Make" SortExpression="Make" />
            <asp:BoundField DataField="Color" 
                HeaderText="Color" SortExpression="Color" />
            <asp:BoundField DataField="PetName" 
                HeaderText="PetName" SortExpression="PetName" />
        </Columns>

    </asp:GridView>
</asp:Content>

