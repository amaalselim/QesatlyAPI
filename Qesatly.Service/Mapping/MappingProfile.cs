using AutoMapper;
using Qesatly.Data.Entities;
using Qesatly.Service.DTO;

namespace Qesatly.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddClientDto, Clients>()
                .ForMember(dest => dest.Cardphoto, opt => opt.Ignore())
                .ForMember(dest => dest.guarantorCardphoto, opt => opt.Ignore());

            CreateMap<AddProductDto, Products>();

        }
    }
}
