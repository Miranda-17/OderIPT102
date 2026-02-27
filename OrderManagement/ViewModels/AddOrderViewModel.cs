using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Framework.Services;
using OrderManagement.Commands;

namespace OrderManagement.ViewModels
{
    public class AddOrderViewModel : BaseViewModel
    {
        private readonly IOrderService _service;
        private readonly MainViewModel _main;

        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string? OrderName { get; set; }

        public RelayCommand SaveCommand { get; }
        public RelayCommand BackCommand { get; }

        public AddOrderViewModel(IOrderService service, MainViewModel main)
        {
            _service = service;
            _main = main;

            SaveCommand = new RelayCommand(_ => Save());
            BackCommand = new RelayCommand(_ => _main.OpenHomeCommand.Execute(null));
        }

        private void Save()
        {
            var order = new Order
            {
                CustomerName = CustomerName,
                OrderDate = OrderDate,
                TotalAmount = TotalAmount,
                OrderStatus = OrderStatus,
                OrderName = OrderName
            };

            _service.CreateOrder(order);
            _main.OpenHomeCommand.Execute(null);
        }
    }
}
