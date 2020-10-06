using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : ICentricaViewModelFactory<HomeViewModel>
    {
        private ICentricaViewModelFactory<DistrictViewModel> _districtViewModelFactory;

        public HomeViewModelFactory(ICentricaViewModelFactory<DistrictViewModel> districtViewModelFactory)
        {
            _districtViewModelFactory = districtViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_districtViewModelFactory.CreateViewModel());
        }
    }
}
