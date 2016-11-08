// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using TravelDatabase.EntityProviders;

namespace TravelDatabase
{
    /// <summary>
    ///     Global database functions like creating connections.
    /// </summary>
    [Chad]
    [NoReorder]
    [PublicAPI]
    public static class Database
    {

        #region Public Connection String

        [Devin] public const string ConnectionStringFilePath = @"ConnectionString.txt";

        /// <summary>
        ///     Connection string used by all the database functions. Defaults to the first line
        ///     in the file <see cref="ConnectionStringFilePath" />, or null if the file doesn't exist.
        /// </summary>
        [Devin]
        [CanBeNull]
        public static string ConnectionString { get; set; } =
            File.Exists(ConnectionStringFilePath)
                ? File.ReadLines(ConnectionStringFilePath).FirstOrDefault()
                : null;

        #endregion

        #region Public Entity Providers

        /// <summary>
        /// Provides database operations for <see cref="Package"/> entities
        /// </summary>
        [Devin]
        [ProvidesContext]
        public static PackageEntityProvider Packages { get; }
            = new PackageEntityProvider();

        /// <summary>
        /// Provides database operations for <see cref="ProductSupplier"/> entities
        /// </summary>
        [Devin]
        [ProvidesContext]
        public static ProductSupplierEntityProvider ProductSuppliers { get; }
            = new ProductSupplierEntityProvider();

        /// <summary>
        /// Provides database operations for <see cref="Product"/> entities
        /// </summary>
        [Devin]
        [ProvidesContext]
        public static ProductEntityProvider Products { get; }
            = new ProductEntityProvider();

        /// <summary>
        /// Provides database operations for <see cref="Supplier"/> entities
        /// </summary>
        [Devin]
        [ProvidesContext]
        public static SupplierEntityProvider Suppliers { get; }
            = new SupplierEntityProvider();

        #endregion

        #region Internal Helpers

        /// <summary>
        /// Creates a new <see cref="SqlConnection"/> with <see cref="ConnectionStringFilePath"/>
        /// </summary>
        /// <returns>new <see cref="SqlConnection"/> instance</returns>
        [Devin]
        [Pure]
        [NotNull]
        internal static SqlConnection GetConnection()
        {
            if (ConnectionString == null)
                throw new InvalidOperationException($"Connection string is null. Check {ConnectionStringFilePath}");
            return new SqlConnection(ConnectionString);
        }

        // ----------- TODO: Helpers below here should probably be made protected members of EntityProviderBase

        /// <summary>
        /// Gets the last assigned key on a table with an auto-incrementing primary key.
        /// May return incorrect results if other sessions are modifying data. 
        /// Throws an exception if the table doesn't exist.
        /// </summary>
        /// <param name="conn">An open <see cref="SqlConnection"/> object</param>
        /// <param name="tablename">Name of a database table</param>
        /// <returns>The last assigned key on a table with an auto-incrementing primary key</returns>
        [Devin]
        [Pure]
        [ContractAnnotation("conn:null=>halt; tablename:null=>halt")]
        internal static int GetLastAssignedId([NotNull] SqlConnection conn, [NotNull] string tablename)
        {
            if (conn == null) throw new ArgumentNullException(nameof(conn));
            if (tablename == null) throw new ArgumentNullException(nameof(tablename));
            return Convert.ToInt32(new SqlCommand($"SELECT IDENT_CURRENT('{tablename}')", conn).ExecuteScalar());
        }

        /// <summary>
        /// Gets the amount by which the primary key is incremented on a table with an auto-incrementing primary key.
        /// May return incorrect results if other sessions are modifying data. 
        /// Throws an exception if the table doesn't exist.
        /// </summary>
        /// <param name="conn">An open <see cref="SqlConnection"/> object</param>
        /// <param name="tablename">Name of a database table</param>
        /// <returns>The amount by which the primary key is incremented</returns>
        [Devin]
        [Pure]
        [ContractAnnotation("conn:null=>halt; tablename:null=>halt")]
        internal static int GetIdIncrementer([NotNull] SqlConnection conn, [NotNull] string tablename)
        {
            if (conn == null) throw new ArgumentNullException(nameof(conn));
            if (tablename == null) throw new ArgumentNullException(nameof(tablename));
            return Convert.ToInt32(new SqlCommand($"SELECT IDENT_INCR('{tablename}')", conn).ExecuteScalar());
        }

