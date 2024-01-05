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
            _model = new MemoriesAppModel();
            _rootPage = new MainFlyoutPage();
            _rootPage.Flyout = new SideMenuPage(_model);
            _rootPage.BindingContext = _model;
            MainPage = _rootPage;

            _model.DetailsPageLoaded += _model_DetailsPageLoaded;

            InitializeComponent();

        }


        private async void _model_DetailsPageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not DetailsPage)
            { 
                await _rootPage.NavigationPage.PushAsync(new DetailsPage(_model));
            }
        }
    }
}