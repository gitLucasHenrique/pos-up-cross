using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SugoiSeries.ViewModel;
using SugoiSeries.ViewModel.Base;
using SugoiSeries.Views;
using Xamarin.Forms;

namespace SugoiSeries.Services.Navigation
{
    public class Navigation : INavigation
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public Navigation()
        {
            _mappings = new Dictionary<Type, Type>();
            CreateViewModelMappings();
        }

        private void CreateViewModelMappings()
        {
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(DetailViewModel), typeof(DetailView));
        }

        public Task Initialize()
        {
            throw new NotImplementedException();
        }

        public Task NavigateAndClearBackStackAsync<TViewModel>(object parameter = null) where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync()
        {
            throw new NotImplementedException();
        }

        #region Not Implemented
        public Task RemoveLastFromBackStack()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
