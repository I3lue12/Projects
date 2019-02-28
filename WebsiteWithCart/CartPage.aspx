<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CartPage.aspx.cs" Inherits="CartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCPTitle" runat="server" Text="ShoppingCart"></asp:Label>
            <br />
            <br />
            <asp:PlaceHolder ID="phCartPage" runat="server"></asp:PlaceHolder>
            <br />
        </div>
        <asp:Label ID="lblCPTotal" runat="server" Text="Total:"></asp:Label>
        <asp:Label ID="lblCPNumTotal" runat="server" Text="$0.00"></asp:Label>
    </form>
</body>
</html>
