using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands
{
    public class CancelLoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action CloseAction { get; set; }

        public CancelLoginCommand(Action closeAction)
        {
            CloseAction = closeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CloseAction();
        }
    }
}
