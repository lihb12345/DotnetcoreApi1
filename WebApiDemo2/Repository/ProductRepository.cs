using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo2.Domain;

namespace WebApiDemo2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionProvider _connectionProvider;
        public ProductRepository(IDbConnectionProvider connectionProvider)
        {
            this._connectionProvider = connectionProvider;
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                using (var conn = _connectionProvider.GetDatabaseConnection())
                {
                    var query = "SELECT *  FROM[WebApiDemo].[dbo].[Products]";
                    var products = conn.Query<Product>(query);
                    return products;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Product Add(Product product)
        {
            try
            {
                using (var conn = _connectionProvider.GetDatabaseConnection())
                {
                    var query = "Insert into Products values(@Name) select scope_identity()";
                    product.Id = conn.ExecuteScalar<int>(query, product);
                    //return conn.Execute(query, product) > 0;
                    return product;
                }
            }
            catch (Exception)
            { throw; }
        }

        public Product Update(Product product)
        {
            try
            {
                using (var conn = _connectionProvider.GetDatabaseConnection())
                {
                    var query = "Update Products set Name=@Name where Id=@Id";
                    conn.Execute(query, product);
                    return product;

                }
            }
            catch (Exception)
            { throw; }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (var conn = _connectionProvider.GetDatabaseConnection())
                {
                    var query = "delete Products where Id=@Id";
                    return conn.Execute(query, new { Id = Id }) > 0;
                }
            }
            catch (Exception)
            { throw; }
        }

        public Product Get(int id)
        {
            try
            {
                using (var conn = _connectionProvider.GetDatabaseConnection())
                {
                    var query = "SELECT *  FROM[WebApiDemo].[dbo].[Products] where Id=@Id";
                    var product = conn.QueryFirstOrDefault<Product>(query, new {Id=id });
                    return product;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

