using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem
{
    public class PromoteSalesmanCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private DistrictItemViewModel _divm { get; set; }

        public PromoteSalesmanCommand(DistrictItemViewModel districtItemViewModel)
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
            bool success = await districtService.PromotePrimarySalesmanInDistrict(_divm.District.ID.ToString(), _divm.SelectedSalesMan);

            if (!success)
            {
                _divm.ErrorText = "Could not remove salesman from district";
            }
            else
            {
                _divm.District.PrimarySalesman = _divm.SelectedSalesMan;
            }
        }
    }
}