        /// <summary>
        /// Gets the next key assignable on a table with an auto-incrementing primary key.
        /// May return incorrect results if other sessions are modifying data. 
        /// Throws an exception if the table doesn't exist.
        /// Equal to <see cref="GetNextAssignedId"/> + <see cref="GetIdIncrementer"/>.
        /// </summary>
        /// <param name="conn">An open <see cref="SqlConnection"/> object</param>
        /// <param name="tablename">Name of a database table</param>
        /// <returns>The next assignable key on a table with an auto-incrementing primary key</returns>
        [Devin]
        [Pure]
        [ContractAnnotation("conn:null=>halt; tablename:null=>halt")]
        internal static int GetNextAssignedId([NotNull] SqlConnection conn, [NotNull] string tablename)
        {
            if (conn == null) throw new ArgumentNullException(nameof(conn));
            if (tablename == null) throw new ArgumentNullException(nameof(tablename));
            return Convert.ToInt32(new SqlCommand($"SELECT IDENT_CURRENT('{tablename}')+IDENT_INCR('{tablename}')", conn).ExecuteScalar());
        }

        //[Devin]
        //[Pure]
        //[ContractAnnotation("tablename:null=>halt")]
        //internal static string GetPrimaryKeyName([NotNull] string tablename, SqlConnection conn = null)
        //{
        //    if (tablename == null) throw new ArgumentNullException(nameof(tablename));
        //    const string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.Table_Constraints tc" +
        //                       " JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu ON tc.TABLE_NAME = kcu.TABLE_NAME AND tc.TABLE_SCHEMA = kcu.TABLE_SCHEMA AND tc.TABLE_CATALOG = kcu.TABLE_CATALOG AND tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME" +
        //                       " WHERE tc.TABLE_NAME=@TableName AND CONSTRAINT_TYPE='PRIMARY KEY'";

        //    Func<SqlConnection, string> executeSql = (c) =>
        //     {
        //         var command = new SqlCommand(sql, c);
        //         command.Parameters.AddWithValue("TableName", tablename);
        //         return (string)command.ExecuteScalar();
        //     };

        //    if (conn != null) return executeSql(conn);
        //    using (var c = GetConnection())
        //    {
        //        return executeSql(c);
        //    }
        //}

        #endregion

        #region Diagnostics

        [Devin]
        [Pure]
        internal static SqlCommand DebuggerLogCommand(SqlCommand command, bool verbose = false) 
            => DebuggerLogCommand(command, null, verbose);

        [Devin]
        [Pure]
        internal static SqlCommand DebuggerLogCommand(SqlCommand command, object source, bool verbose = false)
        {
            #if !DEBUG
            return command; // if Release, don't log any SQL queries or security sensitive information
            #else

            const string category = "Database";
            var src = 
                source == null 
                ? string.Empty 
                : source is string 
                    ? $" of {source}" 
                    : $" of {source.GetType().Name}";

            if (command == null)
            {
                Debug.WriteLine($"Error, {nameof(SqlCommand)}{src} is null", category);
            }
            else
            {
                Debug.WriteLineIf(verbose, string.Empty, category);
                Debug.WriteLineIf(verbose, $"{DateTime.Now.ToLongTimeString()} ----- New Database Operation{src}", category);
                Debug.WriteLineIf(verbose, $"Connection String{src}: {command.Connection.ConnectionString}", category);
                var connected = (command.Connection.State & ConnectionState.Open) == ConnectionState.Open
                    ? "Connected"
                    : "Disconnected";
                Debug.WriteLine($"{nameof(SqlCommand)}{src} {connected} :: {command.CommandText}", category);
                Debug.WriteLineIf(verbose, string.Empty, category);


                // Event Handlers
                command.StatementCompleted +=
                        (sender, e) => Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} {nameof(SqlCommand)}{src} completed with {e.RecordCount} records", category);
                if (verbose) command.Disposed +=
                        (sender, e) => Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} {nameof(SqlCommand)}{src} Disposed", category);

                // Note: The connection's handlers may be added more than once if multiple command
                //       objects use the same connection. To avoid duplicate log entries, we remove
                //       the handler (if it exists) and then add it again.
                SqlInfoMessageEventHandler infoMessageHandler = (sender, e) => Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} {nameof(SqlConnection)}{src} Error, {e.Message}", category);
                command.Connection.InfoMessage -= infoMessageHandler;
                command.Connection.InfoMessage += infoMessageHandler;

                // ReSharper disable once InvertIf
                if (verbose)
                {
                    EventHandler disposedHandler = (sender, e) => Debug.WriteLine($"{DateTime.Now.ToLongTimeString()} {nameof(SqlConnection)}{src} Disposed", category);
                    command.Connection.Disposed -= disposedHandler;
                    command.Connection.Disposed += disposedHandler;
                }
            }

            return command;
            #endif
        }

#endregion

    }
}