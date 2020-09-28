using System;

namespace CheckerApp.WebUI.Authentication
{
    public class BlazorServerAuthData
    {
        public string SubjectId { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
