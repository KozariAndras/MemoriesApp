using Memories_App.Model;
using Memories_App.Persistence.DTO;

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
            _model.Memories.Sort((x, y) => y.Date.CompareTo(x.Date));
            foreach (var memory in _model.Memories)
            {
                Button button = new() { Text = "Details" };
                ShortMemoryView shortMemoryView = new(memory, button);
                shortMemoryView.NavButtonClicked += DetailsButton_Clicked;
                _memoriesView.Children.Add(shortMemoryView);
            }
        }

        private async void DetailsButton_Clicked(object sender, EventArgs e)
        {
            
            UserMemory memory = (sender as ShortMemoryView).BindingContext as UserMemory;
            await _model.LoadDetailsPageAsync(memory);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateUI();
        }

        protected override void OnDisappearing()
        {
            foreach (var child in _memoriesView.Children)
            {
                if (child is ShortMemoryView shortMemoryView)
                {
                    shortMemoryView.NavButtonClicked -= DetailsButton_Clicked;
                }
            }
            _memoriesView.Children.Clear();
            _model.Dispose();
            base.OnDisappearing();
        }
    }
}