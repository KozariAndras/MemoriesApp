using Memories_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Persistence.DTO
{
    public class SaveableUserData
    {
        public List<SaveableUserMemory> Memories { get; set; }


        public SaveableUserData(IEnumerable<UserMemory> mems)
        {
            foreach (var mem in mems)
            {
                this.Memories.Add(new SaveableUserMemory(mem.Id, mem.Image, mem.Title, mem.Description, mem.Tags, mem.Date, mem.Location));
            }
        }
    }
}
