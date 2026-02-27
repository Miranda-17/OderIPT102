using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Framework.Services;
using OrderManagement.Commands;
using System.Collections.ObjectModel;

namespace OrderManagement.ViewModels
{
    public class HomeOrderViewModel : BaseViewModel
    {
        private readonly IOrderService _service;
        private readonly MainViewModel _main;

        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder { get; set; }
        public string SearchText { get; set; }

        public RelayCommand SearchCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand OpenAddOrderCommand { get; }

        public HomeOrderViewModel(IOrderService service, MainViewModel main)
        {
            _service = service;
            _main = main;

            Orders = new ObservableCollection<Order>(_service.GetOrders());

            SearchCommand = new RelayCommand(_ => Search());
            DeleteCommand = new RelayCommand(_ => Delete());
            UpdateCommand = new RelayCommand(_ => Update());
            OpenAddOrderCommand = new RelayCommand(_ =>
                _main.OpenAddOrderCommand.Execute(null));
        }

        private void Search()
        {
            var result = _service.SearchOrders(SearchText);

            Orders.Clear();
            foreach (var order in result)
                Orders.Add(order);
        }

        private void Delete()
        {
            if (SelectedOrder == null) return;

            _service.RemoveOrder(SelectedOrder.OrderId);
            Orders.Remove(SelectedOrder);
        }

        private void Update()
        {
            if (SelectedOrder == null) return;

            _service.EditOrder(SelectedOrder);
        }
    }
}