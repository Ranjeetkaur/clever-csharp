using System.Linq;
using System.Web;

namespace clever_csharp.model
{
    public class ApiParam
    {
        private readonly string _key;
        private readonly string _value;

        public string Key
        {
            get { return _key; }
        }

        public string Value
        {
            get { return _value; }
        }

        public ApiParam()
        {

        }

        public ApiParam(string key, int value)
        {
            _key = key;
            _value = value.ToString();
        }

        public ApiParam(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public ApiParam(string key, bool value)
        {
            _key = key;
            _value = value.ToString();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_value))
            {
                return string.Empty;
            }
            return HttpUtility.UrlEncode(_key) + "=" + HttpUtility.UrlEncode(_value);
        }
    }

    public class ApiParamArray : ApiParam
    {
        private readonly string _key;
        private readonly string[] _values;

        public ApiParamArray(string key, string[] values)
        {
            _key = key;
            _values = values;
        }

        public override string ToString()
        {
            var encodedKey = HttpUtility.UrlEncode(_key);
            var valuesEncoded = (from v in _values select HttpUtility.UrlEncode(v)).ToArray();
            var output = encodedKey + "=" + valuesEncoded.Aggregate((working, next) => working + "&" + encodedKey + "=" + next);
            return output;
        }
    }
}