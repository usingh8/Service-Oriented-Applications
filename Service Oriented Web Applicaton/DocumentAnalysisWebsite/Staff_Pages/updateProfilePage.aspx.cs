using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XML_DLL;

public partial class updateProfilePage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
        }
      


    }
    void getData()
    {
        string username = Request.QueryString["Name"];

        
        string[] userInfo = XML_Data_Handler.getAllUsers(url).Split('#');
        for (int i = 0; i < userInfo.Length; i++)
        {
            string[] details = userInfo[i].Split(':');
            if (username.Equals(details[1]))
            {
                textbox1.Text = details[0];
                textbox2.Text = details[1];
                textbox3.Text = details[2] + "qwertyyu";
                break;
            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {


        Response.Redirect("~/Staff_Pages/updateOwnProfilePage.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Clear();
        HttpCookie kCookies = Request.Cookies["myCookieId"];
        if (kCookies != null)
        {
            kCookies.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(kCookies);
        }
        Response.Redirect("~/Public_Pages/UserLoginPage.aspx");


    }
    protected void Button4_Click(object sender, EventArgs e)
    {


        if (Session["usertype"].Equals("admin"))
        {
            Response.Redirect("~/Staff_Pages/AdminDashBoard.aspx");
        }
        else if (Session["usertype"].Equals("member"))
        {
            Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");
        }
      
        


    }
    protected void Button7_Click(object sender, EventArgs e)
    {


        
        string response = XML_Data_Handler.removeUser(textbox2.Text,url);
        label1.InnerText = response;





    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        string response = XML_Data_Handler.resetPassword(textbox2.Text, url);
        label1.InnerText = response;
        


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (textbox1.Text == null || textbox1.Text.Length == 0)
        {
            label1.InnerText = "Please Enter Valid Name";
            textbox1.Focus();
            return;
        }
        
        string response = XML_Data_Handler.updateName(textbox1.Text, textbox2.Text, url);
        label1.InnerText = response;

        if (response.Equals("Updated Succesfully"))
        {
           getData();
        }
    }
}