using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItunesApi.DAL
{
    class SqlLiteRepository
    {
        public SqlLiteRepository()
        {
        }
        public static SqliteConnection DbConnection()
        {
            return new SqliteConnection(@"Data Source=SongDB.sqlite");
        }

        protected static bool DatabaseExists()
        {
            return File.Exists(@"SongDB.sqlite");
        }

        protected static void CreateDatabase()
        {
            using (var connection = DbConnection())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Song 
                    (
                    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                    Artist          VARCHAR(50),
                    Song            VARCHAR(100)
                    )");
            }
        }
    }
}
