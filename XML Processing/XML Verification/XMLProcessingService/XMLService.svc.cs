using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Xml;


namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string addPerson(List<String> data , string url)
        {
            string response = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode node = doc.DocumentElement;
                XmlElement root = doc.CreateElement("Person");

                XmlElement Name = doc.CreateElement("Name");

                XmlElement First = doc.CreateElement("First");
                First.InnerText = data[0];
                XmlElement Last = doc.CreateElement("Last");
                Last.InnerText = data[1];

                XmlElement Credential = doc.CreateElement("Credential");
                XmlElement Id = doc.CreateElement("Id");
                Id.InnerText = data[2];
                XmlElement Password = doc.CreateElement("Password");
                Password.SetAttribute("encryption", data[7]);
                Password.InnerText = data[3];

                XmlElement Phone = doc.CreateElement("Phone");
                XmlElement Cell = doc.CreateElement("Cell");
                Cell.SetAttribute("provider", data[8]);
                Cell.InnerText = data[5];
                XmlElement Work = doc.CreateElement("Work");
                Work.InnerText = data[4];

                XmlElement Category = doc.CreateElement("Category");
                Category.InnerText = data[6];

                Name.AppendChild(First);
                Name.AppendChild(Last);
                Credential.AppendChild(Id);
                Credential.AppendChild(Password);
                Phone.AppendChild(Cell);
                Phone.AppendChild(Work);

                root.AppendChild(Name);
                root.AppendChild(Credential);
                root.AppendChild(Phone);
                root.AppendChild(Category);


                node.AppendChild(root);

                doc.Save(url);
            }
            catch (System.IO.IOException e)
            {
                response = "XML File Not Found";
            }
            catch (Exception e)
            {
                response = "Something went wrong";
            }
            return response.Length !=0? response : "Done!";
        }
            StringBuilder str;
        public string searchKey(string url, string key)
        {
            str = new StringBuilder();

            string response = "";
            
            XmlDocument doc = new XmlDocument();
            try { 
            
                doc.Load(@url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];
                    Found found = new Found();
                    OutputNode(node, key, found);
                    if (found.found)
                    {
                        print(node);
                        str.Append("@");
                    }


                }
            
           } catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response = "Something went wrong";
                Console.WriteLine(e.Message);
            }
            

            return  response.Length==0?str.ToString(): response ;
        }

        void OutputNode(XmlNode node, string key, Found f) { 
        
            if (node == null) return ;
            
            if (node.Value != null)
            {
               

                if (node.Value.ToLower().Trim().Equals(key.ToLower().Trim()))
                {
                   
                    f.found = true;
                    return;
                }
            }
            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                     OutputNode(child, key, f);

            }
            
               
        }
        void print(XmlNode node)
        {     
            if (node == null) return ;
           
            if (node.Value != null)
            {
                str.Append(node.ParentNode.Name+": "  + node.Value+", ");
               
            }
            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                    print(child);

            }

        }
    }
}
class Found
{
   public bool found = false;
}
