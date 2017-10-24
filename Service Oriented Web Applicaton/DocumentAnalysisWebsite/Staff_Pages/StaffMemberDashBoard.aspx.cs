using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using XML_DLL;

public partial class MemberDashBoard : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
        displayUsers();

    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Public_pages/UserLoginPage.aspx");


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        
        Response.Redirect("~/Staff_Pages/updateProfilePage.aspx?Name=" + userName.Value );

    }
    protected void Button3_Click(object sender, EventArgs e)
    {


        Response.Redirect("~/Staff_Pages/updateOwnProfilePage.aspx");

    }
    protected void displayUsers()
    {
        

        string allUsersData = XML_Data_Handler.getAllUsers(url);

        string [] users = allUsersData.Split('#');
        string data = "";
        for (int i = 0; i < users.Length; i++)
        {
            string [] userInfo = users[i].Split(':');

            if (userInfo.Length>=3 && userInfo[2].Equals("user"))
            {
                data += "<div class='col-md-12' style='margin-top:15px; margin-bottom:15px;'><div class='col-md-10'>" + "<b>Full Name:</b> "+userInfo[0] +",  <b>Username:</b>"+ userInfo[1]+", <b>User Type: </b> "+userInfo[2]+ "</div ><input type='submit' class='btn btn-danger'  id='"+ userInfo[1] + "' value='Update'  onclick='goToUpdatePage(this.id);return false;'/></div> ";
            }
        }
        myDiv.InnerHtml = data;

       // myDiv.InnerText = allUsersData;

    }
}