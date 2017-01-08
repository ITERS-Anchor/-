<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.Ajax.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-3.1.0.js"></script>
    <script type="text/javascript">
        $(function() {//.keyup
            $('#txtname').blur(function() {
                var userName = $(this).val();
                if (userName!='') {
                    $.post('ValidateUserName.ashx', { 'name': userName }, function (data) {
                        $('#nameMsg').text(data);
                    });
                } else {
                    $('#nameMsg').text('用户名不能为空！');
                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名：<input type="text" id="txtname" value="" /><span id="nameMsg" style="color:red;"></span><br />
        密码：<input type="password" id="txtpwd" value="" /><br />
             
    </div>
    </form>
</body>
</html>
