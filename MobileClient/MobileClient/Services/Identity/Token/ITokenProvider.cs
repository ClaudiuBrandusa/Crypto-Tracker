using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Services.Identity.Token
{
    public interface ITokenProvider
    {
        string Token { get; }

        void UpdateToken(string token);
    }
}
