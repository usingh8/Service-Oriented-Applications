using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XML_DLL;

public partial class updateOwnProfilePage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["state"] = "0";
            getData();
        }



    }
    void getData()
    {
        string username = Session["username"]!=null ? Session["username"].ToString():"" ;

        
        string[] userInfo = XML_Data_Handler.getAllUsers(url).Split('#');
        for (int i = 0; i < userInfo.Length; i++)
        {
            string[] details = userInfo[i].Split(':');
            if (username.Equals(details[1]))
            {
                textbox1.Text = details[0];
                textbox2.Text = details[1];
                textbox3.Text = details[2] + "qwertyyu";
                
                
                HttpCookie kCookies = Request.Cookies["myCookieId"];
                if (kCookies != null)
                {
                    kCookies["fullname"] = details[0];
                    Response.Cookies.Add(kCookies);
                }
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
        else if(Session["usertype"].Equals("member"))
        {
            Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");
        }
        else if (Session["usertype"].Equals("user"))
        {
            Response.Redirect("~/Member_Pages/UserMemberDashBoard.aspx");
        }
        


    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        
        ViewState["state"] = "1";
        


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (textbox1.Text == null || textbox1.Text.Length == 0)
        {
            label1.InnerText = "Please Enter Valid Name";
            textbox1.Focus();
            return;
        }
        if (ViewState["state"]!=null && ViewState["state"].Equals("1"))
        {
            if (textbox5.Text == null || textbox5.Text.Length == 0)
            {
                label1.InnerText = "Please Enter Current Password";
                textbox5.Focus();
                return;
            }
            if (textbox6.Text == null || textbox6.Text.Length == 0)
            {
                label1.InnerText = "Please Enter New Password";
                textbox6.Focus();
                return;
            }
            if (textbox7.Text == null || textbox7.Text.Length == 0)
            {
                label1.InnerText = "Please Enter New Password";
                textbox7.Focus();
                return;
            }
            if (!textbox6.Text.Trim().Equals(textbox7.Text.Trim()))
            {
                label1.InnerText = "New Password does not match, Please enter again.";
                textbox6.Focus();
                return;
            }
        }
        string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
        string response1 = XML_Data_Handler.updateName(textbox1.Text, textbox2.Text, url);
        label1.InnerText = response1;
        string response2 = "";
        if (ViewState["state"] != null && ViewState["state"].Equals("1"))
        {
             response2 = XML_Data_Handler.updatePassword(Session["username"] != null ? Session["username"].ToString() : "", XML_DLL.EncryptionDecryption.encrypt(textbox5.Text), XML_DLL.EncryptionDecryption.encrypt(textbox6.Text), url);
            label1.InnerText = response2;
        }
        if (response2.Equals("Password updated Successfully") || response1.Equals("Updated Succesfully"))
        {
            getData();
            
        }
    }
}