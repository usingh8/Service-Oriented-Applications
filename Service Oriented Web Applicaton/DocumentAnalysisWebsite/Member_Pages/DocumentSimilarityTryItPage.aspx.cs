using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_Pages_DocumentSimilarityTryItPage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DocumentSimlarity_Click(object sender, EventArgs e)
    {

        DocumentSimilarityService.Service1Client svc = new DocumentSimilarityService.Service1Client();

        string doc1 = TextBox1.Text.Trim();
        string doc2 = TextBox2.Text.Trim();
        if (doc1 == null || doc1.Length == 0)
        {
            TextBox1.Text = "Enter valid document please";
        }
        if (doc2 == null || doc2.Length == 0)
        {
            TextBox2.Text = "Enter valid document please";
        }
        else
        {
            // calling 
            Double[] topic = svc.getDocumentSimilarity(doc1, doc2);

            if (topic[0] != 0)
            {
                Label1.Text = "Simalarity : " + topic[0];
                Label1.Attributes["style"] = "color:blue; font-weight:bold;";
            }
            else
            {
                Label1.Text = "Some Error Occurred, Try Again Later ";
                Label1.Attributes["style"] = "color:red; font-weight:bold;";
            }
        }
        
    }
}