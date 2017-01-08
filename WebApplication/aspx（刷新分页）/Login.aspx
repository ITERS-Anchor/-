<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.aspx.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        onload = function () {
            var validateCode = document.getElementById("loginValidateCode");
            validateCode.onclick = function () {
                var imgUrl = document.getElementById("Image1");
                imgUrl.src = "ValidateCode.ashx?d=" + new Date().getMilliseconds();
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>                         
        Name:<input type="text" name="name" value="" /><br />
        Password:<input type="password" name="pwd" value="" /><br />
        验证码：<a href="javascript:void(0)" id="loginValidateCode"><img id="Image1" src="ValidateCode.ashx" style="border-width:0px;"/></a><br />
        验证码：<input type="text" name="txtCode" value="" /><br />
        <input type="checkbox" name="autoLogin" value="1"/>Remember me<br />
        <input type="submit" name="btnLogin" value="Login" />   
        <span style="color:red" ><%=ErrorMsg%></span>          
    </div>
    </form>
</body>
</html>
