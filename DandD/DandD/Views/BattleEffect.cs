using System;
using SQLite;
namespace DandD.Views
{
    public partial class BattleEffect
    {
        [PrimaryKey, AutoIncrement]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public string Target { get; set; }
        public string AttribMod { get; set; }
    }
}
