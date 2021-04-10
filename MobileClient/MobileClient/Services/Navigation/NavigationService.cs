using MobileClient.ViewModels;
using Xamarin.Forms;
using MobileClient.Services.Navigation;
using System.Threading.Tasks;
using MobileClient.Services.ViewLocator;

[assembly: Dependency(typeof(NavigationService))]
namespace MobileClient.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IViewLocator _viewLocator;
        private readonly IHaveMainPage _root;
        private INavigation _navigation => _root.MainPage.Navigation;

        public NavigationService(IHaveMainPage root, IViewLocator viewLocator)
        {
            _root = root;
            _viewLocator = viewLocator;
        }

        public async Task Back()
        {
            await _navigation.PopAsync();
        }

        public bool CanGoBack()
        {
            return _navigation.NavigationStack.Count > 0;
        }

        private void ClearStack() // Only the current page remains
        {
            _root.ResetMainPage();
        }

        public async Task NavigateTo(BaseViewModel viewModel, bool newStack)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            if (newStack)
            {
                ClearStack();
            }
            
            await _navigation.PushAsync(page);
        }
    }
}
