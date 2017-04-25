using DandD.Models.Game_Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Services
{
    public class BattlefieldController
    { 


        public void attack(Monster m1, Character c1)
        {
         //   List<int> Dmgholder = new List<int>();
            int first = compareSpeed(m1, c1);

            //Monster goes first
            if (first == 1)
            {
                int localDmg = damage(m1, c1);
                int localDmg2 = damage(c1, m1);
                //Dmgholder.Add(localDmg);
                //Dmgholder.Add(localDmg2);
               // return Dmgholder;
            }
            else
            {
                //Character goes first
                int localDmg = damage(c1, m1);
                int localDmg2 = damage(m1, c1);
                //Dmgholder.Add(localDmg);
                //Dmgholder.Add(localDmg2);
                //return Dmgholder;
            }
           
        }

        public int compareSpeed(Monster m1, Character c1)
        {
            if (m1.Dex > c1.Dex)
                return 1;
            else return 2; 
        }

        private int damage(Fighter m1, Fighter c1)
        {
            int damage = (m1.Str * 4);
            c1.Health -= damage;
            return damage; 
        }

        public bool isDead(Fighter fight)
        {
            if (fight.Health < 1)
            {
                return true;
            }
            return false;
        }

        public void displayStats(Monster m1, Character c1)
        {
            //Implement later
        }
    }
}
