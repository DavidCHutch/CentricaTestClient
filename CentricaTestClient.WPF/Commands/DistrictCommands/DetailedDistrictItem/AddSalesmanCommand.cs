using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.ViewModels;
using CentricaTestClient.WPF.Views.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem
{
    public class AddSalesmanCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action CloseAction { get; set; }
        private SalesmanItemViewModel _sivm { get; set; }
        private DistrictItemViewModel _divm { get; set; }

        public AddSalesmanCommand(SalesmanItemViewModel salesmanViewModel, Action closeAction, DistrictItemViewModel districtItemViewModel)
        {
            _divm = districtItemViewModel;
            _sivm = salesmanViewModel;
            CloseAction = closeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            DistrictService districtService = new DistrictService(LoginViewModel._userName, LoginViewModel._passWord);
            _sivm.ErrorText = "";
            bool success = await districtService.AddSalesmanToDistrict(_sivm.DistrictItemViewModel.District.ID.ToString(), _sivm.SelectedSalesMan);

            if (!success)
            {
                _sivm.ErrorText = "Could not add salesman to district";
            }
            else
            {
                _divm.SalesMen.ToList().Add(_sivm.SelectedSalesMan);
            }

            CloseAction();
        }
    }
}
