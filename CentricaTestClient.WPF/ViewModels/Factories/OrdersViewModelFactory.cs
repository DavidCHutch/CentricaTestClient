using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public class OrdersViewModelFactory : ICentricaViewModelFactory<OrdersViewModel>
    {
        public OrdersViewModelFactory()
        {
            
        }

        public OrdersViewModel CreateViewModel()
        {
            return new OrdersViewModel();
        }
    }
}
