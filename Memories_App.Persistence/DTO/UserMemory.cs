using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Persistence.DTO
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


        public UserMemory(int id, byte[] imageStream, string title, string description, List<string> tags, DateTime date, Location location)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.Location = location;
            
            try
            {
                using (MemoryStream ms = new MemoryStream(imageStream))
                {
                    DecoderOptions decoderOptions = new() { };
                    this.Image = (Image<Rgba32>)Image<Rgba32>.Load(decoderOptions, ms);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"WARNING! Image with Id:{id} could not be loaded!");
            }


            if (tags == null)
            {
                this.Tags = new List<string>();
            }
            else
            {
                this.Tags = tags;
            }
        }
    }
}
