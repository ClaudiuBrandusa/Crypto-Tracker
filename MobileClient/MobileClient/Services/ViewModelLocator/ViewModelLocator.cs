using MobileClient.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.Services.ViewModelLocator
{
    public static class ViewModelLocator
    {
        private static Dictionary<Type, BaseViewModel> viewModelInstances = new Dictionary<Type, BaseViewModel>();
    
        public static BaseViewModel GetViewModel(Page page)
        {
            var pageType = page.GetType();

            var viewModelType = FindViewModelForPage(pageType);

            BaseViewModel viewModel = null;

            if(viewModelInstances.ContainsKey(pageType))
            {
                viewModel = viewModelInstances[pageType];
            }
            else
            {
                viewModel = (BaseViewModel)Activator.CreateInstance(viewModelType, DependencyService.Get<INavigation>());
                viewModelInstances.Add(pageType, viewModel);
            }

            return viewModel;
        }

        public static ViewModel GetViewModelOfType<ViewModel>(Type viewModelType) where ViewModel : BaseViewModel
        {
            ViewModel viewModel = (ViewModel)Activator.CreateInstance(viewModelType, DependencyService.Get<INavigation>());

            return viewModel;
        }

        private static Type FindViewModelForPage(Type pageType)
        {
            var viewModelTypeName = pageType
                .AssemblyQualifiedName
                .Replace("View", "ViewModel");

            var viewModelType = Type.GetType(viewModelTypeName);
            if (viewModelType == null)
                throw new ArgumentException(viewModelTypeName + " type does not exist");

            return viewModelType;
        }
    }
}
