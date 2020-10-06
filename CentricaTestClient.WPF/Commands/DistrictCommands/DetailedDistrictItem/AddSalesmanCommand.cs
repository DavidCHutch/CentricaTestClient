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
    public class AddSalesmanCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action CloseAction { get; set; }
        private SalesmanItemViewModel _sivm { get; set; }
        
        public AddSalesmanCommand(SalesmanItemViewModel salesmanViewModel, Action closeAction)
        {
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
            try
            {
                await districtService.AddSalesmanToDistrict(_sivm.SelectedDistrict.ID.ToString(), _sivm.SelectedSalesMan);
            }
            catch
            {
                _sivm.ErrorText = "Could not add salesman to district";
                return;
            }

            CloseAction();
        }
    }
}
