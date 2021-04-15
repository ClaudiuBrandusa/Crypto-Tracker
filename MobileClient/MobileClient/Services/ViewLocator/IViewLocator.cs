using MobileClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.Services.ViewLocator
{
    public interface IViewLocator
    {
        Page CreateAndBindPageFor<ViewModel>(ViewModel viewModel) where ViewModel : BaseViewModel;
    }
}
