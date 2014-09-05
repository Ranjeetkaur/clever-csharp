using System;

namespace clever_csharp_async.model
{
    public class CleverApiHttpRequestException : Exception
    {
        public CleverApiHttpRequestException(string msg) : base(msg) { }
    }
}