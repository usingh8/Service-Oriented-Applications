using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML_DLL
{
   public  class EncryptionDecryption
    {
        public static string encrypt(string dataInput)
        {
            string respons = "";
            
            try
            {
            Uri baseUri = new Uri("http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionRest/Service.svc/Encrypt?text="+dataInput);

       
            WebClient channel = new WebClient(); // create a channel

            byte[] abc = channel.DownloadData(baseUri); // return byte array

            Stream strm = new MemoryStream(abc); // convert to mem stream

            
            StreamReader reader = new StreamReader(strm);
            string text = reader.ReadToEnd();
            
            string result = text;

            respons = result;
                
            
            }catch (Exception e)
            {
                respons = "";
            }
            return respons;
        }
        public static string decrypt(string inputData)
        {
           
            string respons = "";

            try
            {
                Uri baseUri = new Uri(" http://neptune.fulton.ad.asu.edu/WSRepository/Services/EncryptionRest/Service.svc/Decrypt?text=" + inputData);


                WebClient channel = new WebClient(); // create a channel

                byte[] abc = channel.DownloadData(baseUri); // return byte array

                Stream strm = new MemoryStream(abc); // convert to mem stream


                StreamReader reader = new StreamReader(strm);
                string text = reader.ReadToEnd();

                string result = text;

                respons = result;


            }
            catch (Exception e)
            {
                respons = "";
            }
            return respons;
        }
    }
}
