using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _customer;

        public CustomerItemViewModel(Customer customer)
        {
            _customer = customer;
        }

        public int Id => _customer.Id;

        public string? FirstName
        {
            get => _customer.FirstName;
            set
            {
                _customer.FirstName = value;
                RaisePropertyChange();
            }
        }

        public string? LastName
        {
            get => _customer.LastName;
            set
            {
                _customer.LastName = value;
                RaisePropertyChange();
            }
        }

        public bool IsDeveloper
        {
            get => _customer.IsDeveloper;
            set
            {
                _customer.IsDeveloper = value;   
                RaisePropertyChange();
            }
        }
    }
}
