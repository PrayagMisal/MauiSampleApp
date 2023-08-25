using MauiSampleApp.ViewModels;
using MauiSampleApp.Views;
using CustomNavigationPage = Microsoft.Maui.Controls.NavigationPage;
namespace MauiSampleApp.Services.Navigation
{
    internal class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> mappings;
        protected Application CurrentApplication => Application.Current;
        IServiceProvider _serviceProvider;
        private NavigationPage _lastSavedNavigationPage;
        public NavigationService(IServiceProvider serviceProvider)
        {
            mappings = new();
            CreatePageViewModelMappings();
            _serviceProvider = serviceProvider;
        }

        public void RegisterForPropertyChangeEvent()
        {
            CurrentApplication.PropertyChanged += CurrentApplication_PropertyChanged;
        }

        private void CurrentApplication_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == nameof(CurrentApplication.MainPage))
                {
                    if (_lastSavedNavigationPage is null && CurrentApplication.MainPage is CustomNavigationPage navigationPageInstance)
                        _lastSavedNavigationPage = navigationPageInstance;
                    else
                    {
                        if (_lastSavedNavigationPage is not null)
                            NavigationPageNoLongerInUse(_lastSavedNavigationPage);
                        if (CurrentApplication.MainPage is CustomNavigationPage navigationPage)
                            _lastSavedNavigationPage = navigationPage;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }

        void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
        }
        public async Task InitializeAsync()
        {
            await NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateBackAsync()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public Task NavigateToAsync(Type viewModelType) => InternalNavigateToAsync(viewModelType, null);

        public Task NavigateToAsync(Type viewModelType, object parameter) => InternalNavigateToAsync(viewModelType, parameter);

        public Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is LoginPage)
            {
                CurrentApplication.MainPage = page;
            }
            //RegisterNavigationPageForPagePushedAndPopEvent(navigationPage);
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"Mapping type for {viewModelType} is not a page");

            Page page = _serviceProvider.GetService(pageType) as Page;
            BaseViewModel viewModel = _serviceProvider.GetService(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;

            return page;
        }
        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            return mappings[viewModelType];
        }

        private void NavigationPageNoLongerInUse(object sender)
        {
            try
            {
                if (sender is CustomNavigationPage navigationPage)
                {
                    navigationPage.Pushed -= NavigationPage_Pushed;
                    navigationPage.Popped -= NavigationPage_Popped;
                    IEnumerable<Page> pages = (navigationPage as INavigationPageController).Pages;
                    foreach (Page page in pages)
                        if (page is ContentPage)
                        {
                            BaseViewModel viewModel = (page.BindingContext as BaseViewModel);
                            viewModel.PagePopped(new NavigationEventArgs(page));
                        }
                }
            }
            catch (Exception exc)
            {
                //TraceHandler.ExceptionToTraceError(exc);
            }
        }
        private void NavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            try
            {
                if (sender is CustomNavigationPage navigationPage)
                {
                    BaseViewModel viewModel = e.Page.BindingContext as BaseViewModel;
                    viewModel.PagePopped(e);
                }
            }
            catch (Exception exc)
            {
                //TraceHandler.ExceptionToTraceError(exc);
            }
        }
        private void NavigationPage_Pushed(object sender, NavigationEventArgs e)
        {
            try
            {
                if (sender is CustomNavigationPage navigationPage)
                {
                    BaseViewModel viewModel = e.Page.BindingContext as BaseViewModel;
                    viewModel.PagePushed(e);
                }
            }
            catch (Exception exc)
            {
                //TraceHandler.ExceptionToTraceError(exc);
            }
        }
        private void RegisterNavigationPageForPagePushedAndPopEvent(CustomNavigationPage navigationPage)
        {
            try
            {
                if (navigationPage is not null)
                {
                    if (navigationPage.RootPage is not null)
                    {
                        BaseViewModel viewModel = (navigationPage.RootPage.BindingContext as BaseViewModel);
                        viewModel?.PagePushed(new(navigationPage.RootPage));
                    }
                    navigationPage.Pushed += NavigationPage_Pushed;
                    navigationPage.Popped += NavigationPage_Popped;
                    //navigationPage.Disappearing += NavigationPage_Disappearing;
                }
            }
            catch (Exception exc)
            {
            }
        }
    }
}