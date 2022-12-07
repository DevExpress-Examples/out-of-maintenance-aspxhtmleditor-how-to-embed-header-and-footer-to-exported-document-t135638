<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication43.Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server"></dx:ASPxHtmlEditor>
    </div>
        <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="ASPxButton1_Click" style="height: 23px" Text="Export">
        </dx:ASPxButton>
    </form>
</body>
</html>
