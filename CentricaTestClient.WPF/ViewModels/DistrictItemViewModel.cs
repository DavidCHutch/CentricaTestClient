﻿using CentricaTestClient.CentricaTestAPI.Services;
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
        //private readonly IDistrictService _districtService;
        private District _District;
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
