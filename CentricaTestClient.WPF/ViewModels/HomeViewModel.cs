using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private DistrictViewModel _districtViewModel;
        public DistrictViewModel DistrictViewModel
        {
            get { return _districtViewModel; }

            set
            {
                _districtViewModel = value;
                OnPropertyChanged("DistrictViewModel");
            }
        }

        public HomeViewModel(DistrictViewModel districtViewModel)
        {
            DistrictViewModel = districtViewModel;
        }
    }
}
