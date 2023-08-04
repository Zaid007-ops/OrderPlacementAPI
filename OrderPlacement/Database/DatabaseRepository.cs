using Dapper;
using Newtonsoft.Json;
using OrderPlacement.Controllers;
using System.Data.SqlClient;

namespace OrderPlacement.Database
{
    public class DatabaseRepository
    {
        private string DatabaseConnection => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrdersDB;Integrated Security=True;Pooling=False";
        public List<Order> GetOrders()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection))
            {
                connection.Open();

                var query = "SELECT * FROM Orders";
                var Orders = connection.Query<Order>(query);

                connection.Close();
                return Orders.ToList();
            }
            return new List<Order>();
        }

        public void SaveToDatabase(PlaceOrderRequest request, Product product, int id)
        {
            using(SqlConnection connection = new SqlConnection(DatabaseConnection))
            {
                connection.Open();

                String query = "INSERT INTO Orders (id,Product,Customer,OrderDate) VALUES (@id, @product, @customer, @orderdate)";
                var command = new SqlCommand(query, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                command.Parameters.Add("@product", System.Data.SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(product);
                command.Parameters.Add("@customer", System.Data.SqlDbType.NVarChar).Value = JsonConvert.SerializeObject(request.Customer);
                command.Parameters.Add("@orderdate", System.Data.SqlDbType.DateTime).Value = DateTime.Now;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
