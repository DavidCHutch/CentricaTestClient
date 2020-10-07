using CentricaTestClient.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels
{
    /// <summary>
    /// Main view model that opens up the login view and itself
    /// </summary>
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
