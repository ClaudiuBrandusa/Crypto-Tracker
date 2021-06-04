using MobileClient.Models;
using MobileClient.Services.Identity.Token;
using MobileClient.Utils.HTTP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileClient.Services.Identity
{
    public class LoginService : ILoginService
    {
        ITokenProvider tokenProvider;

        public LoginService(ITokenProvider tokenProvider)
        {
            this.tokenProvider = tokenProvider;
        }

        public async Task<bool> Login(LoginModel model)
        {
            var result = await HttpUtil.PostAsyncWithResults(model, Constants.LoginEndpoint);

            if (result == null) return false;

            if (result.StatusCode != System.Net.HttpStatusCode.OK) return false;

            string content = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content)) return false;

            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

            if (!dictionary.ContainsKey("token"))
            {
                return false;
            }

            tokenProvider.UpdateToken(dictionary["token"]);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Logout()
        {
            var result = await HttpUtil.PostAuthorizedAsync(null, Constants.LogoutEndpoint, tokenProvider.Token);

            return result;
        }
    }
}
