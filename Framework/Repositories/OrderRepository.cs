using System.Collections.Generic;
using System.Data;
using Dapper;
using Domain.Models;
using Framework.Data;

namespace Framework.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all orders
        public IEnumerable<Order> GetAll()
        {
            using var connection = _context.CreateConnection();
            return connection.Query<Order>(
                "GetAllOrders",
                commandType: CommandType.StoredProcedure);
        }

        // Search orders by keyword
        public IEnumerable<Order> Search(string keyword)
        {
            using var connection = _context.CreateConnection();
            return connection.Query<Order>(
                "SearchOrders",
                new { Keyword = keyword },
                commandType: CommandType.StoredProcedure);
        }

        // Add a new order
        public void Add(Order order)
        {
            using var connection = _context.CreateConnection();
            connection.Execute(
                "AddOrder",
                new
                {
                    order.CustomerName,
                    order.OrderName,
                    order.OrderDate,
                    order.TotalAmount,
                    order.OrderStatus
                },
                commandType: CommandType.StoredProcedure);
        }

        // Update an existing order
        public void Update(Order order)
        {
            using var connection = _context.CreateConnection();
            connection.Execute(
                "UpdateOrder",
                new
                {
                    order.OrderId,
                    order.CustomerName,
                    order.OrderName,
                    order.OrderDate,
                    order.TotalAmount,
                    order.OrderStatus
                },
                commandType: CommandType.StoredProcedure);
        }

        // Delete an order by ID
        public void Delete(int id)
        {
            using var connection = _context.CreateConnection();
            connection.Execute(
                "DeleteOrder",
                new { OrderId = id },
                commandType: CommandType.StoredProcedure);
        }
    }
}