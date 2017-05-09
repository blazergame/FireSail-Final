using System;
using System.Collections.Generic;
using System.Text;
using DandD.Models.Game_Files;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(DandD.Services.MockDataStore))]
namespace DandD.Services
{
    public class MockCharacterStore : IDataStore<Character>
    {

        bool isInitialized;
        List<Character> characterList;

        public async Task<bool> AddItemAsync(Character character)
        {
            await InitializeAsync();

            characterList.Add(character);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Character character)
        {
            //await InitializeAsync();

            //var _character = characterList.Where((Character arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(_item);
            //items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Character ch)
        {
            //await InitializeAsync();

            //var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            //items.Remove(_item);

            return await Task.FromResult(true);
        }


        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }


        public async Task<Character> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(characterList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(characterList);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            characterList = new List<Character>();
            var _char = new List<Character>
            {
                new Character { Id = Guid.NewGuid().ToString(), Name = "Bot", Str=13},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Wizard", Str=7},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Warrior", Str=13},
                new Character { Id = Guid.NewGuid().ToString(), Name = "Beast",  Str=13},
            };

            foreach (Character ch in _char)
            {
                characterList.Add(ch);
            }

            isInitialized = true;
        }
    }
}
