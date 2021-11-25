using MobileClient.Models;
using MobileClient.Services.Navigation;
using System.Collections.ObjectModel;

namespace MobileClient.ViewModels.Authorized
{

    public class WalletViewModel : BaseViewModel
    {
        public ObservableCollection<CurrencyModel> Currencies { get; }

        CurrencyModel _selectedCurrency;

        public CurrencyModel SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                navigation.NavigateTo(new CurrencyDetailViewModel(navigation));
            }
        }

        public WalletViewModel(INavigationService navigation) : base(navigation)
        {
            Currencies = new ObservableCollection<CurrencyModel>
            {

                new CurrencyModel
                {
                    Name = "KitCoin",
                    Price = 1.3f,
                    Owned = 50
                },

                new CurrencyModel
                {
                    Name = "CheapCoin",
                    Price = .146f,
                    Owned = 45.3f
                }
            };
        }
    }
}
