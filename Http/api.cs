using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace musicsearch.Http
{
    public static class api
    {
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
