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
    public partial class HomeForm : System.Web.UI.Page
    {
        //In class variables
        static OleDbConnection myCon;
        OleDbCommand myCmd;
        OleDbDataReader reader;

        //Load the page, first called
        protected void Page_Load(object sender, EventArgs e)
        {
            //If page is not Poast back
            if (!Page.IsPostBack)
            {
                //Open DB connection
                myCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + Server.MapPath("~/App_Data/SMTI.accdb"));
                myCon.Open();

                //Set label visible to false
                lblInfo.Visible = lblTeacherCourse.Visible = false;

                //Execute SQL to retreive all the Employees in the Employees table with Teacher as their JobTitle
                myCmd = new OleDbCommand("SELECT [FirstName], [EmployeeId] FROM Employees WHERE JobTitle =@title ORDER BY EmployeeId", myCon);
                myCmd.Parameters.AddWithValue("title", "Teacher");
                reader = myCmd.ExecuteReader();

                //Bind the data with Teacher List
                lstTeachers.DataTextField = "FirstName";
                lstTeachers.DataValueField = "EmployeeId";
                lstTeachers.DataSource = reader;
                lstTeachers.DataBind();
                reader.Close();

                //Excute SQL to retreive all the Courses in the Courses table
                myCmd = new OleDbCommand("SELECT [CourseTitle], [CourseCode] FROM Courses ORDER BY CourseCode", myCon);
                reader = myCmd.ExecuteReader();

                //Bind the data with Courses List
                lstCourses.DataTextField = "CourseTitle";
                lstCourses.DataValueField = "CourseCode";
                lstCourses.DataSource = reader;
                lstCourses.DataBind();
                reader.Close();

                //Excute SQL to retreive all the Groups in the Groups table
                myCmd = new OleDbCommand("SELECT [GroupName], [GroupNumber] FROM Groups ORDER BY GroupNumber", myCon);
                reader = myCmd.ExecuteReader();

                //Bind the data with Groups List
                lstGroups.DataTextField = "GroupName";
                lstGroups.DataValueField = "GroupNumber";
                lstGroups.DataSource = reader;
                lstGroups.DataBind();
                reader.Close();
            } else
            {
                //Set label visible to true after a page post back
                lblInfo.Visible = lblTeacherCourse.Visible = true;
            }
        }

        //When select an item inside the Teacher list
        protected void lstTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Execute SQL to retreive the selected Teacher's information
            myCmd = new OleDbCommand("SELECT [EmployeeId], [FirstName], [LastName] FROM Employees WHERE EmployeeId =@id", myCon);
            myCmd.Parameters.AddWithValue("id", lstTeachers.SelectedItem.Value);
            reader = myCmd.ExecuteReader();

            //If selected teacher exist, store the date inside the textbox teacher to diaplay
            if (reader.Read())
            {
                txtTeacher.Text = reader["EmployeeId"].ToString() + ", " + reader["FirstName"].ToString() + ", " + reader["LastName"].ToString();
            }
            reader.Close();

            //Execute another SQL to retrieve the selected Teacher's information to diaply inside the gridview gridTeacher
            myCmd.CommandText = "SELECT EmployeeId as [Employee ID], FirstName as [First Name],  LastName as [Last Name], " + "Email FROM Employees WHERE EmployeeId =@id";
            reader = myCmd.ExecuteReader();
            gridTeacher.DataSource = reader;
            gridTeacher.DataBind();
            reader.Close();

            //Execute another SQL to retrieve all the courses which has being assigned to the selected Teacher and display it inside the gridAssignedCourse
            myCmd.CommandText = "SELECT EmployeeId as [Employee ID], CourseCode as [Course Code],  GroupNumber as [Group Number], AssignedDate as [Assigned Date] FROM CourseAssignments WHERE EmployeeId =@id";
            reader = myCmd.ExecuteReader();
            gridAssignedCourse.DataSource = reader;
            gridAssignedCourse.DataBind();
            reader.Close();
        }

        //When select an item inside the Courses list
        protected void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Execute SQL to retreive the selected Course's information 
            myCmd = new OleDbCommand("SELECT [CourseTitle], [CourseCode] FROM Courses WHERE CourseCode =@id", myCon);
            myCmd.Parameters.AddWithValue("id", lstCourses.SelectedItem.Value);
            reader = myCmd.ExecuteReader();

            //If the selected course exist, display it inside the Course textbox
            if (reader.Read())
            {
                txtCourse.Text = reader["CourseCode"].ToString() + ", " + reader["CourseTitle"].ToString();
            }
            reader.Close();

            //Execute another SQL to retrive the selected Course's information and display inside the gridCourse
            myCmd.CommandText = "SELECT CourseCode as [Course Code], CourseTitle as [Course Title],  Duration FROM Courses WHERE CourseCode =@id";
            reader = myCmd.ExecuteReader();
            gridCourse.DataSource = reader;
            gridCourse.DataBind();
            reader.Close();
        }

        //When select an item inside the Groups list
        protected void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Execute SQL to retreive the selected Group's information 
            myCmd = new OleDbCommand("SELECT [GroupName], [GroupNumber] FROM Groups WHERE GroupNumber =@id", myCon);
            myCmd.Parameters.AddWithValue("id", lstGroups.SelectedItem.Value);
            reader = myCmd.ExecuteReader();

            //If the selected course exist, display it inside the Group textbox
            if (reader.Read())
            {
                txtGroup.Text = reader["GroupNumber"].ToString() + ", " + reader["GroupName"].ToString();
            }
            reader.Close();

            //Execute another SQL to retrive the selected Group's information and display inside the gridGroup
            myCmd.CommandText = "SELECT GroupNumber as [Group Number], GroupName as [Group Name] FROM Groups WHERE GroupNumber =@id";
            reader = myCmd.ExecuteReader();
            gridGroup.DataSource = reader;
            gridGroup.DataBind();
            reader.Close();
        }

        //When click on the Assign button
        protected void btnAssign_Click(object sender, EventArgs e)
        {
            //If all the input feild are empty, prevent user from the assigning action
            if (txtTeacher.Text == String.Empty || txtGroup.Text == String.Empty || txtCourse.Text == String.Empty)
            {
                Response.Write("<script>alert('You must fulfill all the input data field by selecting before assigning.');</script>");
            } 
            //If all the input fwild are fulfilled, then perform the assigning action
            else
            {
                //Execute SQL to retreive the total number of the selected Teacher inside the CourseAssignment table 
                myCmd = new OleDbCommand("SELECT COUNT(*) FROM CourseAssignments WHERE EmployeeId =@eid", myCon);
                myCmd.Parameters.AddWithValue("eid", lstTeachers.SelectedItem.Value);
                int totalCourses = (Int32)myCmd.ExecuteScalar();

                //Check if he or she has 3 assigned courses or not
                if (totalCourses >= 3)
                {
                    Response.Write("<script>alert('A teacher can only teach maximum up to 3 courses at the same time.');</script>");
                } 
                //If the selected teacher has less than 3 assigned course, than continue
                else
                {
                    try
                    {
                        //Execute SQL to retreive the total number of the row with the selected Course and Group
                        myCmd = new OleDbCommand("SELECT COUNT(*) FROM CourseAssignments WHERE CourseCode =@cid AND GroupNumber =@gid", myCon);
                        myCmd.Parameters.AddWithValue("cid", lstCourses.SelectedItem.Value);
                        myCmd.Parameters.AddWithValue("gid", lstGroups.SelectedItem.Value);
                        int numOfSameCourse = (Int32)myCmd.ExecuteScalar();

                        //Check if the number of the selected group with a same coursecode inside the db is less or bigger than 1
                        //If is 1, it means that the selected course is already being assigned to another teacher with the selected group, there display a message to tell the user to change to another group
                        if (numOfSameCourse >= 1)
                        {
                            Response.Write("<script>alert('The Group that you want to assign is already being assigned to a teacher.');</script>");
                        }
                        //If there is no teacher who has the course and the same group as the selected one, than do this
                        else 
                        {
                            //Execute SQL to insert a new row inside the CourseAssignments table with all data selected by the user
                            String todayDate = DateTime.Now.ToShortDateString();
                            myCmd = new OleDbCommand("INSERT INTO CourseAssignments (EmployeeId, CourseCode, GroupNumber, AssignedDate) VALUES (@eid, @cid, @gid, @date)", myCon);
                            myCmd.Parameters.AddWithValue("eid", lstTeachers.SelectedItem.Value);
                            myCmd.Parameters.AddWithValue("cid", lstCourses.SelectedItem.Value);
                            myCmd.Parameters.AddWithValue("gid", lstGroups.SelectedItem.Value);
                            myCmd.Parameters.AddWithValue("date", todayDate);
                            reader = myCmd.ExecuteReader();
                            reader.Close();

                            //After succesful insert, update the gridAssignedCourse and display the new version of course assigned to the selected teacher
                            myCmd = new OleDbCommand("SELECT [EmployeeId], [CourseCode], [GroupNumber], [AssignedDate] FROM CourseAssignments WHERE EmployeeId =@id", myCon);
                            myCmd.Parameters.AddWithValue("id", lstTeachers.SelectedItem.Value);
                            reader = myCmd.ExecuteReader();
                            gridAssignedCourse.DataSource = reader;
                            gridAssignedCourse.DataBind();
                            reader.Close();
                        }
                    } catch (Exception) {
                        //Display an alert when user try to insert the exact row of data which existed already inside the database
                        Response.Write("<script>alert('You are assigning a course which already has been assigned to this teacher.');</script>");
                    }
                }
            }
            
        }
    }
}