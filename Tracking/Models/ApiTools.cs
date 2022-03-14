using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tracking.Models
{
    public static class ApiTools
    {
        public static object PostWebApiJson(object data, Uri url, Dictionary<string, string> httpHeaders = null)
        {
            // Create a WebClient to GET the request
            WebClient client = new WebClient();

            // Set the header so it knows we are sending JSON
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            if (httpHeaders != null && httpHeaders.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in httpHeaders)
                {
                    client.Headers.Add(pair.Key, pair.Value);
                }
            }

            string serializedData = JsonConvert.SerializeObject(data);

            // Make the request
            var response = client.UploadString(url, serializedData);
            return response;
        }
        public static object PostWebApiURLEncode(string data, Uri url, Dictionary<string, string> httpHeaders = null)
        {
            // Create a WebClient to GET the request
            WebClient client = new WebClient();
            object response = null;

            // Set the header so it knows we are sending JSON
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            if (httpHeaders != null && httpHeaders.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in httpHeaders)
                {
                    client.Headers.Add(pair.Key, pair.Value);
                }
            }


            try
            {
                // Make the request
                response = client.UploadString(url, data);
            }
            catch (Exception ex)
            {
                //UdpLog.SendUdpLog(string.Format("[ERROR: {0}] - {1}", url.AbsoluteUri, ex.Message), "Bermuda Tracking Failed", (int)ApplicationError.Severity.Critical, null, ex);
            }

            // Deserialise the response 
            return response;
            //return JsonConvert.DeserializeObject(response);
        }
        public static object PostWebApiSoap(object data, Uri url, Type classType, Dictionary<string, string> httpHeaders = null, string formatString = null, XmlSerializerNamespaces classNamespace = null)
        {
            object response = null;
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(classType);
                var settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    OmitXmlDeclaration = true,
                };
                var builder = new StringBuilder();
                using (var writer = XmlWriter.Create(builder, settings))
                {
                    serializer.Serialize(writer, data, classNamespace);
                }
                string requestString = builder.ToString();
                using (WebClient client = new WebClient())
                {
                    if (httpHeaders != null && httpHeaders.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> pair in httpHeaders)
                        {
                            client.Headers.Add(pair.Key, pair.Value);
                        }
                    }

                    //client.Headers[HttpRequestHeader.ContentType] = "application/xml";
                    response = client.UploadString(url, requestString);
                    return response;
                }


            }

        }
        public static object PostWebApi(object data, Uri url, Dictionary<string, string> httpHeaders = null, string formatString = null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // Create a WebClient to GET the request
            WebClient client = new WebClient();
            object response = null;

            // Set the header so it knows we are sending JSON
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            if (httpHeaders != null && httpHeaders.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in httpHeaders)
                {
                    client.Headers.Add(pair.Key, pair.Value);
                }
            }

            string serializedData = JsonConvert.SerializeObject(data);

            if (!string.IsNullOrEmpty(formatString))
                serializedData = formatString + serializedData;

            try
            {
                // Make the request
                response = client.UploadString(url, serializedData);

            }
            catch (WebException wex)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(wex.Response.GetResponseStream());
                string error = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(error)) response = error;
            }
            catch (Exception ex)
            {
                // UdpLog.SendUdpLog(string.Empty, "LastMileCommon.PostWebApi Error", (int)ApplicationError.Severity.Serious, null, ex);
            }

            // Deserialise the response 
            return response;
            //return JsonConvert.DeserializeObject(response);
        }
        public static object GetWebApi(object data, Uri url, Dictionary<string, string> httpHeaders = null)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                if (httpHeaders != null && httpHeaders.Count > 0)
                {
                    foreach (KeyValuePair<string, string> pair in httpHeaders)
                    {
                        request.Headers.Add(pair.Key, pair.Value);
                        request.Headers[HttpRequestHeader.Authorization] = string.Format("{0}", pair.Value);
                    }
                }
                String result = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    System.IO.Stream dataStream = response.GetResponseStream();
                    System.IO.StreamReader reader = new StreamReader(dataStream);
                    var test = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    return test;
                }
            }
            catch (Exception ex)
            {
               // UdpLog.SendUdpLog("Error in RedBoxManager.GetWebApi", "Redbox Tracking Failed for last AWBNumber: " + url.ToString(), (int)MyUs.Logging.ApplicationError.Severity.Warning, null, ex);
                return null;
            }
        }
        public static bool WebCall(string _url, string postData, out string JsonData)
        {
            bool result = false;
            JsonData = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_url);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Accept = "image/gif, image/jpeg, image/pjpeg, text/plain, text/html, */*";

                var data = Encoding.ASCII.GetBytes(postData);
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var output = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(output);

                    JsonData = JsonConvert.SerializeXmlNode(doc);
                    if (!string.IsNullOrEmpty(JsonData))
                        result = true;
                }
            }
            catch { }

            return result;

        }
    }
}
