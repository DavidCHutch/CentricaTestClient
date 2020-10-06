using CentricaTestClient.WPF.Commands;
using CentricaTestClient.WPF.Views.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public Action CloseAction { get; set; }
        public ICommand LoginCommand => new LoginCommand(this, CloseAction);
        public ICommand CancelCommand => new CancelLoginCommand(CloseAction);

        public string _errorText;
        public string ErrorText
        {
            get { return _errorText; }

            set
            {
                _errorText = value;
                OnPropertyChanged("ErrorText");
            }
        }

        public static string _userName { get; private set; }
        public string UserName
        {
            get { return _userName; }

            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public static string _passWord { get; private set; }
        public string Password
        {
            get { return _passWord; }

            set
            {
                _passWord = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginViewModel()
        {

        }

        public static void ShowView()
        {
            LoginView lView = new LoginView();
            LoginViewModel lVm= new LoginViewModel();
            lVm.CloseAction = new Action(lView.Close);
            lView.DataContext = lVm;
            lView.ShowDialog();
        }

    }
}
