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


    private void LoadPageContent()
    {

    }



    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadPageContent();
    }
}