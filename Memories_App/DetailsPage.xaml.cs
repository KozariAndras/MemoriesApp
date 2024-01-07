using Memories_App.Model;
namespace Memories_App;

public partial class DetailsPage : ContentPage
{
    private MemoriesAppModel _model;
    
    public DetailsPage(MemoriesAppModel model)
    {
        _model = model;
        InitializeComponent();
    }


    private void UpdateUI()
    {
        if (_model is not null && _model.DetailedMemory is not null)
        {
            _ItemsList.Children.Clear();
            _ItemsList.Children.Add(new UserMemoryView(_model.DetailedMemory));
            if (_model.DetailedMemory.Location is not null)
            {
                Button locationButton = new() { Text = "Open location on map!" };
                locationButton.Clicked += LocationButton_Clicked;
                _ItemsList.Children.Add(locationButton);
            }
            Button deleteButton = new() { Text = "Delete" };
            deleteButton.Clicked += DeleteButton_Clicked;
            _ItemsList.Children.Add(deleteButton);
        }
    }

    private async void LocationButton_Clicked(object sender, EventArgs e)
    {
        var options = new MapLaunchOptions { Name = _model.DetailedMemory.Title };

        try
        {
            await Map.OpenAsync(_model.DetailedMemory.Location, options);
        }
        catch (Exception)
        {
            // No map application available to open
        }
    }

    public async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        _model.Memories.Remove(_model.DetailedMemory);
        _model.DetailedMemory = null;
        await _model.SaveMemoriesAsync();
        await _model.LoadHomePageAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateUI();
    }

    protected override void OnDisappearing()
    {
        _model.DetailedMemory = null;
        foreach (var child in _ItemsList.Children)
        {
            if (child is Button)
            {
                (child as Button).Clicked -= DeleteButton_Clicked;
                (child as Button).Clicked -= LocationButton_Clicked;
            }
        }
        base.OnDisappearing();
    }
}