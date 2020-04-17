using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace APITests
{
    public class Actions
    {
        public string _postParameters;
        public string _url;
        public string value;
        public string Action()
        { 

            TranslationAPI _translationAPI = new TranslationAPI() { postParameters = _postParameters, url = _url };
            _translationAPI.PostRequest();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(_translationAPI.result);
            if (_url == "https://translate.yandex.net/api/v1.5/tr/translate")
            {
                
                value = doc.GetElementsByTagName("text")[0].InnerText;
            }
            else if (_url == "https://translate.yandex.net/api/v1.5/tr/detect")
            {
                
                XmlNode node = doc.DocumentElement.SelectSingleNode("/DetectedLang");
                value = node.Attributes["lang"].InnerText;
            }
            else
            {
                XmlNode node = doc.GetElementsByTagName("Langs")[0];
                if (node.HasChildNodes == true)
                    value = "200";
            }
            
            
            return value;
        }
     }

    public class TranslationAPI
    {
        public string postParameters;
        public string url;
        public string result;
        public string PostRequest()
        {

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = postParameters.Length;
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(postParameters);
            }

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            
            response.Close();
            return result;
        }
    }
}
