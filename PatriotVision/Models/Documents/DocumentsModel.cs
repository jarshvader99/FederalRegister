using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotVision.Models.Documents
{

    public class DocumentsModel
    {
        public int count { get; set; }
        public string description { get; set; }
        public int total_pages { get; set; }
        public string next_page_url { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string title { get; set; }
        public string type { get; set; }
        [JsonProperty("abstract")]
        public string _abstract { get; set; }
        public string document_number { get; set; }
        public string html_url { get; set; }
        public string pdf_url { get; set; }
        public string public_inspection_pdf_url { get; set; }
        public string publication_date { get; set; }
        public Agency[] agencies { get; set; }
        public string excerpts { get; set; }
    }

    public class Agency
    {
        public string raw_name { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string url { get; set; }
        public string json_url { get; set; }
        public int? parent_id { get; set; }
        public string slug { get; set; }
    }

}
