using Pikos.DAL.Models;
using Pikos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikos.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();

        string GetAllExpensiveProducts();
    }
}
