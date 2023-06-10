using api.DTOs;

namespace api.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<BaseDoctorDto>> GetAllAsync();
        Task<BaseDoctorDto> GetByIdAsync(int id);
        Task<(int, CreateDoctorDto)> CreateAsync(CreateDoctorDto dto);
        Task UpdateAsync(int id, CreateDoctorDto dto);
        Task DeleteAsync(int id);
    }
}
