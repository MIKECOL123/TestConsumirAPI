using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TestConsumirAPI
{
    public enum httpVerb
    {
        GET,
        REST,
        PUT,
        DELETE
    }
    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endPoint = "";
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {

            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            

                HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Process the response stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }
    }
}