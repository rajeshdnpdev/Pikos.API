using Pikos.DAL.Contracts;
using System;
using System.Threading.Tasks;

namespace Pikos.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get;}
        Task<int> Complete();
    }
}
