using System;
using System.Collections.Generic;
using System.Linq;
using clever_csharp.model;

namespace clever_csharp
{
    public class UrlUtils
    {
        private const string ApiUrl = "https://api.clever.com/v1.1";
        public static string MeApiUrl = "https://api.clever.com/me";
        public static string AuthTokensUrl = "https://clever.com/oauth/tokens";

        public static string Teachers = "teachers";
        public static string Students = "students";
        public static string Districts = "districts";
        public static string Schools = "schools";
        public static string District = "district";
        
        public static string AddQueryParams(IEnumerable<ApiParam> parameters)
        {
            return parameters == null ? string.Empty
                                : "?" + parameters.Aggregate(string.Empty, (current, parameter) => current + (parameter.Key + "=" + parameter.Value + "&").TrimEnd('&'));
        }

        public static Uri UriMaker(IEnumerable<ApiParam> queryParams = null , params string[] segments)
        {
            return new Uri(string.Format("{0}/{1}{2}", ApiUrl, String.Join("/", segments), AddQueryParams(queryParams)));
        }
    }
}