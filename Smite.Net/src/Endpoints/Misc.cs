using Smite.Net.ReadOnlyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var response = await _restClient.JsonlessMethodAsync("ping").ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Tests the current session.
        /// </summary>
        /// <returns>The response of the test.</returns>
        public async Task<string> TestSessionAsync()
        {
            var response = await _restClient.JsonlessMethodAsync("testsession").ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Gets your current API quota.
        /// </summary>
        /// <returns>Your current usage data.</returns>
        public async Task<DataUsed> GetDataUsedAsync()
        {
            var response = await GetAsync<DataUsedModel>(APIPlatform.PC, "getdataused").ConfigureAwait(false);

            return new DataUsed(response);
        }

        /// <summary>
        /// Gets the statuses of the servers.
        /// </summary>
        /// <returns>A dictionary of the server status of each platform.</returns>
        public async Task<IReadOnlyDictionary<APIPlatform, ServerStatus>> GetServerStatusesAsync()
        {
            var response = await GetCollectionAsync<ServerStatusModel>(APIPlatform.PC, "gethirezserverstatus", _currentSession)
                .ConfigureAwait(false);

            static APIPlatform GetPlatform(string input)
            {
                switch(input)
                {
                    case "xbox":
                        return APIPlatform.Xbox;

                    case "ps4":
                        return APIPlatform.PS4;

                    case "pc":
                        return APIPlatform.PC;
                }

                throw new ArgumentException("Unkown platform type.");
            }

            var dict = response.ToDictionary(x => GetPlatform(x.platform), x => new ServerStatus(x));

            return new ReadOnlyDictionary<APIPlatform, ServerStatus>(dict);
        }

        /// <summary>
        /// Gets the current patch number.
        /// </summary>
        /// <returns>The current patch number.</returns>
        public async Task<string> GetPatchNumberAsync()
        {
            var response = await GetAsync<PatchInfoModel>(APIPlatform.PC, "getpatchinfo", _currentSession)
                .ConfigureAwait(false);

            return response.version_string;
        }
    }
}
