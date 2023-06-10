using api.DTOs;
using api.Entities;
using AutoMapper;

namespace api.Profiles
{
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
}
