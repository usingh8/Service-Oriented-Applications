using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgetPasswordControl : System.Web.UI.UserControl
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox1.Text.Length == 0)
        {
            
            label1.InnerText = "Please Enter Valid Username";
            return;
        }
        
        if (!XML_DLL.XML_Data_Handler.isUserNameExists(TextBox1.Text, url))
        {
            label1.InnerText = "Username does not exist";
            return;
        }
        XML_DLL.XML_Data_Handler.resetPassword(TextBox1.Text, url);

        label1.InnerText = "Your Password has been reset to default password (username@123)";
        Button2.Visible = true;
        Button1.Visible = false;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ViewState["state"] = null;
        Response.Redirect(Request.RawUrl);
        
       // Response.Redirect("UserLoginPage.aspx");
    }
}