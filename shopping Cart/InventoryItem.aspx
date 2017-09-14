<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryItem.aspx.cs" Inherits="shopping_Cart.InventoryItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" OnRowCommand="Gridview_row_command" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="Pname" ForeColor="Black" Height="331px" Width="594px">
            <Columns>
                <asp:BoundField DataField="Pname" HeaderText="Pname" ReadOnly="True" SortExpression="Pname" />
                <asp:BoundField DataField="Pid" HeaderText="Pid" SortExpression="Pid" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />

                <asp:TemplateField HeaderText="Add to cart">
                    <ItemTemplate>
                        <asp:Button Text="Add" runat="server" CommandName="Add" CommandArgument="<%#Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SampleShoppingCartConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>--%>
        <div style="height: 114px">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" BackColor="Black" ForeColor="White" OnClick="Button1_Click" style="margin-top: 0px" Text="MoveToShoppingCart" Width="515px" BorderColor="White" BorderWidth="5px" Height="62px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Admin" BackColor="Black" BorderColor="#FF3300" ForeColor="White" Height="59px" Width="220px" />
    </form>
</body>
</html>
