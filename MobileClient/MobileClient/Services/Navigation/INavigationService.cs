using MobileClient.ViewModels;
using MobileClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileClient.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateTo(BaseViewModel viewModel, bool clearStack);
        bool CanGoBack();
        Task Back();
        void ClearStack();
        void PushAsync(Page page);
    }
}
