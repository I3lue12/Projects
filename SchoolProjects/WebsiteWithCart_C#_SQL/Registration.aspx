<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblRegis" runat="server" Font-Bold="True" Text="Register New User"></asp:Label>
            <br />
            <br />
            <asp:ValidationSummary ID="vbSummary" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vUser" runat="server" ControlToValidate="tbUsername" ErrorMessage="Must Have Username"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblPass" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="Password"></asp:RequiredFieldValidator>
            <br />
            <br />
            Confirm Password:<asp:TextBox ID="tbPassConfirm" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="vComform" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbPassConfirm" ErrorMessage="Confirm Mismatch"></asp:CompareValidator>
            <br />
            <br />
            <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vFirst" runat="server" ControlToValidate="tbFirstName" ErrorMessage="First Name"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vLast" runat="server" ControlToValidate="tbLastName" ErrorMessage="Last Name"></asp:RequiredFieldValidator>
            <br />
            <br />
            Email:<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="Proper Format Email Required" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Require Formated Email Address</asp:RegularExpressionValidator>
            <br />
            <br />
            Age:<asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vAge" runat="server" ControlToValidate="tbAge" ErrorMessage="Your Age" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            <br />
            <br />
            Gender:<br />
            <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" />
            <br />
            <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
            <br />
            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" Width="110px" />
            <br />
            <br />
            <asp:Button ID="btnOwner" runat="server" OnClick="btnOwner_Click" Text="DontClickMe" Visible="False" Width="117px" />
        </div>
    </form>
</body>
</html>
