using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels
{
    public class DistrictItemViewModel : ViewModelBase
    {
        //private readonly IDistrictService _districtService;
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

        public DistrictItemViewModel(District district)
        {
            District = district;
            PopulateDistrict();
        }

        private async void PopulateDistrict()
        {
            DistrictService districtService = new DistrictService(LoginViewModel._userName, LoginViewModel._passWord);
            District.Salesmen = await districtService.GetAllSalesmenInDistrict(District.ID.ToString());
            District.Stores = await districtService.GetAllStoresInDistrict(District.ID.ToString());

            District.PrimarySalesman = District.Salesmen.Where(s => s.IsPrimary).FirstOrDefault();
        }
    }
}
