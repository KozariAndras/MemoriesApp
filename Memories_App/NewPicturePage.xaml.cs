using Memories_App.Model;
using Memories_App.Persistence.DTO;
namespace Memories_App;

public partial class NewPicturePage : ContentPage
{

    private MemoriesAppModel _model;

    public NewPicturePage(MemoriesAppModel model)
    {
        InitializeComponent();
        _model = model;
    }


    public async void TakePhotoButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photoFile = await MediaPicker.CapturePhotoAsync();
            if (photoFile != null)
                await _model.LoadImage(await photoFile.OpenReadAsync());
        }
        catch (FeatureNotSupportedException)
        {
            // Feature is not supported on the device
        }
        catch (PermissionException)
        {
            // Permissions not granted
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
        }
    }

    public async void ChoosePhotoButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photoFile = await MediaPicker.PickPhotoAsync();
            if (photoFile != null)
                await _model.LoadImage(await photoFile.OpenReadAsync());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
        }
    }

    public async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(_titleEntry.Text) || _titleEntry.Text == "" )
        {
            await DisplayAlert("Error", "Please enter a title", "OK");
            return;
        }
        if (String.IsNullOrWhiteSpace(_descriptionEntry.Text) || _descriptionEntry.Text == "")
        {
            await DisplayAlert("Error", "Please enter a description", "OK");
            return;
        }
        if (String.IsNullOrWhiteSpace(_tagsEntry.Text) || _tagsEntry.Text == "")
        {
            await DisplayAlert("Error", "Please enter at least one tag", "OK");
            return;
        }
        if (_model.NewImage == null)
        {
            await DisplayAlert("Error", "Please select an image", "OK");
            return;
        }

        List<string> tags = _tagsEntry.Text.Split(',').ToList();
        Location location = await _model.GetCurrentLocation();
        int id = _model.Memories.Count == 0 ? 1 : _model.Memories.Max(m => m.Id) + 1;
        UserMemory newMemory = new UserMemory(id, _model.NewImage, _titleEntry.Text, _descriptionEntry.Text, tags, DateTime.Now, location);
        _model.NewImage.Dispose();
        _model.NewImage = null;
        _model.Memories.Add(newMemory);
        await _model.SaveMemoriesAsync();
        await DisplayAlert("Success", "Memory added successfully", "OK");
        await _model.LoadHomePageAsync();
    }


    private void _model_PhotoLoaded(object sender, EventArgs e)
    {
        _displayImage.Source = ImageSource.FromStream(() => _model.GetImageStream());
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        _model.PhotoLoaded += _model_PhotoLoaded;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (_model.NewImage != null)
        {
            _model.NewImage.Dispose();
            _model.NewImage = null;
        }
        _choosePhotoButton.Clicked -= ChoosePhotoButton_Clicked;
        _takePhotoButton.Clicked -= TakePhotoButton_Clicked;
        _saveButton.Clicked -= SaveButton_Clicked;
        _model.PhotoLoaded -= _model_PhotoLoaded;
    }
}