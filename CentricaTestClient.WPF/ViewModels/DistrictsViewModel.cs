using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.Callers;
using CentricaTestClient.WPF.Models;
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
    public class DistrictsViewModel : ViewModelBase
    {
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

        public DistrictsViewModel()
        {
            PopulateDistrictList();
            ListViewItem_DoubleClick = new DelegateCommand(ListItemDobuleClicked);
        }

        public ICommand ListViewItem_DoubleClick
        {
            get;

            private set;
        }

        public void ListItemDobuleClicked()
        {

        }


        public async void PopulateDistrictList()
        {
            DistrictCaller dCall = new DistrictCaller();

            IEnumerable<District> newDList = await dCall.GetAllDistricts();

            Districts = new ObservableCollection<District>(newDList);
        }
    }
}
