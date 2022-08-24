namespace musicsearch.Http
{

    public class GeniusJSON
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }

    public class Meta
    {
        public int status { get; set; }
    }

    public class Response
    {
        public Hit[] hits { get; set; }
    }

    public class Hit
    {
        public object[] highlights { get; set; }
        public string index { get; set; }
        public string type { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public int annotation_count { get; set; }
        public string api_path { get; set; }
        public string artist_names { get; set; }
        public string full_title { get; set; }
        public string header_image_thumbnail_url { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public int lyrics_owner_id { get; set; }
        public string lyrics_state { get; set; }
        public string path { get; set; }
        public int? pyongs_count { get; set; }
        public string relationships_index_url { get; set; }
        public Release_Date_Components release_date_components { get; set; }
        public string release_date_for_display { get; set; }
        public string song_art_image_thumbnail_url { get; set; }
        public string song_art_image_url { get; set; }
        public Stats stats { get; set; }
        public string title { get; set; }
        public string title_with_featured { get; set; }
        public string url { get; set; }
        public Featured_Artists[] featured_artists { get; set; }
        public Primary_Artist primary_artist { get; set; }
    }

    public class Release_Date_Components
    {
        public int? year { get; set; }
        public int? month { get; set; }
        public int? day { get; set; }
    }

    public class Stats
    {
        public int unreviewed_annotations { get; set; }
        public bool hot { get; set; }
        public int pageviews { get; set; }
    }

    public class Primary_Artist
    {
        public string api_path { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Featured_Artists
    {
        public string api_path { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}