﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace musicsearch.Http
{
    public static class api
    {
        public static async Task<string> GetGeniusAsync()
        {
            var clientHandler = new HttpClientHandler
            {
                UseCookies = false,
                AutomaticDecompression = DecompressionMethods.GZip,
            };
            var client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.genius.com/search?q=finished"),
                Headers =
                    {
                        { "cookie", "desired_location=https%253A%252F%252Fapi.genius.com%252Foauth%252Fauthorize; flash=%257B%257D; _csrf_token=0tyaBKoN382UVdHYzu5Ht2GXqDV%252BUvMP048zUmjMmlk%253D; _rapgenius_session=BAh7BzoPc2Vzc2lvbl9pZEkiJTFmNjNhNTYwMGEyZDE3MmFhNmVlZjUzMDFjZjJiZDk3BjoGRUY6EF9jc3JmX3Rva2VuSSIxMHR5YUJLb04zODJVVmRIWXp1NUh0MkdYcURWK1V2TVAwNDh6VW1qTW1saz0GOwZG--7d1a4faf0e4e4fc7c0b5ef2a5ffa3086143cf9d4; _genius_ab_test_cohort=30; _genius_ab_test_song_recommendations_v2=mixpanel" },
                        { "Authorization", "Bearer YATwllDTBMVuLsxnz4x7yHMJwLuMPIee2anG8GTmMvNILzdPVwyCcD8O25uvzN1T" },
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
