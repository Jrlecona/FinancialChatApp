namespace ChatApp.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
}