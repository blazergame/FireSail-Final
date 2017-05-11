using System;
using System.Collections.Generic;

namespace DandD.Models.GameFiles
{
    public class Holder
    {
		public class Datum
		{
			public string Name { get; set; }
			public string Attribute { get; set; }
			public int Value { get; set; }
		}

		public class RootObject
		{
			public int error_code { get; set; }
			public string msg { get; set; }
			public List<Datum> data { get; set; }
		}
    }
}
