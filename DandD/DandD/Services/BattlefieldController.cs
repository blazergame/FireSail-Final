using DandD.Models.Game_Files;
using System;
using System.Collections.Generic;
using System.Text;
using DandD.Views;
using System.Threading.Tasks;

namespace DandD.Services
{
    public class BattlefieldController : SettingsPage
    {

        private Random rand = new Random();

        public async Task<List<int>> attack( Monster m1,  Character c1)
        {
           
            List<int> Dmgholder = new List<int>();
            int first = compareSpeed(m1, c1);

            //Monster goes first
            if (first == 1)
            {
                if (m1.EquippedList != null)
                {
                    for (int i = 0; i < m1.EquippedList.Count; i++)
                    {
                        m1.EquippedList[i].Usage--;
                    }
                }
                int localDmg = damageCharacter(ref m1,  ref c1);
                int localDmg2 = damageMonster(ref m1, ref c1);
                Dmgholder.Add(localDmg);
                Dmgholder.Add(localDmg2);

                await App.Database.UpdateMonster(m1);
               return Dmgholder;

            }
            else
            {
                //Character goes first
                if (c1.EquippedList != null)
                {
                    for (int i = 0; i < c1.EquippedList.Count; i++)
                    {
                        c1.EquippedList[i].Usage--;
                    }
                }

                int localDmg = damageMonster(ref m1, ref c1);
                int localDmg2 = damageCharacter(ref m1, ref c1);
                Dmgholder.Add(localDmg2);
                Dmgholder.Add(localDmg);
                await App.Database.UpdateCharacter(c1);
                return Dmgholder;
            }

            
           
        }

        public int compareSpeed(Monster m1, Character c1)
        {
            if (m1.Dex > c1.Dex)
                return 1;
            else return 2; 
        }

        private int damageCharacter(ref Monster m1, ref Character c1)
        {
            int damage = 0; 
            if (critical_hit_bool)
            {
                damage = 2 * (m1.Str * rand.Next(1, 5));
                c1.Health -= damage;
            }
            else
            {
                damage = (m1.Str * rand.Next(1, 5));
                c1.Health -= damage;
            }

            return damage; 
        }

        private int damageMonster(ref Monster m1, ref Character c1)
        {
            int damage = 0;
            if (critical_hit_bool)
            {
                damage = 2 * (c1.Str * rand.Next(1, 5));

                if (c1.EquippedList == null)
                {
                    damage = 2 + (c1.Str * rand.Next(1, 5));
                    System.Diagnostics.Debug.WriteLine(c1.Name + "used fist fighting and dealt " + damage + " damage!");
                }
                m1.Health -= damage;
            }

            else
            {

                damage = (c1.Str * rand.Next(1, 5));

                if (c1.EquippedList == null)
                {
                    damage = 2 + (c1.Str * rand.Next(1, 5));
                    System.Diagnostics.Debug.WriteLine(c1.Name + "used fist fighting and dealt " + damage + " damage!");
                }
                m1.Health -= damage;

            }
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
