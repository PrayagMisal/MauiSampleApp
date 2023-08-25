using MauiSampleApp.Services.Navigation;

namespace MauiSampleApp
{
    public partial class App : Application
    {
        INavigationService _navigationService;
        public App(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            _navigationService.RegisterForPropertyChangeEvent();
            _navigationService.InitializeAsync();
        }
    }
}