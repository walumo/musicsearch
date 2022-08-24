using musicsearch.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace musicsearch.Models
{
    public class GeniusDataModel
    {
        public string Artist { get; set; }
        public string Track { get; set; }
        public string Image { get; set; }
        public bool Hot { get; set; }
        public int ReleaseYear { get; set; }
        public string WebPlayerUrl { get; set; }
        public string EmbedUri { get; set; }
        public string Album { get; set; }



        public static async Task<string> GetAllDataAsStrincAsync()
        {

            var result = api.GetGeniusAsync();

            List<GeniusDataModel> geniusList = new List<GeniusDataModel>();


            for (int i = 0; i < result.Result.response.hits.Length; i++)
            {
                GeniusDataModel newOlio = new GeniusDataModel();
                newOlio.Artist = result.Result.response.hits[i].result.artist_names;
                newOlio.Track = result.Result.response.hits[i].result.title;
                newOlio.Image = result.Result.response.hits[i].result.header_image_url;
                newOlio.Hot = result.Result.response.hits[i].result.stats.hot;
                newOlio.ReleaseYear = result.Result.response.hits[i].result.release_date_components.year; //exception jos on null

                geniusList.Add(newOlio);
            }

            return JsonSerializer.Serialize(appendObjectWithSpotifyData(geniusList));
        }

        public static async Task<List<GeniusDataModel>> appendObjectWithSpotifyData(List<GeniusDataModel> listFromGenius)
        {
            foreach (GeniusDataModel item in listFromGenius)
            {
                string songQuery = item.Artist + " " + item.Track;
                Uri spotifyApiCallUrl = new Uri(@"https://api.spotify.com/v1/search?q=" + songQuery + @"&type=track&limit=1");
                
                SpotifyJSON spotifyData = await api.GetSpotifyAsync(spotifyApiCallUrl);

                item.WebPlayerUrl = spotifyData.tracks.items[0].external_urls.spotify;
                item.EmbedUri = spotifyData.tracks.items[0].uri;
                item.Album = spotifyData.tracks.items[0].album.name;
            }
            return listFromGenius;
        }
    }
}