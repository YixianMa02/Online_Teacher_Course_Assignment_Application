<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homeForm.aspx.cs" Inherits="SMTI_Online_Teacher_Course_Assignment.HomeForm" %>

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
        .heigh0 {height: 25px;}
        .heigh1 {height: 75px;}
        .heigh2 {height: 175px;}
        .heigh3 {height: 300px;}
        .padding_td1 {
          padding-top:20px;
          padding-bottom:20px;
          padding-left:25px;
          padding-right:25px;
        }
    </style>
</head>
<body class="alert alert-primary">
    <div class="heigh1">
        <h2 class="center">Online Teacher-Course Assignment</h2>
    </div>
    <form id="form2" runat="server">
        <div class="container">
            <div class="row justify-content-evenly heigh2">
                <div class="col-3">
                    <table class="alert alert-warning border-success">
                        <tr>
                            <td class="padding_td1">
                                <asp:Label ID="lblTeacher" runat="server"><b>Select a Teacher</b></asp:Label>
                                <br />
                                <asp:ListBox ID="lstTeachers" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="lstTeacher_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-4">
                    <table class="alert alert-warning border-success" style="width:100%">
                        <tr>
                            <td class="padding_td1">
                                <asp:Label ID="lblCourse" runat="server"><b>Select a Course</b></asp:Label>
                                <br />
                                <asp:ListBox ID="lstCourses" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="lstCourses_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-3">
                    <table class="alert alert-warning border-success">
                        <tr>
                            <td class="padding_td1">
                                <asp:Label ID="lblGroup" runat="server"><b>Select a Group</b></asp:Label>
                                <br />
                                <asp:ListBox ID="lstGroups" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="lstGroups_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row justify-content-evenly heigh1">
                <div class="col-3 center">
                    <asp:Label ID="lblSeletedTeacher" runat="server"><b>Selected Teacher</b></asp:Label>
                    <asp:TextBox ID="txtTeacher" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-4 center">
                    <asp:Label ID="lblSelectedCourse" runat="server"><b>Selected Course</b></asp:Label>
                    <asp:TextBox ID="txtCourse" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-3 center">
                    <asp:Label ID="lblSelectedGroup" runat="server"><b>Selected Group</b></asp:Label>
                    <asp:TextBox ID="txtGroup" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="row justify-content-center heigh1">
                <div class="col-3 center">
                    <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" Text="ASSIGN" CssClass="btn btn-success"/>
                </div>
            </div>
            <div class="row justify-content-evently heigh0">
                <div class="col-5 center">
                    <asp:Label ID="lblInfo" runat="server"><b>Selected Teacher/Course/Group Info</b></asp:Label>
                </div>
                <div class="col-7 center">
                    <asp:Label ID="lblTeacherCourse" runat="server"><b>Teacher's Assigned Courses</b></asp:Label>
                </div>
            </div>
            <div class="row justify-content-evently heigh3">
                <div class="col-6 center">
                    <div>
                        <asp:GridView ID="gridTeacher" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px" CellPadding="5" GridLines="Both">
                                <AlternatingRowStyle BackColor="#99ccff"/>
                                <HeaderStyle BackColor="#0066ff" ForeColor="White" Font-Bold="true"/>
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gridCourse" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px" CellPadding="5" GridLines="Both">
                                <AlternatingRowStyle BackColor="#99ccff"/>
                                <HeaderStyle BackColor="#0066ff" ForeColor="White" Font-Bold="true"/>
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gridGroup" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px" CellPadding="5" GridLines="Both">
                                <AlternatingRowStyle BackColor="#99ccff"/>
                                <HeaderStyle BackColor="#0066ff" ForeColor="White" Font-Bold="true"/>
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-6 center">
                    <asp:GridView ID="gridAssignedCourse" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="1px" CellPadding="5" GridLines="Both">
                            <AlternatingRowStyle BackColor="#99ccff"/>
                            <HeaderStyle BackColor="#0066ff" ForeColor="White" Font-Bold="true"/>
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
