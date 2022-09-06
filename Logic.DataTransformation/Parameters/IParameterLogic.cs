using Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.DataTransformation.Parameters
{
    public interface IParameterLogic<DTO>
        where DTO : class
    {
        Task AddAsync(DTO entity);
        Task UpdateAsync(DTO entity);
        Task DeleteAsync(string id);
        Task<DTO> GetByIdAsync(string id);
        Task<List<DTO>> GetAllAsync();
    }
}
