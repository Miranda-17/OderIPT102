using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string? OrderName { get; set; }
    }
}
