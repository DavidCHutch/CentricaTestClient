using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Services;
using CentricaTestClient.WPF.States.Navigators;
using CentricaTestClient.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel(DistrictViewModel.LoadDistrictsViewModel(new DistrictService(LoginViewModel._userName, LoginViewModel._passWord)));
                        break;
                    //case ViewType.Districts:
                    //    _navigator.CurrentViewModel = new DistrictsViewModel();
                    //    break;
                    case ViewType.Orders:
                        _navigator.CurrentViewModel = new OrdersViewModel();
                        break;
                    default:
                        break;
                }
            }
         }
    }
}
