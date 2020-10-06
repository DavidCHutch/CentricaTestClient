using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem;
using CentricaTestClient.WPF.Views.Dialog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.ViewModels
{
    public class SalesmanItemViewModel : ViewModelBase
    {
        public Action CloseAction { get; private set; }
        public ICommand AddSalesmanCommand => new AddSalesmanCommand(this, CloseAction);
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
        private Salesman _SelectedSalesman;
        public Salesman SelectedSalesMan
        {
            get { return _SelectedSalesman; }

            set
            {
                _SelectedSalesman = value;
                OnPropertyChanged("SelectedSalesMan");
            }
        }
        private District _SelectedDistrict;
        public District SelectedDistrict
        {
            get { return _SelectedDistrict; }

            set
            {
                _SelectedDistrict = value;
                OnPropertyChanged("_SelectedDistrict");
            }
        }

        private IEnumerable<Salesman> _Salesmen;
        public IEnumerable<Salesman> Salesmen
        {
            get { return _Salesmen; }

            set
            {
                _Salesmen = value;
                OnPropertyChanged("Salesmen");
            }
        }

        public SalesmanItemViewModel(District selectedDistrict)
        {
            _SelectedDistrict = selectedDistrict;
            PopulateSalesman();
        }

        private async void PopulateSalesman()
        {
            DistrictService districtService = new DistrictService(LoginViewModel._userName, LoginViewModel._passWord);
            Salesmen = await districtService.GetAllSalesmenOutsideDistrict(SelectedDistrict.ID.ToString());
        }
    }
}
