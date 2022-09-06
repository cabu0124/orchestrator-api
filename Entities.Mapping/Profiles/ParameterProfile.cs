using AutoMapper;
using DTO = Entities.DTO;
using Entities.Model.Parameters;

namespace Entities.Mapping.Profiles
{
    public class ParameterProfile : Profile
    {
        public ParameterProfile()
        {
            CreateMap<DTO.Parameters.ProductECM, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ProductType))
                .ForMember(dest => dest.AvailableInStock, opt => opt.MapFrom(src => src.ProductAvailableInStock))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductPrice));

            CreateMap<Product, DTO.Parameters.ProductECM>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.ProductAvailableInStock, opt => opt.MapFrom(src => src.AvailableInStock))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price));

            CreateMap<DTO.Parameters.ProductMKT, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.text))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.type))
                .ForMember(dest => dest.AvailableInStock, opt => opt.MapFrom(src => src.available_number))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.cost));

            CreateMap<Product, DTO.Parameters.ProductMKT>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.available_number, opt => opt.MapFrom(src => src.AvailableInStock))
                .ForMember(dest => dest.cost, opt => opt.MapFrom(src => src.Price));

            CreateMap<DTO.Common.UploadResult<DTO.Parameters.ProductCSV>, Product>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Data.id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Data.prod))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.Data.desc))
                .ForPath(dest => dest.Type, opt => opt.MapFrom(src => src.Data.type))
                .ForPath(dest => dest.AvailableInStock, opt => opt.MapFrom(src => src.Data.qty))
                .ForPath(dest => dest.Price, opt => opt.MapFrom(src => src.Data.value));

            CreateMap<Product, DTO.Common.UploadResult<DTO.Parameters.ProductCSV>>()
                .ForPath(dest => dest.Data.id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Data.prod, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Data.desc, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.Data.type, opt => opt.MapFrom(src => src.Type))
                .ForPath(dest => dest.Data.qty, opt => opt.MapFrom(src => src.AvailableInStock))
                .ForPath(dest => dest.Data.value, opt => opt.MapFrom(src => src.Price));

            CreateMap<DTO.Parameters.ProductCSV, Product>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.prod))
                .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.desc))
                .ForPath(dest => dest.Type, opt => opt.MapFrom(src => src.type))
                .ForPath(dest => dest.AvailableInStock, opt => opt.MapFrom(src => src.qty))
                .ForPath(dest => dest.Price, opt => opt.MapFrom(src => src.value));

            CreateMap<Product, DTO.Parameters.ProductCSV>()
                .ForPath(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.prod, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.desc, opt => opt.MapFrom(src => src.Description))
                .ForPath(dest => dest.type, opt => opt.MapFrom(src => src.Type))
                .ForPath(dest => dest.qty, opt => opt.MapFrom(src => src.AvailableInStock))
                .ForPath(dest => dest.value, opt => opt.MapFrom(src => src.Price));
        }
    }
}
