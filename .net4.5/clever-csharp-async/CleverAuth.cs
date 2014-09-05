using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using clever_csharp_async.model;

namespace clever_csharp_async
{
    public class CleverAuth : ICleverAuth
    {
        private readonly string _redirectUrl;
        private readonly CleverHttpClient _httpClient;

        public CleverAuth(string clientId, string secret, string redirectUrl)
        {
            _redirectUrl = redirectUrl;
            _httpClient = new CleverHttpClient(new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", clientId, secret)))));
        }

        public async Task<string> Authenticate(string code)
        {
            var tokenRequest = "\"{\"code\":\"" + code + "\", \"grant_type\":\"authorization_code\", \"redirect_url\": \"" + _redirectUrl + "\"}";
            var token = await _httpClient.Post<AccessTokenResponse>(new Uri(UrlUtils.AuthTokensUrl), tokenRequest);
            return token.access_token;
        }
    }
}