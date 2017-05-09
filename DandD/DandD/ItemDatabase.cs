using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using System.Threading.Tasks;
using DandD.Models.Game_Files;

namespace DandD
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;
        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Items>().Wait();
        }
        public Task<List<Items>> RetrieveItems()
        {
            return database.Table<Items>().ToListAsync();
        }
        public Task<Items> RetrieveSpecificItem(string name)
        {
            return database.Table<Items>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }
        public Task<int> InsertItem(Items item)
        {
            if (item.Name != null) //Updating Item
                return database.UpdateAsync(item);

            return database.InsertAsync(item);
        }

        public Task<int> deleteItem(Items item)
        {
            return database.DeleteAsync(item);
        }
    }
}
