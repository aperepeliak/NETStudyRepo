using System;

namespace OnlineStore.Repo.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
