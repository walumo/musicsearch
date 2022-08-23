using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using musicsearch.Http;

namespace musicsearch.Models
{
    public class DataModel
    {
        public string ArtistinNimi { get; set; }
        public string BiisinNimi { get; set; }
        public string Image { get; set; }
        public bool Hotti { get; set; } 
        public int JulkaisuVuosi { get; set; }


        public static string setNewObj()
        {
           
            var result = api.GetGeniusAsync();

            List<DataModel> Geniuslist = new List<DataModel>();

            for (int i = 0; i < 1; i++)
            {
                DataModel newOlio = new DataModel();
                newOlio.ArtistinNimi = result.Result.response.hits[i].result.artist_names; //exception jos on tuloksia alle 5 tai 0
                newOlio.BiisinNimi = result.Result.response.hits[i].result.title;
                newOlio.Image = result.Result.response.hits[i].result.header_image_url;
                newOlio.Hotti = result.Result.response.hits[i].result.stats.hot;
                newOlio.JulkaisuVuosi = result.Result.response.hits[i].result.release_date_components.year; //exception jos on null

                Geniuslist.Add(newOlio);
            }
            return JsonSerializer.Serialize(Geniuslist);
        }
    }

    public class SpotifyDataModel
    {
        public string artisti { get; set; } //artists nimellä löytyy jsonista
        public string biisinimi { get; set; }
        public string biisilinkki { get; set; } 
        public string albumi { get; set; } //name sisältö on albumin nimi
    }
}

    

