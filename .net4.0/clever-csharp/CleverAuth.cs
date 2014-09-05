using System;
using System.Net.Http.Headers;
using clever_csharp.model;

namespace clever_csharp
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

        public string Authenticate(string code)
        {
            var tokenRequest = "\"{\"code\":\"" + code + "\", \"grant_type\":\"authorization_code\", \"redirect_url\": \"" + _redirectUrl + "\"}";
            var token = _httpClient.Post<AccessTokenResponse>(new Uri(UrlUtils.AuthTokensUrl), tokenRequest);
            return token.access_token;
        }
    }
}