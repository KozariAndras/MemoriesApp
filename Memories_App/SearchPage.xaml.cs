using Memories_App.Model;
using Memories_App.Persistence.DTO;
namespace Memories_App;

public partial class SearchPage : ContentPage
{

	private MemoriesAppModel _model;

    public SearchPage(MemoriesAppModel model)
    {
        InitializeComponent();
        _model = model;
    }

    public async void SearchButton_Clicked(object sender, EventArgs e)
    {        
        string? filterBy = (string) _filterPicker.SelectedItem;
        string filterValue = _searchEntry.Text;
        await _model.FilterMemoriesAsync(filterBy, filterValue);

        _searchResultList.Children.Clear();
        foreach (var item in _model.FilteredMemories)
        {
            UserMemoryView view = new(item);
            _searchResultList.Children.Add(view);
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _searchButton.Clicked -= SearchButton_Clicked;   
    }
}