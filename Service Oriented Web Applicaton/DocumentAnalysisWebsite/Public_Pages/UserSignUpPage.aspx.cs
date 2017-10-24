using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using XML_DLL;

public partial class Public_Pages_UserSignUpPage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetVerifierString/" + "5");
            string str = doc.DocumentElement.FirstChild.Value;
            ViewState["captcha"] = str;
            Image1.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + str;
            Image1.Visible = true;
        }
    }
    protected void Go_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void Button2_click(object sender, EventArgs e)
    {
        Session["username"] = textbox2.Text;
        
        HttpCookie myCookies = new HttpCookie("myCookieId");
        myCookies["fullname"] = textbox1.Text;
        myCookies.Expires = DateTime.Now.AddMinutes(15);
        Response.Cookies.Add(myCookies);


        Session["usertype"] = radio1.Checked?"user":"member";

        if (Session["usertype"]!=null && Session["usertype"].Equals("user"))
        {
            Response.Redirect("~/Member_Pages/UserMemberDashBoard.aspx");
        }
        else if (Session["usertype"] != null && Session["usertype"].Equals("member"))
        {
            Response.Redirect("~/Staff_Pages/StaffMemberDashBoard.aspx");
        }
        else if (Session["usertype"] != null && Session["usertype"].Equals("admin"))
        {
            Response.Redirect("~/Staff_Pages/AdminDashBoard.aspx");
        }
    }
        protected void SignUp_click(object sender, EventArgs e)
    {

        if (textbox1.Text == null || textbox1.Text.Length == 0)
        {
            label1.InnerText = "Please Enter Full Name";
            textbox1.Focus();
            return;
        }
        if (textbox2.Text == null || textbox2.Text.Length == 0)
        {
            label1.InnerText = "Please Enter Username";
            textbox2.Focus();
            return;
        }
        if (textbox3.Text == null || textbox3.Text.Length == 0)
        {
            label1.InnerText = "Please Enter New Password";
            textbox3.Focus();
            return;
        }
        if (textbox4.Text == null || textbox4.Text.Length == 0)
        {
            label1.InnerText = "Please Enter Confirm Password";
            textbox3.Focus();
            return;
        }
        if (!textbox3.Text.Trim().Equals(textbox4.Text.Trim()))
        {
            label1.InnerText = "New Password does not match, Please enter again.";
            textbox4.Focus();
            return;
        }
        if (textbox5.Text == null || textbox5.Text.Length == 0)
        {
            label1.InnerText = "Please Enter Captcha";
            textbox5.Focus();
            return;
        }
        if (ViewState["captcha"] != null && !ViewState["captcha"].Equals(textbox5.Text))
        {
            label1.InnerText = "Wrong Captcha, Try Again";
            textbox5.Focus();
            return;
        }
        if (!radio1.Checked && !radio2.Checked)
        {
            label1.InnerText = "Please select User type";
            return;
        }

        

        string[] data = new string[4];
        data[2] = textbox1.Text.Trim();
        data[0] = textbox2.Text.Trim();
        data[1] = XML_DLL.EncryptionDecryption.encrypt(textbox3.Text.Trim());
        data[3] =  radio1.Checked ? "user" : "member";
        string response = XML_Data_Handler.signup(data, url);

        label1.InnerText = response;

        


    }
}