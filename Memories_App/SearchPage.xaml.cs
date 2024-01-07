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
        
        string filterBy = _filterPicker.SelectedItem.ToString();
        string filterValue = _searchEntry.Text;

        //IEnumerable<UserMemory> filteredMemories = await _model.FilterMemoriesAsync(filterBy, filterValue);
    }
}