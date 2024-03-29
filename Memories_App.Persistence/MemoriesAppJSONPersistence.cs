﻿using Memories_App.Persistence.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Persistence
{
    public class MemoriesAppJSONPersistence : IMemoriesAppPersistence
    {
        private string _filename => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "data.json");

        #region private methods

        private async Task SaveUserMemoriesAsync(IEnumerable<UserMemory> memories)
        {
            try
            {
                var convertedMemories = new SaveableUserData(memories);
                string json = JsonConvert.SerializeObject(convertedMemories);
                await File.WriteAllTextAsync(_filename, json);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"WARNING! Saving user data threw this exception: \"{ex}\"!");
            }            
        }

        private async Task<IEnumerable<UserMemory>> LoadUserMemoriesAsync()
        {
            try
            {
                //File.Delete(_filename);
                if (File.Exists(_filename))
                {
                    string json = File.ReadAllText(_filename);
                    SaveableUserData userData = JsonConvert.DeserializeObject<SaveableUserData>(json);
                    List<UserMemory> memories = new();
                    foreach (var mem in userData.Memories)
                    {
                        memories.Add(new UserMemory(mem.Id, mem.ImageStream, mem.Title, mem.Description, mem.Tags, mem.Date, mem.Location));
                    }

                    return memories;
                }
                else
                {
                    return new List<UserMemory>();
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"WARNING! Loading user data threw this exception: \"{ex}\"");
                return new List<UserMemory>();
            }            
        }      

        #endregion


        #region public methods


        #region UserMemory Methods

        public async Task AddUserMemoryAsync(UserMemory memory)
        {
            List<UserMemory> memories = (List<UserMemory>)await LoadUserMemoriesAsync();
            memories.Add(memory);
            await SaveUserMemoriesAsync(memories);
        }

        public async Task<IEnumerable<UserMemory>> GetAllUserMemoriesAsync()
        {
            return await LoadUserMemoriesAsync();
        }   

        public async Task RemoveAllUserMemoriesAsync()
        {
            await SaveUserMemoriesAsync(new List<UserMemory>());
        }

        public async Task RemoveUserMemoryAsync(UserMemory memory)
        {
            List <UserMemory> memories = (List<UserMemory>)await LoadUserMemoriesAsync();
            foreach (var mem in memories)
            {
                if (mem.Id == memory.Id)
                {
                    memories.Remove(mem);
                    break;
                }
            }
        }       

        public async Task UpdateUserMemoryAsync(UserMemory memory)
        {
            List<UserMemory> memories = (List<UserMemory>)await LoadUserMemoriesAsync();
            foreach (var mem in memories)
            {
                if (mem.Id == memory.Id)
                {
                    mem.Title = memory.Title;
                    mem.Description = memory.Description;
                    mem.Date = memory.Date;
                    mem.Location = memory.Location;
                    mem.Tags = memory.Tags;
                    mem.ImageBytes = memory.ImageBytes;
                    break;
                }
            }
        }


        public async Task SaveAllUserMemoriesAsync(IEnumerable<UserMemory> memories)
        {
            await SaveUserMemoriesAsync(memories);
        }

        #endregion

        #region State Methods

        public async Task SaveAppStateAsync(MemoriesAppState state)
        {
            throw new NotImplementedException();
        }

        public async Task<MemoriesAppState> LoadAppStateAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
