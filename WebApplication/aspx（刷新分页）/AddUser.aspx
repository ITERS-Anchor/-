<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="WebApplication.aspx.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<input type="hidden" name="isPostBack" value="1" />--%>
    <div>        
            <!--ID:<input type="text" name="id" value="" />-->
            Name:<input type="text" name="name" value="" /><br />
            Password:<input type="password" name="pwd" value="" /><br />
            <input type="submit" name="btnAdd" value="Add" />       
    </div>
    </form>
</body>
</html>
