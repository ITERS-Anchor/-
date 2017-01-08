<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Ajax.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-3.1.0.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btnLogin').click(function() {
                userLogin();
            });
        });
        function userLogin() {
            var userName = $('#txtname').val();
            var userPwd = $('#txtpwd').val();
            if (userName!=''&&userPwd!='') {
                $.post('ValidateLogin.ashx', { 'name': userName,'pwd':userPwd }, function(data) {
                    var serverData = data;
                    if (serverData=='yes') {
                        window.location.href = '/aspx/Index.aspx';
                    } else {
                        $('#msg').text('Inalid Name or PWD');
                    }
                });
            } else {
                $('#msg').text('不能为空');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名：<input type="text" id="txtname" value="" /><br />
    密码：<input type="password" id="txtpwd" value="" /><br />
        <input type="button" id="btnLogin" value="登录" /><br />
        <span id="msg" style="color:red;"></span>
    </div>
    </form>
</body>
</html>
