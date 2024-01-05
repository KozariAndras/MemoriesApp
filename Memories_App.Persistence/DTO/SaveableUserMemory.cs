using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Persistence.DTO
{
    public class SaveableUserMemory
    {
        public int Id { get; set; }
        public byte[] ImageStream { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }

        public SaveableUserMemory(int id , Image<Rgba32> image, string title, string description, List<string> tags, DateTime date, Location location)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.Location = location;

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms);
                    this.ImageStream = ms.ToArray();
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"WARNING! Image with Id:{id} could not be saved!");
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
