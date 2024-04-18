using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private int _navigationColumn;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            this._customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChange(nameof(SelectedCustomer));
            }
        }

        public int NavigationColumn
        {
            get => _navigationColumn;
            private set
            {
                _navigationColumn = value;
                RaisePropertyChange();
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is null)
            {
                return;
            }

            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }

        internal void Add()
        {
            var customer = new Customer() { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(new CustomerItemViewModel(customer));
            SelectedCustomer = viewModel;
        }

        internal void MoveNavigation()
        {
            NavigationColumn = NavigationColumn == 0 ? 2 : 0;
        }
    }
}
