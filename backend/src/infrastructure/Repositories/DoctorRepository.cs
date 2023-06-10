using application.Contracts.Repositories;
using core.Entities;

namespace infrastructure.Repositories;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
    {
    }
}