using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDashBoard : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Public_Pages/UserLoginPage.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/Member_Pages/TopicClassificationTryItPage.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/Member_Pages/DocumentSimilarityTryItPage.aspx");
    }
    protected void Sentiment_Analysis_page_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Member_Pages/PublicServiceTryItPage.aspx");
    }
}