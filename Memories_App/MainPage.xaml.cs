using Memories_App.Model;

namespace Memories_App
{
    public partial class MainPage : ContentPage
    {

        private MemoriesAppModel _model;

        public MainPage(MemoriesAppModel model)
        {
            _model = model;
            InitializeComponent();
        }   

        public MainPage()
        {
            InitializeComponent();
        }
 
    }
}