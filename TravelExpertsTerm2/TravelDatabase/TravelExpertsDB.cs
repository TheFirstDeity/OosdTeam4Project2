// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TravelDatabase
{
    /// <summary>
    ///     Global database functions like creating connections.
    /// </summary>
    [Chad]
    public static class TravelExpertsDB
    {
        [Devin]
        private const string ConnectionStringFilePath = "connectionString.txt";

        /// <summary>
        ///     Connection string used by all the database functions. Defaults to the first line 
        ///     in the file <see cref="ConnectionStringFilePath"/>, or null if the file doesn't exist.
        /// </summary>
        [Devin]
        [CanBeNull]
        public static string ConnectionString { get; set; } =
            File.Exists(ConnectionStringFilePath)
            ? File.ReadLines(ConnectionStringFilePath).FirstOrDefault()
            : null;

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString); //creates a new connection and returns it
            return connection;
        }
    }
}
