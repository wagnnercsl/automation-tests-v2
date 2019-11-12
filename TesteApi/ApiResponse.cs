using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApiTest
{
    class ApiResponse
    {
        private string ApiUrlString = "http://5d9cc58566d00400145c9ed4.mockapi.io/shopping_cart";
        public string GetResponse(string param)
        {
            StringBuilder responseString = new StringBuilder();
            ApiUrlString = String.Format(ApiUrlString);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiUrlString);

            // Set some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            try
            {
                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                if (receiveStream != null)
                {
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string line = "";
                    while ((line = readStream.ReadLine()) != null)
                    {
                        responseString.Append(line);
                    }
                    Console.WriteLine("Response stream received.");
                    Console.WriteLine(responseString);
                    response.Close();
                    readStream.Close();
                }
            }
            catch (Exception)
            {
                responseString.Append("Did not get response");

            }
            return responseString.ToString();
        }

    }
}