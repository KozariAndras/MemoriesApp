using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memories_App.Persistence;

namespace Memories_App.Model
{
    public class MemoriesAppModel
    {
        IMemoriesAppPersistence _persistence;

        public event EventHandler? HomePageLoaded;
        public event EventHandler? SearchPageLoaded;
        public event EventHandler? DetailsPageLoaded;
        public event EventHandler? StatisticsPageLoaded;
        public event EventHandler? NewPicturePageLoaded;


        public MemoriesAppModel(IMemoriesAppPersistence persistence)
        {
            _persistence = persistence;
        }



        public async Task LoadHomePageAsync()
        {
            HomePageLoaded?.Invoke(this, EventArgs.Empty);
        }

        public async Task LoadSearchPageAsync()
        {
            SearchPageLoaded?.Invoke(this, EventArgs.Empty);
        }

        public async Task LoadDetailsPageAsync()
        {
            DetailsPageLoaded?.Invoke(this, EventArgs.Empty);
        }

        public async Task LoadStatisticsPageAsync()
        {
            StatisticsPageLoaded?.Invoke(this, EventArgs.Empty);
        }

        public async Task LoadNewPicturePageAsync()
        {
            NewPicturePageLoaded?.Invoke(this, EventArgs.Empty);
        }
    }
}
