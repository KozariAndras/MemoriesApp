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
                UserMemoryView view = new UserMemoryView();
                view.BindingContext = memory;
                view.ImageValue = ImageSource.FromStream(() => memory.ImageStream);
                view.TitleValue = memory.Title;
                view.DescriptionValue = memory.Description;
                view.TagsValue = memory.Tags;
                view.DateValue = memory.Date.ToLongDateString();
                view.LocationValue = memory.Location is null ? "N/A" : memory.Location.ToString();

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