// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System.Collections.Generic;
using System.Data.SqlClient;

namespace TravelDatabase.EntityProviders
{
    [Devin]
    public sealed class SupplierEntityProvider : EntityProviderBase<Supplier>
    {
        /// <summary>
        /// Access instance through <see cref="Database.Products"/>
        /// </summary>
        internal SupplierEntityProvider()
        {
        }

        #region EntityProviderBase

        protected override string TableName => "Suppliers";

        protected override IEnumerable<Supplier> GetAll(SqlConnection conn)
        {
            using (var reader = new SqlCommand($"SELECT * FROM {TableName} ORDER BY SupplierId", conn).ExecuteReader())
            {
                var suppliers = new List<Supplier>();
                while (reader.Read()) suppliers.Add(ParseSupplier(reader));
                return suppliers;
            }
        }

        protected override Supplier Get(SqlConnection conn, int id)
        {
            //if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Cannot be less than zero");

            using (var reader = new SqlCommand($"SELECT * FROM {TableName} WHERE SupplierId={id}", conn).ExecuteReader())
            {
                return !reader.Read() ? null : ParseSupplier(reader);
            }
        }

        /// <remarks>
        /// ID must be set manually for new suppliers.
        /// </remarks>
        protected override int Add(SqlConnection conn, Supplier entity)
        {
            var command = new SqlCommand($"INSERT INTO {TableName} VALUES(@{C.SupplierId}, @{C.SupName})", conn);
            command.Parameters.AddWithValue(C.SupplierId, entity.SupplierId);
            command.Parameters.AddWithValue(C.SupName, entity.Name);

            if (command.ExecuteNonQuery() < 1) return int.MinValue; // return negative if the command failed
            return entity.SupplierId; // return the id of the item just added (suppliers set a specific ID)
        }

        protected override bool Delete(SqlConnection conn, Supplier entity)
            => DeleteById(entity.SupplierId, "SupplierId", conn);

        protected override bool Update(SqlConnection conn, Supplier entity)
        {
            return new SqlCommand(
                $"UPDATE {TableName} SET SupName='{entity.Name}' WHERE SupplierId={entity.SupplierId}", conn)
                .ExecuteNonQuery() > 0;
        }

        #endregion

        #region Private Methods

        private static Supplier ParseSupplier(SqlDataReader reader)
        {
            return new Supplier
            {
                SupplierId = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
        }

        #endregion

        #region Column Names

        /// <summary>
        /// Column names
        /// </summary>
        private static class C
        {
            public const string SupplierId = nameof(SupplierId);
            public const string SupName = nameof(SupName);
        }

        #endregion

    }
}
