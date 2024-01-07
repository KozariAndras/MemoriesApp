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
        public byte[] ImageBytes { get; set; }
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
            ImageBytes = imageStream;

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
            var tempStream = new MemoryStream();
            image.Save(tempStream, encoder);
            tempStream.Seek(0, SeekOrigin.Begin);
            ImageBytes = tempStream.ToArray();
            tempStream.Dispose();
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
