using AutoMapper;
using SeriesApp.Dtos;
using SeriesApp.Entities;

namespace SeriesApp;

public class SeriesAppApplicationAutoMapperProfile : Profile
{
    public SeriesAppApplicationAutoMapperProfile()
    {
        CreateMap<Serie, SeriesDto>();

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Password, opt => opt.Ignore()); // ⚠️ Ignoramos el campo sensible

        CreateMap<CreateUserInput, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore())
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}