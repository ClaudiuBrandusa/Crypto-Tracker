using MobileClient.Models;
using MobileClient.Services.Identity.Token;
using MobileClient.Utils.HTTP;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileClient.Services.Identity
{
    public class RegisterService : IRegisterService
    {
        ITokenProvider tokenProvider;

        public RegisterService(ITokenProvider tokenProvider)
        {
            this.tokenProvider = tokenProvider;
        }

        public async Task<bool> Register(RegisterModel model)
        {
            var result = await HttpUtil.PostAsyncWithResults(model, Constants.RegisterEndpoint);

            if (result == null) return false;

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
    }
}
