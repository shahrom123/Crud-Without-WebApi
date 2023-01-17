
using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infrastructure.Services
{

   public class CustomerService 
   {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=hometask ;User Id=postgres;Password=233223;";

        public List<Customer> GetCutomer()
        {
             using (var connection = new NpgsqlConnection(_connectionString))
             {
                 string sql = "SELECT * FROM Customers";
                 var result = connection.Query<Customer>(sql);
                 return result.ToList(); 
             }
        }
        public bool AddCustomer(Customer customer)
        {

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" insert into Customers(id, FirstName)" +
                    $"values ({customer.Id}, '{customer.firstName}')";
                var added = connection.Execute(sql);
                if (added > 0) return true;
                else return false;
            }
        }
        public bool UpdateCustomer(Customer customer)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" update Customers set FirstName = '{customer.firstName}'," +
                    $" where id = {customer.Id}";
                var updeted = connection.Execute(sql);
                if (updeted > 0) return true;
                else return false;
            }
        }
        public bool DeleteCustomer(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $" delete from Customers  where id = {id}";
                var deleted = connection.Execute(sql);
                if (deleted > 0) return true;
                else return false;
            }
        }
    }
}
