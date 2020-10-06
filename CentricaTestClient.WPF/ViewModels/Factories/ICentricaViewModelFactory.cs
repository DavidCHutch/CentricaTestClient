using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public interface ICentricaViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
