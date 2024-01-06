using Memories_App.Model;
namespace Memories_App;

public partial class SearchPage : ContentPage
{

	private MemoriesAppModel _model;

    public SearchPage(MemoriesAppModel model)
    {
        InitializeComponent();
        _model = model;
    }
}