﻿using System.ComponentModel;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private readonly CustomersViewModel _customersViewModel;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChange(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
