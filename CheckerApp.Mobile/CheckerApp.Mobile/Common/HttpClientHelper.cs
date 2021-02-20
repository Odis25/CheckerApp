using System.Net.Http;

namespace CheckerApp.Mobile.Common
{
    public static class HttpClientHelper
    {
        public static HttpClient GetHttpClient() 
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback +=
                            (send, certificate, chain, errors) => true;

            var client = new HttpClient(handler);
            client.BaseAddress = Startup.BackendUri;

            return client;
        }
    }
}
