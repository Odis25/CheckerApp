using System;

namespace CheckerApp.WebUI.ViewModels.Login
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
