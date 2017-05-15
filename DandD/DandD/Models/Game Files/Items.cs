using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Items: BaseDataObject
    {
        public string Name { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public bool Equipped { get; set; }
        private int defaultHealth = 10;
        private Random rand = new Random();

        int error_code = 0;
        string msg = string.Empty;
       // string name = string.Empty;
        string attribute = string.Empty;
        int val;

        public int ApiID { get; set; }

        public int Error_Code
        {
            get { return error_code; }
            set { SetProperty(ref error_code, value); }
        }

        public string Msg
        {
            get { return msg; }
            set { SetProperty(ref msg, value); }
        }

        public string Attribute
        {
            get { return attribute; }
            set { SetProperty(ref attribute, value); }
        }

        public int Value
        {
            get { return val; }
            set { SetProperty(ref val, value); }
        }

        public string concat { get { return Attribute + ": " + Value; } }


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
