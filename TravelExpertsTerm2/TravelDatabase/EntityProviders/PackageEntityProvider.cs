// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace TravelDatabase.EntityProviders
{
    [Devin]
    [PublicAPI]
    public sealed class PackageEntityProvider : EntityProviderBase<Package>
    {
        // TODO: EntityProviders need a clean up, need to use the new diagnostic helper function things

        #region Constructors

        /// <summary>
        /// Access instance through <see cref="Database.Packages"/>
        /// </summary>
        internal PackageEntityProvider()
        {
        }

        #endregion

        #region Public Methods

        public IEnumerable<Package> GetEntitiesWithChildren()
        {
            using (var conn = Database.GetConnection())
            {
                var packages = new List<Package>();

                conn.Open();
                using (var reader = CreateSqlCommand($"SELECT * FROM {TableName}", conn).ExecuteReader())
                {
                    while (reader.Read()) packages.Add(ParsePackage(reader));
                }

                foreach (var package in packages)
                {
                    package.ProductSuppliers.AddRange(GetProductSuppliersRelatedToId(conn, package.PackageId));
                }

                return packages;
            }
        }

        public Package GetEntityByIdWithChildren(int id)
        {
            using (var conn = Database.GetConnection())
            {
                Package package;
                conn.Open();
                using (var reader = CreateSqlCommand($"SELECT * FROM {TableName} WHERE PackageId={id}", conn).ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    package = ParsePackage(reader);
                }

                package.ProductSuppliers.AddRange(GetProductSuppliersRelatedToId(conn, id));
                return package;
            }
        }

        #endregion

        #region EntityProviderBase<Package>

        protected override string TableName => "Packages";

        protected override Package Get(SqlConnection conn, int id)
        {
            Package package;
            using (var reader = CreateSqlCommand($"SELECT * FROM {TableName} WHERE PackageId={id}", conn).ExecuteReader())
            {
                if (!reader.Read()) return null;
                package = ParsePackage(reader);
            }
            return package;
        }

        protected override IEnumerable<Package> GetAll(SqlConnection conn)
        {
            var packages = new List<Package>();

            using (var reader = CreateSqlCommand($"SELECT * FROM {TableName}", conn).ExecuteReader())
            {
                while (reader.Read()) packages.Add(ParsePackage(reader));
            }
            
            return packages;
        }

        protected override int Add(SqlConnection conn, Package entity)
        {
            var sql = $"INSERT INTO {TableName} VALUES (@Name, @StartDate, @EndDate, @Description, @BasePrice, @AgencyCommission)";
            var rowsAffected = ExecuteNonQuery(sql, conn,
                new KeyValuePair<string, object>("Name", entity.Name),
                new KeyValuePair<string, object>("StartDate", entity.StartDate),
                new KeyValuePair<string, object>("EndDate", entity.EndDate),
                new KeyValuePair<string, object>("Description", entity.Description),
                new KeyValuePair<string, object>("BasePrice", entity.BasePrice),
                new KeyValuePair<string, object>("AgencyCommission", entity.AgencyCommission)
                );

            if (rowsAffected < 1) return int.MinValue; // return negative if the command failed

            var packageId = Database.GetLastAssignedId(conn, TableName); // id of the item just added

            // If the package has ProductSuppliers, relate them (in Packages_Products_Suppliers)
            if (entity.ProductSuppliers.Count > 0) ReplaceProductSupplierRelations(conn, entity, packageId);
            return packageId; // return the id of the item just added
        }

        protected override bool Delete(SqlConnection conn, Package entity)
        {
            // replace related Packages_Products_Suppliers entries from an empty list (removes them)
            entity.ProductSuppliers.Clear();
            ReplaceProductSupplierRelations(conn, entity);

            //new SqlCommand($"DELETE FROM Packages_Products_Suppliers WHERE PackageId={entity.PackageId}", conn).ExecuteNonQuery();
            return DeleteById(entity.PackageId, "PackageId", conn);
        }


        protected override bool Update(SqlConnection conn, Package entity)
        {
            ReplaceProductSupplierRelations(conn, entity);

            var sql =
                $"UPDATE {TableName} SET PkgName=@PkgName,PkgStartDate=@PkgStartDate,PkgEndDate=@PkgEndDate,PkgDesc=@PkgDesc,PkgBasePrice=@PkgBasePrice,PkgAgencyCommission=@PkgAgencyCommission WHERE PackageId=@PackageId";
            return ExecuteNonQuery(sql, conn,
                new KeyValuePair<string, object>("PkgName", entity.Name),
                new KeyValuePair<string, object>("PkgStartDate", entity.StartDate),
                new KeyValuePair<string, object>("PkgEndDate", entity.EndDate),
                new KeyValuePair<string, object>("PkgDesc", entity.Description),
                new KeyValuePair<string, object>("PkgBasePrice", entity.BasePrice),
                new KeyValuePair<string, object>("PkgAgencyCommission", entity.AgencyCommission),
                new KeyValuePair<string, object>("PackageId", entity.PackageId)
                ) > 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Deletes relations in Packages_Products_Suppliers relating to a particular package, and add them again.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="entity"></param>
        /// <param name="packageId">Package ID to use, if different from the one in <paramref name="entity"/></param>
        /// <returns>Rows affected</returns>
        private int ReplaceProductSupplierRelations(
            SqlConnection conn, 
            Package entity,
            int packageId = int.MinValue)
        {
            // Build a sequence of commands to relate products to suppliers in Packages_Products_Suppliers
            if (packageId == int.MinValue) packageId = entity.PackageId;
            var sqlLines = entity.ProductSuppliers
                .Select(
                    ps => $"INSERT INTO Packages_Products_Suppliers VALUES ({packageId}, {ps.ProductSupplierId})")
                .ToArray();

            var sql = $"DELETE FROM Packages_Products_Suppliers WHERE PackageId={packageId}";
            if (sqlLines.Length > 0) sql += "; " + string.Join("; ", sqlLines);

            var affected = ExecuteNonQuery(sql, conn);
            Debug.Assert(sqlLines.Length <= affected,
                $"The number of rows affected ({affected}) is less than the number of INSERT commands ({sqlLines.Length}).");

            return affected;
        }

        //private int[] GetProductSupplierIdsRelatedToPackage(SqlConnection conn, int packageId)
        //{
        //    // Select ProductSupplier IDs linked to a particular Package in Packages_Products_Suppliers
        //    // (This query returns a count of the IDs in the first row, followed by the IDs.)
        //    var sql = "WITH ps_ids AS (SELECT ps.ProductSupplierId" +
        //              " FROM Packages_Products_Suppliers pps, Products_Suppliers ps" +
        //              " WHERE pps.ProductSupplierId = ps.ProductSupplierId" +
        //              $" AND pps.PackageId = {packageId})" +
        //              " SELECT COUNT(ProductSupplierId)AS 'CountThenIds' FROM ps_ids" +
        //              " UNION SELECT ProductSupplierId AS 'CountThenIds' FROM ps_ids";

        //    using (var reader = CreateSqlCommand(sql, conn).ExecuteReader())
        //    {
        //        if (!reader.Read()) throw new Exception("Cannot retrieve SQL result.");
        //        var resultCount = reader.GetInt32(0); // read result count
        //        var result = new int[resultCount]; // init array

        //        // read IDs into the array
        //        for (var i = 0; i < resultCount; i++)
        //        {
        //            if (!reader.Read()) throw new Exception("Cannot retrieve SQL result.");
        //            result[i] = reader.GetInt32(0);
        //        }

        //        if (reader.Read()) Debug.Fail("Not all SQL results were read");
        //        return result;
        //    }
        //}

        private IEnumerable<ProductSupplier> GetProductSuppliersRelatedToId(SqlConnection conn, int packageId)
        {
            // Select Product_Suppliers where they're linked to this package in Packages_Products_Suppliers 
            var sql = "SELECT ps.ProductSupplierId, p.ProductId, p.ProdName, s.SupplierId, s.SupName" +
                      " FROM Packages_Products_Suppliers pps, Products_Suppliers ps, Products p, Suppliers s" +
                      " WHERE pps.ProductSupplierId=ps.ProductSupplierId AND ps.ProductId=p.ProductId AND ps.SupplierId=s.SupplierId" +
                      $" AND pps.PackageId={packageId}";

            var result = new List<ProductSupplier>();
            using (var reader = new SqlCommand(sql, conn).ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(ProductSupplierEntityProvider.ParseProductSupplier(reader));
                }
            }
            return result;
        }

        private static Package ParsePackage(SqlDataReader reader)
        {
            return new Package
            {
                PackageId = reader.GetInt32(0),
                Name = reader.GetString(1),
                StartDate = reader.GetDateTime(2),
                EndDate = reader.GetDateTime(3),
                Description = reader.GetString(4),
                BasePrice = reader.GetDecimal(5),
                AgencyCommission = reader.GetDecimal(6)
            };
        }

        #endregion

    }
}