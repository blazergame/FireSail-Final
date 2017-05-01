using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Items
    {
        public string Name { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public bool Equipped { get; set; }
        private int defaultHealth = 10;
        private Random rand = new Random();

        public Items(string Name, int Str, int Dex, int Speed)
        {
            this.Name = Name;
            this.Str = Str;
            this.Dex = Dex;
            this.Speed = Speed;
            Health = defaultHealth;

        }

        public Items()
        {
            Name = PopulateAndReturnNames();
            Str = Randomize();
            Dex = Randomize();
            Speed = Randomize();
            Health = defaultHealth;
            Equipped = false;
        }

        private int Randomize()
        {
            Random rand = new Random();
            return rand.Next(1, 10);
        }

        private string PopulateAndReturnNames()
        {
           
            var words = new[] { "Leroy Jenkins", "Warlock", "Qui-gone-drank-the-gin","The_Chosen_One", "Anakin", "Frank", "Jake from Statefarm", "Flo", "Donald Drumpf",
            "Father Sunborg", "Mitt Romney", "Barrack Yo-Momma The 3rd", "Carl", "O_O", "THE_MARINERS_SUCK_AT_BASEBALL" };
            return words[rand.Next(0, words.Length)];
        }
    }
}
