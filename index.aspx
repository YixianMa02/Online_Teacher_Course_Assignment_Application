<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SMTI_Online_Teacher_Course_Assignment.LoginForm" %>

<!DOCTYPE html>
<!-- 
    Coded by Yixian Ma - 1933261
    Finished on 2021-12-05
-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <title>SMTI</title>
    <style type="text/css">
        .center {text-align: center;}
        .title_high {height: 75px;}
        .box_size {width: 325px;}
        .padding_td1 {
          padding-top:20px;
          padding-bottom:20px;  
        }
        .padding_td2 {
          padding-top:8px;
          padding-bottom:8px;  
        }
        .padding_td3 {
          padding-top:30px;
          padding-bottom:40px;  
        }
        .font{
            font-style:oblique;
        }
    </style>
</head>
<body class="alert alert-primary">
    <div class="title_high">
        <h2 class="center">Online Teacher-Course Assignment</h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="alert alert-warning box_size border-success">
                <tr>
                    <td class="padding_td1 center"><b><asp:Label ID="lblLogin" runat="server" Text="Login Form" CssClass="font"></asp:Label></b></td> 
                </tr>
                <tr>
                    <td class="padding_td2 center"><asp:Label ID="lblUserName" runat="server" Text="UserName" CssClass="font"></asp:Label></td>
                </tr>
                <tr>
                    <td class="center"><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="padding_td2 center"><asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="font"></asp:Label></td>
                </tr>
                <tr>
                    <td class="center"><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="padding_td3 center"><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-success"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
