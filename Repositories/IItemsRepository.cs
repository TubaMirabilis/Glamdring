using Glamdring.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamdring.Repositories
{
    public interface IRepository
    {
        Task<Character> GetItemAsync(Guid id);
        Task<IEnumerable<Character>> GetItemsAsync();
        Task CreateItemAsync(Character c);
        Task UpdateItemAsync(Character c);
        Task DeleteItemAsync(Guid id);
    }
}