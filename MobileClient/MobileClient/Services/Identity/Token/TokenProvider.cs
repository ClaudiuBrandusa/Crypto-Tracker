using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Services.Identity.Token
{
    public class TokenProvider : ITokenProvider
    {
        private string token;

        public string Token => token;

        public TokenProvider()
        {
            token = "";
        }

        public void UpdateToken(string token)
        {
            this.token = token;
        }
    }
}
