using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands
{
    /// <summary>
    /// Simple logincommand that checks if it can reach the database.
    /// </summary>
    //TODO: CHANGE THIS LATER
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action CloseAction { get; set; }
        private LoginViewModel _lvm { get; set; }

        public LoginCommand(LoginViewModel loginViewModel, Action closeAction)
        {
            _lvm = loginViewModel;
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
                await districtService.GetAllDistricts();
            }
            catch
            {
                _lvm.ErrorText = "Login failed - Wrong credentials";
                return; 
            }

            CloseAction();
        }
    }
}
