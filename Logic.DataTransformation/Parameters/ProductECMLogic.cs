using DTO = Entities.DTO.Parameters;
using Data.Repository.Collections;
using AutoMapper;

namespace Logic.DataTransformation.Parameters
{
    public class ProductECMLogic : ParameterLogic<DTO.ProductECM>, IProductECMLogic
    {
        public ProductECMLogic(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
