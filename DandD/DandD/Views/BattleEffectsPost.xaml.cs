using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DandD.Views
{
    public partial class BattleEffectsPost
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Tier { get; set; }
		public string Target { get; set; }
		public string AttribMod { get; set; }
	}

    public class UndoneBE
	{
		public string msg { get; set; }
		public int errorCode { get; set; }
        public List<BattleEffectsPost> data { get; set; }
	}
}
