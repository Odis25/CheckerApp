﻿namespace CheckerApp.WebUI.ViewModels.Login
{
    public class UserCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
