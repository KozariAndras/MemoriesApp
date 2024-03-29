using Memories_App.Persistence.DTO;

namespace Memories_App;

public partial class UserMemoryView : ContentView
{

	public static readonly BindableProperty ImageProperty
        = BindableProperty.Create(nameof(ImageValue), typeof(ImageSource), typeof(UserMemoryView), default(ImageSource), BindingMode.OneWay, null,
            (b, o ,n) => (b as UserMemoryView).OnImageChanged(n as ImageSource));
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
        = BindableProperty.Create(nameof(TitleValue), typeof(string), typeof(UserMemoryView), "", BindingMode.OneWay, null,
            (b, o , n) => (b as UserMemoryView).OnTitleChanged(n as string));
	public string TitleValue
	{
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    private void OnTitleChanged(string title)
    {
        Title.Text = "Title: " + title;
    }


	public static readonly BindableProperty DescriptionProperty 
        = BindableProperty.Create(nameof(DescriptionValue), typeof(string), typeof(UserMemoryView), "", BindingMode.OneWay, null,
            (b, o, n) => (b as UserMemoryView).OnDescriptionChanged(n as string));
	public string DescriptionValue
	{
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }
    private void OnDescriptionChanged(string description)
    {
        Description.Text = "Description: " +description;
    }


    public static readonly BindableProperty DateProperty
        = BindableProperty.Create(nameof(DateValue), typeof(string), typeof(UserMemoryView), "", BindingMode.OneWay, null,
            (b, o, n) => (b as UserMemoryView).OnDateChanged(n as string));
	public string DateValue
    {
        get => (string)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    private void OnDateChanged(string date)
    {
        Date.Text = "Date: " + date;
    }


	public static readonly BindableProperty LocationProperty 
        = BindableProperty.Create(nameof(LocationValue), typeof(string), typeof(UserMemoryView), "", BindingMode.OneWay, null,
            (b, o, n) => (b as UserMemoryView).OnLocationChanged(n as string));
	public string LocationValue
    {
        get => (string)GetValue(LocationProperty);
        set => SetValue(LocationProperty, value);
    }
    private void OnLocationChanged(string location)
    {
        Location.Text = "Location: " + location;
    }


	public static readonly BindableProperty TagsProperty 
        = BindableProperty.Create(nameof(TagsValue), typeof(List<string>), typeof(UserMemoryView), default(List<string>), BindingMode.OneWay, null,
            (b, o, n) => (b as UserMemoryView).OnTagChanged(n as List<string>));
	public List<string> TagsValue
    {
        get => (List<string>)GetValue(TagsProperty);
        set => SetValue(TagsProperty, value);
    }

    private void OnTagChanged(List<string> tags)
    {
        Tag.Text = "Tags: " + string.Join(", ", tags);
    }


	public UserMemoryView()
	{
		InitializeComponent();
	}

    public UserMemoryView(UserMemory memory)
    {
        InitializeComponent();
        this.BindingContext = memory;
        ImageValue = ImageSource.FromStream(() => new MemoryStream(memory.ImageBytes));
        TitleValue = memory.Title;
        DescriptionValue = memory.Description;
        TagsValue = memory.Tags;
        DateValue = memory.Date.ToLongDateString();
        LocationValue = memory.Location is null ? "N/A" : $"{memory.Location.Latitude} - {memory.Location.Longitude}";



    }
}