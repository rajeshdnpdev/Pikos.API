using Microsoft.EntityFrameworkCore;
using Pikos.DAL.Contracts;
using Pikos.DAL.Models;
using Pikos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikos.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {

        public OrderRepository(NorthwindDbContext appDbContext) : base(appDbContext)
        {

        }

        public IEnumerable<Order> ExecWithStoreProcedure(string query)
        {
            return context.Set<Order>().FromSqlRaw(query).ToList();
        }

    }
}
