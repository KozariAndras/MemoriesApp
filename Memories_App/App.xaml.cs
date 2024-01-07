using Memories_App.Model;
using Memories_App.Persistence;

namespace Memories_App
{
    public partial class App : Application
    {

        private MainFlyoutPage _rootPage;
        private IMemoriesAppPersistence _persistence;
        private MemoriesAppModel _model;

        public App()
        {
            _persistence = new MemoriesAppJSONPersistence();
            _model = new MemoriesAppModel(_persistence);
            _rootPage = new MainFlyoutPage();
            _rootPage.Flyout = new SideMenuPage(_model);
            _rootPage.Detail = new MainPage(_model);
            _rootPage.BindingContext = _model;
            MainPage = _rootPage;

            _model.HomePageLoaded += _model_HomePageLoaded;
            _model.SearchPageLoaded += _model_SearchPageLoaded;
            _model.DetailsPageLoaded += _model_DetailsPageLoaded;
            _model.StatisticsPageLoaded += _model_StatisticsPageLoaded;
            _model.NewPicturePageLoaded += _model_NewPicturePageLoaded;

            InitializeComponent();

        }


        private void _model_HomePageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not MainFlyoutPage)
            {
                _rootPage.NavigationPage.PopToRootAsync();
            }
        }

        private async void _model_SearchPageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not SearchPage)
            {
                await _rootPage.NavigationPage.PushAsync(new SearchPage(_model));
            }
        }

        private async void _model_DetailsPageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not DetailsPage)
            {
                await _rootPage.NavigationPage.PushAsync(new DetailsPage(_model));
            }
        }

        private async void _model_StatisticsPageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not StatisticsPage)
            {
                await _rootPage.NavigationPage.PushAsync(new StatisticsPage(_model));
            }
        }

        private async void _model_NewPicturePageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not NewPicturePage)
            {
                await _rootPage.NavigationPage.PushAsync(new NewPicturePage(_model));
            }
        }
    }
}