using Memories_App.Model;

namespace Memories_App
{
    public partial class MainPage : ContentPage
    {

        private MemoriesAppModel _model;

        public MainPage()
        {
            InitializeComponent();
            if (BindingContext is MemoriesAppModel model)
            {
                _model = model;
            }
        }   
        
    }
}