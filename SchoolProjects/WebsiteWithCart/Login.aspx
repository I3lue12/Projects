<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgProd" runat="server" Height="319px" Width="586px" />
            <br />
            <br />
            User:
            <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
            <br />
            Pass:
            <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Font-Bold="True" Font-Size="Large" OnClick="btnLogin_Click" Text="Login" />
            <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Font-Size="Medium" OnClick="btnRegister_Click" Text="Register" Width="102px" />
        </div>
    </form>
</body>
</html>
