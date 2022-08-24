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

                string spotifyApiCallUrl = String.Format($"https://api.spotify.com/v1/search?q={0}%20{1}&type=track",
                    newOlio.ArtistinNimi.Trim().Replace(" ", "%20"),
                    newOlio.BiisinNimi.Trim().Replace(" ", "%20"));

                //https://api.spotify.com/v1/search?q=billie%20jean%20chris%20cornell&type=track

                SpotifyJSON spotifyData = await api.GetSpotifyAsync(spotifyApiCallUrl);

                newOlio.WebPlayerUrl = spotifyData.tracks.items[0].external_urls.spotify;
                newOlio.EmbedUri = spotifyData.tracks.items[0].uri;
                newOlio.Album = spotifyData.tracks.items[0].album.name;

                geniusList.Add(newOlio);
            }
            return JsonSerializer.Serialize(geniusList);
        }
    }

    //public class SpotifyDataModel
    //{
    //    public string WebPlayerUrl { get; set; }
    //    public string EmbedUri { get; set; }
    //    public string Album { get; set; }
    //}
}

    

