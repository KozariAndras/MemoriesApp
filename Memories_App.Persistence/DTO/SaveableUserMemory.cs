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

        public SaveableUserMemory(int id , MemoryStream imageStream, string title, string description, List<string> tags, DateTime date, Location location)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.Location = location;
            this.ImageStream = imageStream.ToArray();                     

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
