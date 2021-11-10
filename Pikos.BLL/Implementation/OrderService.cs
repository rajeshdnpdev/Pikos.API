using Microsoft.Extensions.Options;
using Pikos.BLL.Interfaces;
using Pikos.DAL;
using Pikos.DAL.Contracts;
using Pikos.DAL.Models;
using Pikos.Helpers;
using Pikos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikos.BLL.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppSettings appSettings;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings.Value;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
             return await orderRepository.GetAll();
        }

        public string GetAllExpensiveProducts()
        {
            var result = orderRepository.ExecWithStoreProcedure("getallorders3");
            return result.ToString();  
        }
    }
}