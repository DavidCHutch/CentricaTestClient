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
            sitemview.DataContext = new SalesmanItemViewModel(_divm.District);
            sitemview.ShowDialog();
        }
    }
}
