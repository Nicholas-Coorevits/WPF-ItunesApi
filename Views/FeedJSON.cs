using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ItunesApi.Views.ResultsJSON;

namespace ItunesApi.Views
{
    public class FeedJSON
    {
        public string title { get; set; }
        public string copyright { get; set; }
        public string country { get; set; }
        public string icon { get; set; }
        public string updated { get; set; }
        public List<Results> results { get; set; }

    }
}