using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Handlers
{
    public class RequestHandler : DelegatingHandler
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public RequestHandler(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Добавляем токен к запросу авторизованного юзера
            var token = _httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Application.UserId"];

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
