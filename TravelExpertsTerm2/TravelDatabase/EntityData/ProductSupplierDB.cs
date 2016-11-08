// ReSharper disable All
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDatabase.EntityProviders;

namespace TravelDatabase.EntityData
{   [Chad]
    public class ProductSupplierDB
    {

    public static List<ProductSupplier> GetProductSuppliers()
    {
            List<ProductSupplier>ProdSupList = new List<ProductSupplier>();
            string connectionString = "Data Source=localhost\\SAIT;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT ProductSupplierId ,ps.ProductId as ProductId, ProdName, ps.SupplierId as SupplierId, SupName " +
                                    "FROM Products_Suppliers as ps " +
                                  "INNER JOIN Products as p ON p.ProductId = ps.ProductId " +
                                  "INNER JOIN Suppliers as s on s.SupplierId = ps.SupplierId " +
                                  "GROUP BY ProductSupplierId, ps.SupplierId, ps.ProductId, p.ProdName, s.SupName";
        SqlCommand selectCommand = new SqlCommand(selectStatement,connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                ProductSupplier productSupplier = new ProductSupplier();
                   Product product = new Product();
                Supplier supplier = new Supplier();
                productSupplier.ProductSupplierId = (int)reader["ProductSupplierId"];
                product.ProductId = (int) reader["ProductId"];
                    product.Name = (string)reader["ProdName"];
                supplier.SupplierId = (int) reader["SupplierId"];
                supplier.Name = (string) reader["SupName"];
                productSupplier.Product = product;
                productSupplier.Supplier = supplier;

                    ProdSupList.Add(productSupplier);
             }
            connection.Close();
            foreach (ProductSupplier ProdSup in ProdSupList)
            {
                ProdSup.Product = ProductDB.GetEntityById(ProdSup.Product.ProductId);
                ProdSup.Supplier = SupplierDB.GetSupplierByID(ProdSup.Supplier.SupplierId);
            }
        }
        catch (Exception)
        {
                
            throw;
        }
        return ProdSupList;
    } 

        public static ProductSupplier GetProductSupplierById(int productSupplierID)
        {
             int tempSupId;
            int tempProdId;

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT ProductSupplierId, ProductID,SupplierId " +
                "FROM Products_Suppliers " +
                "WHERE ProductSupplierId = @ProductSupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductSupplierId", productSupplierID);
            try
            {
                connection.Open();
                SqlDataReader Reader = selectCommand.ExecuteReader
                    (CommandBehavior.SingleRow); // selecting by PK value
                if (Reader.Read())
                {   // we have  a customer
                    ProductSupplier productSupplier = new ProductSupplier();
                    productSupplier.ProductSupplierId = (int)Reader["ProductSupplierId"];
                    tempSupId = (int)Reader["SupplierId"];
                    tempProdId = (int)Reader["ProductId"];

                    connection.Close();
                    productSupplier.Supplier = SupplierDB.GetSupplierByID(tempSupId);
                    productSupplier.Product = ProductDB.GetEntityById(tempSupId);

                    return productSupplier;
                }
                else // no customer
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // adds new customer record and returns the customer ID
        public static int AddProductSupplier(Product product, Supplier supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT INTO Products_Suppliers " +
                "(ProductId, SupplierId) " +
                "Values(@ProductId, @SupplierId)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductId", product.ProductId);
            insertCommand.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);

            try
            {
                connection.Open();
                int nr = insertCommand.ExecuteNonQuery();
                if (nr > 0) // success
                {
                    // find out what is the customer ID of the added record
                    string selectStatement = "SELECT IDENT_CURRENT('Products_Suppliers') " +
                                             "FROM Products_Suppliers";
                    SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                    int custID = Convert.ToInt32(selectCommand.ExecuteScalar());
                    return custID;
                }
                else // not added
                {
                    return -1;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }


        //DELETE
        public static string DeleteProductSupplier(int productSupplierId)
        {
            if (!CheckDependency(productSupplierId) && !CheckDependency2(productSupplierId))
            {
                SqlConnection connection = TravelExpertsDB.GetConnection();
                string deleteStatement =
                    "DELETE FROM Products_Suppliers " +
                    "WHERE ProductSupplierId = @ProductSupplierId ";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
                deleteCommand.Parameters.AddWithValue("@ProductSupplierId",productSupplierId);
                try
                {
                    connection.Open();
                    int count = deleteCommand.ExecuteNonQuery();
                    if (count > 0)
                        return "Delete Successful";
                    else
                        return "An error has occured during deletion, ensure you're connected to the server";
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                
            }
            return "This ProductSupplier exists in packages or invoices, you must remove it from all packages prior to deletion";
        }

        public static bool CheckDependency(int productSupplierId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT PackageId FROM Packages_Products_Suppliers  WHERE ProductSupplierId = @ProductSupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductSupplierID",productSupplierId);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read()) //while there is data
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public static bool CheckDependency2(int productSupplierId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT BookingDetailId FROM BookingDetails  WHERE ProductSupplierId = @ProductSupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductSupplierID", productSupplierId);

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read()) //while there is data
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
