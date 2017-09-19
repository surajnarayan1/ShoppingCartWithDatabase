<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManipulation.aspx.cs" Inherits="shopping_Cart.ProductManipulation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="ProductTable" runat="server" Width="100%" BorderWidth="2px">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Product Id"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Product Name"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Quantity"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Price"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
