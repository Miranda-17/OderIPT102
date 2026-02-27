using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Framework.Repositories;
using System.Collections.Generic;

namespace Framework.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Order> GetOrders()
            => _repository.GetAll();

        public IEnumerable<Order> SearchOrders(string keyword)
            => _repository.Search(keyword);

        public void CreateOrder(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerName))
                throw new System.Exception("Customer name is required");

            _repository.Add(order);
        }

        public void EditOrder(Order order)
            => _repository.Update(order);

        public void RemoveOrder(int id)
            => _repository.Delete(id);
    }
}