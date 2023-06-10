using application.Contracts.Repositories;
using infrastructure.DbContext;

namespace infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly RestDbContext _context;

    public UnitOfWork(RestDbContext context)
    {
        _context = context;
        DoctorRepository = new DoctorRepository(_context);
    }
    public IDoctorRepository DoctorRepository { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context?.Dispose();
        }
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}