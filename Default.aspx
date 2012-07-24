<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NWSAlert4.Default" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>weather alerts</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="weatherWarning" runat="server" class="weatherWarning">
        <p class="weatherHead">National Weather Service Warning</p>
        <asp:Literal ID="litOut" runat="server" />
    </div>
    </form>
</body>
</html>
