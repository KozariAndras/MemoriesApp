using Memories_App.Model;

namespace Memories_App
{
    public partial class MainPage : ContentPage
    {

        private MemoriesAppModel _model => App.Current.MainPage.BindingContext as MemoriesAppModel;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void UpdateUI()
        {
            _memoriesView.Children.Clear();
            if (_model is null) return;
            if (_model.Memories is null) return;

            foreach (var memory in _model.Memories)
            {
                UserMemoryView view = new UserMemoryView(memory);               
                _memoriesView.Children.Add(view);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UpdateUI();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}