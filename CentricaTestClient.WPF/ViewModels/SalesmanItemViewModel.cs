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
    /// <summary>
    /// Item view model. This view is for adding foreign salesman to a district
    /// </summary>
    public class SalesmanItemViewModel : ViewModelBase
    {
        private readonly IDistrictService _districtService;
        public Action CloseAction { get; private set; }
        public ICommand AddSalesmanCommand => new AddSalesmanCommand(this, CloseAction, DistrictItemViewModel);

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

        private DistrictItemViewModel _districtItemViewModel;
        public DistrictItemViewModel DistrictItemViewModel
        {
            get { return _districtItemViewModel; }

            set
            {
                _districtItemViewModel = value;
                OnPropertyChanged("DistrictItemViewModel");
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

        public SalesmanItemViewModel(IDistrictService districtService, Action close, DistrictItemViewModel dIvm)
        {
            _districtItemViewModel = dIvm;
            _districtService = districtService;
            CloseAction = close;
        }

        /// <summary>
        /// Loads the viewmodel, can be used to instaniate the view model instead of going through constructor
        /// </summary>
        /// <param name="districtService"></param>
        /// <returns></returns>
        public static SalesmanItemViewModel LoadSalesmanItemViewModel(IDistrictService districtService, Action close, DistrictItemViewModel dIvm)
        {
            SalesmanItemViewModel districtItemViewModel = new SalesmanItemViewModel(districtService, close, dIvm);
            districtItemViewModel.LoadSalesmanList();

            return districtItemViewModel;
        }

        /// <summary>
        /// Loads the list of salesman needed to populate the data grid 
        /// </summary>
        private void LoadSalesmanList()
        {
            _districtService.GetAllSalesmenOutsideDistrict(_districtItemViewModel.District.ID.ToString()).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SalesMen = new ObservableCollection<Salesman>(task.Result);
                }
            });
        }

    }
}
