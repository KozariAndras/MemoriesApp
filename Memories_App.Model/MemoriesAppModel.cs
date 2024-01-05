using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Model
{
    public class MemoriesAppModel
    {
        public List<string> Data { get; set; }




        public event EventHandler? DetailsPageLoaded;


        public async Task LoadDetailsPageAsync()
        {
            Data = new List<string>() { "Hello", "World" };
            DetailsPageLoaded?.Invoke(this, EventArgs.Empty);
        }
    }
}
