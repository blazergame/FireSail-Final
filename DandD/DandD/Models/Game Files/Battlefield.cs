using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Battlefield
    {
        Character c1;
        Monster m1;

        public Battlefield()
        {
            
        }

        public int attack(Object obj)
        {
            int damage = 0;
            
            if(obj == m1)
            {
                damage = 10;
            } else
            {
                damage = 10;
            }

            return damage;
        }
        
    }
}
