using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using WiredBrainCoffee.CustomersApp.Command;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            this._customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public DelegateCommand AddCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand MoveNavigationCommand { get; }

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChange(nameof(SelectedCustomer));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
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

        private void Add(object? parameter)
        {
            var customer = new Customer() { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(new CustomerItemViewModel(customer));
            SelectedCustomer = viewModel;
        }

        private bool CanDelete(object? parameter)
        => this.SelectedCustomer is not null;

        private void Delete(object? parameter)
        {
            if (SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }

        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left 
                ? NavigationSide.Right
                : NavigationSide.Left;
        }
    }

    public enum NavigationSide
    {
        Left,
        Right,
    }
}
