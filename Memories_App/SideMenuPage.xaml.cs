using Memories_App.Model;
namespace Memories_App;

public partial class SideMenuPage : ContentPage
{
    private MemoriesAppModel _model;

	public SideMenuPage(MemoriesAppModel model)
	{
        _model = model;
		InitializeComponent();
	}
    public SideMenuPage()
    {
        InitializeComponent();
    }


	private void GenerateNavButtons()
	{
		_NavButtonList.Children.Clear();

		Button button = new Button() { Text = "Home page" };
		button.Clicked += HomePageButton_Clicked;
		_NavButtonList.Children.Add(button);		

		button = new Button() { Text = "Search page" };
		button.Clicked += SearchPageButton_Clicked;
        _NavButtonList.Children.Add(button);

        button = new Button() { Text = "Details page" };
		button.Clicked += DetailsPageButton_Clicked;
        _NavButtonList.Children.Add(button);

        button = new Button() { Text = "Statistics page" };
        button.Clicked += StatisticsPageButton_Clicked;
        _NavButtonList.Children.Add(button);

        button = new Button() { Text = "New picture page" };
        button.Clicked += NewPicturePageButton_Clicked;
        _NavButtonList.Children.Add(button);


    }

    private async void HomePageButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadHomePageAsync();
    }  

    private async void SearchPageButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadSearchPageAsync();
    }

    private async void DetailsPageButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadDetailsPageAsync(null);
    }

	private async void StatisticsPageButton_Clicked(object sender, EventArgs e)
	{
		await _model.LoadStatisticsPageAsync();
	}

    private async void NewPicturePageButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadNewPicturePageAsync();
    }



    protected override void OnAppearing()
	{
		GenerateNavButtons();
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        _model.HomePageLoaded -= HomePageButton_Clicked;
        _model.SearchPageLoaded -= SearchPageButton_Clicked;
        _model.DetailsPageLoaded -= DetailsPageButton_Clicked;
        _model.StatisticsPageLoaded -= StatisticsPageButton_Clicked;
        _model.NewPicturePageLoaded -= NewPicturePageButton_Clicked;
        _NavButtonList.Children.Clear();
        base.OnDisappearing();
    }

}