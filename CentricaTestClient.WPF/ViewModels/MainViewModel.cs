using CentricaTestClient.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public MainViewModel()
        {
            Navigator = new Navigator();
            LoginViewModel.ShowView();
        }
    }
}
