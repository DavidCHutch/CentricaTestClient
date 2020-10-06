using CentricaTestClient.Domain.Models;
using CentricaTestClient.Domain.Services;
using CentricaTestClient.WPF.Commands.DistrictCommands;
using CentricaTestClient.WPF.Models;
using CentricaTestClient.WPF.Views.Dialog;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.ViewModels
{
    public class DistrictViewModel : ViewModelBase
    {
        private readonly IDistrictService _districtService;
        public ICommand OpenDetailedDistrictViewFromListItemCommand => new OpenDetailedDistrictViewFromListItemCommand();
        private District _SelectedDistrict;
        public District SelectedDistrict
        {
            get { return _SelectedDistrict; }

            set
            {
                _SelectedDistrict = value;
                OnPropertyChanged("SelectedDistrict");
            }
        }

        private ObservableCollection<District> _Districts;
        public ObservableCollection<District> Districts
        {
            get { return _Districts; }

            set 
            { 
                _Districts = value;
                OnPropertyChanged("Districts");
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DistrictViewModel(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        /// <summary>
        /// Loads the viewmodel, can be used to instaniate the view model with loadDistrict instead of going through constructor
        /// </summary>
        /// <param name="districtService"></param>
        /// <returns></returns>
        public static DistrictViewModel LoadDistrictsViewModel(IDistrictService districtService)
        {
            DistrictViewModel districtsViewModel = new DistrictViewModel(districtService);
            districtsViewModel.LoadDistrictList();
            return districtsViewModel;
        }

        private void LoadDistrictList()
        {
            _districtService.GetAllDistricts().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Districts = new ObservableCollection<District>(task.Result);
                }
            });
        }
    }
}
