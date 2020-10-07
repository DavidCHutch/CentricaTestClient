using CentricaTestClient.CentricaTestAPI.Services;
using CentricaTestClient.Domain.Models;
using CentricaTestClient.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CentricaTestClient.WPF.Commands.DistrictCommands.DetailedDistrictItem
{
    public class PromoteSalesmanCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private DistrictItemViewModel _divm { get; set; }

        public PromoteSalesmanCommand(DistrictItemViewModel districtItemViewModel)
        {
            _divm = districtItemViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            DistrictService districtService = new DistrictService(LoginViewModel._userName, LoginViewModel._passWord);

            _divm.ErrorText = "";
            if (!_divm.SelectedSalesMan.IsPrimary)
            {
                bool success = await districtService.PromotePrimarySalesmanInDistrict(_divm.District.ID.ToString(), _divm.SelectedSalesMan);
                if (!success)
                {
                    _divm.ErrorText = "Could not promote salesman to primary";
                }
                else
                {
                    // Change primary salesman to new primary salesman
                    // Update salesman list to show new promotions/demotions

                    List<Salesman> newList = new List<Salesman>();

                    newList = _divm.SalesMen.ToList();

                    Salesman oldPrime = newList.Where(e => e.ID.ToString() == _divm.District.PrimarySalesman.ID.ToString()).FirstOrDefault();
                    Salesman newPrime = newList.Where(e => e.ID.ToString() == _divm.SelectedSalesMan.ID.ToString()).FirstOrDefault();

                    _divm.SalesMen.Remove(oldPrime);
                    _divm.SalesMen.Remove(newPrime);

                    oldPrime.IsPrimary = false;
                    newPrime.IsPrimary = true;

                    _divm.SalesMen.Add(oldPrime);
                    _divm.SalesMen.Add(newPrime);

                    _divm.District.PrimarySalesman = newPrime;
                }
            }
            else
            {
                _divm.ErrorText = "Salesman is already primary!";
            }
        }
    }
}
