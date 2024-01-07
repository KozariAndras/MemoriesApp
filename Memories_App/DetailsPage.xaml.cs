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
            Button button = new() { Text = "Delete" };
            button.Clicked += DeleteButton_Clicked;
            _ItemsList.Children.Add(button);
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
}