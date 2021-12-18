using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItunesApi.Views
{
    public class ApiProcessor
    {
        public static string path = "https://rss.applemarketingtools.com/api/v2/be/music/most-played/10/songs.json";
        public static ObjectJSON getSongs()
        {

            using (WebClient client = new WebClient())
            {
                ObjectJSON json = JsonConvert.DeserializeObject<ObjectJSON>(client.DownloadString(path));
                
                return json;


            }
        }
    }
}