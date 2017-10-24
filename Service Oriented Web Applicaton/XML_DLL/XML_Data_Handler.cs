using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_DLL
{
    public class XML_Data_Handler
    {
        //static string strPath = HttpContext.Current.Server.MapPath("~/bin");
        static string url = "";
        //  string url = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\UserCredentials.xm");
        public static string login(string username, string password, string url)
        {

            string response = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    string xmlUsername = node.SelectSingleNode("UserName").InnerText;
                    string xmlPassword = node.SelectSingleNode("Password").InnerText;

                    if (xmlUsername.Equals(username) && xmlPassword.Equals(password))
                    {
                        response = node.SelectSingleNode("Name").InnerText + ":" + node.SelectSingleNode("UserName").Attributes["role"].Value;

                        return response;
                    }

                }


            }
            catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response += "Something went wrong";
                Console.WriteLine(e.Message);
            }

            return response.Length == 0 ? "Invalid Username/ Password" : response;
        }
        public static string signup(string[] data, string url)
        {
            string response = "";
            if (isUserNameExists(data[0],url))
            {
                return "UserName Already Exists";
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode node = doc.DocumentElement;
                XmlElement root = doc.CreateElement("User");

                XmlElement UserName = doc.CreateElement("UserName");
                UserName.InnerText = data[0];
                XmlElement Password = doc.CreateElement("Password");
                Password.InnerText = data[1];
                XmlElement Name = doc.CreateElement("Name");
                Name.InnerText = data[2];

                UserName.SetAttribute("role", data[3]);


                root.AppendChild(UserName);
                root.AppendChild(Password);
                root.AppendChild(Name);


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
            return response.Length != 0 ? response : "Account Created Successfully!";

        }
        public static string updateName(string name, string username, string url)
        {

            string response = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    string xmlUsername = node.SelectSingleNode("UserName").InnerText;


                    if (xmlUsername.Equals(username))
                    {
                        node.SelectSingleNode("Name").InnerText = name;

                        doc.Save(url);
                        return "Updated Succesfully";
                    }

                }


            }
            catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response += "Something went wrong";
                Console.WriteLine(e.Message);
            }

            return response.Length == 0 ? "User Not Found" : response;

        }
        public static string resetPassword(string username, string url)
        {

            string response = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    string xmlUsername = node.SelectSingleNode("UserName").InnerText;


                    if (xmlUsername.Equals(username))
                    {
                        node.SelectSingleNode("Password").InnerText = EncryptionDecryption.encrypt(node.SelectSingleNode("UserName").InnerText + "@123");
                        response = node.SelectSingleNode("Password").InnerText;
                        doc.Save(url);
                        return "Password has been reset to default( username@123)";
                    }

                }


            }
            catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response += "Something went wrong";
                Console.WriteLine(e.Message);
            }

            return response.Length == 0 ? "User Not Found" : response;

        }
        public static string updatePassword(string username, string password, string newPassword, string url)
        {

            string response = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    string xmlUsername = node.SelectSingleNode("UserName").InnerText;
                    string xmlPassword = node.SelectSingleNode("Password").InnerText;

                    if (xmlUsername.Equals(username) && xmlPassword.Equals(password))
                    {
                        node.SelectSingleNode("Password").InnerText = newPassword;
                        response = "Password updated Successfully";
                        doc.Save(url);
                        return response;
                    }

                }


            }
            catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response += "Something went wrong";
                Console.WriteLine(e.Message);
            }

            return response.Length == 0 ? "Invalid Old Password" : response;
        }
        public static Boolean isUserNameExists(string username, string url)
        {
            Boolean response = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    string xmlUsername = node.SelectSingleNode("UserName").InnerText;
                    if (xmlUsername.Equals(username))
                    {
                        return true;
                    }

                }


            }
            catch (Exception e)
            {

            }

            return response;
        }
        public static string removeUser(string username, string url)
        {

            string response = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    string xmlUsername = node.SelectSingleNode("UserName").InnerText;


                    if (xmlUsername.Equals(username))
                    {


                        node.ParentNode.RemoveChild(node);
                        doc.Save(url);
                        response = "User Removed Successfully";
                        return response;
                    }

                }


            }
            catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response += "Something went wrong";
                Console.WriteLine(e.Message);
            }

            return response.Length == 0 ? "Invalid Old Password" : response;
        }
        static StringBuilder str;
        public static string getAllUsers(string url)
        {
            str = new StringBuilder();

            string response = "";

            XmlDocument doc = new XmlDocument();
            try
            {

                doc.Load(@url);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodes = root.ChildNodes;

                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];

                    str.Append(node.SelectSingleNode("Name").InnerText + ":" + node.SelectSingleNode("UserName").InnerText + ":" + node.SelectSingleNode("UserName").Attributes["role"].Value);
                    str.Append("#");



                }
                str.Remove(str.Length - 1, 1);

            }
            catch (System.IO.IOException e)
            {
                response = "Xml File Not Found";
            }
            catch (Exception e)
            {
                response = "Something went wrong";
                Console.WriteLine(e.Message);
            }


            return response.Length == 0 ? str.ToString() : response;
        }
    }
}
