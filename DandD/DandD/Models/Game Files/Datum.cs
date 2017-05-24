using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DandD.Models.GameFiles
{
    public class Datum
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Tier { get; set; }
        public string BodyPart { get; set; }
        public string AttribMod { get; set; }
        public string Creator { get; set; }
        public string Image { get; set; }
        public int Usage { get; set; }
    }

    public class RootObject
    {
        public string msg { get; set; }
        public int errorCode { get; set; }
        public List<Datum> data { get; set; }
    }
}


