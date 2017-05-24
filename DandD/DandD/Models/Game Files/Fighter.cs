using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Fighter : BaseDataObject
    {
        int previousHealth; 
        string name;
        string category;
        int str;
        int dex;
        int speed;
        int health;
        int xpValue;
        int xp;
        int level = 1;
        int damageReceived;
        string dmgHolder;
       public List<Items> EquippedList;
        Random rand = new Random();
        int highScore;

        public Fighter()
        {

        }

        public string DmgHolder { get; set; }

        public string concatHighScore { get { return "HighScore: " + HighScore; } }

        public int HighScore
        {
            get { return highScore; }
            set { SetProperty(ref highScore, value); }
        }

        public int DamangeReceived
        {
            get { return damageReceived; }
            set { SetProperty(ref damageReceived, value); }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public int PreviousHealth
        {
            get { return previousHealth; }
            set { SetProperty(ref previousHealth, value); }
        }

        public string Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        public int Str
        {
            get { return str; }
            set { SetProperty(ref str, value); }
        }

        public int Dex
        {
            get { return dex; }
            set { SetProperty(ref dex, value); }
        }

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        public int Health
        {
            get { return health; }
            set { SetProperty(ref health, value); }
        }

        public int XpValue
        {
            get { return xpValue; }
            set { SetProperty(ref xpValue, value); }
        }

        public int Xp
        {
            get { return xp; }
            set { SetProperty(ref xp, value); }
        }

        public int Level
        {
            get { return level; }
            set { SetProperty(ref level, value); }
        }

        public bool isDead(int health)
        {
            if(health < 1)
            {
                return true;
            }
            return false;
        }

        public List<Items> equippedItem(Items items)
        {
            // return EquippedList.Add(items);
            return EquippedList;
        }

        public bool didLevelUp()
        {
           if(xp > 20)
            {
                level++;
                Str += rand.Next(1, 10);
                Dex += rand.Next(1, 10);
                Speed += rand.Next(1, 5);
                xp = 0;
                return true;
            }

            return false;
        }

        public void displayStats()
        {
            //Prints stats
        }
    }
}
