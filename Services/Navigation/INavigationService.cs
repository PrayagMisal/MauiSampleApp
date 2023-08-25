using MauiSampleApp.ViewModels;

namespace MauiSampleApp.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        void RegisterForPropertyChangeEvent();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();

        Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : BaseViewModel;

        Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : BaseViewModel;
    }
}