namespace application.Contracts.Repositories;

public interface IUnitOfWork : IDisposable
{
    IDoctorRepository DoctorRepository { get; }
    Task SaveAsync();
}