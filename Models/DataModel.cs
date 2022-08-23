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
            DataModel newOlio = new DataModel();
            var result = api.GetGeniusAsync();
            newOlio.ArtistinNimi = result.Result.response.hits[0].result.artist_names;
            newOlio.BiisinNimi = result.Result.response.hits[0].result.title;
            newOlio.Image = result.Result.response.hits[0].result.header_image_url;
            newOlio.Hotti = result.Result.response.hits[0].result.stats.hot;
            newOlio.JulkaisuVuosi = result.Result.response.hits[0].result.release_date_components.year;

            var tulos = $"{newOlio.ArtistinNimi}\n{newOlio.BiisinNimi}\n{newOlio.Image}\n{newOlio.Hotti}\n{newOlio.JulkaisuVuosi}";
            return tulos;
        }
    }

    
}
