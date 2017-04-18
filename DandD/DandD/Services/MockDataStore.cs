using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DandD.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(DandD.Services.MockDataStore))]
namespace DandD.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Blue sword", Description="Deeper than the blue sea", Str="13"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Yellow pants", Description="Bright like the sun", Str="7"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rambo guitar", Description="Noted", Str="13"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wand candle", Description="Make a wish of death", Str="13"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Holiday staff", Description="Keep it a secret!", Str="10"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Frodo Hat", Description="Cool hat", Str="5"},
			};

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
