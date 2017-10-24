using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class Member_Pages_PublicServiceTryItPage : System.Web.UI.Page
{
    string url = HttpContext.Current.Server.MapPath("~/App_Data/UserCredentials.xml");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SentimentAnalysis_Click(object sender, EventArgs e)
    {

        if (TextBox1.Text == "" || TextBox1.Text.Length ==0)
        {
            Label1.Text = "Please Enter Valid Text";

            return;
        }
        string respons = "";
        // Target api URL 
        string endPoint = @"http://api.datumbox.com:80/1.0/SentimentAnalysis.json";

        //DatumBox  Api access key 

        string key = "4d383ab94aa62180d5eea1d870ca85aa";

        try
        {


            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "api_key=" + key + "&text=" + TextBox1.Text.Trim();
            byte[] data = encoding.GetBytes(postData);

            WebRequest request = WebRequest.Create(endPoint);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);   // posting various paremeters to api
            stream.Close();

            WebResponse response = request.GetResponse();  // grabbing response from api
            stream = response.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            // Reading response a JSON

            var jsonString = sr.ReadToEnd();

            JObject o = JObject.Parse(jsonString);
            // Parsing jSON to string
            respons = (string)o["output"]["result"];
            sr.Close();
            stream.Close();
        }
        catch (Exception ex)
        {
            respons = "Error";
        }


        Label1.Text = respons.Equals("Error")?respons:"This document has "+ respons+" sentiment.";

    }
}