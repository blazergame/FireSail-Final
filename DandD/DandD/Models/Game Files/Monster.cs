using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Monster : Fighter
    {
        public Monster(string Name)
        {
            this.Name = Name;
        }

        public bool isValid()
        {
			if (Name != null)
				return true;
			return false;
		}


    }
}
