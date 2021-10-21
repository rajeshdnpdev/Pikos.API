using Pikos.DAL.Contracts;
using Pikos.Models.DTOs;
using Pikos.Models.Entities;
using System;
using static Pikos.Models.DTOs.SignInDtos;
using static Pikos.Models.DTOs.SignUpDtos;

namespace Pikos.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

    }
}
