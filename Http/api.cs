﻿using IdentityModel.Client;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace musicsearch.Http
{
    public static class api
    {
        public static async Task<GeniusSongs> GetGeniusAsync()
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
                RequestUri = new Uri("https://api.genius.com/search?q=Viilt%C3%A4%C3%A4%20sanat%20syvemp%C3%A4%C3%A4n%20Ohi%20kiit%C3%A4%C3%A4%20tunnit%20kuin%20itsest%C3%A4%C3%A4n"),
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
                GeniusSongs result = JsonSerializer.Deserialize<GeniusSongs>(body);
                return result;
            }
        }

        
        public static async Task<string> GetSpotifyAsync(string uri)
        {
            var client = new HttpClient();
            var token = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://accounts.spotify.com/api/token",
                ClientId = "9ff81ac53e1a4aebbdaae52df059499a",
                ClientSecret = "dc34328e3a37437e87e010dd0c91d847",
                GrantType  = "client_credentials"
            });

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Headers = {{ "Authorization", $"Bearer {token.AccessToken}" }}
            };
            
            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                return token.AccessToken + body;
            }
        }
    }
}
