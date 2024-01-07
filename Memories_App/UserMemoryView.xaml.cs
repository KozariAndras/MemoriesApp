namespace Memories_App;

public partial class UserMemoryView : ContentView
{

	public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(ImageValue), typeof(ImageSource), typeof(UserMemoryView));
	public ImageSource ImageValue
	{
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(TitleValue), typeof(string), typeof(UserMemoryView));
	public string TitleValue
	{
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

	public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(DescriptionValue), typeof(string), typeof(UserMemoryView));
	public string DescriptionValue
	{
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

	public static readonly BindableProperty DateProperty = BindableProperty.Create(nameof(DateValue), typeof(DateTime), typeof(UserMemoryView));
	public DateTime DateValue
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

	public static readonly BindableProperty LocationProperty = BindableProperty.Create(nameof(LocationValue), typeof(string), typeof(UserMemoryView));
	public string LocationValue
    {
        get => (string)GetValue(LocationProperty);
        set => SetValue(LocationProperty, value);
    }

	public static readonly BindableProperty TagsProperty = BindableProperty.Create(nameof(TagsValue), typeof(List<string>), typeof(UserMemoryView));
	public List<string> TagsValue
    {
        get => (List<string>)GetValue(TagsProperty);
        set => SetValue(TagsProperty, value);
    }



	public UserMemoryView()
	{
		InitializeComponent();
	}
}