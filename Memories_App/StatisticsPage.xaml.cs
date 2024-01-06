using Memories_App.Model;
namespace Memories_App;

public partial class StatisticsPage : ContentPage
{

	private MemoriesAppModel _model;

	public StatisticsPage(MemoriesAppModel model)
	{
        InitializeComponent();
        _model = model;
    }
}