using Memories_App.Model;

namespace Memories_App
{
    public partial class MainPage : ContentPage
    {

        private MemoriesAppModel _model;

        public MainPage(MemoriesAppModel model)
        {
            _model = model;
            InitializeComponent();
        }   

        public MainPage()
        {
            InitializeComponent();
        }


        private async void _model_HomePageLoaded(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private async void UpdateUI()
        {
            _memoriesView.Children.Clear();
            foreach (var memory in _model.Memories)
            {
                UserMemoryView view = new UserMemoryView();
                view.BindingContext = memory;
                //view.ImageValue = memory.ImageStream;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_model is not null)
            {
                _model.HomePageLoaded += _model_HomePageLoaded;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (_model is not null)
            {
                _model.HomePageLoaded -= _model_HomePageLoaded;
            }
        }
    }
}