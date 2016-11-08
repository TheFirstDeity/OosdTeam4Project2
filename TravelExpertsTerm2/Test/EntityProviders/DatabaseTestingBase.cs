// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using TravelDatabase;

namespace Test.EntityProviders
{
    [Devin]
    public abstract class DatabaseTestingBase
    {
        /// <summary>
        /// Used to lock the test database for concurrent test execution
        /// </summary>
        protected static readonly object TestDatabaseLocker = new object();

        #region Test Database

        private const string ConnectionStringFilePath = @"TestDatabaseConnectionString.txt";

        /// <summary>
        ///     Connection string used by all the database functions. Defaults to the first line
        ///     in the file <see cref="ConnectionStringFilePath" />, or null if the file doesn't exist.
        /// </summary>
        [CanBeNull]
        private static string ConnectionString { get; } =
            File.Exists(ConnectionStringFilePath)
                ? File.ReadLines(ConnectionStringFilePath).FirstOrDefault()
                : null;

        protected DatabaseTestingBase()
        {
            if (ConnectionString == null)
                throw new InvalidOperationException(
                    $"No connection string for test database. Please create {ConnectionStringFilePath} in execution directory.");
            Database.ConnectionString = ConnectionString;
        }

        #endregion

        #region Protected Helpers

        protected int LastAddedIdentity(string tableName)
        {
            if (Database.ConnectionString == null)
                throw new InvalidOperationException($"{nameof(Database.ConnectionString)} is null");
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                using (var command = new SqlCommand($"SELECT IDENT_CURRENT('{tableName}')", conn))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        protected int NextAddedIdentity(string tableName)
        {
            if (Database.ConnectionString == null)
                throw new InvalidOperationException($"{nameof(Database.ConnectionString)} is null");
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                using (var command = new SqlCommand($"SELECT IDENT_CURRENT('{tableName}')+IDENT_INCR('{tableName}')", conn))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        #endregion

    }
}
