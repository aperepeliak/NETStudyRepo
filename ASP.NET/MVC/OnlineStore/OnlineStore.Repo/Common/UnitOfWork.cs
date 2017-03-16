using System;
using System.Data.Entity;

namespace OnlineStore.Repo.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Save() => _context.SaveChanges();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
