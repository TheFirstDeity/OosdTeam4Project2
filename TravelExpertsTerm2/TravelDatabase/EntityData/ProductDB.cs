using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDatabase.EntityProviders;
using System.Data.SqlClient;
using System.Data;

namespace TravelDatabase.EntityData
{
    [Ej]
    public class ProductDB 
    {
        //My default connection string method to allow connection to the database . having problems with the TravelDb connection 
       /*
          *************** Note **********************
             made all my method static because i was calling them on the product form
             and also remove the interface inheritance method from the ProductDB to make my coding easy

       */
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=localhost\\SAIT;Initial Catalog=TravelExperts;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        // insert method to and new record to the database
        public static bool AddEntity(Product entity)
        {
            SqlConnection connection = GetConnection();
            string selectStatement = "set identity_insert Products on INSERT into Products(ProductId,ProdName) values (@ProductId,@ProdName) set identity_insert Products off";
            SqlCommand insertCommand = new SqlCommand(selectStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductId", entity.ProductId);
            insertCommand.Parameters.AddWithValue("@ProdName", entity.Name);
            try
            {
                connection.Open();
                int count;
                count = insertCommand.ExecuteNonQuery();
                if (count > 0)
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
        // check if productId exist in other tables
        public static bool checkIfItExist(Product entity)
        {
            SqlConnection connection = GetConnection();
            string checkStatement = "select productId from Products_Suppliers where Products_Suppliers.ProductId = @productId ";
            SqlCommand checkCommand = new SqlCommand(checkStatement, connection);
            checkCommand.Parameters.AddWithValue("@productId", entity.ProductId);
            try
            {
                connection.Open();
                
                SqlDataReader reader = checkCommand.ExecuteReader();
                
                if (reader.Read())
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
        // Delete method to remove product from the database
        public static bool DeleteEntity(Product entity)
        {
            SqlConnection connection = GetConnection();
            string deleteStatement = "Delete from Products where ProductId = @ProductId "; 
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductId", entity.ProductId);
            try
            {
                connection.Open();
                int check = deleteCommand.ExecuteNonQuery();
                if (check > 0)
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
       
        public List<Product> GetEntities()
        {
            throw new NotImplementedException();
        }
        // method to get product by their product Id. never used it though
         public static  Product GetEntityById(int id)
        {
            SqlConnection connection = GetConnection();
            string selectStatement = "select ProductId, ProdName from Products where ProductId = @ProductId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", id);
            try
            {
                connection.Open();
                SqlDataReader prodReader = selectCommand.ExecuteReader();
                if (prodReader.Read())
                {
                    Product prod = new Product();
                    prod.ProductId = (int)prodReader["ProductId"];
                    prod.Name = prodReader["ProdName"].ToString();
                    return prod;
                }
                else
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
        // update method 
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            SqlConnection connection = GetConnection();
            string updateStatement = "Update Products SET ProdName = @newProdName where ProductId = @ProductId AND ProdName = @oldProdName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@newProdName", newProduct.Name);
            updateCommand.Parameters.AddWithValue("@ProductId", oldProduct.ProductId);
            updateCommand.Parameters.AddWithValue("@oldProdName", oldProduct.Name);
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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
        // method to create a list of product
        public static List<Product> GetProducts()
        {
           
            SqlConnection connection = new SqlConnection();
                connection = GetConnection();
            List<Product> products = new List<Product>();
            Product prod;
            
            String selectStatement = "SELECT ProdName , ProductId from Products ORDER BY ProdName ";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection) ;
            try
            {
              
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader
                           (CommandBehavior.CloseConnection);
                while (reader.Read()) // while there is data in the reader
                {
                    prod = new Product(); // create a new product
                    prod.Name = reader["ProdName"].ToString();
                    prod.ProductId = (int)reader["productId"];
                    products.Add(prod);
                }
                reader.Close(); // closes the connection as well
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return products;
        }


    }
}
