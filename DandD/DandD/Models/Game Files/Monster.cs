using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DandD.Models.Game_Files
{
    public class Monster : Fighter
    {
		[PrimaryKey, AutoIncrement]
		public int Monster_ID { get; set; }
		public int score { get; set; }

        public Monster(string Name)
        {
            this.Name = Name;
        }

        public Monster()
        {
            
        }

        public bool isValid()
        {
			if (Name != null)
				return true;
			return false;
		}


    }
}
