using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  	public string UserName
    {
        get { return TextBox1.Text; }
        set { TextBox1.Text = value; }
    }
    public string Password
    {
        get { return TextBox2.Text; }
        set { TextBox2.Text = value; }
    }

}