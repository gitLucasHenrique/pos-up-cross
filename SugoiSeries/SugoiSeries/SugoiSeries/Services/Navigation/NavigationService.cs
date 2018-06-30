using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SugoiSeries.ViewModel;
using SugoiSeries.ViewModel.Base;
using SugoiSeries.Views;
using Xamarin.Forms;

namespace SugoiSeries.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreateViewModelMappings();
        }

        private void CreateViewModelMappings()
        {
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(DetailViewModel), typeof(DetailView));
        }

        public async Task Initialize()
        {
            await NavigateToAsync<MainViewModel>();
        }

        public async Task NavigateAndClearBackStackAsync<TViewModel>(object parameter = null) where TViewModel : ViewModelBase
        {
            Page page = CreateAndBindPage(typeof(TViewModel), parameter);
            var navigationPage = CurrentApplication.MainPage as NavigationPage;

            await navigationPage.PushAsync(page);
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
            if(navigationPage != null && navigationPage.Navigation.NavigationStack.Count > 0)
            {
                var existingPages = navigationPage.Navigation.NavigationStack.ToList();
                foreach (var existingPage in existingPages)
                {
                    if(existingPage != page)
                    {
                        navigationPage.Navigation.RemovePage(existingPage);
                    }
                }
            }
        }

        public async Task NavigateBackAsync()
        {
            if(CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync(); //colocar animação caso queira ao voltar uma página
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public Task NavigateToAsync(Type viewModelType)
        => InternalNavigateToAsync(viewModelType, null);

        public Task NavigateToAsync(Type viewModelType, object parameter)
        => InternalNavigateToAsync(viewModelType, parameter);

        public Task NavigateToAsync()
        {
            throw new NotImplementedException();
        }
        async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);
            var navigationPage = CurrentApplication.MainPage as NavigationPage;
            if(navigationPage != null)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                CurrentApplication.MainPage = new NavigationPage(page);
            }
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Mapping missing, type {viewModelType} doesn't exist");
            }
            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new Exception($"Mapping missing, type {viewModelType} wasn't found");
            }
            return _mappings[viewModelType];
        }

        #region Not Implemented
        public Task RemoveLastFromBackStack()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
