using System.Collections.Generic;
using System.Threading.Tasks;
using Apox.Models;

namespace Datastore.Abstractions
{
    public interface IProductsRepository : IRepository<object>
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int Id);
        Task<int> AddProduct(Product product);
        Task UpdateProduct(int Id, Product product);
        Task DeleteProduct(int Id);

    }
}
