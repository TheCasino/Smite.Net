using System.Threading.Tasks;

namespace Smite.Net
{
    public partial class SmiteClient
    {
        /// <summary>
        /// Pings the API.
        /// </summary>
        /// <returns>The response of the ping.</returns>
        public async Task<string> PingAsync()
        {
            var response = await _restClient.PingAsync().ConfigureAwait(false);

            return response;
        }
    }
}
