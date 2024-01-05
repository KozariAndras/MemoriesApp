using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Model
{
    public class UserMemory
    {
        public int Id { get; set; }
        public Image<Rgba32> Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }

    }
}
