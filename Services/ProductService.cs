using Celestica.Models;
using Npgsql;
using System.Data;

namespace Celestica.Services
{
    public class ProductService
    {
        private readonly string _connectionString;

        public ProductService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ProductStatus> CheckProductStatusAsync(string productName, DateTime date)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (var cmd = new NpgsqlCommand("product", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_name", productName);
                    cmd.Parameters.AddWithValue("p_today", date.Date);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new ProductStatus()
                            {
                                Name = reader.GetString(0),
                                Aging = reader.GetInt64(1),
                                IsExpired = reader.GetBoolean(2),
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
