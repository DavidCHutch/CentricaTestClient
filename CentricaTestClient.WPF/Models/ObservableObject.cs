using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CentricaTestClient.WPF.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Takes a PropertyChanged event that is not null and invokes it.
        /// This Notifies the UI that a property has changed and updates the binding that has the propertyName
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
