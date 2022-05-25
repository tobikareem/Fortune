
using Newtonsoft.Json;

namespace Core.Models
{

    public class TweetData
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Meta
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }

        [JsonProperty("newest_id")]
        public string NewestId { get; set; }

        [JsonProperty("oldest_id")]
        public string OldestId { get; set; }

        [JsonProperty("next_token")]
        public string NextToken { get; set; }
    }



}
