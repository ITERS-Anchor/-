<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebApplication.aspx.EditUser" %>
<%@ Import Namespace="Model" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" name="id" value="<%=EdUser.UserId%>"/>        
            Name:<input type="text" name="name" value="<%=EdUser.UserName%>" /><br />
            Password:<input type="text" name="pwd" value="<%=EdUser.UserPwd%>" /><br />
            <input type="submit" name="btnEdit" value="Edit" />   
    </div>
    </form>
</body>
</html>
 