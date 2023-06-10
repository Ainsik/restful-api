namespace api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository DoctorRepository { get; }
        Task SaveAsync();
    }
}
