using System.Collections.Generic;
using WebApiDemo2.Domain;

namespace WebApiDemo2.Repository
{
    public interface IProductRepository
    {
        Product Add(Product product);
        bool Delete(int Id);
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Update(Product product);
    }
}