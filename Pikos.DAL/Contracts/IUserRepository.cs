using Pikos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pikos.Models.DTOs.SignInDtos;
using static Pikos.Models.DTOs.SignUpDtos;

namespace Pikos.DAL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
