using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using System.Threading.Tasks;
using DandD.Models.Game_Files;
using DandD.Models;
using DandD.Views;

namespace DandD
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;
        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Items>().Wait();
            database.CreateTableAsync<Character>().Wait();
            database.CreateTableAsync<Monster>().Wait();
        }

        public Task<List<Items>> RetrieveItems()
        {
            return database.Table<Items>().ToListAsync();
        }

        public Task<int> InsertItem(Items item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> deleteItem(Items item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> updateItem(Items item)
        {
            return database.UpdateAsync(item);
        }

        //********************************************CHARACTERS*************************************************************

        public Task<List<Character>> RetrieveCharacters()
        {
            return database.Table<Character>().ToListAsync();
        }
        public Task<Character> RetrieveSpecificCharacter(string name)
        {
            return database.Table<Character>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }
        public Task<int> InsertCharacter(Character character)
        {
            if (character.Character_ID != 0) //Updating Item
               return database.UpdateAsync(character);
             return database.InsertAsync(character);
        }

        public Task<int> UpdateCharacter(Character character)
        {
                return database.UpdateAsync(character);
        }

        public Task<int> deleteCharacter(Character character)
        {
            return database.DeleteAsync(character);
        }


		//*****************************************MONSTER TABLES*************************************************

		public Task<List<Monster>> RetrieveMonsters()
		{
			return database.Table<Monster>().ToListAsync();
		}
		
		public Task<int> InsertMonster(Monster character)
		{
			if (character.Monster_ID != 0) //Updating Item
				return database.UpdateAsync(character);
			return database.InsertAsync(character);
		}

		public Task<int> deleteMonster(Monster character)
		{
			return database.DeleteAsync(character);
		}

        public Task<int> UpdateMonster(Monster monster)
        {
            return database.UpdateAsync(monster);
        }

        public void reset()
        {
            database.ExecuteAsync("DELETE FROM Items");
        }

        public void resetMonster()
        {
            database.ExecuteAsync("DELETE FROM Monster");
        }

        public void resetCharacter()
        {
            database.ExecuteAsync("DELETE FROM Character");
        }
		//*****************************************EFFECTS TABLES*************************************************

		//public Task<List<BattleEffect>> RetrieveBattleEffects()
		//{
		//	return database.Table<BattleEffect>ToListAsync();
		//}

  //      public Task<int> InsertBattleEffect(BattleEffect character)
		//{
		//	if (character.Monster_ID != 0) //Updating Item
		//		return database.UpdateAsync(character);
		//	return database.InsertAsync(character);
		//}

		//public Task<int> deleteMonster(Monster character)
		//{
		//	return database.DeleteAsync(character);
		//}

		//public Task<int> UpdateMonster(Monster monster)
		//{
		//	return database.UpdateAsync(monster);
		//}


	}
}
