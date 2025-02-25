using AutoMapper;
using Kondor.Application.Common.Models;
using Kondor.Domain.Entities;

namespace Kondor.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DatabaseConnection, ConnectionDto>()
            .ForMember(dest => dest.ConnectionString, 
                opt => opt.MapFrom(src => src.ConnectionString.Value))
            .ForMember(dest => dest.Type, 
                opt => opt.MapFrom(src => src.Type.ToString()));
    }
}