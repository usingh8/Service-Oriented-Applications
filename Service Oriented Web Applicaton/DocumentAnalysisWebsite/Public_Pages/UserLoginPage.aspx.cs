using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XML_DLL;

public partial class UserLoginPage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Go_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
        protected void Button1_Click(object sender, EventArgs e)
    {

        
        string username = MyLogin.UserName;
        if (MyLogin.UserName == null || MyLogin.UserName.Length == 0)
        {
            label1.InnerText = "Enter Username";
            return;
        }
        if (MyLogin.Password == null || MyLogin.Password.Length == 0)
        {
            label1.InnerText = "Enter Password";
            return;
        }
        string password = XML_DLL.EncryptionDecryption.encrypt(MyLogin.Password);

        string userType = UserType.Value;

        

        string response = XML_Data_Handler.login(username, password,url);
        string[] info = response.Split(':');
        if (info.Length == 2)
        {
            Session["username"] = username;
            HttpCookie myCookies = new HttpCookie("myCookieId");
            myCookies["fullname"] = info[0];
            myCookies.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(myCookies);


            Session["usertype"] = info[1];

            if (info[1].Equals("user"))
            {
                Response.Redirect("~/Member_Pages/UserMemberDashBoard.aspx");
            }
            else if (info[1].Equals("member"))
            {
                Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");
            }
            else if (info[1].Equals("admin"))
            {
                Response.Redirect("~/Staff_Pages/AdminDashBoard.aspx");
            }
        }
        else
        {
            label1.InnerText = response;
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      
            ViewState["state"] = "forgetpassword";
    }
}