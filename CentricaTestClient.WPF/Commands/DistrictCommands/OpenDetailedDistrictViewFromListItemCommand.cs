using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.ViewModels;
using CentricaTestClient.WPF.Views.Dialog;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands.DistrictCommands
{
    public class OpenDetailedDistrictViewFromListItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public OpenDetailedDistrictViewFromListItemCommand()
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is District)
            {
                District district = (District)parameter;
                DistrictItemView ditemview = new DistrictItemView();
                ditemview.DataContext = DistrictItemViewModel.LoadDistrictItemViewModel(new DistrictService(LoginViewModel._userName, LoginViewModel._passWord), district);
                ditemview.ShowDialog();
            }
        }
    }
}
