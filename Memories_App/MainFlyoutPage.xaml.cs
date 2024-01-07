using Memories_App.Model;
namespace Memories_App;

public partial class MainFlyoutPage : FlyoutPage
{
	public NavigationPage NavigationPage => _navigationPage;

	public MainFlyoutPage()
	{
		InitializeComponent();
	}
}