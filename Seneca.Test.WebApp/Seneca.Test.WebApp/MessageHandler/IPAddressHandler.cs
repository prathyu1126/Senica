using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace Seneca.Test.WebApp.MessageHandler
{
    public class IPAddressHandler:DelegatingHandler
    {
        private const string ipaddresslist = "192.169.1.5";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage,CancellationToken cancellationToken)
        {
            bool validkey = false;
            IEnumerable<string> requestHeaders;
            var checkipaddressExists = httpRequestMessage.Headers.TryGetValues("IPAdreess", out requestHeaders);
            if(checkipaddressExists)
            {
                if(requestHeaders.FirstOrDefault().Equals(ipaddresslist))
                {
                    validkey = true;
                }
            }
            if(!validkey)
            {
               // return httpRequestMessage.;
            }
            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }
    }
}
