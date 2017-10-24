using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Local_Component_Layer_NavBar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        if (Session["usertype"] != null)
        {
            if (Session["usertype"].Equals("admin"))
            {
                Response.Redirect("~/Staff_Pages/AdminDashBoard.aspx");
            }
            else if (Session["usertype"].Equals("member"))
            {
                Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");
            }
            else if (Session["usertype"].Equals("user"))
            {
                Response.Redirect("~/Member_Pages/UserMemberDashBoard.aspx");
            }
        }


    }
    
     protected void HomeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        HttpCookie kCookies = Request.Cookies["myCookieId"];
        if (kCookies != null)
        {
            kCookies.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(kCookies);
        }
        Response.Redirect("~/Default.aspx");


    }
    protected void Button8_Click(object sender, EventArgs e)
    {


        Response.Redirect("~/Staff_Pages/updateOwnProfilePage.aspx");

    }
}