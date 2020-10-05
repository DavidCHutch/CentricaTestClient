using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.ViewModels;
using CentricaTestClient.WPF.Views.Dialog;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands
{
    public class OpenNewWindowFromListItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private District District { get; set; }

        public OpenNewWindowFromListItemCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is District)
            {
                District district = (District)parameter;
                Console.WriteLine("_listViewItem_DoubleClick has been activated");
                //Dialog.DataContext = DialogViewModel
                //Dialog.ShowDialog()
                //DistrictService dCall = new DistrictCaller();
                DistrictItemView ditemview = new DistrictItemView();
                ditemview.DataContext = new DistrictItemViewModel(district);
                ditemview.ShowDialog();
            }
        }
    }
}
