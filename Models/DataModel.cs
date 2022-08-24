using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using musicsearch.Http;

namespace musicsearch.Models
{
    public class GeniusDataModel
    {
        public string ArtistinNimi { get; set; }
        public string BiisinNimi { get; set; }
        public string Image { get; set; }
        public bool Hotti { get; set; } 
        public int JulkaisuVuosi { get; set; }
        public string WebPlayerUrl { get; set; }
        public string EmbedUri { get; set; }
        public string Album { get; set; }



        public static async Task<string> setNewObj()
        {
           
            var result = api.GetGeniusAsync();

            List<GeniusDataModel> geniusList = new List<GeniusDataModel>();
            
            
            for (int i = 0; i < result.Result.response.hits.Length; i++)
            {
                GeniusDataModel newOlio = new GeniusDataModel();
                newOlio.ArtistinNimi = result.Result.response.hits[i].result.artist_names; //exception jos on tuloksia alle 5 tai 0
                newOlio.BiisinNimi = result.Result.response.hits[i].result.title;
                newOlio.Image = result.Result.response.hits[i].result.header_image_url;
                newOlio.Hotti = result.Result.response.hits[i].result.stats.hot;
                newOlio.JulkaisuVuosi = result.Result.response.hits[i].result.release_date_components.year; //exception jos on null

                geniusList.Add(newOlio);
            }


            return JsonSerializer.Serialize(geniusList);
        }

        public static async Task<string> appendObjectWithSpotifyData(List<GeniusDataModel> listFromGenius)
        {
            string test = default;
            foreach (GeniusDataModel item in listFromGenius)
            {
                string spotifyApiCallUrl = String.Format(@"api.spotify.com/v1/search?q=" +item.ArtistinNimi+ @"&type=track");

                SpotifyJSON spotifyData = await api.GetSpotifyAsync("https://api.spotify.com/v1/search?q=paranoid&type=track&limit=1");

                item.WebPlayerUrl = spotifyData.tracks.items[0].external_urls.spotify;
                item.EmbedUri = spotifyData.tracks.items[0].uri;
                item.Album = spotifyData.tracks.items[0].album.name;
            }
            return test;
        }
    }
}
    

