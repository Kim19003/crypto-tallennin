using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin_Tallennin
{
    class API
    {
        WebRequest myRequest;
        WebResponse response;
        Stream dataStream;
        StreamReader reader;
        string responseFromFile;

        public API()
        {
            myRequest = WebRequest.Create(@"https://api.coindesk.com/v1/bpi/currentprice.json");
            response = myRequest.GetResponse();
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);
            responseFromFile = reader.ReadToEnd();
        }

        public string Response()
        {
            return responseFromFile;
        }
    }
}
