// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using JetBrains.Annotations;

namespace TravelDatabase.EntityProviders
{
    /// <summary>
    /// Standard, boilerplate code for performing data operations. Creates and disposes of 
    /// connection and data-reader objects automatically, provides an API through inheritence 
    /// for implementing entity data operations with fewer lines of code.
    /// </summary>
    /// <typeparam name="TEntity">Entity Class</typeparam>
    [Devin]
    [PublicAPI]
    [NoReorder]
    public abstract class EntityProviderBase<TEntity> : IDataOperations<TEntity>
        where TEntity : class, new()
    {
        private const bool VerboseLogging = false;

        [NotNull]
        [ItemNotNull]
        protected abstract IEnumerable<TEntity> GetAll([NotNull]SqlConnection conn);

        [CanBeNull]
        protected abstract TEntity Get([NotNull]SqlConnection conn, int id);

        protected abstract bool Delete([NotNull]SqlConnection conn, [NotNull]TEntity entity);
        protected abstract int Add([NotNull]SqlConnection conn, [NotNull]TEntity entity);
        protected abstract bool Update([NotNull]SqlConnection conn, [NotNull]TEntity entity);

        [NotNull]
        protected abstract string TableName { get; }

        // Internal ctor to block inheretence outside of this assembly
        internal EntityProviderBase()
        {
        }

        #region DatabaseOperation Method

        [Pure]
        [ContractAnnotation("func:null=>halt")]
        protected TReturn DatabaseOperation<TReturn>(Func<SqlConnection, TReturn> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                return func(conn);
            }
        }

        [Pure]
        [ContractAnnotation("func:null=>halt")]
        protected TReturn DatabaseOperation<TReturn, TParam>(
            [NotNull] Func<SqlConnection, TParam, TReturn> func,
            TParam param)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                return func(conn, param);
            }
        }

        #endregion

        #region IDataOperations<TEntity>

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>Enumeration of entities</returns>
        [Pure]
        [NotNull]
        [ItemNotNull]
        public IEnumerable<TEntity> GetEntities() => DatabaseOperation(GetAll);

        /// <summary>
        /// Gets an entity with a particular ID, returns null if the entity doesn't exist.
        /// </summary>
        /// <param name="id">ID of the entity in the database</param>
        /// <returns>Entity with the corresponding <paramref name="id"/>, or null/></returns>
        [Pure]
        [CanBeNull]
        public TEntity GetEntityById(int id) => DatabaseOperation(Get, id);

        /// <summary>
        /// Deletes an entity. Returns true on success.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>true on success, false on failure</returns>
        [ContractAnnotation("entity:null=>halt")]
        public bool DeleteEntity([NotNull] TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            return DatabaseOperation(Delete, entity);
        }

        /// <summary>
        /// Adds an entity to the database. Returns the new item's ID, or negative on failure.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>The ID of the newly added entity, or negative on failure.</returns>
        [ContractAnnotation("entity:null=>halt")]
        public int AddEntity([NotNull] TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            return DatabaseOperation(Add, entity);
        }

        /// <summary>
        /// Updates an entity in the database. Returns true on success.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true on success, false on failure</returns>
        [ContractAnnotation("entity:null=>halt")]
        public bool UpdateEntity([NotNull] TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            return DatabaseOperation(Update, entity);
        }

        #endregion

        #region Protected Helpers

        [ContractAnnotation("idColumnName:null=>halt; conn:null=>halt")]
        protected bool DeleteById(int id, [NotNull]string idColumnName, [NotNull]SqlConnection conn)
        {
            if (idColumnName == null) throw new ArgumentNullException(nameof(idColumnName));
            var sql = $"DELETE FROM {TableName} WHERE {idColumnName}={id}";
            return ExecuteNonQuery(sql, conn) > 0; // success means 1 row was affected

            //return new SqlCommand(sql, conn).ExecuteNonQuery() > 0; // success means 1 row was affected
        }

        [Pure]
        [NotNull]
        [ContractAnnotation("cmdText:null=>halt; connection:null=>halt")]
        protected SqlCommand CreateSqlCommand(
            [NotNull] string cmdText, 
            [NotNull] SqlConnection connection)
        {
            if (cmdText == null) throw new ArgumentNullException(nameof(cmdText));
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            return Database.DebuggerLogCommand(
                new SqlCommand(cmdText, connection ?? Database.GetConnection()),
                this, VerboseLogging);
        }

        protected int ExecuteNonQuery(
            [NotNull] string sql, 
            [NotNull] SqlConnection conn,
            params KeyValuePair<string, object>[] bindingParams)
        {
            var command = CreateSqlCommand(sql, conn);
            foreach (var sqlParam in bindingParams)
                command.Parameters.AddWithValue(sqlParam.Key, sqlParam.Value);
            return command.ExecuteNonQuery();
        }

        #endregion

    }
}