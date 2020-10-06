using CentricaTestClient.CentricaTestAPI.Services;
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
            try
            {
                await districtService.RemoveSalesmanFromDistrict(_divm.District.ID.ToString(), _divm.SelectedSalesMan);
            }
            catch
            {
                _divm.ErrorText = "Could not remove salesman from district";
            }
        }
    }
}
