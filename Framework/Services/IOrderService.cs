using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> SearchOrders(string keyword);
        void CreateOrder(Order order);
        void EditOrder(Order order);
        void RemoveOrder(int id);
    }
}