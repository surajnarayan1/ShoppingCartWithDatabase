<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="shopping_Cart.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            The item has been sent to cart!!!!!!!!!!!!!!!!.<br />
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="CheckOut_click" Text="CheckOut" BackColor="Black" ForeColor="White" Height="89px" Width="328px" />
    </form>
</body>
</html>
