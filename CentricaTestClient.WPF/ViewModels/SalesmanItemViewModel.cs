using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.Domain.Services;
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
        private readonly IDistrictService _districtService;
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

        private Salesman _SelectedSalesMan;
        public Salesman SelectedSalesMan
        {
            get { return _SelectedSalesMan; }

            set
            {
                _SelectedSalesMan = value;
                OnPropertyChanged("SelectedSalesMan");
            }
        }
        private District _District;
        public District District
        {
            get { return _District; }

            set
            {
                _District = value;
                OnPropertyChanged("District");
            }
        }

        private ObservableCollection<Salesman> _SalesMen;
        public ObservableCollection<Salesman> SalesMen
        {
            get { return _SalesMen; }

            set
            {
                _SalesMen = value;
                OnPropertyChanged("SalesMen");
            }
        }

        public SalesmanItemViewModel(IDistrictService districtService, District selectedDistrict, Action close)
        {
            _districtService = districtService;
            _District = selectedDistrict;
            CloseAction = close;
        }

        /// <summary>
        /// Loads the viewmodel, can be used to instaniate the view model instead of going through constructor
        /// </summary>
        /// <param name="districtService"></param>
        /// <returns></returns>
        public static SalesmanItemViewModel LoadSalesmanItemViewModel(IDistrictService districtService, District district, Action close)
        {
            SalesmanItemViewModel districtItemViewModel = new SalesmanItemViewModel(districtService, district, close);
            districtItemViewModel.LoadSalesmanList();

            return districtItemViewModel;
        }

        private void LoadSalesmanList()
        {
            _districtService.GetAllSalesmenOutsideDistrict(District.ID.ToString()).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SalesMen = new ObservableCollection<Salesman>(task.Result);
                    District.Salesmen = SalesMen;
                }
            });
        }

    }
}
