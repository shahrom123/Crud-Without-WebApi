
using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Services
{

    public class OrderService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=hometask ;User Id=postgres;Password=233223;";

        public List<Order> GetOrders()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Orders";
                var result = connection.Query<Order>(sql);
                return result.ToList();
            }
        }
        public bool AddOrders(Order order)
        {

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" insert into Orders(id, ProductId, CustomerId, CreatedAt, ProductCount, Price )" +
                    $"values ({order.Id}, {order.ProductId}, {order.CustomerId}, '{order.CreatedAt}', {order.ProductCount}, {order.Price})";
                var added = connection.Execute(sql);
                if (added > 0) return true;
                else return false;
            }
        }
        public bool UpdateOrders(Order order)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" update Orders set ProductId = {order.ProductId},CustomerId = {order.CustomerId}," +
                    $" CreatedAt = {order.CreatedAt}, ProductCount = {order.ProductCount}, Price = {order.Price}"+
                    $" where id = {order.Id}";
                var updeted = connection.Execute(sql);
                if (updeted > 0) return true; 
                else return false;
            }
        }
        public bool DeleteOrders(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" delete from Orders  where id = {id}";
                var deleted = connection.Execute(sql);
                if (deleted > 0) return true;
                else return false; 
            }
        }
    }
}
