using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItunesApi.Views
{
    public class ResultsJSON : FeedJSON
    {
        public class Results
        {
            public string artistName { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string releaseDate { get; set; }
            public string kind { get; set; }
            public string artistId { get; set; }
            public string artistUrl { get; set; }
            public string contentAdvisoryRating { get; set; }
            public string artworkUrl100 { get; set; }
            public string url { get; set; }

        }
    }
}
