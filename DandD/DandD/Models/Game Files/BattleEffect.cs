using System;
using SQLite;
namespace DandD.Models.GameFiles
{
    public class BattleEffect
    {
		[PrimaryKey, AutoIncrement]
        public int BattleEffect_Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Tier { get; set; }
		public string Target { get; set; }
		public string AttribMod { get; set; }
    }
}
