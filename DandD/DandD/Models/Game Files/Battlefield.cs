using DandD.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Battlefield : BaseDataObject
    {
        int attack;
        BattlefieldController field;

        public Battlefield()
        {
            
        }

        public int Attack
        {
            get { return attack; }
            set { SetProperty(ref attack, value); }
        }

        


    }
}
