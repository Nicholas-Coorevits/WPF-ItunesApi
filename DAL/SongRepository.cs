using Dapper;
using ItunesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItunesApi.DAL
{
    class SongRepository : SqlLiteRepository
    {
        public SongRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }
        public int InsertSong(SongModel song)
        {
            string sql = "INSERT INTO Song (Artist, Song) Values (@Artist, @Song);";

            using (var connection = DbConnection())
            {
                connection.Open();
                return connection.Execute(sql, song);
            }
        }

        public IEnumerable<SongModel> DeleteSongs()
        {
            string sql = "DELETE FROM Song;";

            using (var connection = DbConnection())
            {
                return connection.Query<SongModel>(sql);
            }
        }

        public IEnumerable<SongModel> GetSongs()
        {
            string sql = "SELECT * FROM Song;";

            using (var connection = DbConnection())
            {
                return connection.Query<SongModel>(sql);
            }
        }

    }
}
