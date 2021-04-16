using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient
{
    public class Constants
    {
        public const string ServerHostname = "10.0.2.2:5004";
        public const string ServerProtocol = "http";
        public const string ServerHost = ServerProtocol + "://" + ServerHostname;

        public const string LoginEndpoint = ServerHost + "/api/applicationUser/login";
        public const string RegisterEndpoint = ServerHost + "/api/applicationUser/register";
        public const string LogoutEndpoint = ServerHost + "/api/applicationUser/logout";
    }
}
