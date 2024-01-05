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
        _ItemsList.Children.Clear();

        foreach (string item in _model.Data)
		{
            Label label = new Label() { Text = item };
            _ItemsList.Children.Add(label);
        }
    }



	protected override void OnAppearing()
	{
        base.OnAppearing();
		LoadPageContent();
    }
}