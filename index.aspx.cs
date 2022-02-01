using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

/*
 * Coded by Yixian Ma - 1933261
 * Finished on 2021-12-05
 */

namespace SMTI_Online_Teacher_Course_Assignment
{
    public partial class LoginForm : System.Web.UI.Page
    {
        //In class variables
        String coorUserName, coorPass;
        static OleDbConnection myCon;
        OleDbCommand myCmd;
        OleDbDataReader rdUser;

        //Load the page, first called
        protected void Page_Load(object sender, EventArgs e)
        {
            //Open DB connection
            myCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Server.MapPath("~/App_Data/SMTI.accdb"));
            myCon.Open();
        }

        //When click on the Login button
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Execute SQL to retreive only the Coordinator info from table Employees
            myCmd = new OleDbCommand("SELECT EmployeeId FROM Employees WHERE JobTitle =@title", myCon);
            myCmd.Parameters.AddWithValue("title", "Coordinator");
            rdUser = myCmd.ExecuteReader();

            //If Coordinator exist, than store his EmployeeId
            if (rdUser.Read()) {
                coorUserName = rdUser["EmployeeId"].ToString();
            }
            rdUser.Close();

            //Execute SQL to retreive Coordinator UserName and Password from table Users
            //Need to reimplemented after if we have mutiple Coordinator
            myCmd = new OleDbCommand("SELECT Password FROM Users WHERE Username =@userName", myCon);
            myCmd.Parameters.AddWithValue("userName", coorUserName);
            rdUser = myCmd.ExecuteReader();
            if (rdUser.Read())
            {
                coorPass = rdUser["Password"].ToString();
            }
            rdUser.Close();

            //If input UserName and Password match, going to the homeForm page, if not display an alert
            if (txtUserName.Text != coorUserName && txtPassword.Text != coorPass)
            {
                Response.Write("<script>alert('Incorrect UserName and Password. Only Coordinator will have access to this web application.');</script>");
                txtUserName.Text = null;
                txtPassword.Text = null;
            } else
            {
                Response.Redirect("homeForm.aspx");
            }
        }
    }
}