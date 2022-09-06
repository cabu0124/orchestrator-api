using DTO = Entities.DTO.Parameters;
using Data.Repository.Collections;
using AutoMapper;

namespace Logic.DataTransformation.Parameters
{
    public class ProductMKTLogic : ParameterLogic<DTO.ProductMKT>, IProductMKTLogic
    {
        public ProductMKTLogic(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
