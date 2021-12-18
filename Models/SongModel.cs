using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ItunesApi.Models
{
    class SongModel : IEquatable<SongModel>, IComparable<SongModel>
    {
        public string Artist { get; set; }
        public string Song { get; set; }

        public SongModel()
        {
        }

        public SongModel(string artist, string song)
        {
            Artist = artist;
            Song = song;
        }

        public override int GetHashCode()
        {
            return Song.GetHashCode();
        }

        public bool Equals(SongModel other)
        {
            return Song == other.Song;
        }

        public int CompareTo(SongModel other)
        {
            return Song.CompareTo(other.Song);
        }

    }
        
}

