using Entities.DTO.Parameters;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Logic.DataTransformation.Parameters
{
    public interface IProductCSVLogic
    {
        Task<byte[]> GetAllCSVAsync();
        Task AddFromCSVAsync(Stream stream);
        Task UpdateFromCSVAsync(Stream stream);
    }
}
