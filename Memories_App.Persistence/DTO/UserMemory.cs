using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = SixLabors.ImageSharp.Image;

namespace Memories_App.Persistence.DTO
{
    public class UserMemory
    {
        public int Id { get; set; }
        public MemoryStream ImageStream { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }


        public UserMemory(int id, byte[] imageStream, string title, string description, List<string> tags, DateTime date, Location location)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.Location = location;
            this.ImageStream = new MemoryStream(imageStream);

            if (tags == null)
            {
                this.Tags = new List<string>();
            }
            else
            {
                this.Tags = tags;
            }
        }

        public UserMemory(int id, Image<Rgba32> image, string title, string description, List<string> tags, DateTime date, Location location)
        {
            var encoder = new BmpEncoder();
            this.ImageStream = new MemoryStream();
            image.Save(this.ImageStream, encoder);
            ImageStream.Seek(0, SeekOrigin.Begin);
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Tags = tags;
            this.Date = date;
            this.Location = location;
        }

        public UserMemory()
        {
            
        }
    }
}
