<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.aspx.Index" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/PageBar.css" rel="stylesheet" />
</head>
    
<body>
    <h2>Welcome <%=LoginName %>! </h2>
    <form id="form1" runat="server">
    <div>
    <a href="AddUser.aspx">Add New User</a>
    <table>
        <tr>
            <th>UserID</th>
            <th>UserName</th>
            <th>UserPwd</th>
            <th>Detail</th>
            <th>Delete</th>
        </tr>
      
        <%foreach (UserInfo user in UserList){%>
            <tr>
                <td><%=user.UserId%></td>
                <td><%=user.UserName %></td>
                <td><%=user.UserPwd %></td>
                <td><a href="EditUser.aspx?id=<%=user.UserId%>">Edit</a></td>
                <td><a href="DeleteUser.ashx?id=<%=user.UserId%>">Delete</a></td>
            </tr>
         <% } %>
    </table>
        <div><a href="Index.aspx?page=1">首页</a>  |  <a href="Index.aspx?page=<%=PageIndex-1<1?1:PageIndex-1 %>">前页</a>  |  <a href="Index.aspx?page=<%=PageIndex+1>PageCount ? PageCount :PageIndex+1 %>">后页</a> | <a href="Index.aspx?page=<%=PageCount%>">尾页</a>        页次：<%=PageIndex%>/<%=PageCount%>页 
            <input type="hidden" name="crtPage" value="<%=PageIndex%>" />
            <input size="2" type="text" name="goPage" value="" />页
            <input type="submit" value="Go" />

            <hr />
            <div class="center">
              <ul class="pagination">
                <%=PageBar.GetPageBar(PageIndex,PageCount)%>
              </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
