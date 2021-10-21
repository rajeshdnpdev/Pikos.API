using Pikos.DAL.Contracts;
using Pikos.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikos.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        private bool disposedValue;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            Users = new UserRepository(appDbContext);
        }
        public async Task<int> Complete()
        {
            return await appDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
