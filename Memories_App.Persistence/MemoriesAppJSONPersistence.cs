using Memories_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Persistence
{
    public class MemoriesAppJSONPersistence : IMemoriesAppPersistence
    {

        #region UserMemory Methods
        public Task AddUserMemoryAsync(UserMemory memory)
        {
            throw new NotImplementedException();
        }

        public Task<UserMemory> GetAllUserMemoriesAsync()
        {
            throw new NotImplementedException();
        }   

        public Task RemoveAllUserMemoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserMemoryAsync(UserMemory memory)
        {
            throw new NotImplementedException();
        }       

        public Task UpdateUserMemoryAsync(UserMemory memory)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region State Methods

        public Task SaveAppStateAsync(MemoriesAppState state)
        {
            throw new NotImplementedException();
        }

        public Task<MemoriesAppState> LoadAppStateAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
