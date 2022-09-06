using Entities.Model.Common;
using Entities.Model.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Collections
{
    public interface IProductRepository
    {
        Task AddAsync(Product entity);
        Task AddManyAsync(List<Product> entity);
        Task UpdateAsync(Product entity);
        Task UpdateManyAsync(List<Product> entity);
        Task DeleteAsync(string id);
        Task<Product> GetByIdAsync(string id);
        Task<List<Product>> GetAllAsync();
    }
}
