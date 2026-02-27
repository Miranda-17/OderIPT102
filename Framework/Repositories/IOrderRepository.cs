using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Collections.Generic;

namespace Framework.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> Search(string keyword);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
