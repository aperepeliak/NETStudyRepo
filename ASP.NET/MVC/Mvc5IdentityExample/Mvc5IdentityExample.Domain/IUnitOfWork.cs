using Mvc5IdentityExample.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mvc5IdentityExample.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
