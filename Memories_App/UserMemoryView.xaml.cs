namespace Memories_App;

public partial class UserMemoryView : ContentView
{

	public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(ImageSource), typeof(UserMemoryView));
	public ImageSource Image
	{
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

	public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(UserMemoryView));
	public string Title
	{
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

	public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description", typeof(string), typeof(UserMemoryView));
	public string Description
	{
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

	public static readonly BindableProperty DateProperty = BindableProperty.Create("Date", typeof(DateTime), typeof(UserMemoryView));
	public DateTime Date
	{
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

	public static readonly BindableProperty LocationProperty = BindableProperty.Create("Location", typeof(string), typeof(UserMemoryView));
	public string Location
	{
        get => (string)GetValue(LocationProperty);
        set => SetValue(LocationProperty, value);
    }

	public static readonly BindableProperty TagsProperty = BindableProperty.Create("Tags", typeof(List<string>), typeof(UserMemoryView));
	public List<string> Tags
	{
        get => (List<string>)GetValue(TagsProperty);
        set => SetValue(TagsProperty, value);
    }



	public UserMemoryView()
	{
		InitializeComponent();
	}
}