using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.ViewModels;
using CentricaTestClient.WPF.Views.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem
{
    public class OpenListOfAvailableSalesmenCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private DistrictItemViewModel _divm { get; set; }

        public OpenListOfAvailableSalesmenCommand(DistrictItemViewModel districtItemViewModel)
        {
            _divm = districtItemViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            SalesmanItemView sitemview = new SalesmanItemView();
            Action closeAction = new Action(sitemview.Close);
            sitemview.DataContext = SalesmanItemViewModel.LoadSalesmanItemViewModel(new DistrictService(LoginViewModel._userName, LoginViewModel._passWord), closeAction, _divm);
            sitemview.ShowDialog();
        }
    }
}
