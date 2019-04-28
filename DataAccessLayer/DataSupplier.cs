using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;

namespace DataAccessLayer
{
    public class DataSupplier
    {
        public static DataContainer MakeRequest(string requestUrl, object JSONRequest, string JSONmethod, string mContentType, Type JSONResponseType)
        {
            DataContainer oDataContainer = new DataContainer();
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                //WebRequest WR = WebRequest.Create(requestUrl);   
                string sb = JsonConvert.SerializeObject(JSONRequest);
                request.Method = JSONmethod;
                request.ContentType = mContentType;

                NetworkCredential myNetworkCredential = new NetworkCredential("admin", "admin");

                CredentialCache myCredentialCache = new CredentialCache();
                myCredentialCache.Add(new Uri(requestUrl), "Basic", myNetworkCredential);

                request.PreAuthenticate = true;
                request.Credentials = myCredentialCache;

                // "POST";request.ContentType = JSONContentType; // "application/json";   
                //Byte[] bt = Encoding.UTF8.GetBytes(sb);
                //Stream st = request.GetRequestStream();
                //st.Write(bt, 0, bt.Length);
                //st.Close();

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string strsb = sr.ReadToEnd();
                    object objResponse = JsonConvert.DeserializeObject(strsb, JSONResponseType);

                    oDataContainer.Data = objResponse;
                    return oDataContainer;
                }
            }
            catch (Exception e)
            {
                oDataContainer.errorData = ((WebException)e).Response;
                return oDataContainer;
            }
        }
    }
}
