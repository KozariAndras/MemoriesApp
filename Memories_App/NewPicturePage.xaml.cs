using Memories_App.Model;
namespace Memories_App;

public partial class NewPicturePage : ContentPage
{

    private MemoriesAppModel _model;

    public NewPicturePage(MemoriesAppModel model)
    {
        _model = model;
    }

    public NewPicturePage()
    {
        InitializeComponent();
    }


    public async void TakePhotoButton_Clicked(object sender, EventArgs e)
    {
        //await _model.TakePhotoAsync();
    }

    public async void ChoosePhotoButton_Clicked(object sender, EventArgs e)
    {
        //await _model.ChoosePhotoAsync();
    }
}