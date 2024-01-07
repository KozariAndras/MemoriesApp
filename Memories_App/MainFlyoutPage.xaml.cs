using Memories_App.Model;
namespace Memories_App;

public partial class MainFlyoutPage : FlyoutPage
{
	public NavigationPage NavigationPage => _navigationPage;

	public MainFlyoutPage(MemoriesAppModel model)
	{
		_navigationPage = new NavigationPage(new MainPage(model));
		InitializeComponent();
	}
}