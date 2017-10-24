using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string firstName, lastName, id, password, cellPhone, workPhone, cellProvider, category;
        bool encryption;
        Label2.Visible = true;
        string url = TextBox11.Text;

        if (url == null || url.Length == 0)
        {
            Label2.Text = "Enter Valid Url";
            TextBox11.Focus();
            return;
        }
        firstName = TextBox4.Text;
        if (firstName == null || firstName.Length == 0)
        {
            Label2.Text = "Enter First Name";
            TextBox4.Focus();
            return;
        }
        
        lastName = TextBox5.Text;
        if (lastName == null || lastName.Length == 0)
        {
            Label2.Text = "Enter Last Name";
            TextBox5.Focus();
            return;
        }
        id = TextBox6.Text;
        if (id == null || id.Length == 0)
        {
            Label2.Text = "Enter Id";
            TextBox6.Focus();
            return;
        }
        password = TextBox7.Text;
        if (password == null || password.Length == 0)
        {
            Label2.Text = "Enter Password";
            TextBox7.Focus();
            return;
        }
        
        workPhone = TextBox8.Text;
        if (workPhone == null || workPhone.Length == 0)
        {
            Label2.Text = "Enter Work Phone";
            TextBox8.Focus();
            return;
        }
        cellPhone = TextBox9.Text;
        if (cellPhone == null || cellPhone.Length == 0)
        {
            Label2.Text = "Enter Cell Phone";
            TextBox9.Focus();
            return;
        }
        cellProvider = TextBox10.Text;
       /* if (cellProvider == null || cellProvider.Length == 0)
        {
            Label2.Text = "Enter Cell Provider";
            TextBox10.Focus();
            return;
        }*/
        
        category = testSelect.Value;
        encryption = CheckBox1.Checked;
        Label2.Visible = true;
        

        List<String> data = new List<string>();
         Label2.Text =  category;

        data.Add(firstName);
        data.Add(lastName);
        data.Add(id);
        if (encryption)
        {
            EncryptionService.ServiceClient encryptSVC = new EncryptionService.ServiceClient();
            data.Add(encryptSVC.Encrypt(password));
        }
        else
        {
            data.Add(password);
        }
        data.Add(workPhone);
        data.Add(cellPhone);
        data.Add(category);
        data.Add(encryption.ToString());
        data.Add(cellProvider);

        


     
        XmlService.Service1Client svc = new XmlService.Service1Client();

        string response = svc.addPerson(data.ToArray(), url);

        Label2.Text = response;

        Button2.Focus();
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        XmlService.Service1Client svc = new XmlService.Service1Client();

        if (TextBox1.Text.Length > 0 && TextBox2.Text.Length > 0)
        {
            
            Label1.Visible = true;
            string response = svc.searchKey(TextBox1.Text, TextBox2.Text);
          
            if (response.Trim().Length == 0)
            {
                Label1.Text = "Key did not match with any data in the file";

                TextBox3.Visible = false;
            }
            else if (!response.Equals("File Not Found") && !response.Equals("Something went wrong"))
            {
               
               
                string[] content = response.Split('@');
                int resLength = content.Length - 1;
                    Label1.Text = resLength +( resLength == 1? " result " : " results ")+ "found  :";
                    TextBox3.Visible = true;
                    TextBox3.Text = "";
                    foreach (string result in content)
                    {
                        if (result != null && result.Length > 0)
                        {
                            foreach (string res in result.Split(','))
                            {
                                if (result.Trim().Length > 0)
                                    TextBox3.Text += res.Trim() + "\n";
                            }
                        }
                    }

            }
            else
            {
                TextBox3.Visible = false;
                Label1.Text = response;
            }

        }
        else if (TextBox1.Text.Length <=0)
        {
            TextBox3.Visible = false;
            Label1.Text = "Please Enter URL";
        }
        else if (TextBox2.Text.Length <= 0)
        {
            TextBox3.Visible = false;
            Label1.Text = "Please Enter Key";
        }
        Button1.Focus();

    }
}