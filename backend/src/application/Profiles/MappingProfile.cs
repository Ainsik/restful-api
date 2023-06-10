using application.Dto;
using AutoMapper;
using core.Entities;

namespace application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Doctor, BaseDoctorDto>()
            .ForMember(d => d.FullName, c => c.MapFrom(d => $"{d.FirstName} {d.LastName}"))
            .ForMember(d => d.City, c => c.MapFrom(d => d.Address.City))
            .ForMember(d => d.Street, c => c.MapFrom(d => d.Address.Street))
            .ForMember(d => d.PostalCode, c => c.MapFrom(d => d.Address.PostalCode));

        CreateMap<CreateDoctorDto, Doctor>().ReverseMap();
    }
}