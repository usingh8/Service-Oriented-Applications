using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Pages_TopicClassificationTryItPage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Topic_Classifcation(object sender, EventArgs e)
    {

        TopicClassificationService.Service1Client svc = new TopicClassificationService.Service1Client();

        string input = TextBox1.Text.Trim();
        if (input == null || input.Length == 0)
        {
            TextBox1.Text = "Enter valid document please";
        }
        else
        {
            // calling 
            string topic = svc.getTopicOfDocument(TextBox1.Text);

            if (!topic.Equals("") && !topic.Equals("Error"))
            {
                Label1.Text = "Topic : " + topic;
            }
            else
            {
                Label1.Text = "Some Error Occurred, Try Again Later ";
            }
        }
        
    }
}