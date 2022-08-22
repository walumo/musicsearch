using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace musicsearch.Http
{
    public static class api
    {
        public static async Task<string> GetGeniusAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://api.genius.com/search?q=finished%20with%20my%20woman"),
                Headers =
                    {
                        { "Authorization", "Bearer cSHsluz4Dz3jW1maa1FyhoFSFKmDrh2uZiEpFhyFIX2VUib6yQfyuLH5DpoVfvss" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        
        public static async Task<string> GetSpotifyAsync(string uri)
        {
            var clientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            };
            var client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers =
                    {
                        { "Authorization", "Bearer BQAVizlNnAgOTg2ZxcIMKVl2js0wMSxp5ics64r-xopbpvz6M9VbgOqR9Le5lAjh3LPYhqayrqPs11zZF8zOV5s1YuouTPZUyix4Vr2kIs7N-P-wpTU" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
