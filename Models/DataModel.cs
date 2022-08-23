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

            List<DataModel> Geniuslist = new List<DataModel>
            {
                
            };

            for (int i = 0; i < 5; i++)
            {
                newOlio.ArtistinNimi = result.Result.response.hits[i].result.artist_names;
                newOlio.BiisinNimi = result.Result.response.hits[i].result.title;
                newOlio.Image = result.Result.response.hits[i].result.header_image_url;
                newOlio.Hotti = result.Result.response.hits[i].result.stats.hot;
                newOlio.JulkaisuVuosi = result.Result.response.hits[i].result.release_date_components.year;

                Geniuslist.Add(newOlio);
            }

            return JsonSerializer.Serialize(Geniuslist);
        }
    }
}

    

