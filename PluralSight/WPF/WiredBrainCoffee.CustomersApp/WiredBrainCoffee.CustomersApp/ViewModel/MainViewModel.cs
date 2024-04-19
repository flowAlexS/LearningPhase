using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;


        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = CustomersViewModel;
			SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public CustomersViewModel CustomersViewModel { get; }

        public ProductsViewModel ProductsViewModel { get; }

        public DelegateCommand SelectViewModelCommand
		{
			get;
		}

        public ViewModelBase? SelectedViewModel
		{
			get => _selectedViewModel;
			set
			{
				_selectedViewModel = value;
				RaisePropertyChange();
			}
		}

		public async override Task LoadAsync()
		{
			if (SelectedViewModel is not null)
			{
				await SelectedViewModel.LoadAsync();
			}
		}

        private void SelectViewModel(object? parameter)
        {
			SelectedViewModel = parameter as ViewModelBase;
        }
    }
}
