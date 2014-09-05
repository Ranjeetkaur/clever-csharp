using System;

namespace clever_csharp.model
{
    public class CleverApiHttpRequestException : Exception
    {
        public CleverApiHttpRequestException(string msg) : base(msg) { }
    }
}