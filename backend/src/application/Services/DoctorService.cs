using application.Contracts.Repositories;
using application.Dto;
using application.Exceptions;
using AutoMapper;
using core.Entities;

namespace application.Services;

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BaseDoctorDto>> GetAllAsync()
    {
        var doctors = await _unitOfWork.DoctorRepository
            .GetAllAsync(includeProperties: "Address");

        var doctorsDto = _mapper.Map<List<BaseDoctorDto>>(doctors);

        return doctorsDto;
    }

    public async Task<BaseDoctorDto> GetByIdAsync(int id)
    {
        var doctor = await _unitOfWork.DoctorRepository
            .GetAsync(d => d.Id == id, "Address");

        if (doctor is null) throw new NotFoundApiException(nameof(BaseDoctorDto), id.ToString());

        var doctorDto = _mapper.Map<BaseDoctorDto>(doctor);

        return doctorDto;

    }

    public async Task<(int, CreateDoctorDto)> CreateAsync(CreateDoctorDto dto)
    {
        var doctor = _mapper.Map<Doctor>(dto);

        await _unitOfWork.DoctorRepository.AddAsync(doctor);
        await _unitOfWork.SaveAsync();

        var createdDoctor = _mapper.Map<CreateDoctorDto>(doctor);

        return (doctor.Id, createdDoctor);
    }

    public async Task UpdateAsync(int id, CreateDoctorDto dto)
    {
        var doctorToUpdate = await _unitOfWork.DoctorRepository.GetAsync(id) ?? throw new NotFoundApiException(nameof(CreateDoctorDto), id.ToString());

        _mapper.Map(dto, doctorToUpdate);
        _unitOfWork.DoctorRepository.Modify(doctorToUpdate);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var doctorToDelete = await _unitOfWork.DoctorRepository.GetAsync(id) ?? throw new NotFoundApiException("Wrong doctor id!");

        _unitOfWork.DoctorRepository.Remove(doctorToDelete);
        await _unitOfWork.SaveAsync();
    }
}