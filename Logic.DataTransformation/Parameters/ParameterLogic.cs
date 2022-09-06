using AutoMapper;
using Data.Repository;
using Data.Repository.Collections;
using Entities.Model.Common;
using Entities.Model.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.DataTransformation.Parameters
{
    public class ParameterLogic<DTO> : IParameterLogic<DTO>
        where DTO : class
    {
        protected readonly IProductRepository repository;
        protected readonly IMapper mapper;

        public ParameterLogic(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }   

        public async Task AddAsync(DTO entity)
        {
            Product parameter = mapper.Map<Product>(entity);
            await this.repository.AddAsync(parameter);
        }

        public async Task DeleteAsync(string id)
        {
            await this.repository.DeleteAsync(id);
        }

        public async Task<List<DTO>> GetAllAsync()
        {
            return mapper.Map<List<DTO>>(await this.repository.GetAllAsync());
        }

        public async Task<DTO> GetByIdAsync(string id)
        {
            return mapper.Map<DTO>(await this.repository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(DTO entity)
        {
            Product parameter = mapper.Map<Product>(entity);
            await this.repository.UpdateAsync(parameter);
        }
    }
}
