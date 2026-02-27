using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services;
using OrderManagement.Commands;

namespace OrderManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentView;
        private readonly IOrderService _orderService;

        public BaseViewModel CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenHomeCommand { get; }
        public RelayCommand OpenAddOrderCommand { get; }

        public MainViewModel(IOrderService orderService)
        {
            _orderService = orderService;

            OpenHomeCommand = new RelayCommand(_ => OpenHome());
            OpenAddOrderCommand = new RelayCommand(_ => OpenAddOrder());

            OpenHome();
        }

        private void OpenHome()
        {
            CurrentView = new HomeOrderViewModel(_orderService, this);
        }

        private void OpenAddOrder()
        {
            CurrentView = new AddOrderViewModel(_orderService, this);
        }
    }
}