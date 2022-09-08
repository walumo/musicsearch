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
        public string ReleaseYear { get; set; }
        public string WebPlayerUrl { get; set; }
        public string EmbedUri { get; set; }
        public string Album { get; set; }



        public static Task<string> GetAllDataAsStrincAsync(string searchString)
        {
            string blankSongImageUrl = "process.env.PUBLIC_URL + '/Resources/nocover.png'";
            string notAvailable = "N/A";
            var result = api.GetGeniusAsync(searchString);

            List<GeniusDataModel> geniusList = new List<GeniusDataModel>();


            for (int i = 0; i < result.Result.response.hits.Length; i++)
            {
                GeniusDataModel song = new GeniusDataModel();
                try
                {
                    song.Artist = result.Result.response.hits[i].result.artist_names;
                }
                catch (Exception)
                {
                    song.Artist = notAvailable;
                }
                try
                {
                    song.Track = result.Result.response.hits[i].result.title;
                }
                catch (Exception)
                {
                    song.Track = notAvailable;
                }
                try
                {
                    song.Image = result.Result.response.hits[i].result.header_image_url;
                }
                catch (Exception)
                {
                    song.Image = blankSongImageUrl;
                }
                try
                {
                    song.Hot = result.Result.response.hits[i].result.stats.hot;
                }
                catch (Exception)
                {
                    song.Hot = false;
                }
                try
                {
                    song.ReleaseYear = result.Result.response.hits[i].result.release_date_components.year.ToString();

                }
                catch (Exception)
                {
                    song.ReleaseYear = notAvailable;
                }
                geniusList.Add(song);
            }

            return Task.FromResult(JsonSerializer.Serialize(appendObjectWithSpotifyData(geniusList)));
        }

        public static async Task<List<GeniusDataModel>> appendObjectWithSpotifyData(List<GeniusDataModel> listFromGenius)
        {
            foreach (GeniusDataModel item in listFromGenius)
            {
                string spotifyWebPlayerLink = "https://open.spotify.com/";
                string notAvailable = "N/A";
                string playBlackSabbathParanoid = "spotify:track:1Y373MqadDRtclJNdnUXVc";
                string songQuery = item.Artist + " " + item.Track;
                Uri spotifyApiCallUrl = new Uri(@"https://api.spotify.com/v1/search?q=" + songQuery + @"&type=track&limit=1");
                
                SpotifyJSON spotifyData = await api.GetSpotifyAsync(spotifyApiCallUrl);

                try
                {
                    item.WebPlayerUrl = spotifyData.tracks.items[0].external_urls.spotify;
                }
                catch (Exception)
                {
                    item.WebPlayerUrl = spotifyWebPlayerLink;
                }
                try
                {
                    item.EmbedUri = spotifyData.tracks.items[0].uri;
                }
                catch (Exception)
                {
                    item.EmbedUri = playBlackSabbathParanoid;
                }
                try
                {
                    item.Album = spotifyData.tracks.items[0].album.name;

                }
                catch (Exception)
                {
                    item.Album = notAvailable;
                }            
            }
            return listFromGenius;
        }
    }
}