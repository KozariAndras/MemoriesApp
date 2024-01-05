using Memories_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memories_App.Persistence
{
    public interface IMemoriesAppPersistence
    {
        #region UserMemory Methods

        Task AddUserMemoryAsync(UserMemory memory);
        Task RemoveUserMemoryAsync(UserMemory memory);
        Task<IEnumerable<UserMemory>> GetAllUserMemoriesAsync();
        Task RemoveAllUserMemoriesAsync();
        Task UpdateUserMemoryAsync(UserMemory memory);

        #endregion


        #region State Methods

        Task SaveAppStateAsync(MemoriesAppState state);
        Task<MemoriesAppState> LoadAppStateAsync();

        #endregion
    }
}
