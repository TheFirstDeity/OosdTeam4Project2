// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using JetBrains.Annotations;

namespace TravelDatabase.EntityProviders
{
    [Devin]
    [PublicAPI]
    public sealed class ProductEntityProvider : EntityProviderBase<Product>
    {

        /// <summary>
        /// Access instance through <see cref="Database.Products"/>
        /// </summary>
        internal ProductEntityProvider()
        {
        }

        #region EntityProviderBase

        protected override string TableName => "Products";

        protected override IEnumerable<Product> GetAll(SqlConnection conn)
        {
            using (var reader = new SqlCommand($"SELECT * FROM {TableName}", conn).ExecuteReader())
            {
                var products = new List<Product>();
                while (reader.Read()) products.Add(ParseProduct(reader));
                return products;
            }
        }

        protected override Product Get(SqlConnection conn, int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Cannot be less than zero");

            using (var reader = new SqlCommand($"SELECT * FROM {TableName} WHERE ProductId={id}", conn).ExecuteReader())
            {
                return !reader.Read() ? null : ParseProduct(reader);
            }
        }

        protected override int Add(SqlConnection conn, Product entity)
        {
            var rowsAffected = new SqlCommand($"INSERT INTO Products VALUES('{entity.Name}')", conn).ExecuteNonQuery();
            if (rowsAffected < 1) return int.MinValue; // return negative if the command failed
            return Database.GetLastAssignedId(conn, TableName); // return the id of the item just added
        }

        protected override bool Delete(SqlConnection conn, Product entity) 
            => DeleteById(entity.ProductId, "ProductId", conn);

        protected override bool Update(SqlConnection conn, Product entity)
        {
            return new SqlCommand(
                $"UPDATE Products SET ProdName='{entity.Name}' WHERE ProductId={entity.ProductId}", conn)
                .ExecuteNonQuery() > 0;
        }

        #endregion

        #region Private Methods

        private static Product ParseProduct(IDataRecord reader)
        {
            return new Product
            {
                ProductId = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
        }

        #endregion

    }
}