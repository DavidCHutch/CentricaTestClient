using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public class CentricaViewModelAbstractFactory : ICentricaViewModelAbstractFactory
    {
        private readonly ICentricaViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ICentricaViewModelFactory<OrdersViewModel> _ordersViewModelFactory;
        private readonly ICentricaViewModelFactory<LoginViewModel> _loginViewModelFactory;

        public CentricaViewModelAbstractFactory(ICentricaViewModelFactory<HomeViewModel> homeViewModelFactory, 
            ICentricaViewModelFactory<OrdersViewModel> ordersViewModelFactory,
            ICentricaViewModelFactory<LoginViewModel> loginViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _ordersViewModelFactory = ordersViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Orders:
                    return _ordersViewModelFactory.CreateViewModel();
                //case ViewType.Login:
                //    return _loginViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The viewtype does not have a ViewModel.", "viewType");
            }
        }
    }
}
