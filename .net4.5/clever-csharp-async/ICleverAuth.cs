using System.Threading.Tasks;

namespace clever_csharp_async
{
    public interface ICleverAuth
    {
        Task<string> Authenticate(string code);
    }
}