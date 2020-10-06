using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public class LoginViewModelFactory : ICentricaViewModelFactory<LoginViewModel>
    {
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel();
        }

        //private ICentricaViewModelFactory<LoginViewModel> _loginViewModelFactory;

        //public LoginViewModelFactory(ICentricaViewModelFactory<LoginViewModel> loginViewModelFactory)
        //{
        //    _loginViewModelFactory = loginViewModelFactory;
        //}
    }
}
