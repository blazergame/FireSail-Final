using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Character : Fighter
    {
        [PrimaryKey, AutoIncrement]
        public int Character_ID { get; set; }
        public int score { get; set; }
       
        public Character(string Name)
        {
            this.Name = Name;
            score = 0; 
        }

        public Character()
        {
            score = 0;
            this.Name = Name; 

        }

        public bool IsValid()
        {
            if (Name != null)
                return true;
            return false; 
        }
    }
}
