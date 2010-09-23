<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater runat="server" ID="answersRepeater">
            <HeaderTemplate>
                <table>
                    <tr>
                    <th>Instance id</th>
                    <th>Answer</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                    <td><%# Eval("InstanceId") %></td>
                    <td><%# Eval("Answer") %></td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
