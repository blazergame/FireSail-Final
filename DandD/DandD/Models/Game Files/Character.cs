using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Character : Fighter
    {
        public int score; 
        public Character(string Name)
        {
            this.Name = Name;
            score = 0; 
        }

        public bool IsValid()
        {
            if (Name != null)
                return true;
            return false; 
        }
    }
}
