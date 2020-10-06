using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public class DistrictViewModelFactory : ICentricaViewModelFactory<DistrictViewModel>
    {
        private readonly IDistrictService _districtService;

        public DistrictViewModelFactory(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        public DistrictViewModel CreateViewModel()
        {
            throw new NotImplementedException();
            //return DistrictViewModel.LoadDistrictViewModel(_districtService);
        }
    }
}
