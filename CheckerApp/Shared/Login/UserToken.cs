﻿using System;

namespace CheckerApp.Shared.Login
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
