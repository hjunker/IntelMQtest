using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace IntelMQtest
{
    class MyWebClient : WebClient
    {
        Uri _responseUri;

        public Uri ResponseUri
        {
            get { return _responseUri; }
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            try
            {
                WebResponse response = base.GetWebResponse(request);
                _responseUri = response.ResponseUri;
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
