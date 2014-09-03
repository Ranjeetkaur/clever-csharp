using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using clever_csharp.model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace clever_csharp
{
    public class CleverHttpClient : HttpClient
    {
        public CleverHttpClient(AuthenticationHeaderValue token)
        {
            DefaultRequestHeaders.Authorization = token;
        }

        private readonly Dictionary<HttpStatusCode, Action> _knownHttpStatusErrors = new Dictionary<HttpStatusCode, Action>
        {
            { 
                HttpStatusCode.NotFound,
                () => { throw new HttpRequestException("(404) Resource not available. Check your request url. Resource may have been deleted from Clever."); } 
            },
            {
                HttpStatusCode.BadRequest,
                () =>{ throw new HttpRequestException("(400) Bad request. Check your API key and request body."); }
            },
            {
                HttpStatusCode.Unauthorized,
                () => { throw new HttpRequestException("(401) Unauthorized. Check your API key and request body."); }
            },
            {
                HttpStatusCode.RequestEntityTooLarge,
                () => { throw new HttpRequestException(
                    "(413) Request entity too large. Either a 'page' parameter is over 100 or a 'limit' parameter is over 10,000; reduce accordingly."); }
            },
            {
                (HttpStatusCode) 429,
                () => { throw new HttpRequestException("(429) Rate limit exceeded. Try again after rate limit period renews."); }
            }
        };

        public T Post<T>(Uri queryUri, string content)
        {
            var result = PostAsync(queryUri, new StringContent(content)).ContinueWith(
                response => JsonConvert.DeserializeObject<T>(response.Result.Content.ReadAsStringAsync().Result));
            return result.Result;
        }

        public T Get<T>(Uri queryUri)
        {
            var result = TryGetWithRetryAsync(queryUri).ContinueWith(
                response => JsonConvert.DeserializeObject<T>(response.Result.Content.ReadAsStringAsync().Result));
            return result.Result;
        }

        public Task<HttpResponseMessage> TryGetWithRetryAsync(Uri uri)
        {
            var attempts = 0;
            const int maxAttempts = 3;
            while (attempts < maxAttempts)
            {
                try
                {
                    return GetAsync(uri).ContinueWith(
                        response =>
                        {
                            var statusCode = response.Result.StatusCode;
                            if (statusCode.Equals(HttpStatusCode.OK)) return response;
                            if (_knownHttpStatusErrors[statusCode] != null) _knownHttpStatusErrors[statusCode]();
                            if (ApiFailure(statusCode)) throw new CleverApiHttpRequestException("(500-503) Api Error"); // clever says retry on 500 error codes
                            throw new HttpRequestException(string.Format("({0}) Unknown exception.", statusCode));
                        }).Unwrap();

                }
                catch (CleverApiHttpRequestException)
                {
                    attempts++;
                    if (attempts == maxAttempts)
                        throw new HttpRequestException("(500-503) Api Error, max retries attempted");
                }
            }
            throw new ApplicationException("Unknown error."); // eek
        }

        private  bool ApiFailure(HttpStatusCode statusCode)
        {
            return (int)statusCode >= 500 && (int)statusCode < 600;
        }
    }
}