using api.Entities;
using api.Repositories.Interfaces;

namespace api.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
    }
}
