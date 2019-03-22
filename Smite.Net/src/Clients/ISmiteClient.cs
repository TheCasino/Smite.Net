using System.Threading.Tasks;

namespace Smite.Net
{
    public interface ISmiteClient
    {
        Task<string> PingAsync();
    }
}
