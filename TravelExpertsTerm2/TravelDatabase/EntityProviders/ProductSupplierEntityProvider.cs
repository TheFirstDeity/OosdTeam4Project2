// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace TravelDatabase.EntityProviders
{
    [Devin]
    public class ProductSupplierEntityProvider : EntityProviderBase<ProductSupplier>
    {
        private const string NullProductSupplierExceptionMessage =
            "Invalid object passed to database function. Properties cannot be null.";

        #region Internal Methods

        internal static ProductSupplier ParseProductSupplier(SqlDataReader reader)
        {
            return new ProductSupplier
            {
                ProductSupplierId = reader.GetInt32(0),
                Product = new Product
                {
                    ProductId = reader.GetInt32(1),
                    Name = reader.GetString(2)
                },
                Supplier = new Supplier()
                {
                    SupplierId = reader.GetInt32(3),
                    Name = reader.GetString(4)
                }
            };
        }

        #endregion

        #region EntityProviderBase<ProductSupplier>

        protected override string TableName => "Products_Suppliers";

        /// <summary>
        /// Get all <see cref="ProductSupplier"/> objects with their children
        /// </summary>
        /// <returns>All <see cref="ProductSupplier"/> objects with their children</returns>
        protected override IEnumerable<ProductSupplier> GetAll(SqlConnection conn)
        {
            var sql = 
                $"SELECT ps.{C.ProductSupplierId}, p.{C.ProductId}, p.{C.ProdName}, s.{C.SupplierId}, s.{C.SupName} " +
                $" FROM {TableName} ps, Products p, Suppliers s " +
                $" WHERE ps.{C.ProductId}=p.{C.ProductId} AND ps.{C.SupplierId}=s.{C.SupplierId} " +
                $" ORDER BY ps.{C.ProductSupplierId}";
            
            using (var reader = new SqlCommand(sql, conn).ExecuteReader())
            {
                
                var result = new List<ProductSupplier>();
                while (reader.Read()) result.Add(ParseProductSupplier(reader));
                return result;
            }
        }

        /// <summary>
        /// Get a specific <see cref="ProductSupplier"/> with its children
        /// </summary>
        /// <returns><see cref="ProductSupplier"/> with its children</returns>
        protected override ProductSupplier Get(SqlConnection conn, int id)
        {
            var sql =
                $"SELECT ps.{C.ProductSupplierId}, p.{C.ProductId}, p.{C.ProdName}, s.{C.SupplierId}, s.{C.SupName} " +
                $" FROM {TableName} ps, Products p, Suppliers s " +
                $" WHERE ps.{C.ProductSupplierId}={id} AND ps.{C.ProductId}=p.{C.ProductId} AND ps.{C.SupplierId}=s.{C.SupplierId} " +
                $" ORDER BY ps.{C.ProductSupplierId}";

            using (var reader = new SqlCommand(sql, conn).ExecuteReader())
            {
                return reader.Read() ? ParseProductSupplier(reader) : null;
            }
        }

        protected override bool Delete(SqlConnection conn, ProductSupplier entity)
        {
            var command = new SqlCommand($"DELETE FROM Packages_Products_Suppliers WHERE {C.ProductSupplierId}=@{C.ProductSupplierId}", conn);
            command.Parameters.AddWithValue($"{C.ProductSupplierId}", entity.ProductSupplierId);
            command.ExecuteNonQuery();

            return DeleteById(entity.ProductSupplierId, C.ProductSupplierId, conn);
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException", 
            Justification = "Wraps in InvalidOperationException and rethrows")]
        protected override int Add(SqlConnection conn, ProductSupplier entity)
        {
            var command = new SqlCommand($"INSERT INTO {TableName} VALUES(@{C.ProductId}, @{C.SupplierId})", conn);

            try
            {
                command.Parameters.AddWithValue(C.ProductId, entity.Product.ProductId);
                command.Parameters.AddWithValue(C.SupplierId, entity.Supplier.SupplierId);
            }
            catch (NullReferenceException exception)
            {
                throw new InvalidOperationException(NullProductSupplierExceptionMessage, exception);
            }
            
            return command.ExecuteNonQuery() > 0
                ? Database.GetLastAssignedId(conn, TableName)
                : int.MinValue;
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException",
            Justification = "Wraps in InvalidOperationException and rethrows")]
        protected override bool Update(SqlConnection conn, ProductSupplier entity)
        {
            var command = new SqlCommand($"UPDATE {TableName} SET {C.ProductId}=@{C.ProductId}, {C.SupplierId}=@{C.SupplierId}", conn);

            try
            {
                command.Parameters.AddWithValue(C.ProductId, entity.Product.ProductId);
                command.Parameters.AddWithValue(C.SupplierId, entity.Supplier.SupplierId);
            }
            catch (NullReferenceException exception)
            {
                throw new InvalidOperationException(NullProductSupplierExceptionMessage, exception);
            }

            return command.ExecuteNonQuery() > 0;
        }

        #endregion

        #region Column Names

        /// <summary>
        /// Column names
        /// </summary>
        private static class C
        {
            public const string ProductSupplierId = nameof(ProductSupplierId);
            public const string ProductId = nameof(ProductId);
            public const string SupplierId = nameof(SupplierId);
            public const string ProdName = nameof(ProdName);
            public const string SupName = nameof(SupName);
        }

        #endregion

    }
}
