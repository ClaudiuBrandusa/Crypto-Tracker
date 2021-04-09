﻿using MobileClient.Services;
using MobileClient.ViewModels;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
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

        public void ClearStack() // Only the current page remains
        {
            for(int i = 1; i < _navigation.NavigationStack.Count; i++)
            {
                _navigation.RemovePage(_navigation.NavigationStack[i]);
            }
        }

        public async Task NavigateTo(BaseViewModel viewModel, bool newStack)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);
            
            await _navigation.PushAsync(page);
            
            if(newStack)
            {
                ClearStack();
            }
        }

        public async void PushAsync(Page page)
        {
            await _navigation.PushAsync(page);
        }
    }
}