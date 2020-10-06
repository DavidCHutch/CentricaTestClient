using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem
{
    public class RemoveSalesmanCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private DistrictItemViewModel _divm { get; set; }

        public RemoveSalesmanCommand(DistrictItemViewModel districtItemViewModel)
        {
            _divm = districtItemViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            DistrictService districtService = new DistrictService(LoginViewModel._userName, LoginViewModel._passWord);
            _divm.ErrorText = "";
            bool success = await districtService.RemoveSalesmanFromDistrict(_divm.District.ID.ToString(), _divm.SelectedSalesMan);

            if (!success)
            {
                _divm.ErrorText = "Could not remove salesman from district";
            }
            else
            {
                _divm.SalesMen.Remove(_divm.SelectedSalesMan);
            }
        }
    }
}
