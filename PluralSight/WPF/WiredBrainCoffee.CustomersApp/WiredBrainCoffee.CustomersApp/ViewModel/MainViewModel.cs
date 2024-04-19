namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CustomersViewModel _customersViewModel;
        private ViewModelBase? _selectedViewModel;


        public MainViewModel(CustomersViewModel customersViewModel)
        {
            this._customersViewModel = customersViewModel;
			SelectedViewModel = _customersViewModel;
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
	}
}
