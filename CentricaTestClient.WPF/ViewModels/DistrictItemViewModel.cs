using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.Domain.Services;
using CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.ViewModels
{
    public class DistrictItemViewModel : ViewModelBase
    {
        private readonly IDistrictService _districtService;
        public ICommand OpenListOfAvailableSalesmenCommand => new OpenListOfAvailableSalesmenCommand(this);
        public ICommand PromoteSalesmanCommand => new PromoteSalesmanCommand(this);
        public ICommand RemoveSalesmanCommand => new RemoveSalesmanCommand(this);

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

        private ObservableCollection<Store> _Stores;
        public ObservableCollection<Store> Stores
        {
            get { return _Stores; }

            set
            {
                _Stores = value;
                OnPropertyChanged("Stores");
            }
        }

        private District _District;
        public District District
        {
            get { return _District; }
            set
            {
                _District = value;
                OnPropertyChanged(String.Empty);
            }
        }

        public DistrictItemViewModel(IDistrictService districtService, District district)
        {
            _districtService = districtService;
            _District = district;
        }

        /// <summary>
        /// Loads the viewmodel, can be used to instaniate the view model with loadDistrict instead of going through constructor
        /// </summary>
        /// <param name="districtService"></param>
        /// <returns></returns>
        public static DistrictItemViewModel LoadDistrictItemViewModel(IDistrictService districtService, District district)
        {
            DistrictItemViewModel districtItemViewModel = new DistrictItemViewModel(districtService, district);
            districtItemViewModel.LoadSalesmanList();
            districtItemViewModel.LoadStoresList();

            districtItemViewModel.District.PrimarySalesman = district.Salesmen.Where(s => s.IsPrimary).FirstOrDefault();
            return districtItemViewModel;
        }

        private void LoadSalesmanList()
        {
            _districtService.GetAllSalesmenInDistrict(District.ID.ToString()).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SalesMen = new ObservableCollection<Salesman>(task.Result);
                    District.Salesmen = SalesMen;
                }
            });
        }

        private void LoadStoresList()
        {
            _districtService.GetAllStoresInDistrict(District.ID.ToString()).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Stores = new ObservableCollection<Store>(task.Result);
                    District.Stores = Stores;
                }
            });
        }
    }
}
