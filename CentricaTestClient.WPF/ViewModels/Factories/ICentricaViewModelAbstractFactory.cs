using CentricaTestClient.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentricaTestClient.WPF.ViewModels.Factories
{
    public interface ICentricaViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType type);
    }
}
