using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotVision.Models.Agencies
{

    public class Logo
    {
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty("small_url")]
        public string SmallUrl { get; set; }

        [JsonProperty("medium_url")]
        public string MediumUrl { get; set; }
    }

    public class AgenciesModel
    {
        [JsonProperty("agency_url")]
        public string AgencyUrl { get; set; }

        [JsonProperty("child_ids")]
        public List<int> ChildIds { get; set; }

        [JsonProperty("child_slugs")]
        public List<string> ChildSlugs { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logo")]
        public Logo Logo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent_id")]
        public int? ParentId { get; set; }

        [JsonProperty("recent_articles_url")]
        public string RecentArticlesUrl { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("json_url")]
        public string JsonUrl { get; set; }
    }

}
