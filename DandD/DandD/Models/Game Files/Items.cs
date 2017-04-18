using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.Models.Game_Files
{
    public class Items
    {
        protected string Name { get; set; }
        protected string Category { get; set; }
        protected int Str { get; set; }
        protected int Dex { get; set; }
        protected int Speed { get; set; }
        protected int Health { get; set; }
        private bool Equipped { get; set; }

        public Items()
        {

        }
    }
}
