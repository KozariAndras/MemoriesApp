using Memories_App.Persistence.DTO;
namespace Memories_App;

public partial class ShortMemoryView : ContentView
{
    public event EventHandler NavButtonClicked;


	public static readonly BindableProperty ImageProperty
        = BindableProperty.Create(nameof(ImageValue), typeof(ImageSource), typeof(ShortMemoryView), default(ImageSource), BindingMode.OneWay, null,
		    (b, o ,n) => (b as ShortMemoryView).OnImageChanged(n as ImageSource));

	public ImageSource ImageValue
	{
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    private void OnImageChanged(ImageSource imageSource)
	{
        Image.Source = imageSource;
    }


	public static readonly BindableProperty TitleProperty 
        = BindableProperty.Create(nameof(TitleValue), typeof(string), typeof(ShortMemoryView), "", BindingMode.OneWay, null,
		    (b, o , n) => (b as ShortMemoryView).OnTitleChanged(n as string));

	public string TitleValue
	{
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    private void OnTitleChanged(string title)
    {
        Title.Text = title;
    }


    public static readonly BindableProperty ButtonProperty 
        = BindableProperty.Create(nameof(NavButton), typeof(Button), typeof(ShortMemoryView), default(Button), BindingMode.OneWay, null,
            (b, o, n) => (b as ShortMemoryView).OnNavButtonChanged(n as Button));


    public Button NavButton
    {
        get => (Button)GetValue(ButtonProperty);
        set => SetValue(ButtonProperty, value);
    }

    private void OnNavButtonChanged(Button navButton)
    {
        NavButton = navButton;
    }


	public ShortMemoryView()
	{
		InitializeComponent();
	}

    private void OnNavButton_Clicked(object sender, EventArgs e)
    {
        NavButtonClicked?.Invoke(this, EventArgs.Empty);
    }

    public ShortMemoryView(UserMemory memory, Button button)
    {
        InitializeComponent();
        this.BindingContext = memory;
        ImageValue = ImageSource.FromStream(() => new MemoryStream(memory.ImageBytes));
        TitleValue = memory.Title;
        NavButton = button;
        NavButton.Clicked += OnNavButton_Clicked;

    }
}